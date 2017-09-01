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
            Track xyz = new Track("firework");
            Track xy = new Track();
            Track xx = new Track("Why");
            Artist avril = new Artist("avril");
            Artist katy = new Artist("KATY");
            Album al = new Album("avrilsfirst","avril");
            Album a3 = new Album("perrybro", "perry");
            a3.AddTrack(xyz);
            al.AddTrack(x);
            al.AddTrack(xx);
            al.GetTrack();
            Album a2 = new Album("avrilssecond", "avril");
            a2.AddTrack(y);
            a2.AddTrack(z);
            a2.GetTrack();
            Console.WriteLine("The album for xyz is: " + xyz.GetAlbum());
            Console.WriteLine("The artist for xyz is: " + xyz.GetArtist());
            Console.WriteLine();
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
