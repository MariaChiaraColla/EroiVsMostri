using EroiVsMostri.ADORepository;
using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Services
{
    public class EroiServices
    {
        private IEroeRepository _repo;
        public EroiServices(IEroeRepository repo)
        {
            _repo = repo;
        }

        //GET ALL eroi
        //restituisce e stampa tutti gli eroi
        public IEnumerable<Eroe> GetAllEroi()
        {
            IEnumerable<Eroe> Eroi = _repo.GetAll();
            foreach(var eroe in Eroi)
            {
                Console.WriteLine(eroe);
            }
            return Eroi;
        }

        //GET BY ID
        //cotrollo se k'id è un numero e se è valido
        public Eroe GetEroeByID()
        {
            Eroe eroe = new Eroe();

            int id = 0;
            Console.WriteLine("Inserisci l'id del eroe che vuoi scegliere:");
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
                eroe = _repo.GetByID(id);
            }
            catch (Exception)
            {
                Console.WriteLine("Inserisci un numero!");
            }

            while (eroe.ID == 0)
            {
                Console.WriteLine("Inserisci un id valido:");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                    eroe = _repo.GetByID(id);
                }
                catch (Exception)
                {

                    Console.WriteLine("Inserisci un numero!");
                }
            }
            Console.WriteLine(eroe.ToString());
            return eroe;
        }

        //DELETE
        //controllo se l'id esiste e se è un numero
        public void DeleteEroe()
        {
            Eroe eroe = new Eroe();
            int id = 0;

            while (eroe.ID == 0)
            {
                try
                {
                    Console.WriteLine("Inserisci l'id del eroe che vuoi eleminare:");
                    id = Convert.ToInt32(Console.ReadLine());
                    eroe = _repo.GetByID(id);
                }
                catch (Exception)
                {

                    Console.WriteLine("Inserisci un numero valido!");
                }
            }
            bool elimina = _repo.Delete(eroe);

            if (elimina == false)
                Console.WriteLine("Errore, eroe non presente.");
        }

        //UPDATE
        //posso solo aggiornare i punti vita, il livello e i punti accumulati
        public void UpdateEroe(Eroe eroe)
        {
            _repo.Update(eroe);
        }

        //INSERT
        public void CreateEroe(Giocatore proprietario)
        {
            Console.WriteLine("Crea un nuovo Eroe:");
            //chiedo i paramentri

            //nome
            Console.WriteLine("Nome del Eroe: ");
            string nome = Console.ReadLine();
            //classe
            var classi = new ClassiServices(new ADOClasseRepository());
            Console.WriteLine("Scegli una classe dalla seguenti lista: ");
            classi.GetAllClasse();
            int idClasse = 0;
            Console.WriteLine("Inserisci l'id del eroe che vuoi scegliere:");
            //try
            //{
            //    idClasse = Convert.ToInt32(Console.ReadLine());
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Inserisci un numero!");
            //}

            //while (eroe.ID == 0)
            //{
            //    Console.WriteLine("Inserisci un id valido:");
            //    try
            //    {
            //        id = Convert.ToInt32(Console.ReadLine());
            //        eroe = _repo.GetByID(id);
            //    }
            //    catch (Exception)
            //    {

            //        Console.WriteLine("Inserisci un numero!");
            //    }
            //}

            //arma
            //IsEroe
            bool eroe = true;
            //Punti vita
            int pv = 20;
            //livello
            int livello = 1;
            //punti accumulati
            int pa = 0;
            //proprietario


            Eroe nuovoEroe = new Eroe()
            {
                Nome = nome,
                ClasseDiAppartenenza = 1,
                ArmaScelta = 1,
                IsEroe = eroe,
                PuntiVita = pv,
                Livello = livello,
                PuntiAccumulati = pa,
                Proprietario = proprietario.ID
            };

            _repo.Create(nuovoEroe);
        }
    }
}
