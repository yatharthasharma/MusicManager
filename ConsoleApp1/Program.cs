using System;

namespace Music
{
    /// <summary>
    /// This class only used during the early stages of development for testing purposes.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // adding new tracks.
            Track track1 = new Track("Complicated");
            Track track2 = new Track("Wish you were here");
            Track track3 = new Track("When you're gone");
            Track track4 = new Track("firework");
            Track track5 = new Track("Why");

            // adding artists.
            Artist avril = new Artist("avril");
            Artist katy = new Artist("KATY");

            // adding albums using the two parameter constructor.
            Album album1 = new Album("Avril 1.0", "Avril");
            Album album2 = new Album("Katy", "Katy Perry");
            Album album3 = new Album("Avril 2.0", "Avril");

            // adding tracks to albums and then checking (by printing out to console) if the application puts in the correct tracks in the correct albums.
            album2.AddTrack(track4);
            album1.AddTrack(track1);
            album1.AddTrack(track5);
            album1.GetTrack();
            album3.AddTrack(track2);
            album3.AddTrack(track3);
            album3.GetTrack();
            Console.WriteLine("The album for track4 is: " + track4.GetAlbumName());
            Console.WriteLine("The artist for track4 is: " + track4.GetArtistName());
            Console.WriteLine();
            Console.WriteLine("The album for track1 is: " + track1.GetAlbumName());
            Console.WriteLine("The artist for track1 is: " + track1.GetArtistName());
            Console.WriteLine();
            Console.WriteLine("The album for track5 is: " + track5.GetAlbumName());
            Console.WriteLine("The artist for track5 is: " + track5.GetArtistName());
            Console.WriteLine();
            Console.WriteLine("The album for track2 is: " + track2.GetAlbumName());
            Console.WriteLine("The artist for track2 is: " + track2.GetArtistName());
            Console.WriteLine();
            Console.WriteLine("The album for track3 is: " + track3.GetAlbumName());
            Console.WriteLine("The artist for track3 is: " + track3.GetArtistName());
        }
    }
}
