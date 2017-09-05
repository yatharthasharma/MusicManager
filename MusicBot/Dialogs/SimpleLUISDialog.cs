using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System.Threading.Tasks;
using Music;
/// <summary>
/// This class gets the intent from LUIS AI and uses the following methods to perform appropriate operations.
/// </summary>
namespace MusicBot
{
    [LuisModel("278f3d20-64f5-4bc7-a448-af04f59d724b", "cb3e8b2547f1476d828672a3f840b64c")]
    [Serializable]
    public class SimpleLUISDialog : LuisDialog<object>
    {
        [LuisIntent("GetTracks")]
        public async Task GetTracks(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I havhashdabshdbahsbdut, sorry!");
            context.Wait(MessageReceived);
        }
        [LuisIntent("CreateArtist")]
        public async Task CreateArtist(IDialogContext context, LuisResult result)
        {
            //await context.PostAsync("CreateArtist intent method start.");     // for testing
            string artistName;
            EntityRecommendation rec;
            if (result.TryFindEntity("ArtistName", out rec))
            {
                artistName = rec.Entity;
                Artist newArtist = new Artist(artistName);
                await context.PostAsync($"The artist '{ artistName }' has been created.");
            }
            else
            {
                await context.PostAsync("Sorry, you did not provide a valid name for the new artist.");
            }
            //await context.PostAsync("CreateArtist intent method end.");       // for testing
            context.Wait(MessageReceived);
        }

        [LuisIntent("CreateAlbum")]
        public async Task CreateAlbum(IDialogContext context, LuisResult result)
        {
            string albumName = "";
            EntityRecommendation rec;
            if (result.TryFindEntity("AlbumName", out rec))
            {
                albumName = rec.Entity;
                Album newAlbum = new Album(albumName);
                await context.PostAsync($"The album '{ albumName }' has been created.");
            }
            else
            {
                await context.PostAsync($"Sorry, you did not provide a valid name for the new album.");
            }
            context.Wait(MessageReceived);
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"I have no idea what you are talking about, sorry!");
            context.Wait(MessageReceived);
        }
    }
}