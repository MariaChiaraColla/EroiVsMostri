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

        //GET ALL
        public IEnumerable<Livelli> GetAllLivelli()
        {
            IEnumerable<Livelli> Livelli = _repo.GetAll();
            foreach(var livello in Livelli)
            {
                Console.WriteLine(livello);
            }
            return Livelli;
        }
    }
}
