using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Core.Entità
{
    public class PassaggioLivello
    {
        //proprietà
        public int Livello { get; set; }
        public int PuntiNecessari { get; set; }

        //Metodi
        public override string ToString()
        {
            return "Livello " + Livello + ": " + PuntiNecessari + " Punti necessari";
        }

    }
}
