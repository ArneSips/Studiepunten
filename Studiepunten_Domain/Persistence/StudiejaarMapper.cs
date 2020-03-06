using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studiepunten_Domain.Business;
using MySql.Data.MySqlClient;

namespace Studiepunten_Domain.Persistence
{
    class StudiejaarMapper
    {
        private string _connectionString;
        public StudiejaarMapper()
        {
            _connectionString = "server = localhost; user id = root;password=1234; database=studiepunten";
        }
        public StudiejaarMapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Studiejaar> getStudiejaarFromDB()
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM studiepunten.studiejaar", conn);
            List<Studiejaar> studiejaarLijst = new List<Studiejaar>();
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Studiejaar studiejaar = new Studiejaar(
                Convert.ToInt16(dataReader[0]),
                Convert.ToString(dataReader[1]),
                Convert.ToInt32(dataReader[2])
                );
                studiejaarLijst.Add(studiejaar);
            }
            conn.Close();
            return studiejaarLijst;
        }
        public void addStudiejaarToDB(Studiejaar studiejaar)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "INSERT INTO studiepunten.studiejaar (IDStudiejaar, Naam, FKStudierichting) VALUES (@id, @naam, @fkstudierichting);";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("id", studiejaar.IDStudiejaar);
            cmd.Parameters.AddWithValue("naam", studiejaar.Naam);
            cmd.Parameters.AddWithValue("fkstudierichting", studiejaar.FKStudierichting);


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
