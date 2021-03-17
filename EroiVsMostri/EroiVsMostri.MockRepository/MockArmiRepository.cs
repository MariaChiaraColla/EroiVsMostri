using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.MockRepository
{
    public class MockArmiRepository : IArmaRepository
    {
        public void Create(Arma obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Arma obj)
        {
            throw new NotImplementedException();
        }

        public Arma GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Arma> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Arma obj)
        {
            throw new NotImplementedException();
        }
    }
}
