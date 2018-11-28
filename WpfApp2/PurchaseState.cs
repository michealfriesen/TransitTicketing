using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    enum TicketDurationType {
        SingleFare,
        FullDay,
        ThreeDay,
        Week,
        Month };

    class PurchaseState
    {
        public TicketDurationType Duration { get ; set; }
        public TicketType[] TicketTypes { get; set; }
        public decimal GetTotal()
        {
            return this.TicketTypes.Aggregate(0.0M, (runningTotal, ticket) => runningTotal + ticket.GetPrice(this.Duration));
        }

        public const Dictionary<Tuple<String, TicketDurationType>, Double> price = new Dictionary<Tuple<String, TicketDurationType>, Double>()
        {
            {new Tuple<String, TicketDurationType>("Adult", SingleFare), 3.50 }
        }


    }
}
