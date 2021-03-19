using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Core.Entità
{
    public class Arma
    {
        //proprietà
        public int ID { get; set; }
        public string Nome { get; set; }
        public int PuntiDanno { get; set; }
        public int ClasseApparteneza { get; set; }

        //Metodi
        public override string ToString()
        {
            return ID+") "+Nome;
        }
    }
}
