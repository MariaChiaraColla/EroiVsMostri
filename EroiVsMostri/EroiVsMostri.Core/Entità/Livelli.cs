using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Core.Entità
{
    public class Livelli
    {
        //proprietà
        public int Livello { get; set; }
        public int PuntiVita { get; set; }

        //costruttori
        public Livelli()
        {
        }
        public Livelli(int l, int p)
        {
            Livello = l;
            PuntiVita = p;
        }

        //Metodi
        public override string ToString()
        {
            return "Livello "+ Livello+": "+PuntiVita+" Punti vita";
        }

    }
}
