using CoreLocation;
using CoreMotion;
using System.Collections.Generic;
using UIKit;
using Xamarin.Forms;
using XrnCourse.NativeServices.Domain;
using XrnCourse.NativeServices.Domain.Services;

[assembly: Dependency(typeof(XrnCourse.NativeServices.iOS.Services.IOSDeviceInformationService))]

namespace XrnCourse.NativeServices.iOS.Services
{
    internal class IOSDeviceInformationService : IDeviceInformationService
    {
        private UIDevice device;
        private CMMotionManager motionManager;
        private CLLocationManager locationManager;

        public IOSDeviceInformationService()
        {
            device = new UIDevice();
            motionManager = new CMMotionManager();
            locationManager = new CLLocationManager();
        }

        public DeviceInformation GetDeviceInfo()
        {
            var info = new DeviceInformation
            {
                Manufacturer = "Apple",
                Model = device.Model,
                ReleaseVersion = device.SystemVersion,
                CanVibrate = true,
                Sensors = new List<string>()
            };

            if (motionManager.AccelerometerAvailable)
                info.Sensors.Add("Accelerometer");
            if (motionManager.GyroAvailable)
                info.Sensors.Add("Gyroscope");
            if (motionManager.MagnetometerAvailable)
                info.Sensors.Add("Magnetometer");

            return info;
        }
    }
}