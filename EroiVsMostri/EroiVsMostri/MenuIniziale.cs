using EroiVsMostri.Core.Entità;
using EroiVsMostri.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace EroiVsMostri
{
    public class MenuIniziale
    {
        public void ShowMenu(Giocatore giocatore)
        {
            //service provider
            var serviceProvider = DIConfig.Configurazione();
            ClassiServices classeService = serviceProvider.GetService<ClassiServices>();
            ArmiServices armaService = serviceProvider.GetService<ArmiServices>();
            LivelliServices livelloService = serviceProvider.GetService<LivelliServices>();
            GiocatoriServices giocatoreService = serviceProvider.GetService<GiocatoriServices>();
            EroiServices eroeService = serviceProvider.GetService<EroiServices>();
            MostriServices mostroService = serviceProvider.GetService<MostriServices>();

            //creo il menu
            Console.WriteLine("1- Crea un nuovo Eroe,");
            Console.WriteLine("2- Elimina un Eroe,");
            Console.WriteLine("3- Continua una partita con un Eroe già esistente,");
            Console.WriteLine("4- Esci dal gioco.");
            Console.WriteLine();
            int comando = 0;
            bool ok = false;

            //controlli sull' input
            while(ok == false)
            {
                try
                {
                    Console.WriteLine("Scegli un'azione: ");
                    comando = Convert.ToInt32(Console.ReadLine());
                    if (comando > 0 && comando < 5)
                        ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Inserisci un numero!");
                }
            }

            //chiamo le funzione per le varie voci del menù
            while(comando != 4)
            {
                switch (comando)
                {
                    case 1:
                        Eroe eroe = eroeService.CreateEroe(giocatore);
                        Gioco gioco = new Gioco();
                        gioco.StartGioco(giocatore, eroe);
                        break;
                    case 2:
                        eroeService.GetAllEroi();
                        eroeService.DeleteEroe(0);
                        break;
                    case 3:
                        eroeService.GetAllEroi();
                        Eroe eroe1 = eroeService.GetEroeByID();
                        Gioco gioco1 = new Gioco();
                        gioco1.StartGioco(giocatore, eroe1);
                        break;
                }
            }
          
            
        }
    }
}
