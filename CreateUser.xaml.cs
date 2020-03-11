using Newtonsoft.Json;
using Pill_Popper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class CreateUser : Page
    {
        Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        User user = new User();
        Medication m = new Medication();
        public CreateUser()
        {
            this.InitializeComponent();
        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user.Name = NameInput.Text;
                m.name = m_Name.Text;
            
                if(user.Name == "" || m.name == "")
                {
                    throw new System.Exception();
                }
                m.dosagePDay = Int32.Parse(m_DosesPDay.Text);
                m.quantity = Int32.Parse(m_qty.Text);
                m.qtyPDose = Int32.Parse(m_qty_doses.Text);
            }
            catch(Exception x){
                var messsageDialog = new MessageDialog("Error, Please check that all boxes are filled out correctly.");
                await messsageDialog.ShowAsync();
                return;
            }

            user.Medicines.Add(m);
            CheckIfFileExistsAndAdd();
            this.Frame.Navigate(typeof(MedicineScreen), user);
        }

        private async void CheckIfFileExistsAndAdd()
        {
            //Check if file exists
            if (File.Exists(localFolder.Path + "\\PillPopperUsers.json"))
            {
                //If it exists add to the list.
                Windows.Storage.StorageFile jsonFile = await localFolder.GetFileAsync("PillPopperUsers.json");
                var jsonContent = await Windows.Storage.FileIO.ReadTextAsync(jsonFile);
                List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonContent);
                AddUserToFile(users);
            }
            else
            {
                //File does not exist. Create it.
                Windows.Storage.StorageFile jsonFile = await localFolder.CreateFileAsync("PillPopperUsers.json");
                AddUserToFile(new List<User>());
            }

        }

        private async void AddUserToFile(List<User> users)
        {
            users.Add(user);
            Windows.Storage.StorageFile jsonFile = await localFolder.GetFileAsync("PillPopperUsers.json");
            await Windows.Storage.FileIO.WriteTextAsync(jsonFile, JsonConvert.SerializeObject(users));
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            //m.dosageType = Enum.Parse(Medication.DOSAGETYPE, rb.Tag.ToString());
        }



        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
