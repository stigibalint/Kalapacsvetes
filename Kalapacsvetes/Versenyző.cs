using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalapacsvetes
{
    public class Versenyző
    {
        string nev;
        string csoport;
        string nemzetEsKod;
        double d1, d2, d3;

        public Versenyző(string nev, string csoport, string nemzetEsKod, double d1, double d2, double d3)
        {
            this.Nev = nev;
            this.Csoport = csoport;
            this.NemzetEsKod = nemzetEsKod;
            this.D1 = d1;
            this.D2 = d2;
            this.D3 = d3;
        }
        public Versenyző(string sor)
        {
            var adatok = sor.Split(';');
            Nev = adatok[0];
            Csoport =adatok[1];
            NemzetEsKod = adatok[2];
            D1 = ParseDobas(adatok[3]);
            D2 = ParseDobas(adatok[4]);
            D3 = ParseDobas(adatok[5]);
        }
        public double ParseDobas(string eredmeny)
        {
            switch (eredmeny)
            {
                case "X":
                    return -1.0;
                case "-":
                    return -2.0; 
                default:
                    return Convert.ToDouble(eredmeny);
            }
        }


        public double LegnagyobbDobas()
        {
            double[] dobások = { D1, D2, D3 };
            return dobások.Max();
        }

        public double Eredmény()
        {
            return LegnagyobbDobas();
        }

        public string Nemzet()
        {
            return NemzetEsKod.Split(' ')[0];
        }

        public string Kód()
        {
            return NemzetEsKod.Split(' ')[1].Trim('(', ')');
        }


        public string Nev { get => nev; set => nev = value; }
        public string Csoport { get => csoport; set => csoport = value; }
        public string NemzetEsKod { get => nemzetEsKod; set => nemzetEsKod = value; }
        public double D1 { get => d1; set => d1 = value; }
        public double D2 { get => d2; set => d2 = value; }
        public double D3 { get => d3; set => d3 = value; }
    }
}
