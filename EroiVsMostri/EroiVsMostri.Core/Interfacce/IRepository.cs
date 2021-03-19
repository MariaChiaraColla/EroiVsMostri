using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Core.Interfacce
{
    public interface IRepository<T>
    {
        //CRUD

        //leggi, tutti e byID
        T GetByID(int ID);
        IEnumerable<T> GetAll();

        //aggiungi
        T Create(T obj);
        
        //modifica
        bool Update(T obj);

        //cancella
        bool Delete(T obj);
    }
}
