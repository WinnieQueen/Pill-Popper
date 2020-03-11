﻿using System;
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

        public MedAlarm(string time, string medName, int quantity)
        {
            timeToTake = DateTime.Parse(time);
            name = medName;
            numToTake = quantity;
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
