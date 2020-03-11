using Pill_Popper.Models;
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
        private User user;


        public NotificationsScreen()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            user = (User) e.Parameter;
            alarmList.ItemsSource = user.alarms;
        }

        private void Auto_Alarms_Click(object sender, RoutedEventArgs e)
        {
            Notifier.SetUpAutos(user.Medicines);
        }
        private void Add_Alarm_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateAlarmPage));
        }
        private void Delete_Alarm_Click(object sender, RoutedEventArgs e)
        {

        }
        private void alarmList_ItemClick(object sender, ItemClickEventArgs e)
        {
            MedAlarm a = (MedAlarm) e.ClickedItem;
            Notifier.deleteAlarm(a.Name, a.NumToTake, a.TimeToTake);
        }
    }
}
