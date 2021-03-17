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
        public IEnumerable<Arma> GetAllArmi()
        {
            List<Arma> ArmiPerClasse = new List<Arma>();
            //Classe classeDiAppartenenza = ClassiServices.GetClassByID();
            IEnumerable<Arma> TutteLeArmi = _repo.GetAll();
            foreach (var a in TutteLeArmi)
            {
                if (a.ClasseApparteneza == 1)
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
        public Arma GetArmaByID()
        {
            Arma arma = new Arma();
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
            return arma;
        }
    }
}
