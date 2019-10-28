using System.Collections.Generic;
using Windows.Devices.Haptics;
using Windows.Devices.Sensors;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Xamarin.Forms;
using XrnCourse.NativeServices.Domain;
using XrnCourse.NativeServices.Domain.Services;

[assembly: Dependency(typeof(XrnCourse.NativeServices.UWP.Services.UWPDeviceInformationService))]

namespace XrnCourse.NativeServices.UWP.Services
{
    internal class UWPDeviceInformationService : IDeviceInformationService
    {
        EasClientDeviceInformation easDevice;
        private Accelerometer accelerometer;
        private Gyrometer gyrometer;
        private Magnetometer magnetometer;
        private VibrationDevice vibrationDevice;

        public UWPDeviceInformationService()
        {
            easDevice = new EasClientDeviceInformation();
            accelerometer = Accelerometer.GetDefault();
            gyrometer = Gyrometer.GetDefault();
            magnetometer = Magnetometer.GetDefault();
            try
            {
                vibrationDevice = VibrationDevice.GetDefaultAsync().GetResults();
            }
            catch { }

        }

        public DeviceInformation GetDeviceInfo()
        {
            var info = new DeviceInformation
            {
                Manufacturer = easDevice.SystemManufacturer,
                Model = easDevice.SystemManufacturer,
                ReleaseVersion = easDevice.OperatingSystem,
                CanVibrate = false,
                Sensors = new List<string>()
            };

            if (vibrationDevice != null)
                info.CanVibrate = true;
            if (accelerometer != null)
                info.Sensors.Add("Accelerometer ");
            if (gyrometer != null)
                info.Sensors.Add("Gyroscope ");
            if (magnetometer != null)
                info.Sensors.Add("Magnetometer");

            return info;
        }
    }
}

