using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pill_Popper
{
    class Medication
    {
        string name { get; set; }
        int dosage { get; set; }
        int quantity { get; set; }
        DOSAGETYPE dosageType { get; set; }
        enum DOSAGETYPE
        {
            tablet,
            puffs
        }
        public void takeMed()
        {
            quantity -= dosage;
        }
        public override string ToString()
        {
            return this.name + " " + this.dosage + " " + this.dosageType + " " + this.quantity;
        }
    }
}
