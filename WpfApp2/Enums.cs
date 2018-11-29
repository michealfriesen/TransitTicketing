using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace WpfApp2
{
    enum TicketDurationType
    {
        [Description("Single Fare")]
        SingleFare,
        [Description("Full Day")]
        FullDay,
        [Description("Three Day")]
        ThreeDay,
        [Description("Week")]
        Week,
        [Description("Month")]
        Month
    };

    enum TicketAgeType
    {
        Adult,
        Youth,
        Senior
    };
}
