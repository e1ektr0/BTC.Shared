using System.Collections.Generic;
using System.Linq;
using BTC.Shared.Automapper;

namespace BTC.Shared.QueryObjects
{
    /// <summary>
    /// Объект исполняющий запросы, опираясь на queryobject
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class QueryExecutor<TEntity> where TEntity : class
    {
        private readonly ITable<TEntity> _table;

        public QueryExecutor(ITable<TEntity> table)
        {
            _table = table;
        }

        /// <summary>
        /// Получить коллекцию
        /// </summary>
        public IEnumerable<TEntity> Fecth(QueryObject<TEntity> queryObject)
        {
            return queryObject.Query(_table.Table).ToList();
        }

        /// <summary>
        /// Получить коллекцию и сконвертировать
        /// </summary>
        public IEnumerable<TModel> Fecth<TModel>(QueryObject<TEntity> queryObject) where TModel : new()
        {
            return queryObject.Query(_table.Table).ToList().Select(new TModel());
        }

        /// <summary>
        /// Общее колличество объектов
        /// </summary>
        public int Count(QueryObject<TEntity> queryObject)
        {
            return queryObject.TotalCount(_table.Table);
        }
    }
}