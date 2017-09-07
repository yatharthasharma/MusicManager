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
    /// <summary>
    /// Modelling this as Luis Model. Specifying App ID and Key to connect it with the AI.
    /// Specified intents and entities and trained the AI on luis.ai
    /// </summary>

    [LuisModel("278f3d20-64f5-4bc7-a448-af04f59d724b", "cb3e8b2547f1476d828672a3f840b64c")]
    [Serializable]
    public class SimpleLUISDialog : LuisDialog<object>
    {
        // create new track
        [LuisIntent("CreateTrack")]                 // intent declared on luis.ai along with the utterances for it. 
        public async Task CreateTracks(IDialogContext context, LuisResult result)       // linked this method with the intent specified above.
        {
            string trackName = "";
            if (result.TryFindEntity("trackName", out EntityRecommendation rec))    // first parameter specifies the entity. Second parameter helps link the entity to a field.
            {
                trackName = rec.Entity;
                Track newTrack = new Track(trackName);                              // using the skeleton code from Music project to create a new track
                await context.PostAsync($"The track '{ trackName }' has been created.");    // bot gives this as a reply to the user
            }
            else
            {
                await context.PostAsync("Sorry, you did not provide a valid name for the new track.");  // if the entity is not found
            }
            context.Wait(MessageReceived);      // wait for user response
        }
        // create new artist
        [LuisIntent("CreateArtist")]
        public async Task CreateArtist(IDialogContext context, LuisResult result)
        {
            string artistName = "";
            if (result.TryFindEntity("artistName", out EntityRecommendation rec))   // first parameter specifies the entity. Second parameter helps link the entity to a field.
            {
                artistName = rec.Entity;
                Artist currentArtist; // artistName is equals to the entity value
                if (Artist.IsArtistAvailable(artistName))
                {
                    await context.PostAsync($"The artist '{ artistName }' is already in the list of artists.");
                }
                else
                {
                    currentArtist = new Artist(artistName);
                    await context.PostAsync($"The artist '{ artistName }' has been created.");
                }
            }
            else
            {
                await context.PostAsync("Sorry, you did not provide a valid name for the new artist.");
            }
            context.Wait(MessageReceived);
        }
        // create new album associated with a specific artist
        // if the artist is present link the newly created album to that specific artist, otherwise create a new artist and link the album to that
        [LuisIntent("CreateAlbum")]
        public async Task CreateAlbum(IDialogContext context, LuisResult result)
        {
            string albumName = "";
            string artistName = "";
            if (result.TryFindEntity("artistName", out EntityRecommendation getArtistName) && result.TryFindEntity("albumName", out EntityRecommendation getAlbumName))
            {
                artistName = getArtistName.Entity;
                albumName = getAlbumName.Entity;
                Album newAlbum = new Album(albumName, artistName);                      // use Album class' constructor
                await context.PostAsync($"New album '{albumName}' created by the artist '{artistName}'");
            }
            else
            {
                await context.PostAsync($"Sorry, you did not provide valid names for the album and/or artist.");
            }
            context.Wait(MessageReceived);
        }
        // add track to album of a specific artist
        [LuisIntent("AddTrackToAlbum")]
        public async Task AddTrackToAlbum(IDialogContext context, LuisResult result)
        {
            string artistName = "";
            string trackName = "";
            string albumName = "";
            if (result.TryFindEntity("artistName", out EntityRecommendation rec) && result.TryFindEntity("trackName", out EntityRecommendation rex) && result.TryFindEntity("albumName", out EntityRecommendation reg))
            {
                artistName = rec.Entity;
                trackName = rex.Entity;
                albumName = reg.Entity;
                Artist currentArtist = null;
                // check if artist already present, if it is get the artist
                if (Artist.IsArtistAvailable(artistName))           
                {
                    foreach (Artist x in Artist.GetArtists())
                    {
                        if (artistName == x.GetName())
                        {
                            currentArtist = x;
                            break;
                        }
                    }
                }
                // if not create a new artist.
                else
                {
                    currentArtist = new Artist(artistName);
                }
                // check if the album specified by the user exists.
                if (currentArtist.IsAlbumAvailable(albumName))
                {
                    foreach (Album x in currentArtist.GetAlbums())                      // iterate over the current artist's list of albums
                    {
                        if (albumName == x.GetTitle())                                  // get the album which matches the albumName and add track to it
                        {
                            x.AddTrack(new Track(trackName));
                            break;
                        }
                    }
                }
                else
                // if album not found 
                {
                    currentArtist.GetAlbums().Add(new Album(albumName, artistName));    // create a new album in the list of albums of the current artist
                    foreach (Album x in currentArtist.GetAlbums())                      // iterate over the current artist's list of albums
                    {
                        if (albumName == x.GetTitle())                                  // get the album which matches the albumName and add track to it
                        {
                            x.AddTrack(new Track(trackName));
                            break;
                        }
                    }
                }
                await context.PostAsync($"The track '{ trackName }' has been created and added to the album '{albumName}' of artist '{artistName}'.");
            }
            else
            {
                await context.PostAsync("Sorry, you did not provide a valid names for artist/track/album.");
            }
            context.Wait(MessageReceived);
        }
        // get tracks associated with the specified artist
        [LuisIntent("GetTracksFromArtist")]
        public async Task GetTracksFromArtist(IDialogContext context, LuisResult result)
        {
            string artistName = "";
            if (result.TryFindEntity("artistName", out EntityRecommendation getArtistName))
            {
                artistName = getArtistName.Entity;
                Artist currentArtist = null;
                if (Artist.IsArtistAvailable(artistName))
                {
                    foreach (Artist x in Artist.GetArtists())
                    {
                        if (artistName == x.GetName())
                        {
                            currentArtist = x;
                            break;
                        }
                    }
                    string results = "";
                    foreach (Track x in currentArtist.GetTracks())
                    {
                        results += x.GetTitle();
                        results += ", ";
                    }
                    await context.PostAsync($"Artist { artistName }'s tracks are - {results}");
                }
                // if not create a new artist.
                else
                {
                    await context.PostAsync($"Sorry, there's no artist with this name.");
                }
            }
            else
            {
                await context.PostAsync($"Sorry, you did not provide a valid name for the artist.");
            }
            context.Wait(MessageReceived);
        }
        [LuisIntent("GetTracksFromAlbum")]
        public async Task GetTracksFromAlbum(IDialogContext context, LuisResult result)
        {
            string albumName = "";
            string artistName = "";
            if (result.TryFindEntity("artistName", out EntityRecommendation getArtistName) && result.TryFindEntity("albumName", out EntityRecommendation getAlbumName))
            {
                albumName = getAlbumName.Entity;
                artistName = getArtistName.Entity;
                Artist currentArtist = null;
                Album currentAlbum = null;
                if (Artist.IsArtistAvailable(artistName))
                {
                    foreach (Artist x in Artist.GetArtists())
                    {
                        if (artistName == x.GetName())
                        {
                            currentArtist = x;
                            break;
                        }
                    }
                }
                else
                {
                    await context.PostAsync($"Sorry, there's no artist with this name.");
                }
                // check if album available
                if (currentArtist.IsAlbumAvailable(albumName))
                {
                    foreach (Album x in currentArtist.GetAlbums())                      // iterate over the current artist's list of albums
                    {
                        if (albumName == x.GetTitle())                                  // get the album which matches the albumName and add track to it
                        {
                            currentAlbum = x;
                            break;
                        }
                    }
                }
                else
                // if album not found 
                {
                    await context.PostAsync($"Sorry, there's no album with this name.");
                }
                string results = "";
                foreach (Track x in currentAlbum.GetTracks())
                {
                    results += x.GetTitle();
                    results += ", ";
                }
                await context.PostAsync($"Tracks are - {results} for album '{albumName}' of artist '{artistName}'");
            }
            else
            {
                await context.PostAsync($"Name of the artist and/or album is incorrect.");
            }
            context.Wait(MessageReceived);
        }
        // to get help with list of commands
        [LuisIntent("GetAlbumsFromArtist")]
        public async Task GetAlbumsFromArtist(IDialogContext context, LuisResult result)
        {
            string artistName = "";
            if (result.TryFindEntity("artistName", out EntityRecommendation getArtistName))
            {
                artistName = getArtistName.Entity;
                Artist currentArtist = null;
                if (Artist.IsArtistAvailable(artistName))
                {
                    foreach (Artist x in Artist.GetArtists())
                    {
                        if (artistName == x.GetName())
                        {
                            currentArtist = x;
                            break;
                        }
                    }
                    string results = "";
                    foreach (Album x in currentArtist.GetAlbums())
                    {
                        results += x.GetTitle();
                        results += ", ";
                    }
                    await context.PostAsync($"Artist { artistName }'s albums are - {results}");
                }
                // if not.
                else
                {
                    await context.PostAsync($"Sorry, there's no artist with this name.");
                }
            }
            else
            {
                await context.PostAsync($"Sorry, you did not provide a valid name for the artist.");
            }
            context.Wait(MessageReceived);
        }
        [LuisIntent("Help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"To add track: 'add track 'trackname'', To add artist: 'add artist 'artistname'', To add new album to artist: 'add album 'albumname' to artist 'artistname'', To add new track to album: 'add track 'trackname' to album 'albumname' of artist 'artistname'', To get list of tracks of an artist: 'get tracks of artist 'artistname'', To see commands again: 'help'");
            context.Wait(MessageReceived);
        }
        // if the statement doesn't match any of the criteria for methods
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"I have no idea what you are talking about, sorry! Please try again or type in 'help' to see the list of commands available at this moment.");
            context.Wait(MessageReceived);
        }
    }
}