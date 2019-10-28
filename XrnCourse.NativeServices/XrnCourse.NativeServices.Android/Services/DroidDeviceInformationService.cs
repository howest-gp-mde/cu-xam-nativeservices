using Android.Content;
using Android.Hardware;
using Android.OS;
using System.Collections.Generic;
using Xamarin.Forms;
using XrnCourse.NativeServices.Domain;
using XrnCourse.NativeServices.Domain.Services;

[assembly: Dependency(typeof(XrnCourse.NativeServices.Droid.Services.DroidDeviceInformationService))]

namespace XrnCourse.NativeServices.Droid.Services
{
    internal class DroidDeviceInformationService : IDeviceInformationService
    {
        public DeviceInformation GetDeviceInfo()
        {
            var info = new DeviceInformation
            {
                Manufacturer = Build.Manufacturer,
                Model = Build.Model,
                ReleaseVersion = Build.VERSION.Release + Build.VERSION.Incremental,
                CanVibrate = false,
                Sensors = new List<string>()
            };

            using (var vib =
                (Vibrator)Android.App.Application.Context.GetSystemService(Context.VibratorService))
            {
                info.CanVibrate = vib.HasVibrator;
            }

            using (var sensormgr =
                (SensorManager)Android.App.Application.Context.GetSystemService(Context.SensorService))
            {
                foreach (var sensor in sensormgr.GetSensorList(Android.Hardware.SensorType.All))
                {
                    info.Sensors.Add(sensor.Name);
                }
            }
            return info;
        }
    }
}
