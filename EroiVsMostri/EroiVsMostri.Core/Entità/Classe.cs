using System;
using System.Collections.Generic;
using System.Text;

namespace EroiVsMostri.Core.Entità
{
    public class Classe
    {
        //proprietà
        public int ID { get; set; }
        public string Nome { get; set; }
        public bool IsEroe { get; set; }

        //costruttori
        public Classe()
        {
        }
        public Classe(string nome, bool eroe)
        {
            Nome = nome;
            IsEroe = eroe;
        }

        //Metodi
        public override string ToString()
        {
            string eroe;
            if (IsEroe == true)
                eroe = "Eroe";
            else
                eroe = "Mostro";
            return ID +") "+ Nome;
        }
    }
}
