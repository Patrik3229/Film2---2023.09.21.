using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film2
{
    internal class Film
    {
        private int helyezes;
        private string cim;
        private int ev;
        private string hossz;
        private List<string> mufaj;

        public Film(int helyezes, string cim, int ev, string hossz, List<string> mufaj)
        {
            this.helyezes = helyezes;
            this.cim = cim;
            this.ev = ev;
            this.hossz = hossz;
            this.mufaj = mufaj;
        }

        public Film(string sor)
        {
            string[] adatok = sor.Split(';');
            string sorszam = int.Parse(adatok[0].Substring(0, adatok[0].Length-1));
            string cim = adatok[1];
            int ev = int.Parse(adatok[2]);
            string hosszusag = adatok[3];
            string[] m = adatok[4].Split(',');
            List<string> mufajok = new List<string>();
            foreach (var s in m)
            {
                mufajok.Add(s.Trim());
            }
            Film f = new Film(sorszam, cim, ev, hosszusag, mufajok);
            filmek.Add(f);
        }

        public int Helyezes { get => helyezes; set => helyezes = value; }
        public string Cim { get => cim; set => cim = value; }
        public int Ev { get => ev; set => ev = value; }
        public string Hossz { get => hossz; set => hossz = value; }
        public List<string> Mufaj { get => mufaj; set => mufaj = value; }
    }
}
