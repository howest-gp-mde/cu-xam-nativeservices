using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrnCourse.NativeServices.Domain;
using XrnCourse.NativeServices.Domain.Services;
using XrnCourse.NativeServices.ViewModels;
using Xunit;

namespace XrnCourse.NativeServices.Tests
{
    public class DeviceViewModelTests
    {
        /// <summary>
        /// Eerder zinloze unit test, want eigenlijk test je enkel de
        /// toekenning van een resultaat aan een VM property.
        /// </summary>
        [Fact]
        public void Init_PopulatesDeviceInformation()
        {
            // arrange
            IDeviceInformationService service = new FakeInformationService();
            var viewModel = new DeviceViewModel(service);

            // act
            viewModel.Init(null);

            // assert
            Assert.NotNull(viewModel.Info);

        }

        public class FakeInformationService : IDeviceInformationService
        {
            public DeviceInformation GetDeviceInfo()
            {
                return new DeviceInformation{
                    CanVibrate = true,
                    Manufacturer = "Howest Cellular",
                    Model = "Ultimo 3000",
                    ReleaseVersion = "YXZ",
                    Sensors = new List<string>
                    {
                        "n00bDetector",
                        "CheatReporter",
                        "GPS"
                    }
                };
            }
        }
    }
}
