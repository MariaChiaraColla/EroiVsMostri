using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.MockRepository
{
    public class MockArmiRepository : IArmaRepository
    {
        List<Arma> Armi = new List<Arma>()
        {
            new Arma("Spada",5,2),
            new Arma("Arco",3,2),
            new Arma("Magia",4,1)
        };
        public Arma Create(Arma obj)
        {
            Console.WriteLine("Crea Arma:");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Punti danno:");
            int pd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Classe:");
            int classe = Convert.ToInt32(Console.ReadLine());

            obj = new Arma(nome,pd, classe);
            Armi.Add(obj);
            return obj;
        }

        public bool Delete(Arma obj)
        {
            Armi.Remove(obj);
            return true;
        }

        public Arma GetByID(int ID)
        {
            Arma arma = Armi[ID];
            return arma;
        }

        public IEnumerable<Arma> GetAll()
        {
            return Armi;
        }

        public bool Update(Arma obj)
        {
            throw new NotImplementedException();
        }
    }
}
