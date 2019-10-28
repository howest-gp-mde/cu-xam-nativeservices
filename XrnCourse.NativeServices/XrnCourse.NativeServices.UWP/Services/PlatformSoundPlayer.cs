using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using XrnCourse.NativeServices.Domain.Services;

[assembly: Dependency(typeof(XrnCourse.NativeServices.UWP.Services.PlatformSoundPlayer))]

namespace XrnCourse.NativeServices.UWP.Services
{
    internal class PlatformSoundPlayer : ISoundPlayer
    {
        public async Task PlaySound()
        {
            MediaElement mysong = new MediaElement();
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package
                .Current.InstalledLocation.GetFolderAsync("Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("guitar-m.mp3");
            var stream = await file.OpenReadAsync();
            mysong.SetSource(stream, file.ContentType);
            mysong.Play();
        }
    }
}
