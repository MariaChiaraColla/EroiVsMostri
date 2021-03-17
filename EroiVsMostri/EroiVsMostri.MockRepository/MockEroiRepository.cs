using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;

namespace EroiVsMostri.MockRepository
{
    public class MockEroiRepository : IEroeRepository
    {
        public void Create(Eroe obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Eroe obj)
        {
            throw new NotImplementedException();
        }

        public Eroe GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Eroe> GetAll()
        {
            throw new NotImplementedException();
        }
        public bool Update(Eroe obj)
        {
            throw new NotImplementedException();
        }
    }
}
