using EroiVsMostri.Core.Entità;
using EroiVsMostri.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Diagnostics;

namespace EroiVsMostri
{
    public class MenuIniziale
    {
        //controllo che tipo di giocatore è (admin o utente) e gli mostro il menù giusto
        public void ShowMenu(Giocatore giocatore)
        {
            //se è utente
            if (giocatore.Admin == false)
            {
                ShowMenuUtente(giocatore);
            }
            else
                ShowMenuAdmin(giocatore);
        }

        //menu dell'utente
        public void ShowMenuUtente(Giocatore giocatore)
        {
            //service provider
            var serviceProvider = DIConfig.Configurazione();
            ClassiServices classeService = serviceProvider.GetService<ClassiServices>();
            ArmiServices armaService = serviceProvider.GetService<ArmiServices>();
            LivelliServices livelloService = serviceProvider.GetService<LivelliServices>();
            GiocatoriServices giocatoreService = serviceProvider.GetService<GiocatoriServices>();
            EroiServices eroeService = serviceProvider.GetService<EroiServices>();
            MostriServices mostroService = serviceProvider.GetService<MostriServices>();

            int comando = 0;
            bool ok = false;

            while(comando != 4)
            {
                //stampo il menu e controllo l'input
                while (ok == false)
                {
                    try
                    {
                        //creo il menu
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine();
                        Console.WriteLine("------- Menù Principale -------");
                        Console.WriteLine("1- Crea un nuovo Eroe,");
                        Console.WriteLine("2- Elimina un Eroe,");
                        Console.WriteLine("3- Continua una partita con un Eroe già esistente,");
                        Console.WriteLine("4- Esci dal gioco.");
                        Console.WriteLine();
                        Console.WriteLine("Scegli un'azione: ");
                        Console.ResetColor();
                        //controlli
                        comando = Convert.ToInt32(Console.ReadLine());
                        if (comando > 0 && comando < 5)
                            ok = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Inserisci un numero!");
                    }
                }
                //chiamo le funzione per le varie voci del menù, ognivolta resetto comando e ok per tornare dentro
                //i due while e ripetere le operazioni finchè non dice di uscire (comando = 4)
                switch (comando)
                {
                    case 1:
                        Eroe eroe = eroeService.CreateEroe(giocatore);
                        if(eroe.ID == 0)
                        {
                            comando = 0;
                            ok = false;
                            break;
                        }
                        Gioco gioco = new Gioco();
                        gioco.StartGioco(giocatore, eroe);
                        comando = 0;
                        ok = false;
                        break;
                    case 2:
                        List<Eroe> Eroi = (List<Eroe>)eroeService.GetAllEroiByGiocatore(giocatore,1);
                        if (Eroi.Count() == 0)
                        {
                            Console.WriteLine("Nessun Eroe presente!");
                            comando = 0;
                            ok = false;
                            break;
                        }
                        Console.WriteLine();
                        eroeService.DeleteEroe(0);
                        comando = 0;
                        ok = false;
                        break;
                    case 3:
                        List<Eroe> Eroi1 = (List<Eroe>)eroeService.GetAllEroiByGiocatore(giocatore,1);
                        if (Eroi1.Count() == 0)
                        {
                            Console.WriteLine("Nessun Eroe presente!");
                            comando = 0;
                            ok = false;
                            break;
                        }
                        Console.WriteLine();
                        Eroe eroe1 = eroeService.GetEroeByID();
                        Gioco gioco1 = new Gioco();
                        int partita = gioco1.StartGioco(giocatore, eroe1);
                        comando = 0;
                        ok = false;
                        break;
                    case 0:
                        break;
                }
            }
        }

