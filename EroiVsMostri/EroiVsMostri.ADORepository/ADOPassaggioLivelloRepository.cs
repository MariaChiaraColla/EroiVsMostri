using EroiVsMostri.ADORepository.Estensioni;
using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EroiVsMostri.ADORepository
{
    public class ADOPassaggioLivelloRepository : IPassaggioLivelloRepository
    {
        //stringa di connessione
        const string connectionString = @"Persist Security Info = False; Integrated Security = true; Initial Catalog=EroiVsMostri; Server = .\SQLEXPRESS";

        public PassaggioLivello Create(PassaggioLivello obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(PassaggioLivello obj)
        {
            throw new NotImplementedException();
        }

        public PassaggioLivello GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        //get all: tutti i livelli con i punti necessari corrispondenti
        public IEnumerable<PassaggioLivello> GetAll()
        {
            List<PassaggioLivello> PassaggiLivelli = new List<PassaggioLivello>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM PassaggioLivello";

                //eseguo il comando
                SqlDataReader reader = command.ExecuteReader();

                //leggo e salvo i dati letti
                while (reader.Read())
                {
                    //devo creare un estenzione del reader
                    PassaggiLivelli.Add(reader.ToPassaggioLivello());
                }

                //chiudo
                reader.Close();
                connection.Close();
            }
            return PassaggiLivelli;
        }

        public bool Update(PassaggioLivello obj)
        {
            throw new NotImplementedException();
        }
    }
}
