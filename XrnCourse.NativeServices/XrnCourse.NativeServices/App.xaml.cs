using FreshMvvm;
using Plugin.Toasts;
using Xamarin.Forms;
using XrnCourse.NativeServices.Domain.Services;
using XrnCourse.NativeServices.Infrastructure;
using XrnCourse.NativeServices.ViewModels;

namespace XrnCourse.NativeServices
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            //register dependencies
            FreshIOC.Container.Register(DependencyService.Get<IDeviceInformationService>());
            FreshIOC.Container.Register(DependencyService.Get<ISoundPlayer>());
            FreshIOC.Container.Register<ISpeechService, DefaultSpeechService>();

            var platformSpecificToastDinges = DependencyService.Get<IToastNotificator>();
            FreshIOC.Container.Register(platformSpecificToastDinges);

            var mainview = FreshPageModelResolver.ResolvePageModel<MainViewModel>();
            MainPage = new FreshNavigationContainer(mainview);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
