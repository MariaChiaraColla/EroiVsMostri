using EroiVsMostri.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Core.Entità
{
    public class Eroe : Personaggio
    {
        //proprietà
        public int Proprietario { get; set; }
        public int PuntiAccumulati { get; set; }

        //costruttori
        public Eroe()
        {
        }

        //metodi
        public override string ToString()
        {
            return ID +") "+Nome+": Livello = "+Livello+", Punti vita = "+PuntiVita+", Punti accumulati = "+PuntiAccumulati;
        }
    }
}
