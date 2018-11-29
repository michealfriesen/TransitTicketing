using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;


namespace WpfApp2
{
    

    class SummaryScreenRow
    {
        public TicketAgeType AgeType { get; set; }
        public decimal BasePrice => Resources.price_list[new Tuple<TicketAgeType, TicketDurationType>(this.AgeType, this.Duration)];
        public decimal TotalPrice { get { return BasePrice * Quantity; } }
        public TicketDurationType Duration { get; set; }
        public int Quantity { get; set; }
        public string IconUrl { get; set; }
    }

    class PurchaseState
    {
        public PurchaseState()
        {
            var adultTicketType = new TicketType { Name = TicketAgeType.Adult };
            var youthTicketType = new TicketType { Name = TicketAgeType.Youth };
            var seniorTicketType = new TicketType { Name = TicketAgeType.Senior };
            this.TicketTypes = new TicketType[] { adultTicketType, youthTicketType, seniorTicketType };
        }
        public TicketDurationType Duration { get; set; }

        public string PageSubtitle { get; set; }

        public string GetDurationString {
            get {
                return this.Duration
                           .GetType()
                           .GetMember(this.Duration.ToString())
                           .FirstOrDefault()
                           ?.GetCustomAttribute<DescriptionAttribute>()
                            ?.Description;
            }
        }

        public TicketType[] TicketTypes { get; set; }

        public List<SummaryScreenRow> SummaryScreenTicketTypes {
            get
            {
                var selectedTypes = this.TicketTypes.Where(t => t.Quantity > 0);
                return selectedTypes.Select(st => MapTicketTypeToSummaryTicketType(st)).ToList();
            }
        }

        #region Mappers
        private SummaryScreenRow MapTicketTypeToSummaryTicketType(TicketType type)
        {
            return new SummaryScreenRow()
            {
                AgeType = type.Name,
                Quantity = type.Quantity,
                IconUrl = type.IconUrl,
                Duration = this.Duration
            };
        }
        #endregion



        #region User Actions
        public void IncreaseTicketQuantity(TicketAgeType type)
        {
            var ticketTypeToChange = this.TicketTypes.FirstOrDefault(tt => tt.Name == type);
            ticketTypeToChange.Quantity++;
        }

        public void DecreaseTicketQuantity(TicketAgeType type)
        {
            var ticketTypeToChange = this.TicketTypes.FirstOrDefault(tt => tt.Name == type);
            if (ticketTypeToChange.Quantity > 0)
            {
                ticketTypeToChange.Quantity--;
            }
        }

        #endregion

        public decimal GetTotal
        {
            get { return this.TicketTypes.Aggregate(0.0M, (runningTotal, ticket) => runningTotal + (Fare_price(ticket.Name, Duration) * ticket.Quantity));  }
        }

        public decimal Fare_price(TicketAgeType fare_type, TicketDurationType duration)
        {
            return Resources.price_list[new Tuple<TicketAgeType, TicketDurationType>(fare_type, duration)];
        }
    }
}
