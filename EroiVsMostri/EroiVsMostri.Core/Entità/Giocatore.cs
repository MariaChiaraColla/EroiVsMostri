using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Core.Entità
{
    public class Giocatore
    {
        //proprietà
        public int ID { get; set; }
        public string Nome { get; set; }
        public bool Admin { get; set; }

        //costruttori
        public Giocatore()
        {
        }
        public Giocatore(string nome)
        {
            Nome = nome;
            Admin = false;
        }

        //metodi
        public override string ToString()
        {
            string ruolo;
            if (Admin == false)
                ruolo = "Utente: ";
            else
                ruolo = "Admin: ";
            return ID +") "+ruolo + Nome;
        }
    }
}
