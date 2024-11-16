using GestionCitas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionCitas.Infraestructura.ConfiguracionesBD
{
    public class ConfigurationCita : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.ToTable("Citas");
            builder.HasKey(x => x.Id);

            builder.OwnsOne(p => p.Lugar, lugar =>
            {
                lugar.Property(ci => ci.NombreIps)
                    .HasMaxLength(100)
                    .HasColumnName("NombreIps");

                lugar.OwnsOne(l => l.Direccion, dir =>
                {
                    dir.Property(d => d.Calle)
                        .HasMaxLength(100)
                        .HasColumnName("Calle");

                    dir.Property(d => d.Barrio)
                        .HasMaxLength(100)
                        .HasColumnName("Barrio");

                    dir.Property(d => d.Departamento)
                        .HasMaxLength(100)
                        .HasColumnName("Departamento");

                    dir.Property(d => d.Municipio)
                        .HasMaxLength(100)
                        .HasColumnName("Municipio");
                });
            });
        }
    }
}
