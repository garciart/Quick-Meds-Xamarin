using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Quick_Meds_Xamarin {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        async void Med_Button_Clicked(object sender, EventArgs e) {
            await this.DisplayAlert("Press Check!", "You pressed " + ((Button)sender).ToString() + "!", "OK");
        }

        async void Con_Button_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new KeypadPage());
        }
    }
}
