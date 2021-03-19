using EroiVsMostri.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Core.Entità
{
    public class Mostro: Personaggio
    {
        //Metodi
        public override string ToString()
        {
            return ID + ") " + Nome + ", livello: "+ Livello;
        }

    }
}
