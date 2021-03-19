using EroiVsMostri.ADORepository.Estensioni;
using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EroiVsMostri.ADORepository
{
    public class ADOLivelloRepository : ILivelloRepository
    {
        //stringa di connessione
        const string connectionString = @"Persist Security Info = False; Integrated Security = true; Initial Catalog=EroiVsMostri; Server = .\SQLEXPRESS";

        public void Create(Livelli obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Livelli obj)
        {
            throw new NotImplementedException();
        }

        public Livelli GetByID(int id)
        {
            Livelli livello = new Livelli();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Livello WHERE Livello=@id";
                command.Parameters.AddWithValue("@id", id);

                //eseguo il comando
                SqlDataReader reader = command.ExecuteReader();

                //leggo e salvo i dati letti
                while (reader.Read())
                {
                    //devo creare un estenzione del reader
                    livello = reader.ToLivello();
                }

                //chiudo
                reader.Close();
                connection.Close();
            }
            return livello;
        }

        //get all: tutti i livelli con i punti vita corrispondenti
        public IEnumerable<Livelli> GetAll()
        {
            List<Livelli> Livelli = new List<Livelli>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Livello";

                //eseguo il comando
                SqlDataReader reader = command.ExecuteReader();

                //leggo e salvo i dati letti
                while (reader.Read())
                {
                    //devo creare un estenzione del reader
                    Livelli.Add(reader.ToLivello());
                }

                //chiudo
                reader.Close();
                connection.Close();
            }
            return Livelli;
        }

        public bool Update(Livelli obj)
        {
            throw new NotImplementedException();
        }
    }
}
