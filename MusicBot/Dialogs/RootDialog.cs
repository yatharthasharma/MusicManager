using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Music;
using System.Threading;

/// <summary>
/// This class was just used for testing purposes during the early stages of development - not used in the actual implementation of the bot.
/// </summary>
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
        /// <summary>
        /// This method uses a hardcoded string just for testing purposes - type the hardcoded string in the chat window to see if the bot 
        /// gives the appropriate output (according to the code).
        /// </summary>
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