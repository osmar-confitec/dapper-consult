using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
  public  interface IPedidoRepository: IRepository<Pedido>
    {

        Task<IEnumerable<Pedido>> GetAllDapper(Expression<Func<Pedido, bool>> consulta);

        Task<IEnumerable<Pedido>> GetAllEntity(Expression<Func<Pedido, bool>> consulta);


        Task<IEnumerable<PedidoViewModel>> GetAllDapperItens2(PedidoViewModel consulta);


        Task<IEnumerable<PedidoViewModel>> GetAllDapperItens(Expression<Func<PedidoViewModel, bool>> consulta);

    }
}
