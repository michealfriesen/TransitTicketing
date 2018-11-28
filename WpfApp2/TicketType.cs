using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class TicketType
    {
        public string Name { get; set; }
        public int Quantity { get; set; } = 0;
        public string IconUrl { get; set; }
        public decimal GetPrice(TicketDurationType duration)
        {
            return 0.0M;
        }
    }
}
