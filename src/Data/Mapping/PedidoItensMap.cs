using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class PedidoItensMap : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens");

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
            builder.HasOne(s => s.Pedido)
            .WithMany(g => g.PedidoItens)
            .HasForeignKey(s => s.PedidoId);
        }
    }
}
