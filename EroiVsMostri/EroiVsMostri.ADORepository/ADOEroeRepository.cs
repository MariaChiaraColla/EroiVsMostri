﻿using EroiVsMostri.ADORepository.Estensioni;
using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EroiVsMostri.ADORepository
{
    public class ADOEroeRepository : IEroeRepository
    {
        //stringa di connessione
        const string connectionString = @"Persist Security Info = False; Integrated Security = true; Initial Catalog=EroiVsMostri; Server = .\SQLEXPRESS";

        public void Create(Eroe obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO Eroe VALUES(@Nome,@ClasseID,@ArmaID,@IsEroe,@PuntiVita,@Livello,@PuntiAccumulati,@GiocatoreID)";

                //aggiungo i parametri al comando
                command.Parameters.AddWithValue("@Nome", obj.Nome);
                command.Parameters.AddWithValue("@ClasseID", obj.ClasseDiAppartenenza);
                command.Parameters.AddWithValue("@ArmaID", obj.ArmaScelta);
                command.Parameters.AddWithValue("@IsEroe", obj.IsEroe);
                command.Parameters.AddWithValue("@PuntiVita", obj.PuntiVita);
                command.Parameters.AddWithValue("@Livello", obj.Livello);
                command.Parameters.AddWithValue("@PuntiAccumulati", obj.PuntiAccumulati);
                command.Parameters.AddWithValue("@GiocatoreID", obj.Proprietario);

                //eseguo il comando
                int row = command.ExecuteNonQuery();

                //stampo il successo o no
                if (row > 0)
                    Console.WriteLine("L'eroe è stata creato con successo!");
                else
                    Console.WriteLine("Errore, eroe non creato.");

                //chiudo
                connection.Close();
            }
        }

        //cancello l'eroe con l'id dell'eroe che mi è stato passato
        public bool Delete(Eroe obj)
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
                command.CommandText = "DELETE FROM Eroe WHERE ID=@id";

                //aggiungo i parametri al comando
                command.Parameters.AddWithValue("@id", obj.ID);

                //eseguo il comando
                int row = command.ExecuteNonQuery();

                //stampo il successo o no
                if (row > 0)
                {
                    Console.WriteLine("L'eroe è stata cancellato!");
                    successo = true;
                }
                else
                    Console.WriteLine("Errore, eroe non cancellato.");

                //chiudo
                connection.Close();
            }
            return successo;
        }

        //tutti gli eroi
        public IEnumerable<Eroe> GetAll()
        {
            List<Eroe> Eroi = new List<Eroe>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Eroe";

                //eseguo il comando
                SqlDataReader reader = command.ExecuteReader();

                //leggo e salvo i dati letti
                while (reader.Read())
                {
                    //devo creare un estenzione del reader
                    Eroi.Add(reader.ToEroe());
                }

                //chiudo
                reader.Close();
                connection.Close();
            }
            return Eroi;
        }

        //eroe con quel id
        public Eroe GetByID(int id)
        {
            Eroe eroe = new Eroe();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Eroe WHERE ID=@id";
                command.Parameters.AddWithValue("@id", id);

                //eseguo il comando
                SqlDataReader reader = command.ExecuteReader();

                //leggo e salvo i dati letti
                while (reader.Read())
                {
                    //devo creare un estenzione del reader
                    eroe = reader.ToEroe();
                }

                //chiudo
                reader.Close();
                connection.Close();
            }
            return eroe;
        }

        //update
        //un eroe non può essere modificato
        //ma dopo una scontro posso affiornare i punti vita, il livello, i punti accumulati
        public bool Update(Eroe obj)
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
                command.CommandText = "UPDATE Eroe SET PuntiVita=@pv, Livello=@livello, PuntiAccumulati=@pa WHERE ID=@ID";

                //parametri
                //id, non modificabile
                command.Parameters.AddWithValue("@ID", obj.ID);
                // nuovi punti vita
                command.Parameters.AddWithValue("@pv", obj.PuntiVita);
                command.Parameters.AddWithValue("@livello", obj.Livello);
                command.Parameters.AddWithValue("@pa", obj.PuntiAccumulati);

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
