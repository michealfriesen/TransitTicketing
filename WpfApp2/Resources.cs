using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Resources
    {
        public static readonly Dictionary<Tuple<TicketAge, TicketDuration>, Decimal> price_list = new Dictionary<Tuple<TicketAge, TicketDuration>, Decimal>()
        {
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Adult, TicketDuration.SingleFare), 3.50M },
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Adult, TicketDuration.FullDay), 10.00M },
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Adult, TicketDuration.ThreeDay), 25.00M },
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Adult, TicketDuration.Week), 50.00M },
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Adult, TicketDuration.Month), 100.00M },
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Youth, TicketDuration.SingleFare), 2.50M },
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Youth, TicketDuration.FullDay), 8.00M },
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Youth, TicketDuration.ThreeDay), 20.00M },
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Youth, TicketDuration.Week), 40.00M },
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Youth, TicketDuration.Month), 80.00M },
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Senior, TicketDuration.SingleFare), 3.25M },
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Senior, TicketDuration.FullDay), 9.00M },
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Senior, TicketDuration.ThreeDay), 22.50M },
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Senior, TicketDuration.Week), 45.00M },
            {new Tuple<TicketAge, TicketDuration>(TicketAge.Senior, TicketDuration.Month), 90.00M }
        };
    }
}
