using System.Linq;

namespace BTC.Shared.QueryObjects
{
    public interface ITable<T>
    {
        IQueryable<T> Table { get; }
    }
}