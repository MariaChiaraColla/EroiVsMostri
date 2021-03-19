using EroiVsMostri.Core.Entità;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Core.Interfacce
{
    public interface IEroeRepository : IRepository<Eroe>
    {
        IEnumerable<Eroe> GetAllByGiocatore(Giocatore giocatore);

        Eroe GetByName(string name);
    }
}
