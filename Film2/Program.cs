using System;
using System.Diagnostics;

namespace Film2

{
    internal class Program
    {
        static List<Film> filmek = new List<Film>();
        public static void Main(string[] args)
        {
            Fajlbeolvasas("filmadatbazis.csv");
            foreach (var item in filmek)
            {
                Console.WriteLine(item.Cim);
            }
            Feladat01();
            Feladat02();
            Feladat03();
            Feladat04();
        }

        private static void Fajlbeolvasas(string fajlnev)
        {
            using (StreamReader sr = new StreamReader(fajlnev))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    Film f = new Film(sor);
                    filmek.Add(f);
                }
            }
        }

        private static object GetAtlagHossz()
        {
            int osszHossz = 0;
            foreach (var item in filmek)
            {
                osszHossz += item.Hossz;
            }
            return osszHossz / filmek.Count;
        }

        private static void Feladat01()
        {
            Console.WriteLine($"1. Filmek átlagos hossza: {GetAtlagHossz()} perc.");
        }

        private static void Feladat02()
        {
            Film leghosszabbFilm = GetLeghosszabbFilm();
            Console.WriteLine($"A leghosszabb film: {leghosszabbFilm.Hossz} perc.");
        }

        private static Film GetLeghosszabbFilm()
        {
            Film leghosszabbFilm = filmek[0];
            for (int i = 1; i < filmek.Count; i++)
            {
                if (filmek[i].Hossz > leghosszabbFilm.Hossz)
                {
                    leghosszabbFilm = filmek[i];
                }
            }
            return leghosszabbFilm;
        }

        private static void Feladat03()
        {
            Console.WriteLine("Adjon meg egy film címet: ");
            string cim = Console.ReadLine();
            Film film = Filmkeres(cim);
            if (film == null)
            {
                Console.WriteLine("A megadott film nem található");
            }
            else
            {
                Console.WriteLine($"A megadott film {film.Hossz} perces.");
            }
        }

        private static Film Filmkeres(string cim)
        {
            int i = 0;
            while (i < filmek.Count && filmek[i].Cim != cim)
            {
                i++;
            }
            if (i < filmek.Count)
            {
                return filmek[i];
            }
            return null;
        }

        private static void Feladat04()
        {
            Console.WriteLine("Adja meg a keresendő részletet: ");
            string keresendo = Console.ReadLine();
            List<string> cimek = FilmReszKeres(keresendo);
            Console.WriteLine("A keresett részlet az alábbi filmek címében szerepel: ");
            foreach (var item in cimek)
            {
                Console.WriteLine("\t" + item);
            }
        }

        private static List<string> FilmReszKeres(string keresendo)
        {
            List<string> cimek = new List<string>();
            foreach (var item in filmek)
            {
                if (item.Cim.Contains(keresendo))
                {
                    cimek.Add(item.Cim);
                }
            }
            return cimek;
        }
    }
}
