using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.MockRepository
{
    public class MockGiocatoreRepository : IGiocatoreRepository
    {
        List<Giocatore> Giocatori = new List<Giocatore>()
        {
            new Giocatore("Mery"),
            new Giocatore("Admin"),
            new Giocatore("MariaChiara")
        };

        public Giocatore Create(Giocatore obj)
        {
            Console.WriteLine("Crea Giocatore:");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();

            obj = new Giocatore(nome);
            return obj;
        }

        public bool Delete(Giocatore obj)
        {
            bool ok = Giocatori.Remove(obj);
            return ok;
        }

        public IEnumerable<Giocatore> GetAll()
        {
            return Giocatori;
        }

        public Giocatore GetByID(int ID)
        {
            Giocatore gio = Giocatori[ID];
            return gio;
        }

        public Giocatore GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Giocatore obj)
        {
            throw new NotImplementedException();
        }
    }
}
