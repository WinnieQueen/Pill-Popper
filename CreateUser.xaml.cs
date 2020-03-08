using Pill_Popper.Models;
using System;
using System.Collections.Generic;
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
    public sealed partial class CreateUser : Page
    {
        Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        User user = new User();
        public CreateUser()
        {
            this.InitializeComponent();
        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            user.Name = NameInput.Text;
            CheckIfFileExists();
            this.Frame.Navigate(typeof(MedicineScreen));
        }

        private async void CheckIfFileExists()
        {
            //Check if file exists
            if (File.Exists(localFolder.Path + "\\PillPopperUsers.txt"))
            {
                Windows.Storage.StorageFile sampleFile = await localFolder.GetFileAsync("PillPopperUsers.txt");
                await File.AppendAllTextAsync(sampleFile.Path, $"{user.Name}-{user.Medicines}-");
                //String fileContent = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
            }
            else
            {
                //File does not exist. Create it.
                Windows.Storage.StorageFile file = await localFolder.CreateFileAsync("PillPopperUsers.txt");
                if (user.Name != null && user.Name.Trim().Length > 0)
                {
                    await Windows.Storage.FileIO.WriteTextAsync(file, $"{user.Name}-{user.Medicines}-");
                }
            }

        }
    }
}
