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
        public override void Attacco(Personaggio avversario)
        {
            if (avversario.PuntiVita <= 0)
            {
                //int puntiVinti = avversario.Livello.Livello * 10;
                //Console.WriteLine("Hai Vinto " + puntiVinti + " punti, il Mostro: " + avversario.Nome + " è stato sconfitto!");
                //PuntiAccumulati = PuntiAccumulati + puntiVinti;
            }
        }

        public bool Fuga(Personaggio avversario)
        {
            var rand = new Random();
            var probabilita = rand.Next(10);
            //successo fuga
            if (probabilita % 2 == 0)
            {
                //int puntiPersi = avversario.Livello.Livello * 5;
                //Console.WriteLine("Sei riuscito a fuggire, ma hai perso: " + puntiPersi + " punti.");
                return true;
            }   
            //insuccesso
            else 
                return false;
        }
    }
}
