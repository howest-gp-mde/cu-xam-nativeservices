using FreshMvvm;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XrnCourse.NativeServices.Domain.Services;

namespace XrnCourse.NativeServices.ViewModels
{
    public class SpeechViewModel : FreshBasePageModel
    {
        protected readonly ISpeechService _speechService;

        public SpeechViewModel(ISpeechService speechService)
        {
            _speechService = speechService;

            Volume = 0.9f; // 90% volume by default
            Pitch = 1.0f;  // normal speaking pitch

            SayTimeCommand = new Command(SayTime);
            DictateCommand = new Command(Dictate);
            IsReady = true; //will enable controls by default
        }

        public override void Init(object initData)
        {
            DictateText = "Type something for me to say.";
            base.Init(initData);
        }

        public ICommand SayTimeCommand { get; private set; }

        public ICommand DictateCommand { get; private set; }

        private float pitch;
        public float Pitch
        {
            get { return pitch; }
            set {
                pitch = value;
                RaisePropertyChanged(nameof(Pitch));
            }
        }

        private float volume;
        public float Volume
        {
            get { return volume; }
            set
            {
                //ensure value is between 0 and 100%
                volume = Math.Max(Math.Min(value, 1.0f), 0.0f);
                RaisePropertyChanged(nameof(Volume));
            }
        }

        private string dictateText;
        public string DictateText
        {
            get { return dictateText; }
            set
            {
                dictateText = value;
                RaisePropertyChanged(nameof(DictateText));
            }
        }

        private bool isReady;
        public bool IsReady             // to disable input when talking. true == not talking
        {
            get { return isReady; }
            set { 
                isReady = value;
                RaisePropertyChanged(nameof(IsReady));
            }
        }

        private async void SayTime()    // SayTimeCommand execution method
        {
            await Speak($"It's now {DateTime.Now.Hour} hours and {DateTime.Now.Minute} minutes");
        }

        private async void Dictate()    // DictateCommand execution method
        {
            await Speak(DictateText);
        }

        private async Task Speak(string text)
        {
            try
            {
                IsReady = false;
                await _speechService.Talk(text, Volume, Pitch);
            }
            catch (Exception ex)
            {
                await CurrentPage?.DisplayAlert("Error", ex.Message, "Oh, snap!");
            }
            finally
            {
                IsReady = true;
            }
        }
    }
}
