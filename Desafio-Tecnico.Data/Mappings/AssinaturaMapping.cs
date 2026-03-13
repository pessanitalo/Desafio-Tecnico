using Desafio_Tecnico.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Desafio_Tecnico.Data.Mappings
{
    public class AssinaturaMapping : IEntityTypeConfiguration<Assinatura>
    {
        public void Configure(EntityTypeBuilder<Assinatura> builder)
        {
            builder.ToTable("Assinaturas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .UseIdentityColumn();

            builder.Property(c => c.NomeCompleto)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");


            builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("varchar(100)");

            builder.Property(c => c.DataInicioAssinatura)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(c => c.Plano)
                 .IsRequired()
                 .HasConversion<string>()
                 .HasMaxLength(10)
                 .HasColumnType("varchar(10)");

            builder.Property(c => c.ValorMensalAssinatura)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnType("decimal(18,2)");


            builder.Property(c => c.StatusAssinatura)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(c => c.TempoAssinaturaMeses)
                .IsRequired()
                .HasColumnType("int");
        }
    }
}
