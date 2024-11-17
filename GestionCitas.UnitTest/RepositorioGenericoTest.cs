using GestionCitas.Domain.Entities;
using GestionCitas.Domain.Enums;
using GestionCitas.Domain.ValueObjects;
using GestionPersonas.Domain.ExcepcionesGenerales;
using GestionPersonas.Domain.ValueObjects;
using GestionPersonas.Infraestructura.Persistencia;
using GestionPersonas.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Moq;

public class RepositorioGenericoTests
{
    private readonly Mock<AplicacionDbContext> _mockDbContext;
    private readonly RepositorioGenerico<Cita> _repositorio;

    public RepositorioGenericoTests()
    {
        _mockDbContext = new Mock<AplicacionDbContext>(new DbContextOptions<AplicacionDbContext>());
        _repositorio = new RepositorioGenerico<Cita>(_mockDbContext.Object);
    }

    [Fact]
    public async Task AddAsync()
    {
        // Arrange
        Direccion direccion = new Direccion("calle 70", "La Francia", "Caldas", "Manizales");
        Lugar lugar = new Lugar("San Marcel", direccion);
        var cita = Cita.CrearCita(1, 1, DateTime.Now, EstadoCita.Pendiente, lugar);
        _mockDbContext.Setup(db => db.Set<Cita>().Add(It.IsAny<Cita>()));
        // Act
        var result = await _repositorio.AddAsync(cita);

        // Assert
        _mockDbContext.Verify(db => db.Set<Cita>().Add(It.Is<Cita>(r => r == cita)), Times.Once);
        _mockDbContext.Verify(db => db.SaveChangesAsync(default), Times.Once);
        Assert.Equal(cita, result);
    }

    [Fact]
    public async Task GetAllAsync()
    { // Arrange

        Direccion direccion = new Direccion("calle 70", "La Francia", "Caldas", "Manizales");
        Lugar lugar = new Lugar("San Marcel", direccion);

        var citas = new List<Cita> {
                                Cita.CrearCita(1, 1, DateTime.Now, EstadoCita.Pendiente, lugar),
                                Cita.CrearCita(2, 2, DateTime.Now, EstadoCita.Pendiente, lugar),
                             };
        _mockDbContext.Setup(db => db.Set<Cita>().ToListAsync(default)).ReturnsAsync(citas);
        // Act
        var result = await _repositorio.GetAllAsync();
        // Assert 
        Assert.Equal(citas, result);
    }

    [Fact]
    public async Task GetByIdAsync()
    {
        // Arrange
        Direccion direccion = new Direccion("calle 70", "La Francia", "Caldas", "Manizales");
        Lugar lugar = new Lugar("San Marcel", direccion);
        var cita = Cita.CrearCita(1, 1, DateTime.Now, EstadoCita.Pendiente, lugar);

        _mockDbContext.Setup(db => db.Set<Cita>().FindAsync(1)).ReturnsAsync(cita);

        // Act
        var result = await _repositorio.GetByIdAsync(1);

        // Assert
        Assert.Equal(cita, result);
    }

    [Fact]
    public async Task GetByIdAsync_DeberiaSacarExcepcionNoHayDatosException_CuandoIdNoExiste()
    {
        // Arrange
        _mockDbContext.Setup(db => db.Set<Cita>().FindAsync(It.IsAny<int>())).ReturnsAsync((Cita)null);

        // Act & Assert
        await Assert.ThrowsAsync<NoHayDatosException>(() => _repositorio.GetByIdAsync(1));
    }
}
