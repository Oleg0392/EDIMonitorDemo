using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIMonitorDemoData.Models
{
    public class KonturOrder
    {
        public string? Number { get; set; }
        public DateTime OrderDate { get; set; }
        public int RevisionNumber { get; set; } = 0;
        public string? BuyerName { get; set;}
    }
}
