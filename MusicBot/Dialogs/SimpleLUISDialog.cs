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
                artistName = rec.Entity;                                            // artistName is equals to the entity value
                Artist newArtist = new Artist(artistName);                          // using the skeleton code from Music project to create a new artist
                await context.PostAsync($"The artist '{ artistName }' has been created.");  // bot gives this as a reply to the user
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
                // create a new artist with the given name
                Artist newArtist = new Artist(artistName);
                // using currentArtist because the new artist might have merged into an existing artist of the same name because its been added to a hashset of all artists.
                Artist currentArtist = Artist.GetArtistByName(artistName);
                // copying contents of hashset of albums of current artist to an array so that we can iterate through easily
                int count = 0;
                Album[] albums = new Album[currentArtist.GetAlbums().Count];
                currentArtist.GetAlbums().CopyTo(albums);
                // alternative method to check the array of albums for the album specified by the user. Ignore because I haven't added comments to it just yet.
                /*for (int i = 0; i < albums.Length; i++)
                {
                    if (i != albums.Length - 1)
                    {
                        if (albums[i].GetTitle() == albumName)
                        {
                            albums[i].AddTrack(new Track(trackName));
                            break;
                        }
                    }
                    else
                    {
                        if (albums[i].GetTitle() == albumName)
                        {
                            albums[i].AddTrack(new Track(trackName));
                            break;
                        }
                        else
                        {
                            currentArtist.GetAlbums().Add(new Album(albumName, artistName));
                            foreach (Album x in currentArtist.GetAlbums())
                            {
                                if (x.GetTitle() == albumName)
                                {
                                    x.AddTrack(new Track(trackName));
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }*/
                // checking the array of albums if the album specified by user already exists or not? and taking the appropriate action
                while ((count < currentArtist.GetAlbums().Count - 1) && (albumName != albums[count].GetTitle()))        // while elements are still present and names of albums are not equal
                {
                    count++;
                }
                if (count > 0 && albumName != albums[count].GetTitle())             // if number of elements in the list of albums is more than 0 and name of albums are not equal.
                {
                    currentArtist.GetAlbums().Add(new Album(albumName, artistName));    // then add new album and add the track to it.
                    foreach (Album x in currentArtist.GetAlbums())
                    {
                        if (x.GetTitle() == albumName)
                        {
                            x.AddTrack(new Track(trackName));
                            break;
                        }
                    }

                }
                else
                {
                    if (count > 0)                                                  // else if number of elements more than zero
                    {
                        foreach (Album x in currentArtist.GetAlbums())
                        {
                            if (x.GetTitle() == albumName)                          // add new track if given name and artist name from the list are same
                            {
                                x.AddTrack(new Track(trackName));
                                break;
                            }
                        }
                    }
                    else
                    {
                        currentArtist.GetAlbums().Add(new Album(albumName, artistName));    // if number of elements zero then create a new album.
                        foreach (Album x in currentArtist.GetAlbums())
                        {
                            if (x.GetTitle() == albumName)                          // add new track if given name and artist name from the list are same
                            {
                                x.AddTrack(new Track(trackName));
                                break;
                            }
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
                // a bit of same logic like last method - convert the hashset to an array for iteration purposes. Then check if number of elements more than zero and if the names are equal
                // to confirm if the artist is present in the hashset contating all the artist objects or not.
                int count = 0;
                Artist[] tempArray = new Artist[Artist.GetArtists().Count];
                Artist.GetArtists().CopyTo(tempArray);
                while (count < Artist.GetArtists().Count - 1 && artistName != tempArray[count].GetName())
                {
                    count++;
                }
                if (count > 0 && artistName != tempArray[count].GetName())
                {
                    await context.PostAsync($"Sorry, there's no artist with this name.1");
                }
                else if (count > 0 && artistName == tempArray[count].GetName())
                {
                    string results = "";
                    foreach (Track x in tempArray[count].GetTracks())
                    {
                        results += x.GetTitle();
                        results += ", ";
                    }

                    await context.PostAsync($"Artist { artistName }'s tracks are - {results}");
                }
                else if (count <= 0 && artistName != tempArray[count].GetName())
                {
                    await context.PostAsync($"Sorry, there's no artist with this name.2");
                }
                else
                {
                    string results = "";
                    foreach (Track x in tempArray[count].GetTracks())
                    {
                        results += x.GetTitle();
                        results += ", ";
                    }

                    await context.PostAsync($"Artist { artistName }'s tracks are - {results}");
                }

            }
            else
            {
                await context.PostAsync($"Sorry, you did not provide a valid name for the artist.");
            }
            context.Wait(MessageReceived);
        }
        // to get help with list of commands
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