using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Services
{
    public class GiocatoriServices
    {
        private IGiocatoreRepository _repo;
        public GiocatoriServices(IGiocatoreRepository repo)
        {
            _repo = repo;
        }

        //GET ALL
        //restituisce un IEnurable
        //se i = 1 voglio stampare a schermo i risultati
        //altrimenti non li stampo
        public IEnumerable<Giocatore> GetAllGiocatori(int i)
        {
            IEnumerable<Giocatore> Giocatori = _repo.GetAll();

            if (i == 1)
            {
                foreach (var giocatore in Giocatori)
                {
                    Console.WriteLine(giocatore);
                }
            }

            return Giocatori;
        }

        //GET BY ID,
        //controllo se esiste
        public Giocatore GetGiocatoreByID()
        {
            Giocatore giocatore = new Giocatore();
            int id = 0;
            Console.WriteLine("Inserisci l'id del giocatore che vuoi scegliere:");
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
                giocatore = _repo.GetByID(id);
            }
            catch (Exception)
            {
                Console.WriteLine("Inserisci un numero!");
            }

            while (giocatore.ID == 0)
            {
                Console.WriteLine("Inserisci un id valido:");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                    giocatore = _repo.GetByID(id);
                }
                catch (Exception)
                {

                    Console.WriteLine("Inserisci un numero!");
                }
            }
            Console.WriteLine("Benvenuto/a! " + giocatore.Nome);
            return giocatore;
        }

        //INSERT
        public Giocatore CreateGiocatore(string nome)
        {
            Giocatore giocatore = new Giocatore()
            {
                Nome = nome
            };

            Giocatore giocatore1 = _repo.Create(giocatore);

            return giocatore1;
        }

        //DELETE
        //controllo se l'id dato esiste e se è un numero, se si cancello, altrimenti errore
        public void DeleteGiocatore()
        {
            Giocatore giocatore = new Giocatore();
            int id = 0;
 
            while (giocatore.ID == 0)
            {
                try
                {
                    Console.WriteLine("Inserisci l'id del eroe che vuoi eleminare:");
                    id = Convert.ToInt32(Console.ReadLine());
                    giocatore = _repo.GetByID(id);
                }
                catch (Exception)
                {

                    Console.WriteLine("Inserisci un numero valido!");
                }
            }
            bool elimina = _repo.Delete(giocatore);

            if (elimina == false)
                Console.WriteLine("Errore, giocatore non presente.");
        }

        //UPDATE
        //controllo se esiste l'id, se si richiedo tutti i dati del giocatore per poterlo modificare
        public void UpdateGiocatore()
        {
            Console.WriteLine("Modifica giocatore: ");
            Giocatore giocatore = new Giocatore();

            //richiesta id e nuovi parametri
            int id = 0;

            while (giocatore.ID == 0)
            {
                try
                {
                    Console.WriteLine("Inserisci l'id del eroe che vuoi modificare:");
                    id = Convert.ToInt32(Console.ReadLine());
                    giocatore = _repo.GetByID(id);
                }
                catch (Exception)
                {

                    Console.WriteLine("Inserisci un numero valido!");
                }
            }
            //nuovo nome
            _repo.Update(giocatore);
        }

        //GET BY ID,
        //controllo se esiste
        public Giocatore GetGiocatoreByName(string name)
        {
            Giocatore giocatore = _repo.GetByName(name);
            if(giocatore.ID == 0)
            {
                CreateGiocatore(name);
                giocatore = GetGiocatoreByName(name);
            }

            return giocatore;
        }

    }
}