        //menu dell'admin
        public void ShowMenuAdmin(Giocatore giocatore)
        {
            //service provider
            var serviceProvider = DIConfig.Configurazione();
            ClassiServices classeService = serviceProvider.GetService<ClassiServices>();
            ArmiServices armaService = serviceProvider.GetService<ArmiServices>();
            LivelliServices livelloService = serviceProvider.GetService<LivelliServices>();
            GiocatoriServices giocatoreService = serviceProvider.GetService<GiocatoriServices>();
            EroiServices eroeService = serviceProvider.GetService<EroiServices>();
            MostriServices mostroService = serviceProvider.GetService<MostriServices>();

            int comando = 0;
            bool ok = false;

            while (comando != 7)
            {
                //stampo il menu e controllo l'input
                while (ok == false)
                {
                    try
                    {
                        //creo il menu
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine();
                        Console.WriteLine("------- Menù Principale -------");
                        Console.WriteLine("1- Crea un nuovo Eroe,");
                        Console.WriteLine("2- Elimina un Eroe,");
                        Console.WriteLine("3- Continua una partita con un Eroe già esistente,");
                        Console.WriteLine("4- Crea Mostro,");
                        Console.WriteLine("5- Elimina un Mostro,");
                        Console.WriteLine("6- Guarda le Classifiche globali,");
                        Console.WriteLine("7- Esci dal gioco.");
                        Console.WriteLine();
                        Console.WriteLine("Scegli un'azione: ");
                        Console.ResetColor();
                        //controlli
                        comando = Convert.ToInt32(Console.ReadLine());
                        if (comando > 0 && comando < 8)
                            ok = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Inserisci un numero!");
                    }
                }
                //chiamo le funzione per le varie voci del menù, ognivolta resetto comando e ok per tornare dentro
                //i due while e ripetere le operazioni finchè non dice di uscire (comando = 4)
                switch (comando)
                {
                    case 1:
                        Eroe eroe = eroeService.CreateEroe(giocatore);
                        if (eroe.ID == 0)
                        {
                            comando = 0;
                            ok = false;
                            break;
                        }
                        Gioco gioco = new Gioco();
                        gioco.StartGioco(giocatore, eroe);
                        comando = 0;
                        ok = false;
                        break;
                    case 2:
                        List<Eroe> Eroi = (List<Eroe>)eroeService.GetAllEroiByGiocatore(giocatore,1);
                        if (Eroi.Count() == 0)
                        {
                            Console.WriteLine("Nessun Eroe presente!");
                            comando = 0;
                            ok = false;
                            break;
                        }
                        Console.WriteLine();
                        eroeService.DeleteEroe(0);
                        comando = 0;
                        ok = false;
                        break;
                    case 3:
                        List<Eroe> Eroi1 = (List<Eroe>)eroeService.GetAllEroiByGiocatore(giocatore,1);
                        if (Eroi1.Count() == 0)
                        {
                            Console.WriteLine("Nessun Eroe presente!");
                            comando = 0;
                            ok = false;
                            break;
                        }
                        Console.WriteLine();
                        Eroe eroe1 = eroeService.GetEroeByID();
                        Gioco gioco1 = new Gioco();
                        int partita = gioco1.StartGioco(giocatore, eroe1);
                        comando = 0;
                        ok = false;
                        break;
                    case 4:
                        mostroService.CreateMostro();
                        comando = 0;
                        ok = false;
                        break;
                    case 5:
                        List<Mostro> Mostri = (List<Mostro>)mostroService.GetAllMostri();
                        if (Mostri.Count() == 0)
                        {
                            Console.WriteLine("Nessun Mostro presente!");
                            comando = 0;
                            ok = false;
                            break;
                        }
                        Console.WriteLine();
                        mostroService.DeleteMostro();
                        comando = 0;
                        ok = false;
                        break;
                    case 6:
                        Console.WriteLine("Statistiche:");
                        Statistiche();
                        comando = 0;
                        ok = false;
                        break;
                    case 0:
                        break;
                }
            }
        }


        //statistiche, tempo e punti totali
        public void Statistiche()
        {
            //service provider
            var serviceProvider = DIConfig.Configurazione();
            GiocatoriServices giocatoreService = serviceProvider.GetService<GiocatoriServices>();
            EroiServices eroeService = serviceProvider.GetService<EroiServices>();
            MostriServices mostroService = serviceProvider.GetService<MostriServices>();

            //mostro l'elenco dei giocatori
            List<Giocatore> giocatori = (List<Giocatore>)giocatoreService.GetAllGiocatori(0);

            //per ogni giocatore devo stampare la lista degli eroi con il loro tempo di gioco totale e i punti
            foreach(var g in giocatori)
            {
                Console.WriteLine(g.Nome);

                List<Eroe> eroi = (List<Eroe>)eroeService.GetAllEroiByGiocatore(g,0);
                foreach(var e in eroi)
                {
                    if (e == null) break;
                    decimal? tempo = (decimal)e.TempoDiGioco/60000;
                    Console.WriteLine("   - "+e.Nome+": "+e.PuntiAccumulati+" punti accumulati, "+tempo+" minuti giocati");
                }
            }

        }



    }
}
