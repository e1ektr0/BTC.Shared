using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace BTC.Shared.Extensions
{
    /// <summary>
    /// Класс содержащий методы расширения на System.Object
    /// </summary>
    public static class SystemObjectExtension
    {
        /// <summary>
        /// Получает значение поля безопастно
        /// Если объект источник null вернёт null
        /// </summary>
        public static TProperty GetSafety<TE, TProperty>(this TE obj, Func<TE, TProperty> func)
            where TE : class
            where TProperty : class
        {
            return obj != null ? func(obj) : null;
        }

        public static string[] GetFieldsNames(this object obj)
        {
            return obj.GetType().GetProperties().Select(n => n.Name).ToArray();
        }


        /// <summary>
        /// Возвращает пустую строку если объект равен null или строковое представление результата функции
        /// </summary>
        public static string GetStringSafty<T, TU>(this T obj, Func<T, TU> func) where T : class
        {
            return obj == null ? "" : func(obj).ToString();
        }

        public static TU GetSafty<T, TU>(this T obj, Func<T, TU> func)
            where T : class
            where TU : class
        {
            return obj == null ? null : func(obj);
        }

        public static TU? GetSaftyV<T, TU>(this T obj, Func<T, TU> func)
            where T : class
            where TU : struct
        {
            return obj == null ? null : new TU?(func(obj));
        }

        public static IEnumerable<PropertyInfo> GetPropertysByAttribute<TA>(this object obj)
            where TA : Attribute
        {
            return obj.GetType().GetProperties().Where(n => n.GetCustomAttributes(typeof(TA), false).Length != 0);
        }


        /// <summary>
        /// Строковое представление имени поля
        /// </summary>
        public static string GetPropertyName<TKeyModel>(this TKeyModel model, Expression<Func<TKeyModel, object>> keySelector)
        {
            var methodCallExpression = keySelector.Body as MemberExpression;
            if (methodCallExpression != null)
                return methodCallExpression.Member.Name;

            var unaryExpression = keySelector.Body as UnaryExpression;
            if (unaryExpression == null)
                throw new Exception("Should be a property");

            var expression = unaryExpression.Operand as MemberExpression;
            if (expression != null)
                return expression.Member.Name;
            throw new Exception("Should be a property");
        }

        //todo:В отдельный файл экстеншена
        public static bool IsNullOrEmpty<TItem>(this IEnumerable<TItem> collection)
        {
            return (collection == null || !collection.Any());
        }

        public static string GetLetters(this string str)
        {
            return new string(str.Where(Char.IsLetter).ToArray());
        }

    }
}
