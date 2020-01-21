using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WorldCities.Data
{
    public static class IQueryableExtension
    {
        public static string ToSql<T>(this IQueryable<T> query)
        {
            var enumerator = query.Provider
                .Execute<IEnumerable<T>>(query.Expression).GetEnumerator();
            var relationalCommandCache = enumerator
                .Private("_relationalCommandCache");
            var selectExpression = relationalCommandCache
                .Private<SelectExpression>("_selectExpression");
            var factory = relationalCommandCache
                .Private<IQuerySqlGeneratorFactory>("_querySqlGeneratorFactory");

            var sqlGenerator = factory.Create();
            var command = sqlGenerator.GetCommand(selectExpression);

            string sql = command.CommandText;
            return sql;
        }

        private static object Private(this object obj, string privateField) => 
            obj?.GetType()
            .GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?
            .GetValue(obj);
        private static T Private<T>(this object obj, string privateField) => 
            (T)obj?
            .GetType()
            .GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?
            .GetValue(obj);
    }
}
