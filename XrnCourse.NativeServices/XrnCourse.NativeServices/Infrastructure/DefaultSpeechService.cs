using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XrnCourse.NativeServices.Domain.Services;

namespace XrnCourse.NativeServices.Infrastructure
{
    public class DefaultSpeechService : ISpeechService
    {
        public async Task Talk(string text, float volume, float pitch)
        {
            var options = new SpeechOptions
            {
                Pitch = pitch,
                Volume = volume
            };
            await TextToSpeech.SpeakAsync(text, options);
        }
    }
}
