using EroiVsMostri.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Abstract;

namespace EroiVsMostri
{
    public class Turno
    {
        //gestisco tutti i turni di una partita
        //se ritorna 1 = l'eroe ha vinto o è scappato
        //se ritorna 2 = ha vinto il mostro
        //0 errore
        public int StartTurno(Eroe eroe)
        {
            //service provider
            var serviceProvider = DIConfig.Configurazione();
            EroiServices eroeService = serviceProvider.GetService<EroiServices>();
            MostriServices mostroService = serviceProvider.GetService<MostriServices>();

            //creo un mostro con livello <= ad eroe
            Mostro mostro = mostroService.GetMostroByID(eroe);
            int i = 1;

            //inizio lo scontro
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine("INIZIO SCONTRO!");
            Console.WriteLine("------ " + eroe.Nome + ", livello: " + eroe.Livello + "   Vs   " + mostro.Nome + ", livello: " + mostro.Livello + " ------");
            Console.ResetColor();

            //turno eroe
            while (eroe.PuntiVita>0 && mostro.PuntiVita>0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Turno " + i + ":");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Tocca a " + eroe.Nome);
                Console.ResetColor();
                Console.WriteLine();
                int risultatoAzione = 0;
                int azioneEroe = MenuAzioniTurno();

                switch (azioneEroe)
                {
                    case 1:
                        risultatoAzione = Attacco(eroe, mostro);
                        break;
                    case 2:
                        bool fuga = Fuga(eroe, mostro);
                        if (fuga == true)
                        {
                            Console.WriteLine("Scontro finito.");
                            return 1;
                        }
                        break;
                    case 0:
                        Console.WriteLine("Errore, ripeti turno");
                        i--;
                        break;
                }
                //controllo se l'eroe ha vinto, nel caso esco
                if (risultatoAzione == 2)
                {
                    VittoriaPunti(eroe, mostro);
                    return 1;
                }

                //turno mostro
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Tocca a " + mostro.Nome + ": Atacca!");
                Console.ResetColor();
                risultatoAzione = Attacco(mostro, eroe);
                i++;
                //controllo se il mostro ha vinto, se si cancello l'eroe dal db ed esco
                if(risultatoAzione == 3)
                {
                    eroeService.DeleteEroe(eroe.ID);
                    return 2;
                }
            }
            return 0;
        }

