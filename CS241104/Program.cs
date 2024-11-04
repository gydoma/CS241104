using CS241104;
using System.Text;

List<Versenyzok> versenyzok = [];
using StreamReader sr = new("..\\..\\..\\res\\forras.txt", Encoding.UTF8);
while (!sr.EndOfStream)
{
    versenyzok.Add(new(sr.ReadLine()));
}
Console.WriteLine($"Versenyzők száma: {versenyzok.Count}");

var f11 = versenyzok.Count(v => v.Kategoria == "elit");
Console.WriteLine($"Elit kategóriában: {f11} versenyző");
var f12 = versenyzok.Count(v => v.Kategoria == "elit junior");
Console.WriteLine($"Elit Juniro Kategóriában: {f12} versenyzo");
var f13 = versenyzok.Count(v => v.Kategoria == "25-29");
Console.WriteLine($"25-29 Kategóriában: {f13} versenyző");
Console.WriteLine("");

var f21 = versenyzok.Where(v => !v.Nem).Average(v => DateTime.Now.Year - v.Szul);
Console.WriteLine($"Női versenyzők átlagéletkora: {f21:0.00}");
var f22 = versenyzok.Where(v => v.Nem).Average(v => DateTime.Now.Year - v.Szul);
Console.WriteLine($"Férfi versenyzők átlagéletkora: {f22:0.00}");
var f23 = versenyzok.Average(v => DateTime.Now.Year - v.Szul);
Console.WriteLine("");

var f31 = versenyzok.Sum(v => v.Versenyidok["kerekpar"].TotalHours);
Console.WriteLine($"A versenyzők kerékpározással töltött összideje: {f31:0.00} óra");
var f32 = versenyzok.Sum(v => v.Versenyidok["futas"].TotalHours);
Console.WriteLine($"A versenyzők futással töltött összideje: {f32:0.00} óra");
var f33 = versenyzok.Sum(v => v.Versenyidok["uszas"].TotalHours);
Console.WriteLine($"A versenyzők úszással töltött összideje: {f33:0.00} óra");
Console.WriteLine("");

var f41 = versenyzok.Where(v => v.Kategoria == "elit junior").Average(v => v.Versenyidok["uszas"].TotalMinutes);
Console.WriteLine($"Átlagos úszási idő elit junior kategóriában: {f41:0.00} perc");
var f42 = versenyzok.Where(v => v.Kategoria == "20-24").Average(v => v.Versenyidok["uszas"].TotalMinutes);
Console.WriteLine($"Átlagos úszási idő 20-24es kategóriában: {f42:0.00} perc");
var f43 = versenyzok.Where(v => v.Kategoria == "elit").Average(v => v.Versenyidok["uszas"].TotalMinutes);
Console.WriteLine($"Átlagos úszási idő elit kategóriában: {f43:0.00} perc");
Console.WriteLine("");

var f51 = versenyzok.Where(v => v.Nem).MinBy(v => v.OsszIdosec);
Console.WriteLine($"Férfi győztes: {f51}");
var f52 = versenyzok.Where(v => v.Nem).MinBy(v => v.OsszIdosec);
Console.WriteLine($"Női győztes: {f52}");
Console.WriteLine($"Férfi győztes: {f51}");
Console.WriteLine("");


var f61 = versenyzok.GroupBy(v => v.Kategoria).OrderBy(g => g.Key);
Console.WriteLine("Versenyt befejező versenyzők száma:");
foreach (var grp in f61)
{
	Console.WriteLine($"{grp.Key,11}: {grp.Count(),2} fő, avg depó: {grp.Average(v => v.Versenyidok["depo1"].TotalMinutes + v.Versenyidok["depo2"].TotalMinutes):0.000} sec");
}
var f62 = versenyzok.GroupBy(v => v.Nem).OrderBy(g => g.Key);
Console.WriteLine("Versenyt befejező versenyzők száma:");
foreach (var grp in f62)
{
    if(grp.Key)
    {
        Console.WriteLine($"Férfi: {grp.Count(),2} fő");
    }
    else
    {
        Console.WriteLine($"Nő:    {grp.Count(),2} fő");
    }
}
Console.WriteLine("Versenyt befejező versenyzők száma:");
foreach (var grp in f61)
{
    Console.WriteLine($"{grp.Key,11}: {grp.Count(),2} fő, avg depó: {grp.Average(v => v.Versenyidok["depo1"].TotalMinutes + v.Versenyidok["depo2"].TotalMinutes):0.000} sec");
}




/*

------- versenyzők száma 'elit junior' kategóriában
------- férfi versenyzők átlagéletkora
------- a versenyzők futással töltött összideje órában. 2tj-ig kerekítve
------- átlagos úszási idő 20-24 kategóriában
------- női győztes (legrövidebb összidő)
- nemenként a versenyt befejezők száma

------- versenyzők száma '25-29' korkategóriában
------- versenyzők átlagéletkora
------- a versenyzők úszással töltött összideje órában. 2tj-ig kerekítve
- átlagos úszási idő elit kategóriában
- férfi győztes (legrövidebb összidő)
- korkategóriánként a versenyt befejezők száma

 */