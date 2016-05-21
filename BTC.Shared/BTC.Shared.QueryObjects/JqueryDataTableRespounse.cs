namespace BTC.Shared.QueryObjects
{
    public class JqueryDataTableRespounse
    {
        public int sEcho { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public object data { get; set; }
    }
}