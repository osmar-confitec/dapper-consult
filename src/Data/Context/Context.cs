using Data.Mapping;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
   public class ContextoS : DbContext
    {

        public ContextoS(DbContextOptions<ContextoS> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<PedidoItem> PedidosItens { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PedidoItensMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
