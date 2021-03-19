using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;

namespace EroiVsMostri.MockRepository
{
    public class MockEroiRepository : IEroeRepository
    {
        List<Eroe> Eroi = new List<Eroe>()
        {
            new Eroe("Aladin",2,1),
            new Eroe("Ercules",2,2),
            new Eroe("Merlino",1,1)
        };

        public Eroe Create(Eroe obj)
        {
            Console.WriteLine("Crea eroe:");
            Console.WriteLine("Nome eroe:");
            string nome = Console.ReadLine();
            Console.WriteLine("Classe eroe:");
            int classe = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Arma eroe:");
            int arma = Convert.ToInt32(Console.ReadLine());

            obj = new Eroe(nome, classe, arma);
            Eroi.Add(obj);
            return obj;
        }

        public bool Delete(Eroe obj)
        {
            bool ok = Eroi.Remove(obj);
            return ok;
        }

        public Eroe GetByID(int ID)
        {
            Eroe eroe = Eroi[ID];
            return eroe;
        }

        public IEnumerable<Eroe> GetAll()
        {
            return Eroi;
        }
        public bool Update(Eroe obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Eroe> GetAllByGiocatore(Giocatore giocatore)
        {
            throw new NotImplementedException();
        }

        public Eroe GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
