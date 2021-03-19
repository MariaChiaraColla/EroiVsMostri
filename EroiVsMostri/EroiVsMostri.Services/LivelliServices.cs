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
        //se i = 1 li stampo anche
        public IEnumerable<Livelli> GetAllLivelli(int i)
        {
            IEnumerable<Livelli> Livelli = _repo.GetAll();

            if(i == 1)
            {
                foreach (var livello in Livelli)
                {
                    Console.WriteLine(livello);
                }
            }
  
            return Livelli;
        }

        //GET BY ID
        public Livelli GetLivelloByID(int id)
        {
            Livelli livello = _repo.GetByID(id);
            return livello;
        }
    }
}
