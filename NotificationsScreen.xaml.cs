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

        private static void AddAlarm(double timeToTake, Medicine med)
        {
            if(timeToTake <= 0 || timeToTake > 24)
            {
                Debug.WriteLine( System.DateTime.Now);
                throw new Exception("TimeToTake cannot be lower than 0 or greater than 24. Use decimals to show minutes (ie 12.30 for 12:30)");
            }
        }
    }
}
