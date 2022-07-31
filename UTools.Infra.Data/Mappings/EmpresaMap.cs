using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UTools.Domain.Entities;

namespace UTools.Infra.Data.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {

        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");

            builder.Property(c => c.Id)
                   .HasColumnName("Id");

            builder.Property(c => c.CNPJ)
                   .HasColumnName("CNPJ")
                   .HasMaxLength(14);

            builder.Property(c => c.Abertura)
                   .HasColumnName("Abertura")
                   .HasMaxLength(20);

            builder.Property(c => c.Situacao)
                   .HasColumnName("Situacao")
                   .HasMaxLength(20);

            builder.Property(c => c.Tipo)
                   .HasColumnName("Tipo")
                   .HasMaxLength(20);

            builder.Property(c => c.Nome)
                   .HasColumnName("Nome")
                   .HasMaxLength(200);

            builder.Property(c => c.Fantasia)
                   .HasColumnName("Fantasia")
                   .HasMaxLength(150);

            builder.Property(c => c.Porte)
                   .HasColumnName("Porte")
                   .HasMaxLength(50);

            builder.Property(c => c.NaturezaJuridica)
                   .HasColumnName("NaturezaJuridica")
                   .HasMaxLength(200);

            builder.Property(c => c.Logradouro)
                   .HasColumnName("Logradouro")
                   .HasMaxLength(200);

            builder.Property(c => c.Numero)
                   .HasColumnName("Numero")
                   .HasMaxLength(5);

            builder.Property(c => c.Municipio)
                   .HasColumnName("Municipio")
                   .HasMaxLength(200);

            builder.Property(c => c.Bairro)
                   .HasColumnName("Bairro")
                   .HasMaxLength(100);

            builder.Property(c => c.UF)
                   .HasColumnName("UF")
                   .HasMaxLength(2);

            builder.Property(c => c.CEP)
                   .HasColumnName("CEP")
                   .HasMaxLength(10);

            builder.Property(c => c.Email)
                   .HasColumnName("Email")
                   .HasMaxLength(200);

            builder.Property(c => c.Telefone)
                   .HasColumnName("Telefone")
                   .HasMaxLength(20);

            builder.Property(c => c.DataSituacao)
                   .HasColumnName("DataSituacao")
                   .HasMaxLength(20);

            builder.Property(c => c.CapitalSocial)
                   .HasColumnName("CapitalSocial")
                   .HasMaxLength(10);

            builder.Property(c => c.CnaeCodigo)
                   .HasColumnName("CnaeCodigo")
                   .HasMaxLength(10);

            builder.Property(c => c.CnaeDescricao)
                   .HasColumnName("CnaeCnaeDescricaoCodigo")
                   .HasMaxLength(150);
        }
    }
}
