using QuickMeds.Common;
using QuickMeds.Resources;
using System;
using System.IO;
using Xamarin.Forms;

namespace QuickMeds {
    public partial class AboutPage : ContentPage {
        public AboutPage() {
            InitializeComponent();
            headerImage.Source = ImageSource.FromResource("QuickMeds.Assets.headerImage_v1.png");
        }

        private async void UpdateDatabaseButton_Clicked(object sender, EventArgs e) {
            // await this.DisplayAlert("Quick Meds", "You want to update the database!", "OK");
            string databaseFile = "medications.db";
            string databaseURL = "https://raw.githubusercontent.com/garciart/QuickMeds/master/Database/" + databaseFile;
            try {
                byte[] returnedBytes = await AppFunctions.DownloadFileAsync(databaseURL);
                File.WriteAllBytes(String.Format("{0}/{1}", Constants.AppDataPath, databaseFile), returnedBytes);
                await this.DisplayAlert("Quick Meds", AppResources.DownloadSuccessMessage, "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex) {
                await this.DisplayAlert("Quick Meds", String.Format(AppResources.DownloadErrorMessage, ex.Message), "OK");
            }
        }
    }
}