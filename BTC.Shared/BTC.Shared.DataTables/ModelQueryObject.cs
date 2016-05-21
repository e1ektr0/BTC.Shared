using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BTC.Shared.Extensions;
using BTC.Shared.QueryObjects;
using Mvc.JQuery.Datatables;

namespace BTC.Shared.DataTables
{
    /// <summary>
    /// Базовый объект связывания модели представления и объекта запроса
    /// </summary>
    public abstract class ModelQueryObject<TModel, TEntity> : QueryObject<TEntity> where TModel : new()
    {
        protected readonly DataTablesParam DataTablesParam;
        protected ModelQueryObject() { }

        protected ModelQueryObject(DataTablesParam dataTablesParam)
        {
            DataTablesParam = dataTablesParam;
            if (dataTablesParam == null)
                return;

            Count = DataTablesParam.iDisplayLength < 0 ? int.MaxValue : DataTablesParam.iDisplayLength;
            Skip = DataTablesParam.iDisplayStart;
            Search = dataTablesParam.sSearch;

            for (var i = 0; i < DataTablesParam.sSortDir.Count; i++)
            {
                if (DataTablesParam.sSortDir[i] == null)
                    continue;

                if (DataTablesParam.sSortDir[i] == "asc")
                {
                    SortingColumn = new TModel().GetFieldsNames()[DataTablesParam.iSortCol[i]];
                    SortingDirection = SortingDirection.Asc;
                }
                if (DataTablesParam.sSortDir[i] == "desc")
                {
                    SortingColumn = new TModel().GetFieldsNames()[DataTablesParam.iSortCol[i]];
                    SortingDirection = SortingDirection.Desc;
                }
            }
            SearchCoditionals = new List<ColumnConditional>();
            for (var i = 0; i < DataTablesParam.sSearchColumns.Count; i++)
            {
                var sSearchColumn = DataTablesParam.sSearchColumns[i];
                if (sSearchColumn == null)
                    continue;
                SearchCoditionals.Add(new ColumnConditional { Key = new TModel().GetFieldsNames()[i], Value = sSearchColumn });
            }
        }

        /// <summary>
        /// Добавляет сортировку по ключу модели
        /// </summary>
        protected void AddOrdering<TKeySelector>(Expression<Func<TModel, object>> keyExpression,
            Expression<Func<TEntity, TKeySelector>> orderExpression)
        {
            AddOrdering(GetPropertyKey(keyExpression), orderExpression);
        }

        /// <summary>
        /// Проверяет введённ ли кондишен на конкретное поле
        /// </summary>
        protected bool HasConditional(Expression<Func<TModel, object>> keyExpression)
        {
            if (SearchCoditionals == null)
                return false;
            return SearchCoditionals.Any(n => n.Key == GetPropertyKey(keyExpression) && !n.Value.IsNullOrEmpty());
        }

        /// <summary>
        /// Получить ограничение по ключу модели
        /// </summary>
        protected string GetConditional(Expression<Func<TModel, object>> keyExpression)
        {
            return SearchCoditionals.First(n => n.Key == GetPropertyKey(keyExpression)).Value;
        }

        /// <summary>
        /// Получить строковое представления по экспрешену модели
        /// </summary>
        private static string GetPropertyKey(Expression<Func<TModel, object>> keyExpression)
        {
            return new TModel().GetPropertyName(keyExpression);
        }
    }
}