using Kalapacsvetes;
using System.IO;
using System.Linq;
using System.Text;

List<Versenyző> versenyzoAdatok = new List<Versenyző>();

try
{
    File.ReadAllLines("Selejtezo2012.txt").Skip(1).ToList().ForEach(adatok => versenyzoAdatok.Add(new Versenyző(adatok)));
}
catch (IOException e)
{
    Console.WriteLine($"Hiba történt a fájl olvasása közben: {e.Message}");
}
Console.WriteLine($"5. feladat: Versenyzők száma a selejtezőben: {versenyzoAdatok.Count} fő");
int tovabbjutok = versenyzoAdatok.Count(v => v.D1 > 78 || v.D2 > 78);
Console.WriteLine($"6. feladat: 78,00 méter feletti eredménnyel továbbjutott: {tovabbjutok}");

Versenyző legjobbEredményVersenyző = versenyzoAdatok.OrderByDescending(v => v.LegnagyobbDobas()).First();


Console.WriteLine($"9. feladat: A selejtező nyertese:");
Console.WriteLine($"\tNév: {legjobbEredményVersenyző.Nev}");
Console.WriteLine($"\tCsoport: {legjobbEredményVersenyző.Csoport}");
Console.WriteLine($"\tNemzet és kód: {legjobbEredményVersenyző.NemzetEsKod}");
Console.WriteLine($"\tLegjobb eredmény: {legjobbEredményVersenyző.LegnagyobbDobas()}");



using (StreamWriter file = new StreamWriter("Dontos2012.txt", false, Encoding.UTF8))
{
    file.WriteLine("Név;Csoport;Nemzet és kód;D1;D2;D3");
    int szamol = 1;
    for (int i = 0; i < 12 && i < versenyzoAdatok.Count; i++)
    {
        Versenyző elsoTizenketto = versenyzoAdatok.OrderByDescending(v => v.LegnagyobbDobas()).ToList()[i];
        file.WriteLine($"{szamol};{elsoTizenketto.Nev};{elsoTizenketto.Csoport};{elsoTizenketto.NemzetEsKod};{elsoTizenketto.D1};{elsoTizenketto.D2};{elsoTizenketto.D3}");
        szamol++;
    }
}

Console.WriteLine("A Dontos2012.txt fájl létrehozva az első 12 versenyző adataival.");

Console.ReadLine(); 
