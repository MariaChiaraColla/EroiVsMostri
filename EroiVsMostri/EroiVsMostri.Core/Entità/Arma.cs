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

        //costruttori
        public Arma()
        {
        }
        public Arma(string name, int pd, int classe)
        {
            Nome = name;
            PuntiDanno = pd;
            ClasseApparteneza = classe;
        }

        //Metodi
        public override string ToString()
        {
            return ID+") "+Nome;
        }
    }
}
