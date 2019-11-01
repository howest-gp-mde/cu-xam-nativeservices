using FreshMvvm;
using Plugin.Toasts;
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
        public ICommand OpenSpeechPageCommand { get; private set; }
        public ICommand ShowToastCommand { get; private set; }

        public MainViewModel(ISoundPlayer soundPlayer)
        {
            _soundPlayer = soundPlayer;
            OpenDevicePageCommand = new Command(OpenDevicePage);
            PlaySoundCommand = new Command(PlaySound);
            OpenSpeechPageCommand = new Command(OpenSpeechPage);
            ShowToastCommand = new Command(ShowToast);
        }

        private async void OpenDevicePage()
        {
            await CoreMethods.PushPageModel<DeviceViewModel>(true);
        }

        private async void PlaySound()
        {
            await _soundPlayer.PlaySound();
        }

        private async void OpenSpeechPage()
        {
            await CoreMethods.PushPageModel<SpeechViewModel>(true);
        }

        private async void ShowToast()
        {
            //see https://github.com/EgorBo/Toasts.Forms.Plugin for usage
            //of this Toasts plugin
            var notificator = DependencyService.Get<IToastNotificator>();

            var options = new NotificationOptions()
            {
                Title = "This is a toast",
                Description = "To many useful and beautiful apps!",
                IsClickable = true,
                WindowsOptions = new WindowsOptions() { LogoUri = "icon.png" },
                ClearFromHistory = false,
                AllowTapInNotificationCenter = false,
                AndroidOptions = new AndroidOptions()
                {
                    HexColor = "#F99D1C",
                    ForceOpenAppOnNotificationTap = true
                }
            };

            await notificator.Notify(options);

        }
    }
}
