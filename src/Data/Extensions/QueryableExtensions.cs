using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Text;
using System.Data.Entity.Core.Objects;

namespace Data.Extensions
{
    public static class QuerySql
    {

        //link https://www.thetopsites.net/article/51583047.shtml



        public static IEnumerable<string> ToParameters<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
        
            var dicRet = new List<string>();
            Microsoft.EntityFrameworkCore.Storage.IRelationalCommand command = GetCommand(query);
            foreach (var item in command.Parameters)
                dicRet.Add($"@{item.InvariantName}");

            return dicRet;
        }


        public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            Microsoft.EntityFrameworkCore.Storage.IRelationalCommand command = GetCommand(query);

            string sql = command.CommandText;
            return sql;
        }

        static Microsoft.EntityFrameworkCore.Storage.IRelationalCommand GetCommand<TEntity>(IQueryable<TEntity> query) where TEntity : class
        {
            var enumerator = query.Provider.Execute<IEnumerable<TEntity>>(query.Expression).GetEnumerator();
            var relationalCommandCache = enumerator.Private("_relationalCommandCache");
            var selectExpression = relationalCommandCache.Private<SelectExpression>("_selectExpression");
            var factory = relationalCommandCache.Private<IQuerySqlGeneratorFactory>("_querySqlGeneratorFactory");

            var sqlGenerator = factory.Create();
            var command = sqlGenerator.GetCommand(selectExpression);
            return command;
        }

        private static object Private(this object obj, string privateField) => obj?.GetType().GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);
        private static T Private<T>(this object obj, string privateField) => (T)obj?.GetType().GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);

    }
}
