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

using QuickMeds.Common;
using System;
using Xamarin.Forms;

namespace QuickMeds {
    /// <summary>
    /// 
    /// </summary>
    public partial class MainPage : ContentPage {

        /// <summary>
        /// Constructor
        /// </summary>
        public MainPage() {
            InitializeComponent();
            headerImage.Source = ImageSource.FromResource("QuickMeds.Assets.headerImage_v1.png");
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnAppearing() {
            base.OnAppearing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void MedNameButton_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new KeypadPage(Constants.LookUpFlag.MEDS)).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void ConNameButton_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new KeypadPage(Constants.LookUpFlag.CONS)).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AboutButton_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new AboutPage()).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TestButton_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new Test()).ConfigureAwait(false);
        }
    }
}
