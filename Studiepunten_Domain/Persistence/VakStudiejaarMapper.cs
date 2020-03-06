using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studiepunten_Domain.Business;
using MySql.Data.MySqlClient;

namespace Studiepunten_Domain.Persistence
{
    class VakStudiejaarMapper
    {
        private string _connectionString;
        public VakStudiejaarMapper()
        {
            _connectionString = "server = localhost; user id = root;password=1234; database=studiepunten";
        }
        public VakStudiejaarMapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<VakStudiejaar> getVakStudiejaarFromDB()
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            MySqlCommand cmd = new MySqlCommand("SELECT vak.Naam as Naam, studiejaar.Naam as Studiejaar FROM studiepunten.vak_has_studiejaar INNER JOIN studiepunten.vak on vak_has_studiejaar.FKVak = vak.Naam INNER JOIN studiepunten.studiejaar on vak_has_studiejaar.FKStudiejaar = studiejaar.Naam; ", conn);
            List<VakStudiejaar> vakstudiejaarLijst = new List<VakStudiejaar>();
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                VakStudiejaar vakstudiejaar = new VakStudiejaar(
                Convert.ToInt16(dataReader[0]),
                Convert.ToInt16(dataReader[1])
                );
                vakstudiejaarLijst.Add(vakstudiejaar);
            }
            conn.Close();
            return vakstudiejaarLijst;
        }
        public void addVakStudiejaarToDB(VakStudiejaar vakstudiejaar)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "INSERT INTO studiepunten.vak_has_studiejaar(FKVak, FKStudiejaar) VALUES(@idvak, @idstudiejaar)";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("idvak", vakstudiejaar.IDVak);
            cmd.Parameters.AddWithValue("idstudiejaar", vakstudiejaar.IDStudiejaar);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void removeVakStudiejaarFromDB(int idvak, int idstudiejaar)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "DELETE FROM studiepunten.vak_has_studiejaar where (idvak = @idvak, idstudiejaar = @idstudiejaar)";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval

            cmd.Parameters.AddWithValue("@idvak", idvak);
            cmd.Parameters.AddWithValue("@idstudiejaar", idstudiejaar);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
