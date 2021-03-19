using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Services
{
    public class LivelliServices
    {
        private ILivelloRepository _repo;
        public LivelliServices(ILivelloRepository repo)
        {
            _repo = repo;
        }

        //GET ALL, recupero tutti i possibili livelli con i punti vita corrispondenti
        public IEnumerable<Livelli> GetAllLivelli()
        {
            IEnumerable<Livelli> Livelli = _repo.GetAll();
            //foreach(var livello in Livelli)
            //{
            //    Console.WriteLine(livello);
            //}
            return Livelli;
        }

        public Livelli GetLivelloByID(int id)
        {
            Livelli livello = _repo.GetByID(id);
            return livello;
        }
    }
}
