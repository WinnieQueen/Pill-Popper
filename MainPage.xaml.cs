using Pill_Popper.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Pill_Popper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        List<User> users = new List<User>();
        public MainPage()
        {
            this.InitializeComponent();

            Debug.WriteLine(System.DateTime.Now.ToLocalTime().TimeOfDay);
            getUsers();
        }

        private async void getUsers()
        {
            //Check if file exists
            if (File.Exists(localFolder.Path + "\\PillPopperUsers.txt"))
            {
                //Get the File
                Windows.Storage.StorageFile sampleFile = await localFolder.GetFileAsync("PillPopperUsers.txt");
                String fileContent = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
                PutOutUsers(fileContent);
            }
        }

        private void PutOutUsers(String fileContent)
        {
            string[] users = fileContent.Split("-");
            int amountOfUsers = (users.Length-1) / 2;
            int[] primes = { 1, 3, 5 };

            if(amountOfUsers > 5)
            {
                amountOfUsers = 5;
            }

            for (int i = 0; i < amountOfUsers; i++)
            {
                HyperlinkButton hyperBtn = new HyperlinkButton();
                hyperBtn.Content = users[i * 2];
                hyperBtn.VerticalAlignment = VerticalAlignment.Stretch;
                hyperBtn.HorizontalAlignment = HorizontalAlignment.Stretch;
                hyperBtn.Click += Login_Click;
                hyperBtn.FontFamily = new FontFamily("Snap ITC");
                hyperBtn.FontSize = 32;
                hyperBtn.Background = new SolidColorBrush(Color.FromArgb(255, (byte)(i * 25), (byte)(i * 25), (byte)(i * 25)));
                hyperBtn.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 63, 255, 225));
                hyperBtn.BorderThickness = new Thickness(2);

                if (i > 2)
                {
                    Grid.SetColumn(hyperBtn, primes[i - 3]);
                    Grid.SetRow(hyperBtn, 3);
                }
                else
                {
                    Grid.SetColumn(hyperBtn, primes[i]);
                    Grid.SetRow(hyperBtn, 1);
                }

                UsersGrid.Children.Add(hyperBtn);
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MedicineScreen));
        }

        private void Add_User_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateUser));
        }
    }
}
