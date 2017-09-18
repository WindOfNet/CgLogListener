using System.IO;
using System.Media;

namespace CgLogListener
{
    public static class PlaySoundHelper
    {
        public static bool PlaySound()
        {
            Settings settings = Settings.GetInstance();

            if (!settings.PlaySound)
            {
                return true;
            }
            else
            {
                const string wavName = "sound.wav";
                string wavPath = Path.Combine(Directory.GetCurrentDirectory(), wavName);
                Stream wavStream = null;

                try
                {
                    if (!File.Exists(wavPath))
                    {
                        // set default wav
                        wavStream = Resource.sound;
                    }
                    else
                    {
                        wavStream = File.Open(wavPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    }

                    SoundPlayer player = new SoundPlayer
                    {
                        Stream = wavStream
                    };

                    player.Play();
                    return true;
                }
                catch { return false; }
                finally
                {
                    if (wavStream != null)
                    {
                        using (wavStream) { }
                    }
                }
            }
        }
    }
}
