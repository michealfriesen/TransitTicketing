using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace WpfApp2
{
    enum TicketDuration
    {
        [Description("2 Hours")]
        SingleFare,
        [Description("Full Day")]
        FullDay,
        [Description("3-Day")]
        ThreeDay,
        [Description("Week")]
        Week,
        [Description("Month")]
        Month
    };

    enum TicketAge
    {
        Adult,
        Youth,
        Senior
    };
}
