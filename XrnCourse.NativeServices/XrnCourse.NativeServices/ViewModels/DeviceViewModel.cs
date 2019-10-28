using FreshMvvm;
using XrnCourse.NativeServices.Domain;
using XrnCourse.NativeServices.Domain.Services;

namespace XrnCourse.NativeServices.ViewModels
{
    public class DeviceViewModel : FreshBasePageModel
    {
        private readonly IDeviceInformationService _deviceInfoService;

        public DeviceViewModel(IDeviceInformationService deviceInfoService)
        {
            _deviceInfoService = deviceInfoService;
        }

        public DeviceInformation Info { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);
            Info = _deviceInfoService.GetDeviceInfo();
        }
    }
}
