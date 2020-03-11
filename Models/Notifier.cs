using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Xaml;

namespace Pill_Popper.Models
{
    public class Notifier
    {
        private static List<MedAlarm> autoAlarms = new List<MedAlarm>();
        private static DispatcherTimer timer = new DispatcherTimer();
        public static void Notify(String message, String img)
        {
            String projectDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))));

            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText02);

            XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
            stringElements[0].AppendChild(toastXml.CreateTextNode(message));


            String imagePath = ($"{projectDirectory}/images/{img}.png");

            XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
            imageElements[0].Attributes[1].NodeValue = imagePath;


            ToastNotification toast = new ToastNotification(toastXml);

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public static void setUpAutos(List<Medication> meds)
        {
            foreach (Medication medication in meds)
            {
                int timeBtwnDose = medication.dosagePDay / 24;
                for (int i = 0; i <= 24; i += timeBtwnDose)
                {
                    autoAlarms.Add(new MedAlarm($"{timeBtwnDose}:00", medication));
                }
            }
        }

        public static void startTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Tick += checkIfNotify;
        }

        public static void checkIfNotify(object sender, object e)
        {
            foreach(MedAlarm alarm in autoAlarms)
            {
                if (alarm.GetTimeToTake() == DateTime.Now.ToLocalTime().ToString("HH:mm"))
                {
                    Medication med = alarm.GetMedToTake();
                    Notify($"It's time to take {med.qtyPDose} of your {med.name}!", "Medicine Logo Transparent");
                }
            }
        }
    }
}
