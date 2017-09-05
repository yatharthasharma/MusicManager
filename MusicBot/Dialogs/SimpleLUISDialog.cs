using System;
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
        [LuisIntent("CreateTrack")]
        public async Task CreateTracks(IDialogContext context, LuisResult result)
        {
            // create new track
            string trackName = "";
            EntityRecommendation rec;
            if (result.TryFindEntity("trackName", out rec))
            {
                trackName = rec.Entity;
                Track newTrack = new Track(trackName);
                await context.PostAsync($"The track '{ trackName }' has been created.");
            }
            else
            {
                await context.PostAsync("Sorry, you did not provide a valid name for the new track.");
            }
            context.Wait(MessageReceived);
        }
        // create new artist
        [LuisIntent("CreateArtist")]
        public async Task CreateArtist(IDialogContext context, LuisResult result)
        {
            //await context.PostAsync("CreateArtist intent method start.");     // for testing
            string artistName = "";
            EntityRecommendation rec;
            if (result.TryFindEntity("artistName", out rec))
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
        // create new album associated with a specific artist
        // if the artist is present link the newly created album to that specific artist, otherwise create a new artist and link the album to that
        [LuisIntent("CreateAlbum")]
        public async Task CreateAlbum(IDialogContext context, LuisResult result)
        {
            string albumName = "";
            string artistName = "";
            EntityRecommendation getArtistName;
            EntityRecommendation getAlbumName;
            if (result.TryFindEntity("artistName", out getArtistName) && result.TryFindEntity("albumName", out getAlbumName))
            {
                artistName = getArtistName.Entity;
                albumName = getAlbumName.Entity;
                Album newAlbum = new Album(albumName, artistName);
                await context.PostAsync($"New album '{ albumName }' created by the artist ' {artistName} '");
            }
            else
            {
                await context.PostAsync($"Sorry, you did not provide valid names for the new album and/or artist.");
            }
            context.Wait(MessageReceived);
        }
        // if the statement doesn't match any of the criteria for methods
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"I have no idea what you are talking about, sorry!");
            context.Wait(MessageReceived);
        }
    }
}