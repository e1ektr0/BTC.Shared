using System.Collections.Generic;

namespace BTC.Shared.QueryObjects
{
    public class AjaxDbResult<T>
    {
        public List<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int TotalCountNoFilter { get; set; }
    }
}
