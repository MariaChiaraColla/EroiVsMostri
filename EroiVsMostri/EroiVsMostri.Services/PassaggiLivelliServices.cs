using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Services
{
    public class PassaggiLivelliServices
    {
        private IPassaggioLivelloRepository _repo;
        public PassaggiLivelliServices(IPassaggioLivelloRepository repo)
        {
            _repo = repo;
        }

        //GET ALL, recupero tutti i possibili livelli con i punti necessari corrispondenti
        public IEnumerable<PassaggioLivello> GetAllPassaggiLivelli()
        {
            IEnumerable<PassaggioLivello> PassaggiLivelli = _repo.GetAll();
            //foreach(var livello in Livelli)
            //{
            //    Console.WriteLine(livello);
            //}
            return PassaggiLivelli;
        }
    }
}
