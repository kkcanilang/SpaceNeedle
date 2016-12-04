using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Tax.Automation.UI
{
    public partial class ConnectingModal : Form
    {
        private System.Timers.Timer _timer;
        private Random rand;


        public ConnectingModal()
        {
           rand = new Random();

            InitializeComponent();
        }


        public void OnTimedEvent()
        {
            rand = new Random();
            int number = rand.Next(1, 5);


           switch (number)
            {

                case 1:
                    ThreadHelperClass.SetText(this, this.ConnectionText, "Connecting.");
                    break;
                case 2:
                    ThreadHelperClass.SetText(this, this.ConnectionText, "Connecting..");
                    break;
                case 3:
                    ThreadHelperClass.SetText(this, this.ConnectionText, "Connecting...");
                    break;
                case 4:
                    ThreadHelperClass.SetText(this, this.ConnectionText, "Connecting....");
                    break;
                case 5:
                    ThreadHelperClass.SetText(this, this.ConnectionText, "Connecting....");
                    break;
            }
        }
    }
}
