using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Pedido
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<PedidoItem> PedidoItens { get; set; }

        public Pedido()
        {
            PedidoItens = new List<PedidoItem>();
            Id = Guid.NewGuid();
        }
    }
}
