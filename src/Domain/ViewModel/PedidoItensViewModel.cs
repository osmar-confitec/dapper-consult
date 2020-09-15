using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class PedidoViewModel
    {

        public string Id { get; set; }

        public string Descricao { get; set; }

        public string PedidoItemId { get; set; }

        public string PedidoItemDescricao { get; set; }

        

        public PedidoViewModel()
        {
           
        }
    }

    public  class PedidoItensViewModel
    {

        public string Id { get; set; }

        public string Descricao { get; set; }

    }
}
