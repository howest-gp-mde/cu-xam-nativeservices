using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;
using XrnCourse.NativeServices.Domain.Services;

namespace XrnCourse.NativeServices.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {
        private readonly ISoundPlayer _soundPlayer;

        public ICommand OpenDevicePageCommand { get; private set; }
        public ICommand PlaySoundCommand { get; private set; }

        public MainViewModel(ISoundPlayer soundPlayer)
        {
            _soundPlayer = soundPlayer;
            OpenDevicePageCommand = new Command(OpenDevicePage);
            PlaySoundCommand = new Command(PlaySound);
        }

        private async void OpenDevicePage()
        {
            await CoreMethods.PushPageModel<DeviceViewModel>(true);
        }

        private async void PlaySound()
        {
            await _soundPlayer.PlaySound();
        }
    }
}
