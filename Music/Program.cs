using System;

namespace Music
{
    class Program
    {
        static void Main(string[] args)
        {
            Track x = new Track("Complicated");
            Track y = new Track("Wish you were here");
            Track z = new Track("When you're gone");
            Track xyz = new Track();
            Track xy = new Track();
            Track xx = new Track("Why");
            Artist avril = new Artist("avril");
            Album al = new Album("avrilsfirst","avril");
            al.AddTrack(x);
            al.AddTrack(xx);
            al.GetTrack();
            Album a2 = new Album("avrilssecond", "avril");
            a2.AddTrack(y);
            a2.AddTrack(z);
            a2.GetTrack();
            Console.WriteLine("The album for x is: " + x.GetAlbum());
            Console.WriteLine("The artist for x is: " + x.GetArtist());
            Console.WriteLine();
            Console.WriteLine("The album for xx is: " + xx.GetAlbum());
            Console.WriteLine("The artist for xx is: " + xx.GetArtist());
            Console.WriteLine();
            Console.WriteLine("The album for y is: " + y.GetAlbum());
            Console.WriteLine("The artist for y is: " + y.GetArtist());
            Console.WriteLine();
            Console.WriteLine("The album for z is: " + z.GetAlbum());
            Console.WriteLine("The artist for z is: " + z.GetArtist());
        }
    }
}
