namespace CS241104;
internal class Versenyzok
{
    public string Nev { get; set; }
    public int Szul { get; set; }
    public string Rajtszam { get; set; }
    public bool Nem { get; set; }
    public string Kategoria{ get; set; }
    public Dictionary<string,TimeSpan> Versenyidok { get; set; }
    public override string ToString() => $"[{Rajtszam}] {Nev} ({(Nem ? "Férfi":"Nő")}, {Kategoria})";

    public int OsszIdosec => (int)Versenyidok.Values.Sum(v => v.TotalSeconds);

    public Versenyzok(string sor)
    {
        string[] adatok = sor.Split(';');
        Nev = adatok[0];
        Szul = int.Parse(adatok[1]);
        Rajtszam = adatok[2];
        Nem = adatok[3] == "f";
        Kategoria = adatok[4];
        Versenyidok = new()
        {
            { "uszas", TimeSpan.Parse(adatok[5]) },
            { "depo1", TimeSpan.Parse(adatok[6]) },
            { "kerekpar", TimeSpan.Parse(adatok[7]) },
            { "depo2", TimeSpan.Parse(adatok[8]) },
            { "futas", TimeSpan.Parse(adatok[9]) }
        };
    }


}
/*
 2014-es Keszthely Triatlon verseny sprint távjának eredményeit kell
feldolgoznod. Az forras.txt állomány sorai a versenyt befejező versenyzők adatait és az általuk elért időeredményeket tartalmazzák pontosvesszőkkel elválasztva.

pl:
Nagy Máté;1996;4;f;18-19;00:12:47;00:00:34;00:31:40;00:00:26;00:17:42

Az első adat a versenyző neve
A második adat a versenyző születésének éve.
A harmadik szám a versenyző rajtszáma.
A negyedik adat a neme (n = nő, f = férfi).
Az ötödik adat a versenyző életkor szerinti kategóriáját határozza meg.
(A kategóriák: 16-17, 18-19, 20-24, 25-29, 30-34, 35-39, 40-44,
45-49, 50-54, elit, elit junior).
Majd a következő öt időadat a versenyen mért időeredmények, melyek sorban a következők (óra:perc:másodperc formátumban):
	úszás ideje,
	első depóban töltött idő,
	kerékpározás ideje,
	második depóban töltött idő,
	futás ideje.

A versenyt az a versenyző nyeri, akinek a legkisebb az öt idő összege

- hozz létre egy osztályt egy persenyző adatainak reprezentálására
- to-string override, ami tartalmazza a versenyző adatait
- olvasd be a file tartalmát egy objektumokat tartalmazó kollekcióba
- írd ki a konzolra, hogy hány versenyző fejezte be a versenyt

LINQ függvények alkalmazásával határozza határozza meg ís írja ki a konzolképernyére az alábbiakat:

- versenyzők száma 'elit' kategóriában
- női versenyzők átlagéletkora
- a versenyzők kerékpározással töltött összideje órában. 2tj-ig kerekítve
- átlagos úszási idő elit junior kategóriában
- férfi győztes (legrövidebb összidő)
- korkategóriánként a versenyt befejezők száma

+ korkategóriánként az átlag depóban töltött idő
 */