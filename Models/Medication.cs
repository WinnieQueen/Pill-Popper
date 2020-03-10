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
        public int dosage { get; set; }
        public int quantity { get; set; }
        public DOSAGETYPE dosageType { get; set; }
        public enum DOSAGETYPE
        {
            tablet,
            puffs
        }
        public void takeMed()
        {
            quantity -= dosage;
        }
    }
}
