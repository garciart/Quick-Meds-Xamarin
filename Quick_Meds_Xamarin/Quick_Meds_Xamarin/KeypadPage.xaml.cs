using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quick_Meds_Xamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class KeypadPage : ContentPage
	{
		public KeypadPage ()
		{
			InitializeComponent ();
		}

        async void Button_Clicked(object sender, EventArgs e) {
            switch(((Button)sender).CommandParameter) {
                case "1": {
                        await this.DisplayAlert("Press Check!", "You pressed ABC!", "OK");
                        break;
                    }
                case "2": {
                        await this.DisplayAlert("Press Check!", "You pressed DEF!", "OK");
                        break;
                    }
                case "3": {
                        await this.DisplayAlert("Press Check!", "You pressed GHI!", "OK");
                        break;
                    }
                case "4": {
                        await this.DisplayAlert("Press Check!", "You pressed JKL!", "OK");
                        break;
                    }
                case "5": {
                        await this.DisplayAlert("Press Check!", "You pressed MNO!", "OK");
                        break;
                    }
                case "6": {
                        await this.DisplayAlert("Press Check!", "You pressed PQR!", "OK");
                        break;
                    }
                case "7": {
                        await this.DisplayAlert("Press Check!", "You pressed STU!", "OK");
                        break;
                    }
                case "8": {
                        await this.DisplayAlert("Press Check!", "You pressed VWX!", "OK");
                        break;
                    }
                case "9": {
                        await this.DisplayAlert("Press Check!", "You pressed YZ!", "OK");
                        break;
                    }
                default: {
                        await this.DisplayAlert("Press Check!", "What button did you press?", "OK");
                        break;
                    }
            }

            /*
            if (((Button)sender).Equals(ABC)) {
                await this.DisplayAlert("Press Check!", "You pressed Button 1!", "OK");
            }
            else {
                await this.DisplayAlert("Press Check!", "You pressed Button 2!", "OK");
            }
            */
        }
    }
}