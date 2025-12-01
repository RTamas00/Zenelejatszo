using System;
using System.Collections.Generic;

namespace Zenelejatszo
{
    internal class Program
    {
        
        class Zene
        {
            public string Cim;
            public string Eloado;
            public string Mufaj;
            public double HosszPerc;  

            public override string ToString()
            {
                return $"{Cim} - {Eloado} | {Mufaj} | {HosszPerc} perc";
            }
        }

        static void Main(string[] args)
        {
            List<Zene> zenek = new List<Zene>();

            string fajleleres = "C:\\Zene\\playlist.txt"; 
            StreamReader sr = new StreamReader(fajleleres); 
            List<int> szamok = new List<int>();
            string sor = "";
            while ((sor = sr.ReadLine()) != null)
            {
                szamok.AddRange(
                    sor.Split(",")
                            .Select(s => int.Parse(s.Trim()))
                            );
            }
            Console.WriteLine("beolvasott lista elemei: " + string.Join(";", zenek));

            
            zenek.Add(new Zene { Cim = "Shape of You", Eloado = "Ed Sheeran", Mufaj = "Pop", HosszPerc = 4.1 });
            zenek.Add(new Zene { Cim = "Numb", Eloado = "Linkin Park", Mufaj = "Rock", HosszPerc = 3.0 });
            zenek.Add(new Zene { Cim = "Blinding Lights", Eloado = "The Weeknd", Mufaj = "Pop", HosszPerc = 3.6 });

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Zenelejátszó Menü =====");
                Console.WriteLine("0 - Kilépés");
                Console.WriteLine("1 - Zeneszámok listázása");
                Console.WriteLine("2 - Keresés cím szerint");
                Console.WriteLine("3 - POP műfajú zenék");
                Console.WriteLine("4 - 3,5 percnél hosszabb zenék");
                Console.WriteLine("5 - Új zene hozzáadása");
                Console.WriteLine("6 - Zene törlése");
                Console.WriteLine("7 - Zene módosítása");
                Console.Write("\nVálasztás: ");

                string valasztas = Console.ReadLine();

                switch (valasztas)
                {
                    case "0":
                        return;

                    case "1":  
                        Console.Clear();
                        int i = 0;
                        foreach (var z in zenek)
                            Console.WriteLine($"{i++}. {z}");
                        break;

                    case "2":  
                        Console.Clear();
                        Console.Write("Add meg a cím részletét: ");
                        string keres = Console.ReadLine().ToLower();
                        foreach (var z in zenek)
                        {
                            if (z.Cim.ToLower().Contains(keres))
                                Console.WriteLine(z);
                        }
                        break;

                    case "3": 
                        Console.Clear();
                        foreach (var z in zenek)
                        {
                            if (z.Mufaj.ToLower() == "pop")
                                Console.WriteLine(z);
                        }
                        break;

        }
    }
}
