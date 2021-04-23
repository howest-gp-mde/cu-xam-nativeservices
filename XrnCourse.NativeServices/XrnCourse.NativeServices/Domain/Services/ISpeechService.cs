using System.Threading.Tasks;

namespace XrnCourse.NativeServices.Domain.Services
{
    public interface ISpeechService
    {
        Task Talk(string text, float volume, float pitch);

    }
}
