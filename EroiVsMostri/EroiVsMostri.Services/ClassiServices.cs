using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Services
{
    public class ClassiServices
    {
        private IClasseRepository _repo;
        public ClassiServices(IClasseRepository repo)
        {
            _repo = repo;
        }

        //get all Classi, 
        //creo due liste, quella che contiene tutti 
        //e quella che restituisco con solo le classi eroe (IsEroe == true)
        public IEnumerable<Classe> GetAllClasse()
        {
            List<Classe> classiEroe = new List<Classe>();
            IEnumerable<Classe> TutteLeClassi = _repo.GetAll();
            foreach(var c in TutteLeClassi)
            {
                if(c.IsEroe == true)
                {
                    classiEroe.Add(c);
                }
            }
            foreach(var classe in classiEroe)
            {
                Console.WriteLine(classe);
            }
            return classiEroe;
        }

        //get by id Classe,
        //controllo che siano visibili solo le classi eroi e 
        //che l'id inserito sia un numero e che sia valido
        public Classe GetClassByID()
        {
            Classe classe = new Classe();
            int id = 0;
            Console.WriteLine("Inserisci l'id della classe che vuoi scegliere:");
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
                classe = _repo.GetByID(id);
            }
            catch (Exception)
            {
                Console.WriteLine("Inserisci un numero!");
            }
            
            while (classe.ID == 0)
            {
                Console.WriteLine("Inserisci un id valido:");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                    classe = _repo.GetByID(id);
                }
                catch (Exception)
                {

                    Console.WriteLine("Inserisci un numero!");
                }
            }
            Console.WriteLine(classe.ToString());
            return classe;
        }
    }
}
