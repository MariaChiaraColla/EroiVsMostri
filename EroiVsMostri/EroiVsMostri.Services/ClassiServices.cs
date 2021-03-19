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
        //e quella che restituisce solo le classi eroe o mostro a seconda del passato (IsEroe == true)
        public IEnumerable<Classe> GetAllClassi(bool eroe)
        {
            List<Classe> classiEroeOmostro = new List<Classe>();
            IEnumerable<Classe> TutteLeClassi = _repo.GetAll();
            foreach(var c in TutteLeClassi)
            {
                if(c.IsEroe == eroe)
                {
                    classiEroeOmostro.Add(c);
                }
            }
            foreach(var classe in classiEroeOmostro)
            {
                Console.WriteLine(classe);
            }
            return classiEroeOmostro;
        }

        //get by id Classe,
        //controllo che siano visibili solo le classi eroi e 
        //che l'id inserito sia un numero e che sia valido
        public Classe GetClassByID()
        {
            Classe classe = new Classe();
            int id = 0;
            //Console.WriteLine("Inserisci l'id della classe che vuoi scegliere:");
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
            //Console.WriteLine(classe.ToString());
            return classe;
        }
    }
}
