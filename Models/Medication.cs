using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pill_Popper
{
    class Medication
    {
        public string name { get; set; }
        public int dosagePerDay { get; set; }
        public int quantity { get; set; }
        public int dosageQty { get; set; }
        public void takeMed()
        {
            quantity -= dosageQty;
        }
    }
}
