using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;


namespace WpfApp2
{
    class PurchaseState
    {
        public PurchaseState()
        {
            var adultTicket = new TicketGroup { Age = TicketAge.Adult };
            var youthTicket = new TicketGroup { Age = TicketAge.Youth };
            var seniorTicket = new TicketGroup { Age = TicketAge.Senior };
            this.TicketGroups = new TicketGroup[] { adultTicket, youthTicket, seniorTicket };
        }

		public TicketGroup[] TicketGroups { get; set; }
		private TicketDuration selectedDuration;

        public TicketDuration SelectedDuration {
			get { return selectedDuration; }
			set
			{
				selectedDuration = value;

				// Because our system only has one duration possible, 
				// this is so that each ticket group knows the selected duration
				// and to reset if any groups have been added already
				foreach(var ticketGroup in TicketGroups)
				{
					ticketGroup.Duration = value;
					ticketGroup.Quantity = 0;
				}
			}
		}

        public string PageSubtitle { get; set; }

        public string GetDurationString {
            get {
                return this.SelectedDuration
                           .GetType()
                           .GetMember(this.SelectedDuration.ToString())
                           .FirstOrDefault()
                           ?.GetCustomAttribute<DescriptionAttribute>()
                           ?.Description;
            }
        }

        #region User Actions
        public void IncreaseTicketQuantity(TicketAge age)
        {
            var ticketTypeToChange = this.TicketGroups.FirstOrDefault(tt => tt.Age == age);
            ticketTypeToChange.Quantity++;
        }

        public void DecreaseTicketQuantity(TicketAge age)
        {
            var ticketTypeToChange = this.TicketGroups.FirstOrDefault(tt => tt.Age == age);
            if (ticketTypeToChange.Quantity > 0)
            {
                ticketTypeToChange.Quantity--;
            }
        }

		public void SelectDuration(TicketDuration duration)
		{
			this.SelectedDuration = duration;
		}

        #endregion

        public decimal GetTotal
        {
            get { return this.TicketGroups.Aggregate(0.0M, (runningTotal, ticket) => runningTotal + (Fare_price(ticket.Age, SelectedDuration) * ticket.Quantity));  }
        }

        public decimal Fare_price(TicketAge fare_type, TicketDuration duration)
        {
            return Resources.price_list[new Tuple<TicketAge, TicketDuration>(fare_type, duration)];
        }
    }
}
