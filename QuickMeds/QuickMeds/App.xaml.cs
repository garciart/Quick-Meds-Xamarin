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
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace QuickMeds {

    public partial class App : Application {
        /// <summary>
        /// 
        /// </summary>
        static DataFunctions database;

        /// <summary>
        /// Open the database once and only once when the application starts.
        /// </summary>
        public static DataFunctions Database {
            get {
                if (database == null) {
                    // The database is stored in /data/user/0/com.companyname.QuickMeds/files/QuickMeds.db
                    string dataPath = Path.Combine(Constants.AppDataPath, "QuickMeds.db");
                    database = new DataFunctions(dataPath);
                }
                return database;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public App() {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        /// <summary>
        /// Handle when your app starts
        /// </summary>
        protected override void OnStart() {

        }

        /// <summary>
        /// Handle when your app sleeps
        /// </summary>
        protected override void OnSleep() {

        }

        /// <summary>
        /// Handle when your app resumes
        /// </summary>
        protected override void OnResume() {

        }
    }
}
