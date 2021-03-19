using EroiVsMostri.Core.Entità;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using EroiVsMostri.Services;
using System.Diagnostics;

namespace EroiVsMostri
{
    public class Gioco
    {
        public int StartGioco(Giocatore giocatore, Eroe eroe)
        {
            //service provider
            var serviceProvider = DIConfig.Configurazione();
            EroiServices eroeService = serviceProvider.GetService<EroiServices>();

            //Faccio partire il timer per misurare il tempo di gioco per eroe
            Stopwatch timer = new Stopwatch();
            timer.Start();

            int risultatoTurno = 1;
            int continua;

            while (risultatoTurno != 2)
            {
                //inizio il turno
                Turno turno = new Turno();
                risultatoTurno = turno.StartTurno(eroe);

                //controllo se l'eroe è morto, nel caso salvo e torno al menù principale
                if (risultatoTurno == 2)
                {
                    //fermo il timer
                    timer.Stop();
                    //Console.WriteLine("Timer: " + timer.ElapsedMilliseconds);
                    TimeSpan tempo = new TimeSpan(timer.ElapsedMilliseconds * 10000);
                    //Console.WriteLine("Tempo : " + tempo);
                    eroe.TempoDiGioco = eroe.TempoDiGioco + timer.ElapsedMilliseconds;

                    //aggiorno l'eroe
                    eroeService.UpdateEroe(eroe);
                    return 0;
                }

                //dopo ogni turno mostro un menù con: continua? si o no
                continua = MenuDopoOgniTurno();

                //se decide di non continuare salvo i progressi dell'eroe nel db e torno al menu
                if (continua == 2)
                {
                    //fermo il timer
                    timer.Stop();
                    //Console.WriteLine("Timer: " + timer.ElapsedMilliseconds);
                    
                    //salvo nel db
                    eroe.TempoDiGioco = eroe.TempoDiGioco + timer.ElapsedMilliseconds;
                    eroeService.UpdateEroe(eroe);
                    return 0;
                }

                //se decide di tornare al menu senza salvare
                if(continua == 3)
                {
                    //fermo il timer
                    timer.Stop();
                    return 0;
                }
            }
            return 0;
        }

        public int MenuDopoOgniTurno()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine("Vuoi continuare?");
            Console.WriteLine("1- si, affronta il prossimo mostro");
            Console.WriteLine("2- no, salva i progessi e torna al menù principale");
            Console.WriteLine("3- no, torna al menù senza salvare");
            Console.ResetColor();

            int risposta = 0;
            bool ok = false;

            //controlli sull' input
            while (ok == false)
            {
                try
                {
                    Console.WriteLine("Scegli una risposta: ");
                    risposta = Convert.ToInt32(Console.ReadLine());
                    if (risposta > 0 && risposta < 4)
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
