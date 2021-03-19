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
        public long? TempoDiGioco { get; set; }

        //costruttori
        public Eroe()
        {
        }
        public Eroe(string nome, int classe, int arma)
        {
            Nome = nome;
            ClasseDiAppartenenza = classe;
            ArmaScelta = arma;
            Livello = 1;
            PuntiVita = 20;
            PuntiAccumulati = 0;
            TempoDiGioco = 0;
            IsEroe = true;
        }

        //metodi
        public override string ToString()
        {
            return ID +") "+Nome+": Livello = "+Livello+", Punti vita = "+PuntiVita+", Punti accumulati = "+PuntiAccumulati;
        }
    }
}
