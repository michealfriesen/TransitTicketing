using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class TicketGroup
    {
		public TicketAge Age { get; set; }
		public TicketDuration Duration { get; set; }
		public decimal BasePrice => Resources.price_list[new Tuple<TicketAge, TicketDuration>(this.Age, this.Duration)];
		public decimal TotalGroupPrice { get { return BasePrice * Quantity; } }
		public int Quantity { get; set; }
		public string IconUrl { get; set; }
	}
}
