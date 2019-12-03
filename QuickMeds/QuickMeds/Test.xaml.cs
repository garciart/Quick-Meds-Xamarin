
using Xamarin.Forms;

namespace QuickMeds {
    public partial class Test : ContentPage {
        public Test() {
            InitializeComponent();
        }

        /*
        protected override void OnAppearing() {
            base.OnAppearing();
            // listView.ItemsSource = await App.Database.GetMedicationsAsync();
            listView.ItemsSource = new string[] {
                "mono",
                "monodroid",
                "monotouch",
                "monorail",
                "monodevelop",
                "monotone",
                "monopoly",
                "monomodal",
                "mononucleosis"
            };
        }
        */

        protected override async void OnAppearing() {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetConditionsAsync();
        }
    }
}