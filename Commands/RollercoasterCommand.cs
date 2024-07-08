using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionDiscordBot.Commands
{
    public class RollercoasterCommand : ApplicationCommandModule
    {
        private async Task MoveUserToChannel(DiscordMember member, DiscordChannel channel)
        {
            await member.PlaceInAsync(channel);
        }

        [SlashCommand("Rollercoaster", "Put player in a rollercoaster")]
        public async Task Rollercoaster(InteractionContext context, [Option("user", "User to put in a rollercoaster")] DiscordUser user)
        {
            await context.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

            try
            {
                var guild = context.Guild;

                List<ulong> channelIds = new List<ulong>()
                {
                    1161596221773844512,
                    1161595905951158303,
                    1161596178052415488,
                    1161635117366775888,
                    1161659391699849356,
                    1161595763604860968
                };

                var member = await guild.GetMemberAsync(user.Id);

                var voiceState = member?.VoiceState;
                if (voiceState?.Channel != null)
                {
                    foreach (ulong channelId in channelIds)
                    {
                        var channel = guild.GetChannel(channelId);
                        await MoveUserToChannel(member, channel);
                        await Task.Delay(100);
                    }

                    await context.EditResponseAsync(new DiscordWebhookBuilder()
                        .WithContent($"Moved {user.Username} through the rollercoaster! 🎢"));
                }
                else
                {
                    await context.EditResponseAsync(new DiscordWebhookBuilder()
                        .WithContent($"Sorry, {user.Username} is not in a voice channel!"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                await context.EditResponseAsync(new DiscordWebhookBuilder()
                    .WithContent("An error occurred while processing the command. Please try again later."));
            }
        }
    }
}
