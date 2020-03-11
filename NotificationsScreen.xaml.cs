using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pill_Popper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NotificationsScreen : Page
    {
        private List<MedAlarm> alarms = new List<MedAlarm>();

        public NotificationsScreen()
        {
            this.InitializeComponent();
        }

        private static void AddAlarm(string timeToTake, Medicine med)
        {
            bool worked = true;
            try
            {
                DateTime.Parse(timeToTake);
            }
            catch (Exception e)
            {
                worked = false;
                throw new ArgumentException("TimeToTake has to follow the format of a DateTime, such as: HH:mm");
            }
            Debug.WriteLine(System.DateTime.Now.ToLocalTime().TimeOfDay.ToString("HH:mm"));
        }
    }
}
