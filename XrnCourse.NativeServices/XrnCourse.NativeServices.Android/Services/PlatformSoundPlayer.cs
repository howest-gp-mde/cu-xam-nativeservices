using Android.Media;
using System.Threading.Tasks;
using Xamarin.Forms;
using XrnCourse.NativeServices.Domain.Services;

[assembly: Dependency(typeof(XrnCourse.NativeServices.Droid.Services.PlatformSoundPlayer))]

namespace XrnCourse.NativeServices.Droid.Services
{
    public class PlatformSoundPlayer : ISoundPlayer
    {
        private MediaPlayer _mediaPlayer;

        public Task PlaySound()
        {
            _mediaPlayer = MediaPlayer
                .Create(global::Android.App.Application.Context, Resource.Raw.guitarm);
            _mediaPlayer.Start();
            return Task.Delay(0);
        }
    }
}
