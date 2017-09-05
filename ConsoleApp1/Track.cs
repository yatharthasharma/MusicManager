using System;
using System.Collections.Generic;
using System.Text;

namespace Music
{
    // skeleton class used to create tracks, get and set artist/album name.
    public class Track
    {
        private string title;       // track name
        private Artist artist;      // track artist
        private Album album;        // track album
        // make a track with the constructor
        public Track(string title)
        {
            this.title = title;
        }
        public string GetTitle()
        {
            return title;
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public string GetArtistName()
        {
            return artist.GetName();
        }
        public string GetAlbumName()
        {
            return album.GetTitle();
        }
        public void SetAlbum(Album album)
        {
             this.album = album;
        }
        public void SetArtist(Artist artist)
        {
            this.artist = artist;
        }
    }
}