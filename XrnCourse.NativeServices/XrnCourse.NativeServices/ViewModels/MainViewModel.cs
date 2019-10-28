using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace XrnCourse.NativeServices.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {
        public ICommand OpenDevicePageCommand { get; private set; }

        public MainViewModel()
        {
            OpenDevicePageCommand = new Command(OpenDevicePage);
        }

        private async void OpenDevicePage()
        {
            await CoreMethods.PushPageModel<DeviceViewModel>(true);
        }
    }
}
