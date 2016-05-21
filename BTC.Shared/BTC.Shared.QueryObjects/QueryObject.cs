using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BTC.Shared.QueryObjects
{
    /// <summary>
    /// Базовый объект запроса
    /// Хранит информацию о пейдженге, сортировке
    /// </summary>
    public abstract class QueryObject<TEntity> : QueryObjectBase
    {
        #region Properties

        /// <summary>
        /// Словарь связываения ключа сортировки с объектом сортровки
        /// Необходим для связываения полей DTO/ViewModel с сортировкой
        /// todo:при расширении по аналогии добавить словарь связывания поиска по колонкам
        /// </summary>
        public readonly IDictionary<string, IOrderObject<TEntity>> OrderDictionary = new Dictionary<string, IOrderObject<TEntity>>();

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Осуществляет поиск, пейджинг и сортировку
        /// </summary>
        public virtual IQueryable<TEntity> Query(IQueryable<TEntity> query, SortingDirection sortingDirection = SortingDirection.None)
        {
            return Paging(Order(query.Where(Filter().GetExpression()), sortingDirection));
        }

        public virtual IQueryable<TEntity> QueryWithoutPaging(IQueryable<TEntity> query, SortingDirection sortingDirection = SortingDirection.None)
        {
            return Order(query.Where(Filter().GetExpression()), sortingDirection);
        }

        public int TotalCount(IQueryable<TEntity> query)
        {
            return query.Where(Filter().GetExpression()).Count();
        }

        public int TotalCountNoFilter(IQueryable<TEntity> query)
        {
            return query.Where(BaseFilter().GetExpression()).Count();
        }

        public virtual IQueryable<TEntity> Prepare(IQueryable<TEntity> asQueryable)
        {
            return asQueryable;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Сортировка
        /// </summary>
        private IQueryable<TEntity> Order(IQueryable<TEntity> query, SortingDirection sortingDirection = SortingDirection.None)
        {
            if (SortingColumn == null || !OrderDictionary.ContainsKey(SortingColumn))
            {
                SortingDirection = sortingDirection;
            }

            if (SortingColumn == null || !OrderDictionary.ContainsKey(SortingColumn))
                SortingColumn = OrderDictionary.First().Key;

            var orderObject = OrderDictionary[SortingColumn];
            if (SortingDirection != SortingDirection.Desc)
                return orderObject.Order(query);
            return orderObject.OrderDesc(query);
        }

        /// <summary>
        /// Пейджинг
        /// </summary>
        private IQueryable<TEntity> Paging(IQueryable<TEntity> query)
        {
            return query.Skip(Skip).Take(Count);
        }

        /// <summary>
        /// Добавляет связь ключа вьюхи с выборкой сортировки
        /// </summary>
        protected void AddOrdering<TKeySelector>(string key, Expression<Func<TEntity, TKeySelector>> orderExpression)
        {
            OrderDictionary.Add(key, new OrderObject<TEntity, TKeySelector>(orderExpression));
        }

        /// <summary>
        /// Генерирует ограничение на запрос(опираясь на обхект запроса)
        /// </summary>
        protected virtual Conditional<TEntity> Filter()
        {
            return BaseFilter();
        }

        /// <summary>
        /// Генерирует ограничение на запрос(опираясь на обхект запроса)
        /// </summary>
        protected virtual Conditional<TEntity> BaseFilter()
        {
            return new Conditional<TEntity>(true);
        }

        #endregion Private Methods

    }
}