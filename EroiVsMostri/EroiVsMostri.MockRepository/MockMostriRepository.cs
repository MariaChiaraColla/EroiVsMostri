using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.MockRepository
{
    public class MockMostriRepository : IMostroRepository
    {
        List<Mostro> Mostri = new List<Mostro>()
        {
            new Mostro("Jafar",2,3),
            new Mostro("Ade",2,4),
            new Mostro("Malefica",1,3)
        };

        public Mostro Create(Mostro obj)
        {
            Console.WriteLine("Crea Mostro:");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Classe:");
            int classe = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Arma:");
            int arma = Convert.ToInt32(Console.ReadLine());

            obj = new Mostro(nome, classe, arma);
            Mostri.Add(obj);
            return obj;
        }

        public bool Delete(Mostro obj)
        {
            bool ok = Mostri.Remove(obj);
            return ok;
        }

        public IEnumerable<Mostro> GetAll()
        {
            return Mostri;
        }

        public Mostro GetByID(int ID)
        {
            Mostro mostro = Mostri[ID];
            return mostro;
        }

        public bool Update(Mostro obj)
        {
            throw new NotImplementedException();
        }
    }
}
