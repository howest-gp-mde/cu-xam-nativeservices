using System.Collections.Generic;

namespace XrnCourse.NativeServices.Domain
{
    public class DeviceInformation
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string ReleaseVersion { get; set; }
        public bool CanVibrate { get; set; }
        public List<string> Sensors { get; set; }
    }
}
