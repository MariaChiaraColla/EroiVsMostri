using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Services
{
    public class ArmiServices
    {
        private IArmaRepository _repo;
        public ArmiServices(IArmaRepository repo)
        {
            _repo = repo;
        }

        //Get All Armi
        //per il momento restitruisce tutte le armi, provo a amettere il controllo in eroe
        public IEnumerable<Arma> GetAllArmi(int idClasse)
        {
            List<Arma> ArmiPerClasse = new List<Arma>();
            IEnumerable<Arma> TutteLeArmi = _repo.GetAll();

            foreach (var a in TutteLeArmi)
            {
                if (a.ClasseApparteneza == idClasse)
                {
                    ArmiPerClasse.Add(a);
                }
            }
            foreach(var arma in ArmiPerClasse)
            {
                Console.WriteLine(arma);
            }
            return ArmiPerClasse;
        }

        //Get by ID
        //restituisce l'arma scelta, controllo che sia un numero e che sia valido
        //il parametroID lo passo solo se voglio resistuisco l'arma senza l'interazione con l'utente
        //so che l'id nel db on può essere zero quindi lo uso per il ramo dell'else con l'irazione utente
        public Arma GetArmaByID(int parametroID)
        {
            Arma arma = new Arma();

            if (parametroID != 0)
            {
                arma = _repo.GetByID(parametroID);
            }
            else
            {
                int id = 0;
                Console.WriteLine("Inserisci l'id dell'arma che vuoi scegliere:");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                    arma = _repo.GetByID(id);
                }
                catch (Exception)
                {
                    Console.WriteLine("Inserisci un numero!");
                }

                while (arma.ID == 0)
                {
                    Console.WriteLine("Inserisci un id valido:");
                    try
                    {
                        id = Convert.ToInt32(Console.ReadLine());
                        arma = _repo.GetByID(id);
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Inserisci un numero!");
                    }
                }
                Console.WriteLine(arma.ToString());
            }

            return arma;
        }
    }
}
