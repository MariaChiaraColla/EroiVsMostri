using EroiVsMostri.Core.Entità;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri
{
    public class Gioco
    {
        public void StartGioco(Giocatore giocatore, Eroe eroe)
        {
            int risultatoTurno = 1;

            while (risultatoTurno != 2)
            {
                //inizio il turno
                Turno turno = new Turno();
                risultatoTurno = turno.StartTurno(eroe);
                //dopo ogni turno mostro un menù con: continua? si o no
                int continua = MenuDopoOgniTurno();
                if (continua == 2)
                {
                    Console.WriteLine("Ciao!");
                    break;
                }
            }
            
        }

        public int MenuDopoOgniTurno()
        {
            Console.WriteLine("Vuoi continuare?");
            Console.WriteLine("1- si");
            Console.WriteLine("2- no");

            int risposta = 0;
            bool ok = false;

            //controlli sull' input
            while (ok == false)
            {
                try
                {
                    Console.WriteLine("Scegli una risposta: ");
                    risposta = Convert.ToInt32(Console.ReadLine());
                    if (risposta > 0 && risposta < 3)
                        ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Inserisci un numero!");
                }
            }
            return risposta;
        }
    }
}
