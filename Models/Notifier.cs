using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        private static ObservableCollection<MedAlarm> alarms = new ObservableCollection<MedAlarm>();
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

        public static void SetUpAutos(ObservableCollection<Medication> meds)
        {
            foreach (Medication medication in meds)
            {
                int timeBtwnDose = 24 / medication.dosagePDay;
                for (int i = 0 + timeBtwnDose; i <= 24; i += timeBtwnDose)
                {
                    int a = i;
                    string afterPiece = "am";
                    if (i > 12)
                    {
                        a = i - 12;
                        afterPiece = "pm";
                    }
                    alarms.Add(new MedAlarm($"{a}:00 {afterPiece}", medication.name, medication.qtyPDose));
                }
            }
        }

        public static void setupTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Tick += checkIfNotify;
        }

        public static void stopTimer()
        {
            timer.Stop();
        }
        public static void startTimer()
        {
            timer.Start();
        }

        public static void checkIfNotify(object sender, object e)
        {
            Debug.WriteLine("checked");
            foreach (MedAlarm alarm in alarms)
            {
                if (alarm.GetTimeToTake() == DateTime.Now.ToLocalTime().ToString("HH:mm"))
                {
                    Notify($"It's time to take {alarm.GetNumToTake()} of your {alarm.GetMedName()}!", "Medicine Logo Transparent");
                }
            }
        }

        public static void clearAlarms()
        {
            alarms.Clear();
        }

        public static void deleteAlarm(MedAlarm alarm)
        {
            alarms.Remove(alarm);
        }

        public static void addAlarm(MedAlarm alarm)
        {
            alarms.Add(alarm);
        }

        public static void PrintAll()
        {
            foreach (MedAlarm alarm in alarms)
            {
                Debug.WriteLine($"One for {alarm.GetMedName()} will ring at {alarm.GetTimeToTake()}");
            }
        }
    }
}
