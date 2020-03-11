using Pill_Popper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Notifications;
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
using Windows.Data.Xml.Dom;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pill_Popper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MedicineScreen : Page
    {
        Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        User user = new User();
        public MedicineScreen()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                user = (User)e.Parameter;
            }
            base.OnNavigatedTo(e);
            medList.ItemsSource = user.Medicines;
            Notifier.setupTimer();
            Notifier.startTimer();
        }


        private void View_Alarm_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NotificationsScreen), user);
        }
        
        private void addMedicine_Click(object sender, RoutedEventArgs e)
        {
            medPopup.IsOpen = true;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Medication m = new Medication();
                m.name = m_Name.Text;

                if (m.name == "")
                {
                    throw new System.Exception();
                }
                m.dosagePDay = Int32.Parse(m_DosesPDay.Text);
                m.quantity = Int32.Parse(m_qty.Text);
                m.qtyPDose = Int32.Parse(m_qty_doses.Text);
                user.Medicines.Add(m);
                m_Name.Text = "";
                m_DosesPDay.Text = "";
                m_qty.Text = "";
                m_qty_doses.Text = "";
                AddToFile();
            }
            catch (Exception x)
            {
                var messsageDialog = new MessageDialog("Error, Please check that all boxes are filled out correctly.");
                await messsageDialog.ShowAsync();
                return;
            }
        }

        private async void AddToFile()
        {
            Windows.Storage.StorageFile jsonFile = await localFolder.GetFileAsync("PillPopperUsers.json");
            var jsonContent = await Windows.Storage.FileIO.ReadTextAsync(jsonFile);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonContent);

            for(int u = 0; u < users.Count; u++)
            {
                if(users[u].Name.Equals(user.Name))
                {

                    users[u] = user;
                }
            }
            await Windows.Storage.FileIO.WriteTextAsync(jsonFile, JsonConvert.SerializeObject(users));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
