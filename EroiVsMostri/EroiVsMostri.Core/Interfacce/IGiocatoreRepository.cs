using EroiVsMostri.Core.Entità;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Core.Interfacce
{
    public interface IGiocatoreRepository : IRepository<Giocatore>
    {
        //get giocatore by name
        Giocatore GetByName(string name);
    }
}
