using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.MockRepository
{
    public class MockClassiRepository : IClasseRepository
    {
        List<Classe> Classi = new List<Classe>()
            {
                new Classe("Mago", true),
                new Classe("Guerriero", true),
                new Classe("Troll", false),
                new Classe("Demone", false)
            };

        public Classe Create(Classe obj)
        {
            Console.WriteLine("Crea Classe:");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();

            obj = new Classe(nome,true);
            Classi.Add(obj);
            return obj;
        }

        public bool Delete(Classe obj)
        {
            bool ok = Classi.Remove(obj);
            return ok;
        }

        public Classe GetByID(int id)
        {
            Classe classe = Classi[id];
            return classe;
        }

        public IEnumerable<Classe> GetAll()
        {
            return Classi;
        }

        public bool Update(Classe obj)
        {
            throw new NotImplementedException();
        }
    }
}
