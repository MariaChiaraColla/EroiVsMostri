using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.MockRepository
{
    public class MockClassiRepository : IClasseRepository
    {
        public void Create(Classe obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Classe obj)
        {
            throw new NotImplementedException();
        }

        public Classe GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Classe> GetAll()
        {
            return new List<Classe>()
            {
                new Classe(1,"Mago", true),
                new Classe(2,"Guerriero", true),
                new Classe(3,"Troll", false),
                new Classe(4,"Demone", false)
            };
        }

        public bool Update(Classe obj)
        {
            throw new NotImplementedException();
        }
    }
}
