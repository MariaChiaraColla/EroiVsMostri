using EroiVsMostri.ADORepository.Estensioni;
using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EroiVsMostri.ADORepository
{
    public class ADOMostroRepository : IMostroRepository
    {
        //stringa di connessione
        const string connectionString = @"Persist Security Info = False; Integrated Security = true; Initial Catalog=EroiVsMostri; Server = .\SQLEXPRESS";

        //creo il mostro
        public Mostro Create(Mostro obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO Mostro VALUES(@Nome,@ClasseID,@ArmaID,@IsEroe,@PuntiVita,@Livello)";

                //aggiungo i parametri al comando
                command.Parameters.AddWithValue("@Nome", obj.Nome);
                command.Parameters.AddWithValue("@ClasseID", obj.ClasseDiAppartenenza);
                command.Parameters.AddWithValue("@ArmaID", obj.ArmaScelta);
                command.Parameters.AddWithValue("@IsEroe", obj.IsEroe);
                command.Parameters.AddWithValue("@PuntiVita", obj.PuntiVita);
                command.Parameters.AddWithValue("@Livello", obj.Livello);

                //eseguo il comando
                int row = command.ExecuteNonQuery();

                //stampo il successo o no
                if (row > 0)
                    Console.WriteLine("Il mostro è stata creato con successo!");
                else
                    Console.WriteLine("Errore, mostro non creato.");

                //chiudo
                connection.Close();
            }
            return obj;
        }

        //cancello il mostro con l'id del mostro che mi è stato passato
        public bool Delete(Mostro obj)
        {
            bool successo = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM Mostro WHERE ID=@id";

                //aggiungo i parametri al comando
                command.Parameters.AddWithValue("@id", obj.ID);

                //eseguo il comando
                int row = command.ExecuteNonQuery();

                //stampo il successo o no
                if (row > 0)
                {
                    Console.WriteLine("Il mostro è stata cancellato!");
                    successo = true;
                }
                else
                    Console.WriteLine("Errore, mostro non cancellato.");

                //chiudo
                connection.Close();
            }
            return successo;
        }

        //tutti i mostri
        public IEnumerable<Mostro> GetAll()
        {
            List<Mostro> Mostri = new List<Mostro>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Mostro";

                //eseguo il comando
                SqlDataReader reader = command.ExecuteReader();

                //leggo e salvo i dati letti
                while (reader.Read())
                {
                    //devo creare un estenzione del reader
                    Mostri.Add(reader.ToMostro());
                }

                //chiudo
                reader.Close();
                connection.Close();
            }
            return Mostri;
        }

        //mostro con quel id
        public Mostro GetByID(int id)
        {
            Mostro mostro = new Mostro();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Mostro WHERE ID=@id";
                command.Parameters.AddWithValue("@id", id);

                //eseguo il comando
                SqlDataReader reader = command.ExecuteReader();

                //leggo e salvo i dati letti
                while (reader.Read())
                {
                    //devo creare un estenzione del reader
                    mostro = reader.ToMostro();
                }

                //chiudo
                reader.Close();
                connection.Close();
            }
            return mostro;
        }

        //update
        public bool Update(Mostro obj)
        {
            bool successo = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro connessione
                connection.Open();

                //comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE Mostro SET PuntiVita=@pv WHERE ID=@ID";

                //parametri
                //id, non modificabile
                command.Parameters.AddWithValue("@ID", obj.ID);
                // nuovi punti vita
                command.Parameters.AddWithValue("@pv", obj.PuntiVita);

                //eseguo il comando
                int row = command.ExecuteNonQuery();

                //controllo il successo
                if (row > 0)
                {
                    successo = true;
                    Console.WriteLine("Aggiornato con successo");
                }
                else
                    Console.WriteLine("Aggiornamento non riuscito");

                //chiudo connessione
                connection.Close();
            }

            return successo;
        }
    }
}
