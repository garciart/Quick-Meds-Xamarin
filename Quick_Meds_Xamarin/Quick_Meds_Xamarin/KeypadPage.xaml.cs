/*
 * The MIT License
 *
 * Copyright 2018 Rob Garcia at rgarcia@rgprogramming.com.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Quick_Meds_Xamarin.Constants;

namespace Quick_Meds_Xamarin
{
    /**
     * Keypad page to look up medications or conditions
     *
     * @author Rob Garcia at rgarcia@rgprogramming.com
     */
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class KeypadPage : ContentPage
	{
        private LookUpFlag lookUpFlag;

        public KeypadPage(LookUpFlag lookUpFlag) {
            InitializeComponent();
            this.lookUpFlag = lookUpFlag;
            KeypadLabel.Text = (String.Format("Press the key that matches the first letter of the {0} you are searching for:", (lookUpFlag == LookUpFlag.CONS ? "condition" : "medication")));
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