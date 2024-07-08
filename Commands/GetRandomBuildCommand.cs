using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlbionDiscordBot.Utilities;
using AlbionDiscordBot.ApiResponses;
using AlbionDiscordBot.Models;
using DSharpPlus.Net.Models;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using System.Reflection;
using System.IO;
using SixLabors.ImageSharp.Processing;
using System.Collections;

namespace AlbionDiscordBot.Commands
{
    public class GetRandomBuildCommand : ApplicationCommandModule
    {
        static Random rnd = new Random();

        [SlashCommand("GetRandomBuild", "Gets a random build")]
        public async Task GetRandomBuild(InteractionContext context)
        {
            await context.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

            await Task.Run(async () =>
            {
                List<EventsResponse> eventsResponse = await ApiUtility.GetEvents();
                var killer = eventsResponse[rnd.Next(eventsResponse.Count)].Killer;

                Image<Rgba32> inventory = DrawingUtility.GetInventory();
                inventory = DrawingUtility.AddImages(inventory, killer);

                using (MemoryStream stream = new MemoryStream())
                {
                    inventory.SaveAsJpeg(stream);
                    stream.Position = 0;

                    DiscordEmbedBuilder embedBuilder = new DiscordEmbedBuilder
                    {
                        Title = "",
                        Description = "",
                        ImageUrl = "attachment://output.png"
                    };

                    var webhookBuilder = new DiscordWebhookBuilder()
                        .AddEmbed(embedBuilder)
                        .AddFile("output.png", stream);

                    await context.EditResponseAsync(webhookBuilder);
                }
            });
        }
    }
}
