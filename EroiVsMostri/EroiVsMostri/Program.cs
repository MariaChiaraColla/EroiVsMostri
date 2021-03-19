using EroiVsMostri.Core.Entità;
using EroiVsMostri.Services;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace EroiVsMostri
{
    class Program
    {
        static void Main(string[] args)
        {
            //stampa titolo
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("BENVENUTO/A AD EROI VS MOSTRI!");
            Console.WriteLine();
            Console.ResetColor();

            //service provider
            var serviceProvider = DIConfig.Configurazione();
            ClassiServices classeService = serviceProvider.GetService<ClassiServices>();
            ArmiServices armaService = serviceProvider.GetService<ArmiServices>();
            LivelliServices livelloService = serviceProvider.GetService<LivelliServices>();
            GiocatoriServices giocatoreService = serviceProvider.GetService<GiocatoriServices>();
            EroiServices eroeService = serviceProvider.GetService<EroiServices>();
            MostriServices mostroService = serviceProvider.GetService<MostriServices>();

            //chidi il nome al giocatore, se esiste usa quello altrimenti crea un nuovo giocatore           
            Console.WriteLine("Iserisci il tuo nome: ");
            string nomeGiocatore = Console.ReadLine();
            Giocatore giocatore = giocatoreService.GetGiocatoreByName(nomeGiocatore);

            //richiamo il menu iniziale
            MenuIniziale menu = new MenuIniziale();
            menu.ShowMenu(giocatore);
        }
    }
}
