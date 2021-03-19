using EroiVsMostri.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Core.Entità
{
    public class Mostro: Personaggio
    {
        //costruttori
        public Mostro() { }
        public Mostro(string nome, int classe, int arma)
        {
            Nome = nome;
            ClasseDiAppartenenza = classe;
            ArmaScelta = arma;
            IsEroe = false;
            Livello = 1;
            PuntiVita = 20;
        }
        //Metodi
        public override string ToString()
        {
            return ID + ") " + Nome + ", livello: "+ Livello;
        }

    }
}
