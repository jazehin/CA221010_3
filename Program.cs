using System.Drawing;

namespace CA221010_3
{
    public class Allat { }
    public class Tita : Allat, ILoggable, ITudKoszonni
    {
        private int _x, _y;
        public ConsoleColor Szin { get; set; }
        public string Nev { get; set; }

        public Point Pozicio { 
            get => new Point(_x, _y); 
            set
            {
                _x = value.X;
                _y = value.Y;
            }
        }

        public string GetLogEntry()
        {
            return $"macska neve: {Nev} \n" +
                   $"macska színe: {Szin} \n" +
                   $"pozíció: [{Pozicio.X};{Pozicio.Y}] \n";
        }
        public void Mozog(Point valtozas)
        {
            Pozicio = new Point();
        }
        public void Koszon(string nev)
        {
            Console.WriteLine($"Szia, {nev}!");
        }

        public void Nyavog() 
        {
            Console.ForegroundColor = Szin;
            Console.WriteLine("Mijau");
            Console.ResetColor();
        }
    }
    public class Vaza : ILoggable
    {
        public string Anyag { get; set; }
        public bool Torott { get; set; } = false;
        public Point Pozicio { get; set; }

        public string GetLogEntry()
        {
            return $"anyag: {Anyag} \n" +
                   $"torott: {Torott} \n" +
                   $"pozíció: [{Pozicio.X};{Pozicio.Y}] \n";
        }
    }
    public interface ILoggable
    {
        public Point Pozicio { get; set; }

        public string GetLogEntry();
    }
    public interface ITudKoszonni
    {
        public void Koszon(string nev);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Vaza v1 = new()
            {
                Anyag = "agyag",
                Torott = true,
            };
            Vaza v2 = new() { Anyag = "kerámia" };
            Tita t1 = new() { Szin = ConsoleColor.Cyan, Nev = "Bálint" };
            Tita t2 = new() { Szin = ConsoleColor.Magenta, Nev = "Nem" };

            List<ILoggable> dolgok = new() { v1, v2, t1, t2 };
            foreach (var item in dolgok)
            {
                Console.WriteLine(item.GetLogEntry());
                if (item is Tita) (item as Tita).Koszon("Béla");
            }
        }
    }
}