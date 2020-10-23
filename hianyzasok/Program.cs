using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hianyzasok
{
    class Program
    {
        static List<Adatok> adatok = new List<Adatok>();
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("naplo.txt"))
            {
                int jelennap = 0;
                int jelenhonap = 0;
                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();
                    string[] r = row.Split(' ');
                    if (r[0] == "#")
                    {
                        jelenhonap = int.Parse(r[1]);
                        jelennap = int.Parse(r[2]);
                    }
                    else
                    {
                        string nev = r[0] + " " + r[1];
                        adatok.Add(new Adatok
                        {
                            Hianyzasok = r[2],
                            Honap = jelenhonap,
                            Nap = jelennap,
                            Nev = nev
                        });
                    }
                }
            }

            //2.feladat
            Console.WriteLine("2.Feladat");
            Console.WriteLine("A naplóban {0} bejegyzés van!", adatok.Count);

            //3.feladat
            Console.WriteLine("3.Feladat");
            int igazolt = 0;
            int igazolatlan = 0;

            for (int i = 0; i < adatok.Count; i++)
            {
                for (int g = 0; g < adatok[i].Hianyzasok.Length; g++)
                {
                    if (adatok[i].Hianyzasok[g] == 'X')
                    {
                        igazolt++;
                    }
                    if (adatok[i].Hianyzasok[g] == 'I')
                    {
                        igazolatlan++;
                    }
                }
            }
            Console.WriteLine("Igazolt hianyzasok száma {0}, az igazolatlanlanoké {1} óra", igazolt, igazolatlan);

            //4.feladat
            //fgv.

            //5.feladat
            Console.WriteLine("5.feladat");

            Console.Write("a hónap sorszáma=");
            int behonap = Convert.ToInt32(Console.ReadLine());
            Console.Write("a nap sorszáma=");
            int benap = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Azon a napon {0} volt!",hetnapja(behonap, benap));

            //6.feladat
            Console.WriteLine("6.feladat");

            Console.Write("a nap neve=");
            string benev = Console.ReadLine();
            Console.Write("a óra sorszáma=");
            int beora = Convert.ToInt32(Console.ReadLine());

            int db = 0;

            for (int i = 0; i < adatok.Count; i++)
            {
                if (hetnapja(adatok[i].Honap, adatok[i].Nap) == benev)
                {
                    if (adatok[i].Hianyzasok[beora-1] == 'X' || adatok[i].Hianyzasok[beora - 1] == 'I')
                    {
                        db++;
                    }
                }

            }
            Console.WriteLine("Ekkor összesen {0} óra hianyzas történt.",db);

            //7.feladat
            Console.WriteLine("7.Feladat");
            Dictionary<string, int> hianyzasok = new Dictionary<string, int>();
            for (int i = 0; i < adatok.Count; i++)
            {
                if (hianyzasok.ContainsKey(adatok[i].Nev))
                {
                    hianyzasok[adatok[i].Nev]+= adatok[i].HianyzasDarab();
                }
                else
                {
                    hianyzasok.Add(adatok[i].Nev, adatok[i].HianyzasDarab());
                }
            }

            int max = 0;
            foreach (var i in hianyzasok)
            {
                if (i.Value > max)
                {
                    max = i.Value;
                }
            }
            Console.Write("A legtöbbet hiányzó tanulók: ");
            foreach (var i in hianyzasok)
            {
                if (i.Value == max)
                {
                    Console.Write(" " + i.Key);
                }
            }

            Console.ReadKey();
        }
        static string hetnapja(int honap, int nap)
        {
            string[] napnev = new string[] { "vasarnap", "hetfo", "kedd", "szerda", "csutortok", "pentek", "szombat"};
            int[] napszam = new[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 335 };
            int napsorszam = (napszam[honap - 1] + nap) % 7;
            return napnev[napsorszam];
        }
    }
}
