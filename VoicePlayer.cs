using System.Media;
using System.IO;
using System.Reflection;

namespace CyberAwarenessBotGUI
{
    public static class VoicePlayer
    {
        public static void PlayGreeting()
        {
            try
            {
                // Try to load from resources
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "CyberAwarenessBotGUI.Resources.greeting.wav";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        using (var player = new SoundPlayer(stream))
                        {
                            player.Play();
                        }
                    }
                }
            }
            catch
            {
                // Ignore errors
            }
        }
    }
}