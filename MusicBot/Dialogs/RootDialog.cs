using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Music;
using System.Threading;

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
            var message = await result;
            if (activity.Text.Contains("wowo"))
            {
                Track x = new Track("Why");
                Album xx = new Album("Avril Lavigne 1.0");
                xx.AddTrack(x);
                await context.PostAsync($"The track {x} has been added to the album {xx}");
            }
            context.Wait(MessageReceivedAsync);
        }
    }
}