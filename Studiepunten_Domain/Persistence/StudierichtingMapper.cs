using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studiepunten_Domain.Business;
using MySql.Data.MySqlClient;

namespace Studiepunten_Domain.Persistence
{
    class StudierichtingMapper
    {
        private string _connectionString;
        public StudierichtingMapper()
        {
            _connectionString = "server = localhost; user id = root;password=1234; database=rapport";
        }
        public StudierichtingMapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Studierichting> getStudierichtingFromDB()
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM studiepunten.studierichting", conn);
            List<Studierichting> studierichtingLijst = new List<Studierichting>();
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Studierichting studierichting = new Studierichting(
                dataReader[0].ToString(),
                Convert.ToString(dataReader[1]),
                Convert.ToInt32(dataReader[2])
                );
                studierichtingLijst.Add(studierichting);
            }
            conn.Close();
            return studierichtingLijst;
        }
        public void addStudierichtingToDB(Studierichting studierichting)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "INSERT INTO studiepunten.studierichting(Naam, Jaren) VALUES(@naam, @jaren); ";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("naam", studierichting.Naam);
            cmd.Parameters.AddWithValue("jaren", studierichting.Jaren);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void removeStudierichtingFromDB(int id)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "DELETE FROM studiepunten.studierichting where (id = @id)";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval

            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void AdjustStudentFromDB(Studierichting studierichting, int id)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "UPDATE studiepunten.studierichting SET Naam = @naam where (id = @id)";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("@naam", studierichting.Naam);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
