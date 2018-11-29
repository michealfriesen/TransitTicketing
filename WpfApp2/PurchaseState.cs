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

    enum TicketAgeType {
        Adult,
        Youth,
        Senior };

    class PurchaseState
    {
        public TicketDurationType Duration { get ; set; }
        public TicketType[] TicketTypes { get; set; }
        public decimal GetTotal()
        {
            return this.TicketTypes.Aggregate(0.0M, (runningTotal, ticket) => runningTotal + (Fare_price(ticket.Name, Duration) * ticket.Quantity));
        }

        public decimal Fare_price(TicketAgeType fare_type, TicketDurationType duration)
        {
            return price_list[new Tuple<TicketAgeType, TicketDurationType>(fare_type, duration)];
        }

        private readonly Dictionary<Tuple<TicketAgeType, TicketDurationType>, Decimal> price_list = new Dictionary<Tuple<TicketAgeType, TicketDurationType>, Decimal>()
        {
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Adult, TicketDurationType.SingleFare), 3.50M },
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Adult, TicketDurationType.FullDay), 10.00M },
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Adult, TicketDurationType.ThreeDay), 25.00M },
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Adult, TicketDurationType.Week), 50.00M },
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Adult, TicketDurationType.Month), 100.00M },
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Youth, TicketDurationType.SingleFare), 2.50M },
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Youth, TicketDurationType.FullDay), 8.00M },
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Youth, TicketDurationType.ThreeDay), 20.00M },
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Youth, TicketDurationType.Week), 40.00M },
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Youth, TicketDurationType.Month), 80.00M },
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Senior, TicketDurationType.SingleFare), 3.25M },
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Senior, TicketDurationType.FullDay), 9.00M },
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Senior, TicketDurationType.ThreeDay), 22.50M },
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Senior, TicketDurationType.Week), 45.00M },
            {new Tuple<TicketAgeType, TicketDurationType>(TicketAgeType.Senior, TicketDurationType.Month), 90.00M }
        };
    }
}
