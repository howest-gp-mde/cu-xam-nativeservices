using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrnCourse.NativeServices.Domain.Services;
using XrnCourse.NativeServices.ViewModels;
using Xunit;

namespace XrnCourse.NativeServices.Tests
{
    public class SpeechViewModelTests
    {
        [Fact]
        public void DictateCommand_SetsReadyToTrueDuringExecution()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void DictateCommand_CallsTalkWithDictationParameters()
        {
            //arrange
            string textToRead = "Read me!";
            float pitch = 0.3f;
            float volume = 0.8f;

            var fakeSpeechService = new FakeSpeechService();
            ISpeechService service = fakeSpeechService;
            var viewModel = new SpeechViewModel(service);
            viewModel.DictateText = textToRead;
            viewModel.Volume = volume;
            viewModel.Pitch = pitch;

            //act
            viewModel.DictateCommand.Execute(null);

            //assert
            Assert.Equal(textToRead, fakeSpeechService.ISaidThisText);
            Assert.Equal(pitch, fakeSpeechService.ISaidItThisHigh);
            Assert.Equal(volume, fakeSpeechService.ISaidItThisLoud);
        }


        [Theory]
        [InlineData(-100.0f, 0f)]
        [InlineData(100.0f, 1f)]
        [InlineData(0.5f, 0.5f)]
        [InlineData(0f, 0f)]
        [InlineData(1f, 1f)]
        public void DictateCommand_TalksWithClampedVolume(float inputVolume, float expectedVolume)
        {
            //arrange
            string textToRead = "Read me!";
            float pitch = 0.3f;

            var fakeSpeechService = new FakeSpeechService();
            ISpeechService service = fakeSpeechService;
            var viewModel = new SpeechViewModel(service);
            viewModel.DictateText = textToRead;
            viewModel.Volume = inputVolume;
            viewModel.Pitch = pitch;

            //act
            viewModel.DictateCommand.Execute(null);

            //assert
            Assert.Equal(expectedVolume, fakeSpeechService.ISaidItThisLoud);
        }


        [Fact]
        public void DictateCommand_Mocked_CallsTalkWithDictationParameters()
        {
            //arrange
            string textToRead = "Read me!";
            float pitch = 0.3f;
            float volume = 0.8f;

            string receivedText = null;
            float receivedPitch = -1, receivedVolume = -1;

            var mockSpeechService = new Mock<ISpeechService>();
            mockSpeechService
                .Setup(service => service.Talk(
                    It.IsAny<string>(),
                    It.IsAny<float>(),
                    It.IsAny<float>()))
                .Callback((
                    string callbackText, 
                    float callbackVolume, 
                    float callbackPitch) => {

                        receivedText = callbackText;
                        receivedVolume = callbackVolume;
                        receivedPitch = callbackPitch;
                    });

            ISpeechService service = mockSpeechService.Object;
            //todo: mock speechservice
            var viewModel = new SpeechViewModel(service);
            viewModel.DictateText = textToRead;
            viewModel.Volume = volume;
            viewModel.Pitch = pitch;

            //act
            viewModel.DictateCommand.Execute(null);

            //assert
            Assert.Equal(textToRead, receivedText);
            Assert.Equal(pitch, receivedPitch);
            Assert.Equal(volume, receivedVolume);
        }

    }

    internal class FakeSpeechService : ISpeechService
    {
        public string ISaidThisText { get; set; }
        public float ISaidItThisLoud { get; set; }
        public float ISaidItThisHigh { get; set; }

        public async Task Talk(string text, float volume, float pitch)
        {
            //I'm not really saying anything, but that's ok.

            //I'm just gonna populate some properties to report back to
            //the unit test
            ISaidThisText = text;
            ISaidItThisLoud = volume;
            ISaidItThisHigh = pitch;

            await Task.Delay(0);
        }
    }
}
