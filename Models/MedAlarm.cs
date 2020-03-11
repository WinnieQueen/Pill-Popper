using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Pill_Popper
{
    public class MedAlarm
    {
        private DateTime timeToTake = new DateTime();
        private String name;
        private int numToTake;

        public String TimeToTake
        {
            get { return timeToTake.ToString("hh:mm tt"); }
            set { timeToTake = DateTime.Parse(value); }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NumToTake
        {
            get { return numToTake; }
            set { numToTake = value; }
        }

        public MedAlarm(string time, string medName, int quantity)
        {
            try
            {
                timeToTake = DateTime.Parse(time);
                name = medName;
                numToTake = quantity;

            }
            catch { };
        }

        public string GetTimeToTake()
        {
            return timeToTake.ToString("HH:mm tt");
        }

        public string GetMedName()
        {
            return name;
        }

        public int GetNumToTake()
        {
            return numToTake;
        }
    }
}