        //menu delle azione che l'eroe può fare per ogni turno: attacco, fuga
        public int MenuAzioniTurno()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Azioni Possibili:");
            Console.WriteLine("1) Attacca");
            Console.WriteLine("2) Tenta la fuga");
            Console.WriteLine();
            Console.ResetColor();
            bool ok = false;
            int azione = 0;
            while(ok == false)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Scegli un azione: ");
                    Console.ResetColor();
                    azione = Convert.ToInt32(Console.ReadLine());
                    if (azione == 1 || azione == 2) ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Scegli un numero valido");
                }
            }
            return azione;
        }

        //l'attacco va sempre a buon fine e toglie dei punti vita all'avversario
        //se ritrona 1 nessuno dei due è morto
        //se ritorna 2 ha vinto l'eroe
        //se ritorna 3 ha vinto il mostro
        //0 errore
        public int Attacco(Personaggio attaccante, Personaggio avversario)
        {
            int i = 0;
            //devo recuperare i punti danno dell'arma del personaggio
            //service proveder
            var serviceProvider = DIConfig.Configurazione();
            ArmiServices armaService = serviceProvider.GetService<ArmiServices>();
            EroiServices eroeService = serviceProvider.GetService<EroiServices>();
            //recupero l'arma dell'attaccate
            var arma = armaService.GetArmaByID(attaccante.ArmaScelta);

            //tolgo i punti danno dell' arma ai punti vita dell'avversario
            avversario.PuntiVita = avversario.PuntiVita - arma.PuntiDanno;
            //stampo i punti vita dopo l'attacco, solo se nessuno dei due è morto
            if (attaccante.IsEroe == true)
            {
                if (attaccante.PuntiVita > 0 && avversario.PuntiVita > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Punti vita: " + attaccante.Nome + "= " + attaccante.PuntiVita + " e " + avversario.Nome + "= " + avversario.PuntiVita);
                    i = 1;
                    Console.ResetColor();
                }
            }
            else 
            {
                if (attaccante.PuntiVita > 0 && avversario.PuntiVita > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Punti vita: " + avversario.Nome + "= " + avversario.PuntiVita + " e " + attaccante.Nome + "= " + attaccante.PuntiVita);
                    i = 1;
                    Console.ResetColor();
                }   
            }

            //controllo se dopo l'attacco uno dei due è morto
            if (attaccante.PuntiVita <= 0)
            {
                //se l'attaccante morto è l'eroe, scrivo che è morto e lo cancello dal db
                if(attaccante.IsEroe == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Oh no il tuo eroe è morto! sei stato sconfitto da "+avversario.Nome);
                    Console.ResetColor();
                    i = 3;
                }
                //se l'attacante moerto è il mostro, scrivo che ha vinto l'eroe
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulazioni hai vinto! hai sconfitto "+attaccante.Nome);
                    Console.ResetColor();
                    i = 2;
                }
            }
            if (avversario.PuntiVita <= 0)
            {
                //se l'avversario morto è l'eroe, scrivo che è morto e lo cancello dal db
                if (avversario.IsEroe == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Oh no il tuo eroe è morto! sei stato sconfitto da " + attaccante.Nome);
                    Console.ResetColor();
                    i = 3;
                }
                //se l'avversario morto è il mostro, scrivo che ha vinto l'eroe
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulazioni hai vinto! hai sconfitto " + avversario.Nome);
                    Console.ResetColor();
                    i = 2;
                }
            }
            return i;
        }

        //l'eroe può tentare la fuga, se va a buon fine finisce lo scontro e perde dei punti, altrimenti
        //deve continuare lo scontro
        public bool Fuga(Eroe eroe, Mostro mostro)
        {
            var rand = new Random();
            var probabilita = rand.Next(10);

            //successo fuga
            if (probabilita % 2 == 0)
            {
                int puntiPersi = mostro.Livello * 5;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sei riuscito a fuggire, ma hai perso: " + puntiPersi + " punti.");
                Console.ResetColor();
                eroe.PuntiAccumulati = eroe.PuntiAccumulati - puntiPersi;
                Console.WriteLine("Totale punti accumulati: " + eroe.PuntiAccumulati);
                return true;
            }
            //insuccesso
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Non sei riuscito a fuggire!");
                Console.ResetColor();
                return false;
            }
                
            
        }

        //se l'eroe vince lo scontro gli assegno dei punti e controllo se è passato di livello o se ha vinto
        public void VittoriaPunti(Eroe eroe, Mostro mostro)
        {
            int puntiVinti = mostro.Livello * 10;
            eroe.PuntiAccumulati = eroe.PuntiAccumulati + puntiVinti;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hai vinto " + puntiVinti + " punti!, Punti totali: " + eroe.PuntiAccumulati);
            Console.ResetColor();

            //controllo se l'eroe è passato di livello 
            PassaggioDiLivello(eroe);

            //controllo se HA VINTO
            if(eroe.PuntiAccumulati == 200)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("CONGRATULAZIONI HAI VINTO IL GIOCO!!!");
                Console.ResetColor();
            }
        }

        //passaggio di livello e vittoria
        public void PassaggioDiLivello(Eroe eroe)
        {
            //recupero dal db tutti i livelli con i punti necessari e i punti vita corrispondenti
            var serviceProvider = DIConfig.Configurazione();
            LivelliServices livelloService = serviceProvider.GetService<LivelliServices>();
            PassaggiLivelliServices passaggioLiv = serviceProvider.GetService<PassaggiLivelliServices>();
            EroiServices eroeService = serviceProvider.GetService<EroiServices>();

            List<Livelli> LivelliPV = (List<Livelli>)livelloService.GetAllLivelli(0);
            List<PassaggioLivello> LivelliPA = (List<PassaggioLivello>)passaggioLiv.GetAllPassaggiLivelli();

            foreach(var liv in LivelliPA)
            {
                if(eroe.PuntiAccumulati == liv.PuntiNecessari)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    eroe.Livello = liv.Livello;
                    Console.WriteLine("Congratulazioni sei passato al livello " + eroe.Livello);
                    //recupero dalla tabella livello i punti vita corrispondenti per darli all'eroe
                    Livelli livello = livelloService.GetLivelloByID(liv.Livello);
                    eroe.PuntiVita = livello.PuntiVita;
                    Console.WriteLine("I tuoi punti vita sono stati rispristinati a " + eroe.PuntiVita);
                    Console.ResetColor();
                }
            } 
        }



    }
}
