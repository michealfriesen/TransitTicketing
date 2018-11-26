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
        public int StepNumber { get; set; }

        public Window CurrentWindow { get; set; }

        public void GotoNext()
        {
            StepNumber++;
            Window nextWin = Flow[StepNumber];
            CurrentWindow.Close();

            nextWin.Close();
        }


        public Window[] Flow = { new DurationWindow(), new FaresWindow() };
    }
}
