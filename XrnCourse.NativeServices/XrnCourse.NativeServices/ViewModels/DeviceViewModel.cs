using FreshMvvm;
using XrnCourse.NativeServices.Domain;

namespace XrnCourse.NativeServices.ViewModels
{
    public class DeviceViewModel : FreshBasePageModel
    {
        public DeviceInformation Info { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);

            Info = new DeviceInformation();
        }
    }
}
