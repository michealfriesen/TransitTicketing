using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    public class State
    {
        public string StepNumber { get; set; }

        public Window[] Flow = { new DurationWindow(), new FaresWindow() };
    }
}
