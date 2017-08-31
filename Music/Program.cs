using System;

namespace Music
{
    class Program
    {
        static void Main(string[] args)
        {
            Track x = new Track("Complicated");
            Track y = new Track();
            Track z = new Track();
            Track xyz = new Track();
            Track xy = new Track();
            Track xx = new Track("Why");
            Artist avril = new Artist("avril");
            Album al = new Album("avril");
            al.AddTrack(x);
            al.AddTrack(xx);
            al.GetTrack();
            Console.WriteLine("Hello World!");
            Console.WriteLine("The album for x is: " + x.GetAlbum());
            Console.WriteLine("The artist for x is: " + x.GetArtist());
        }
    }
}
