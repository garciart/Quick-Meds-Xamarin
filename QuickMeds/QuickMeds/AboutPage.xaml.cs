using QuickMeds.Common;
using QuickMeds.Resources;
using System;
using System.IO;
using Xamarin.Forms;

namespace QuickMeds {
    public partial class AboutPage : ContentPage {
        public AboutPage() {
            InitializeComponent();
            HeaderImage.Source = ImageSource.FromResource("QuickMeds.Assets.headerImage_v1.png");
            CopyrightLabel.Text = string.Format(AppResources.CopyrightLabel, DateTime.Now.Year.ToString());
        }

        private async void UpdateDatabaseButton_Clicked(object sender, EventArgs e) {
            bool answer = await DisplayAlert("Quick Meds", AppResources.UpdateConfirm, AppResources.ButtonYes, AppResources.ButtonNo);
            if (answer) {
                string databaseFile = "QuickMeds.db";
                string databaseURL = "https://raw.githubusercontent.com/garciart/QuickMeds/master/Database/" + databaseFile;
                try {
                    byte[] returnedBytes = await AppFunctions.DownloadFileAsync(databaseURL);
                    File.WriteAllBytes(string.Format("{0}/{1}", Constants.AppDataPath, databaseFile), returnedBytes);
                    await this.DisplayAlert("Quick Meds", AppResources.DownloadSuccessMessage, "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                catch (Exception ex) {
                    await this.DisplayAlert("Quick Meds", string.Format(AppResources.DownloadErrorMessage, ex.Message), "OK");
                }
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e) {
            await Application.Current.MainPage.Navigation.PopAsync();
            Navigation.RemovePage(this);
        }
    }
}