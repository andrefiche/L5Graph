using System;
namespace graphConnect.Models
{
    public class AccessLogs
    {
        public int Id { get; set; }
        public string TenantID { get; set; }
        public String Token { get; set; }
        public DateTime DataHora { get; set; }
    }
}
