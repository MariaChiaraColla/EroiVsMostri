using EroiVsMostri.ADORepository.Estensioni;
using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EroiVsMostri.ADORepository
{
    public class ADOClasseRepository : IClasseRepository
    {
        //stringa di connessione
        const string connectionString = @"Persist Security Info = False; Integrated Security = true; Initial Catalog=EroiVsMostri; Server = .\SQLEXPRESS";
        public void Create(Classe obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Classe obj)
        {
            throw new NotImplementedException();
        }

        //GET BY ID CLASSE
        public Classe GetByID(int id)
        {
            Classe classeById = new Classe();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro connessione
                connection.Open();

                //comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Classe WHERE ID = @ID AND IsEroe=1";
                command.Parameters.AddWithValue("@ID", id);

                //esecuzione del comando
                SqlDataReader reader = command.ExecuteReader();

                //lettura
                while (reader.Read())
                {
                    classeById = reader.ToClasse();
                }

                //chiusura
                reader.Close();
                connection.Close();
            }
            return classeById;
        }

        //GET ALL CLASSI
        public IEnumerable<Classe> GetAll()
        {
            List<Classe> movies = new List<Classe>();
            //ADO net
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro connesione
                connection.Open();

                //comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Classe";

                //esecuzione comando
                SqlDataReader reader = command.ExecuteReader();

                //lettura dati
                while (reader.Read())
                {
                    //devo estendere il metodo reader
                    movies.Add(reader.ToClasse()); //leggo e aggiungo alla lista
                }
                //chiusura connessione e reader
                reader.Close();
                connection.Close();
            }
            return movies;
        }

        public bool Update(Classe obj)
        {
            throw new NotImplementedException();
        }
    }
}
