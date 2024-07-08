using AlbionDiscordBot.Commands;
using AlbionDiscordBot.Models;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Interactivity;
using DSharpPlus.SlashCommands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot
{
    internal class Program
    {
        private static DiscordClient Client { get; set; }
        private static AppConfig Config { get; set; }

        private static void SetConfig()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            Config = JsonConvert.DeserializeObject<AppConfig>(File.ReadAllText(path));
            SavedConfig.Config = Config;
        }

        static async Task Main(string[] args)
        {
            SetConfig();

            DiscordConfiguration discordConfiguration = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = Config.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };

            Client = new DiscordClient(discordConfiguration);
            Client.Ready += ClientReady;

            var interactivity = Client.UseInteractivity(new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromSeconds(30)
            });

            RegisterCommands();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task ClientReady(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }

        private static void RegisterCommands()
        {
            var slashCommandConfig = Client.UseSlashCommands();

            var types = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Namespace == "AlbionDiscordBot.Commands")
                .Where(s => s.Name.Contains("Command"));

            foreach (var t in types)
            {
                slashCommandConfig.RegisterCommands(t);
                Console.WriteLine($"{t.Name} has been initialised.");
            }
        }
    }
}
