using System.IO;


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


          List<Zene> zenek = new List<Zene>();


string fajleleres = "C:\\Zene\\playlist.txt"; 

if (File.Exists(fajleleres))
{
    string[] sorok = File.ReadAllLines(fajleleres);

    foreach (var sor in sorok)
    {
        if (string.IsNullOrWhiteSpace(sor)) continue;

        string[] adatok = sor.Split(';'); 
        if (adatok.Length != 4) continue;

        Zene z = new Zene();
        z.Cim = adatok[0];
        z.Eloado = adatok[1];
        z.Mufaj = adatok[2];

        if (double.TryParse(adatok[3], out double hossz))
            z.HosszPerc = hossz;
        else
            z.HosszPerc = 0;

        zenek.Add(z);
    }
}
else
{
    Console.WriteLine($"A fájl nem található: {fajleleres}");
}


Console.WriteLine("Zeneszámok listázása:");
int i = 0;
foreach (var z in zenek)
{
    Console.WriteLine($"{i++}. {z}");
}
