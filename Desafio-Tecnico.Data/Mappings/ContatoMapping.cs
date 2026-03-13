using Desafio_Tecnico.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Desafio_Tecnico.Data.Mappings
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contatos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .UseIdentityColumn();

            builder.Property(c => c.NomeContato)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");

            builder.Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(c => c.Sexo)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnType("char(1)");

            builder.Property(c => c.Idade)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.Ativo)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(c => c.Idade)
                .IsRequired();
        }
    }
}
