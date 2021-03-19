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
            Console.WriteLine("BENVENUTO AD EROI VS MOSTRI!");

            ////GIOCATORE
            //Console.WriteLine("Nome del giocatore: ");
            //string nomeGiocatore = Console.ReadLine();
            //Giocatore giocatore = new Giocatore(nomeGiocatore);
            ////provo a stampare il giocatore
            //Console.WriteLine(giocatore);

            ////CLASSE
            //////definisco classe mostro
            ////Console.WriteLine("Nome del mostro: ");
            ////string nomeMostro = Console.ReadLine();
            ////Classe mostro = new Classe(nomeMostro,false);
            //////provo a stampare la classe mostro
            ////Console.WriteLine(mostro);

            //////definisco classe eroe
            ////Console.WriteLine("Nome dell'eroe: ");
            ////string nomeEroe = Console.ReadLine();
            ////Classe eroe = new Classe(nomeEroe, true);
            //////provo a stampare la classe eroe
            ////Console.WriteLine(eroe);

            ////LIVELLO
            //Livelli l = new Livelli(1, 20);
            //Console.WriteLine(l);

            var serviceProvider = DIConfig.Configurazione();
            ClassiServices classeService = serviceProvider.GetService<ClassiServices>();
            ArmiServices armaService = serviceProvider.GetService<ArmiServices>();
            LivelliServices livelloService = serviceProvider.GetService<LivelliServices>();
            GiocatoriServices giocatoreService = serviceProvider.GetService<GiocatoriServices>();
            EroiServices eroeService = serviceProvider.GetService<EroiServices>();
            MostriServices mostroService = serviceProvider.GetService<MostriServices>();

            //var classi = classeService.GetAllClasse();
            //foreach (var c in classi)
            //{
            //    Console.WriteLine(c);
            //}
            //Console.WriteLine("By id");
            //var CLASSE = classeService.GetClassByID();

            //var armi = armaService.GetAllArmi();
            //foreach (var c in armi)
            //{
            //    Console.WriteLine(c);
            //}
            //var a = armaService.GetArmaByID();

            //var livelli = livelloService.GetAllLivelli();
            //foreach (var l in livelli)
            //{
            //    Console.WriteLine(l);
            //}

            var giocatori = giocatoreService.GetAllGiocatori();
            var giocatore = giocatoreService.GetGiocatoreByID();

            //////giocatoreService.CreateGiocatore();
            ////bool s = giocatoreService.DeleteGiocatore();
            ////Console.WriteLine(s);
            ////giocatoreService.UpdateGiocatore();

            ////eroeService.GetAllEroi();
            ////Eroe e = eroeService.GetEroeByID();
            ////e.PuntiAccumulati = 0;
            ////eroeService.UpdateEroe(e);
            ////Console.WriteLine(e);

            //eroeService.CreateEroe(giocatore);

            //mostroService.GetAllMostri();
            //mostroService.GetMostroByID(1);
            //mostroService.CreateMostro();
            //mostroService.DeleteMostro();

            //eroeService.GetAllEroi();
            //Eroe eroe = eroeService.GetEroeByID();
            //Turno turno = new Turno();
            //turno.StartTurno(eroe);


            MenuIniziale menu = new MenuIniziale();
            menu.ShowMenu(giocatore);
        }
    }
}
