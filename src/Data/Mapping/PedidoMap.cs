using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {

            builder.ToTable("Pedido");

            builder.Property(c => c.Id)
             .HasColumnName("Id");

            builder.HasKey(x => x.Id);

            builder.Property(c => c.Descricao)
                .HasColumnName("Descricao")
                 .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();
            ;

            /*One to Many*/
            builder.HasMany(g => g.PedidoItens)
                .WithOne(s => s.Pedido)
                .HasForeignKey(s => s.PedidoId);
        }
    }
}
