using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using System.ComponentModel;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.PixelFormats;
using System.IO;
using SixLabors.ImageSharp;

namespace AlbionDiscordBot.Commands
{
    public class ProgressBarCommand : ApplicationCommandModule
    {
        private static Dictionary<ulong, ProgressBar> progressBarInfo = new Dictionary<ulong, ProgressBar>(); // Channel ID -> ProgressBarInfo

        [SlashCommand("progressbar", "Displays a progress bar")]
        public async Task ProgressBar(InteractionContext context,
            [Option("currentvalue", "The current value of the progress bar")] long currentValue,
            [Option("maxvalue", "The maximum value of the progress bar")] long maxValue,
            [Option("description", "Goal of the progress bar")] string goal)
        {
            //using (var image = Image.Load<Rgba32>(Path.Combine(AppContext.BaseDirectory, "Images", "progress.png")))
            //{
            //    using (var memoryStream = new MemoryStream())
            //    {
            //        image.SaveAsPng(memoryStream);
            //        memoryStream.Position = 0;

            //        var builder = new DiscordMessageBuilder()
            //            .AddFile("progress.png", memoryStream);

            //        var message = await context.Channel.SendMessageAsync(builder);
            //    }
            //}

            await context.DeferAsync();

            var embed = new DiscordEmbedBuilder()
                .WithTitle("Progress Bar")
                .WithDescription($"We hebben {currentValue} van de {maxValue} {goal} verzameld.")
                .WithColor(DiscordColor.DarkRed)
                .Build();

            var progressBarMessage = await context.Channel.SendMessageAsync(embed: embed);

            var progressBar = new ProgressBar(progressBarMessage.Id, currentValue, maxValue, goal);
            progressBarInfo[context.Channel.Id] = progressBar;

            await context.DeleteResponseAsync();
        }

        //[SlashCommand("fillprogressbar", "Fills up the progress bar")]
        //public async Task FillProgressBar(InteractionContext context,
        //[Option("increaseby", "Amount to increase the progress bar by (default is 10)")] long increaseBy = 10)
        //{
        //    if (!progressBarInfo.TryGetValue(context.Channel.Id, out ProgressBar info))
        //    {
        //        await context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Progress bar has not been initialized."));
        //        return;
        //    }

        //    var progressBarMessage = await context.Channel.GetMessageAsync(info.MessageId);
        //    if (progressBarMessage == null)
        //    {
        //        await context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Progress bar message not found."));
        //        return;
        //    }

        //    // Calculate new current value
        //    long newValue = Math.Min(info.CurrentValue + increaseBy, info.MaxValue);

        //    // Calculate percentage
        //    long percentage = (newValue * 100) / info.MaxValue;

        //    // Update the message with the new progress
        //    await progressBarMessage.ModifyAsync($"Progress: {info.Description} [{new string('#', (int)(percentage / 10))}{new string('-', (int)(10 - percentage / 10))}] {newValue}/{info.MaxValue}");

        //    // Update the progress bar info
        //    info.CurrentValue = newValue;
        //    progressBarInfo[context.Channel.Id] = info;

        //    // Respond with acknowledgment message
        //    await context.EditResponseAsync(new DiscordWebhookBuilder()
        //        .WithContent($"Progress bar updated. Current value: {newValue}/{info.MaxValue}"));
        //}
    }

    public class CollectInfo
    {
        public DiscordUser User { get; set; }
        public long Amount { get; set; }
    }

    public class ProgressBar
    {
        public ulong MessageId { get; set; } // to update with
        public long CurrentValue { get; set; }
        public long MaxValue { get; set; }
        public string Goal { get; set; }
        public List<CollectInfo> Collected { get; set; }

        public ProgressBar(ulong messageId, long currentValue, long maxValue, string goal)
        {
            MessageId = messageId;
            CurrentValue = currentValue;
            MaxValue = maxValue;
            Goal = goal;
            Collected = new List<CollectInfo>();
        }
    }
}