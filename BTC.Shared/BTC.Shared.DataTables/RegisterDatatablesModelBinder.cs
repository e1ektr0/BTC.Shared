using System.Web;
using System.Web.Mvc;
using Mvc.JQuery.Datatables;

[assembly: PreApplicationStartMethod(typeof(BTC.Shared.DataTables.RegisterDatatablesModelBinder), "Start")]

namespace BTC.Shared.DataTables {
    public static class RegisterDatatablesModelBinder {
        public static void Start() {
            if (!ModelBinders.Binders.ContainsKey(typeof(DataTablesParam)))
                ModelBinders.Binders.Add(typeof(DataTablesParam), new Mvc.JQuery.Datatables.DataTablesModelBinder());
        }
    }
}
