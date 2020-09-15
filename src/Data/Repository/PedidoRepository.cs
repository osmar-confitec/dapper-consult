using Dapper;
using Data.Extensions;
using Domain.Models;
using Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(Context.ContextoS context) 
            : base(context)
        {


        }

        public async Task<IEnumerable<Pedido>> GetAllDapper(Expression<Func<Pedido, bool>> consulta)
        {
            return await Db.Database.GetDbConnection()
                            .QueryAsync<Pedido>(Db.Pedidos
                               .AsNoTracking()
                               .Where(consulta).ToSql());
        }

        public async Task<IEnumerable<PedidoViewModel>> GetAllDapperItens(Expression<Func<PedidoViewModel, bool>> consulta)
        {
            var pedido = Db.Set<Pedido>().AsNoTracking();
            var pedidosItens = Db.Set<PedidoItem>().AsNoTracking();

            var query = from p in pedido
                        join pi in pedidosItens on p.Id equals pi.PedidoId

                        select new PedidoViewModel
                        { 
                            
                            Descricao = p.Descricao
                        
                        }
                        ;

            var sql =  query.ToSql();

            var sql2 =  query
                              .Where(consulta).ToSql();

            return await Db.Database.GetDbConnection()
                           .QueryAsync<PedidoViewModel>(query
                              .Where(consulta).ToSql());


        }

        object GetValue<TEntity>(TEntity entity,
                                 string descMetodo,
                                 string par) where TEntity  : class 
        {

            object value = null;
            PropertyInfo prop = GetInfo(entity, descMetodo, par);
            value = prop.GetValue(entity, null);

            return value;
        }

        DbType? GetTypeDb(Type type)
        {

            if (type == typeof(string))
                return DbType.String;

            return null;

        }


        (object value, DbType? dbType, ParameterDirection? direction, int? size) GetParameter<TEntity>(
                                                TEntity entidade,
                                                string descMetodo,
                                                string par) where TEntity: class
        {

            DbType? dbType = null;
            object value = null;
            ParameterDirection? direction = ParameterDirection.Input;
            int? size = null;

            PropertyInfo prop = GetInfo(entidade, descMetodo, par);
            if (prop != null)
            {
                var typeProp = prop.PropertyType;
                dbType = GetTypeDb(typeProp);
                value = prop.GetValue(entidade, null);
            }
            return (value, dbType, direction, size);

        }

        PropertyInfo GetInfo<TEntity>(TEntity entidade, string descMetodo, string par) where TEntity : class
        {
            par = par.Replace("@", "").Replace("__", "").Replace(descMetodo, "").Replace("_0", "").Replace("_", "");

            var type = entidade.GetType();
            var prop = type.GetProperties().FirstOrDefault(x => x.Name.ToLower() == par.ToLower());
            return prop;
        }

        public async Task<IEnumerable<PedidoViewModel>> GetAllDapperItens2(PedidoViewModel consulta)
        {
            var pedido = Db.Set<Pedido>().AsNoTracking();
            var pedidosItens = Db.Set<PedidoItem>().AsNoTracking();
            var parameters = new  DynamicParameters();

            var query = from p in pedido
                        join pi in pedidosItens on p.Id equals pi.PedidoId
                       // where p.Descricao.Equals(consulta.Descricao)
                        select new PedidoViewModel
                        {

                            Descricao = p.Descricao, 
                            Id = p.Id.ToString(),
                            PedidoItemDescricao = pi.Descricao,
                            PedidoItemId = pi.Id.ToString()
                        }
                        ;

            if (!string.IsNullOrEmpty(consulta.Descricao))
                query = query.Where(x => x.Descricao.Contains(consulta.Descricao));


            foreach (var item in query.ToParameters())
            {
                //parameters.Add(item, GetParameter(consulta, nameof(consulta), item));
                parameters.Add(item, GetValue(consulta, nameof(consulta), item));
            }

            var sql = query.ToSql();

            var par =  query.ToParameters();




            return await Db.Database.GetDbConnection()
                           .QueryAsync<PedidoViewModel>(query
                              .ToSql(), parameters);

        }

        public async Task<IEnumerable<Pedido>> GetAllEntity(Expression<Func<Pedido, bool>> consulta)
        {
                return  await Db.Set<Pedido>().AsNoTracking().Where(consulta).ToListAsync();
        }
    }
}
