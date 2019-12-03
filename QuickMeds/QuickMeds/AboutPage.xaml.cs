using QuickMeds.Common;
using QuickMeds.Resources;
using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace QuickMeds {
    /// <summary>
    /// 
    /// </summary>
    public partial class AboutPage : ContentPage {
        /// <summary>
        /// 
        /// </summary>
        public AboutPage() {
            InitializeComponent();
            HeaderImage.Source = ImageSource.FromResource("QuickMeds.Assets.headerImage_v1.png");
            CopyrightLabel.Text = string.Format(CultureInfo.InvariantCulture, AppResources.CopyrightLabel, DateTime.Now.Year.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UpdateDatabaseButton_Clicked(object sender, EventArgs e) {
            bool answer = await DisplayAlert("Quick Meds", AppResources.UpdateConfirm, AppResources.ButtonYes, AppResources.ButtonNo);
            if (answer) {
                string databaseFile = "QuickMeds.db";
                string databaseURL = "https://raw.githubusercontent.com/garciart/QuickMeds/master/Database/" + databaseFile;
                try {
                    byte[] returnedBytes = await AppFunctions.DownloadFileAsync(databaseURL);
                    File.WriteAllBytes(string.Format("{0}/{1}", Constants.AppDataPath, databaseFile), returnedBytes);
                    await DisplayAlert("Quick Meds", AppResources.DownloadSuccessMessage, "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                catch (Exception ex) {
                    await DisplayAlert("Quick Meds", string.Format(AppResources.DownloadErrorMessage, ex.Message), "OK");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BackButton_Clicked(object sender, EventArgs e) {
            await Application.Current.MainPage.Navigation.PopAsync();
            Navigation.RemovePage(this);
        }
    }
}