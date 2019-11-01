using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XrnCourse.NativeServices.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpeechPage : ContentPage
    {
        public SpeechPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            txtDictate.Focus(); // let this textbox gain focus on startup
        }
    }
}