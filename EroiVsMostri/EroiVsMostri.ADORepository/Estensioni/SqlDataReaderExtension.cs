using EroiVsMostri.Core.Entità;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EroiVsMostri.ADORepository.Estensioni
{
    public static class SqlDataReaderExtension
    {
        //CLASSE
        public static Classe ToClasse(this SqlDataReader reader)
        {
            return new Classe()
            {
                ID = (int)reader["ID"],
                Nome = (String)reader["Nome"],
                IsEroe = (bool)reader["IsEroe"]
            };
        }

        //ARMA
        public static Arma ToArma(this SqlDataReader reader)
        {
            return new Arma()
            {
                ID = (int)reader["ID"],
                Nome = (String)reader["Nome"],
                PuntiDanno = (int)reader["PuntiDanno"],
                ClasseApparteneza = (int)reader["ClasseID"]
            };
        }

        //LIVELLO
        public static Livelli ToLivello(this SqlDataReader reader)
        {
            return new Livelli()
            {
                Livello = (int)reader["Livello"],
                PuntiVita = (int)reader["PuntiVita"]
            };
        }

        //GIOCATORE
        public static Giocatore ToGiocatore(this SqlDataReader reader)
        {
            return new Giocatore()
            {
                ID = (int)reader["ID"],
                Nome = (string)reader["Nome"],
                Ruolo = (bool)reader["Ruolo"]
            };
        }

        //EROE
        public static Eroe ToEroe(this SqlDataReader reader)
        {
            return new Eroe()
            {
                ID = (int)reader["ID"],
                Nome = (String)reader["Nome"],
                ClasseDiAppartenenza = (int)reader["ClasseID"],
                ArmaScelta = (int)reader["ArmaID"],
                IsEroe = (bool)reader["IsEroe"],
                PuntiVita = (int)reader["PuntiVita"],
                Livello = (int)reader["Livello"],
                PuntiAccumulati = (int)reader["PuntiAccumulati"],
                Proprietario = (int)reader["GiocatoreID"]
            };
        }

        //MOSTRO
        public static Mostro ToMostro(this SqlDataReader reader)
        {
            return new Mostro()
            {
                ID = (int)reader["ID"],
                Nome = (String)reader["Nome"],
                ClasseDiAppartenenza = (int)reader["ClasseID"],
                ArmaScelta = (int)reader["ArmaID"],
                IsEroe = (bool)reader["IsEroe"],
                PuntiVita = (int)reader["PuntiVita"],
                Livello = (int)reader["Livello"]
            };
        }

        //PASSAGGIO LIVELLO
        public static PassaggioLivello ToPassaggioLivello(this SqlDataReader reader)
        {
            return new PassaggioLivello()
            {
                Livello = (int)reader["Livello"],
                PuntiNecessari = (int)reader["PuntiAccumulati"]
            };
        }
    }
}
