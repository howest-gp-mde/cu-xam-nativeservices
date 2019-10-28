using FreshMvvm;
using Xamarin.Forms;
using XrnCourse.NativeServices.Domain;
using XrnCourse.NativeServices.Domain.Services;

namespace XrnCourse.NativeServices.ViewModels
{
    public class DeviceViewModel : FreshBasePageModel
    {
        public DeviceInformation Info { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);

            IDeviceInformationService service = DependencyService.Get<IDeviceInformationService>();
            Info = service.GetDeviceInfo();
        }
    }
}
