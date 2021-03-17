using EroiVsMostri.Core.Entità;
using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Core.Abstract
{
    public abstract class Personaggio
    {
        //proprietà
        public int ID { get; set; }
        public string Nome { get; set; }
        public int ClasseDiAppartenenza { get; set; }
        public int ArmaScelta { get; set; }
        public bool IsEroe { get; set; }
        public int PuntiVita { get; set; }
        public int Livello { get; set; }

        //Metodi
        public virtual void Attacco(Personaggio avversario)
        {
            //int danni = ArmaScelta.PuntiDanno;
            //avversario.PuntiVita = avversario.PuntiVita - danni;
        }
    }
}
