using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot
{
    public static class SavedConfig
    {
        public static AppConfig Config { get; set; }
    }

    public class AppConfig
    {
        public string Token { get; set; }
        public string Prefix { get; set; }
        public string ApiUrl { get; set; }
        public string RenderUrl { get; set; }
    }
}
