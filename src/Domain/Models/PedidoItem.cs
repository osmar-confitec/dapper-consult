using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public  class PedidoItem
    {

        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public Guid PedidoId { get; set; }
        public virtual  Pedido Pedido { get; set; }

        public PedidoItem()
        {
            Id = Guid.NewGuid();
        }

    }
}
