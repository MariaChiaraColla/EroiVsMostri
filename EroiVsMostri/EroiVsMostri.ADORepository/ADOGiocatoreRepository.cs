using EroiVsMostri.ADORepository.Estensioni;
using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EroiVsMostri.ADORepository
{
    public class ADOGiocatoreRepository : IGiocatoreRepository
    {
        //stringa di connessione
        const string connectionString = @"Persist Security Info = False; Integrated Security = true; Initial Catalog=EroiVsMostri; Server = .\SQLEXPRESS";

        //creo un nuovo giocatore
        public void Create(Giocatore obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO Giocatore VALUES(@Nome,@Ruolo)";

                //aggiungo i parametri al comando
                command.Parameters.AddWithValue("@Nome", obj.Nome);
                command.Parameters.AddWithValue("@Ruolo", 0);

                //eseguo il comando
                int row = command.ExecuteNonQuery();

                //stampo il successo o no
                if (row > 0)
                    Console.WriteLine("Il giocatore è stata aggiunto con successo!");
                else
                    Console.WriteLine("Errore, giocatore no aggiunto.");

                //chiudo
                connection.Close();
            }
        }

        //Cancella giocatore e ritorna bool se c'è riusicto o no
        public bool Delete(Giocatore obj)
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
                command.CommandText = "DELETE FROM Giocatore WHERE ID=@id";

                //aggiungo i parametri al comando
                command.Parameters.AddWithValue("@id", obj.ID);

                //eseguo il comando
                int row = command.ExecuteNonQuery();

                //stampo il successo o no
                if (row > 0)
                {
                    Console.WriteLine("Il giocatore è stata cancellato!");
                    successo = true;
                }    
                else
                    Console.WriteLine("Errore, giocatore non cancellato.");

                //chiudo
                connection.Close();
            }
            return successo;
        }

        //restituisco tutti i giocatori presenti nel db
        public IEnumerable<Giocatore> GetAll()
        {
            List<Giocatore> Giocatori = new List<Giocatore>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Giocatore";

                //eseguo il comando
                SqlDataReader reader = command.ExecuteReader();

                //leggo e salvo i dati letti
                while (reader.Read())
                {
                    //devo creare un estenzione del reader
                    Giocatori.Add(reader.ToGiocatore());
                }

                //chiudo
                reader.Close();
                connection.Close();
            }
            return Giocatori;
        }

        //restituisco il giocatore con quel id
        public Giocatore GetByID(int id)
        {
            Giocatore giocatore = new Giocatore();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Giocatore WHERE ID=@ID";
                command.Parameters.AddWithValue("@ID",id);

                //eseguo il comando
                SqlDataReader reader = command.ExecuteReader();

                //leggo e salvo i dati letti
                while (reader.Read())
                {
                    //devo creare un estenzione del reader
                    giocatore = reader.ToGiocatore();
                }

                //chiudo
                reader.Close();
                connection.Close();
            }
            return giocatore;
        }

        //aggiorno un giocatore già esistente
        public bool Update(Giocatore obj)
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
                command.CommandText = "UPDATE Giocatore SET Nome=@nome WHERE ID=@ID";

                //parametri
                command.Parameters.AddWithValue("@ID", obj.ID);
                Console.WriteLine("Inserisci il nuovo nome del giocatore:");
                string nome = Console.ReadLine();
                command.Parameters.AddWithValue("@nome", nome);
                command.Parameters.AddWithValue("@ruolo", 0);

                //eseguo il comando
                int row = command.ExecuteNonQuery();

                //controllo il successo
                if (row > 0)
                {
                    successo = true;
                }

                //chiudo connessione
                connection.Close();
            }

            return successo;
        }

    }
}
