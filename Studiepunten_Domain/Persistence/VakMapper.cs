using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studiepunten_Domain.Business;
using MySql.Data.MySqlClient;

namespace Studiepunten_Domain.Persistence
{
    class VakMapper
    {
        private string _connectionString;
        public VakMapper()
        {
            _connectionString = "server = localhost; user id = root;password=1234; database=studiepunten";
        }
        public VakMapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Vak> getVakFromDB()
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM studiepunten.vak", conn);
            List<Vak> vakLijst = new List<Vak>();
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Vak vak = new Vak(
                Convert.ToInt32(dataReader[0]),
                Convert.ToString(dataReader[1]),
                Convert.ToInt32(dataReader[2]),
                Convert.ToInt32(dataReader[3])
                );
                vakLijst.Add(vak);
            }
            conn.Close();
            return vakLijst;
        }
        public void addVakToDB(Vak vak)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "INSERT INTO studiepunten.vak(Naam, Lesuren, Punten) VALUES(@naam, @lesuren, @punten); ";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("naam", vak.Naam);
            cmd.Parameters.AddWithValue("jaren", vak.Lesuren);
            cmd.Parameters.AddWithValue("punten", vak.Punten);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void removeVakFromDB(int id)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "DELETE FROM studiepunten.vak where (id = @id)";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval

            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void AdjustVakFromDB(Vak vak, int id)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "UPDATE studiepunten.vak SET Naam = @naam, Lesuren = @lesuren, Punten = @punten where (id = @id)";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("@naam", vak.Naam);
            cmd.Parameters.AddWithValue("@lesuren", vak.Lesuren);
            cmd.Parameters.AddWithValue("@punten", vak.Punten);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

