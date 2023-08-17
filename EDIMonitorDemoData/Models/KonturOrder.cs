using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIMonitorDemoData.Models
{
    public class KonturOrder
    {
        public string? FileName { get; set; }
        public string? OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string? BuyerName { get; set;}
    }
}
