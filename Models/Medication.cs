using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pill_Popper
{
    public class Medication
    {
        public string name { get; set; }
        public int dosagePDay { get; set; }
        public int quantity { get; set; }
        public int qtyPDose { get; set; }
        public void takeMed()
        {
            quantity -= qtyPDose;
        }
    }
}
