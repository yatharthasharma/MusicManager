using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Music;

namespace MusicBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text.Contains("Add track album"))
            {
                Track x = new Track("Why");
                Album xx = new Album("Avril Lavigne 1.0");
                xx.AddTrack(x);
                await context.PostAsync($"The track {x} has been added to the album {xx}");
            }
            else
            { 
            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user
            await context.PostAsync($"You sent {activity.Text} which was {length} characters");
            }
            context.Wait(MessageReceivedAsync);
        }
    }
}