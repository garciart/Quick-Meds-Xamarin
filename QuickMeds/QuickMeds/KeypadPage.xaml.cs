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

using QuickMeds.Resources;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuickMeds {
    /**
     * Keypad page to look up medications or conditions
     *
     * @author Rob Garcia at rgarcia@rgprogramming.com
     */
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KeypadPage : ContentPage {
        public KeypadPage(Constants.LookUpFlag lookUpFlag) {
            InitializeComponent();
            Title = (lookUpFlag == Constants.LookUpFlag.CONS ? AppResources.ConditionSearchTitle : AppResources.MedicationSearchTitle);
            KeypadLabel.Text = (lookUpFlag == Constants.LookUpFlag.CONS ? AppResources.ConditionSearchText : AppResources.MedicationSearchText);
        }

        async void Button_Clicked(object sender, EventArgs e) {
            string letterGroup = "";
            switch (((Button)sender).CommandParameter) {
                case "1": {
                        letterGroup = "ABC";
                        break;
                    }
                case "2": {
                        letterGroup = "DEF";
                        break;
                    }
                case "3": {
                        letterGroup = "GHI";
                        break;
                    }
                case "4": {
                        letterGroup = "JKL";
                        break;
                    }
                case "5": {
                        letterGroup = "MNO";
                        break;
                    }
                case "6": {
                        letterGroup = "PQR";
                        break;
                    }
                case "7": {
                        letterGroup = "STU";
                        break;
                    }
                case "8": {
                        letterGroup = "VWX";
                        break;
                    }
                case "9": {
                        letterGroup = "YZ";
                        break;
                    }
                default: {
                        letterGroup = "???";
                        break;
                    }
            }
            await this.DisplayAlert(AppResources.PressCheckTitle, (String.Format(AppResources.PressCheckText, letterGroup)), "OK");
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