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
        private Medication medToTake = new Medication();

        public MedAlarm(string time, Medication med)
        {
            timeToTake = DateTime.Parse(time);
            medToTake = new Medication();
        }

        public string GetTimeToTake()
        {
            return timeToTake.ToString("HH:mm");
        }

        public Medication GetMedToTake()
        {
            return medToTake;
        }

    }
}
