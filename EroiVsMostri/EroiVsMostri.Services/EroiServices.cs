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
        //cotrollo se l'id è un numero e se è valido
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
            //Console.WriteLine(eroe.ToString());
            return eroe;
        }

        //DELETE
        //controllo se l'id esiste e se è un numero
        //gli passo come parametro un id, se quell'id non è zero voglio eliminare l'eroe senza l'interazione del
        //utente altrimenti chiedo al giocatore quale eroe vuole cancellare
        public void DeleteEroe(int idEroe)
        {
            Eroe eroe = new Eroe();
            bool elimina;

            if(idEroe == 0)
            {
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
            }
            else
            {
                eroe = _repo.GetByID(idEroe);
            }

            elimina = _repo.Delete(eroe);
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
        public Eroe CreateEroe(Giocatore proprietario)
        {
            Console.WriteLine("Crea un nuovo Eroe:");
            //chiedo i paramentri

            //nome
            Console.WriteLine("Nome del Eroe: ");
            string nome = Console.ReadLine();
            //classe, stampo la lista di tutte le classi per gli eroei presenti con GetAllClassi 
            //e gli faccio scegliere la classe con GetClasseByID
            var classi = new ClassiServices(new ADOClasseRepository());
            Console.WriteLine("Scegli una classe tra quelle disponibili:");
            bool eroe = true;
            classi.GetAllClassi(eroe);
            Classe classeScelta = classi.GetClassByID();
            //arma, stessa cosa della classe
            var armi = new ArmiServices(new ADOArmaRepository());
            Console.WriteLine("Armi disponibili per " + classeScelta.Nome + ":");
            armi.GetAllArmi(classeScelta.ID);
            Arma armaScelta = armi.GetArmaByID(0);
            //li gestisco nel costruttore
            //IsEroe, è sempre true
            //Punti vita all'inizio sono sempre 20
            //livello all'inizio è sempre 1
            //punti accumulati all'inizio sono sempre 0
            //proprietario, me lo passo come parametro della funzione

            Eroe nuovoEroe = new Eroe()
            {
                Nome = nome,
                ClasseDiAppartenenza = classeScelta.ID,
                ArmaScelta = armaScelta.ID,
                IsEroe = true,
                PuntiVita = 20,
                Livello = 1,
                PuntiAccumulati = 0,
                Proprietario = proprietario.ID
            };

            _repo.Create(nuovoEroe);
            return nuovoEroe;
        }

    }
}
