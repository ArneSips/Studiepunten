using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studiepunten_Domain.Business;
using MySql.Data.MySqlClient;

namespace Studiepunten_Domain.Persistence
{
    class VakStudentMapper
    {
        private string _connectionString;
        public VakStudentMapper()
        {
            _connectionString = "server = localhost; user id = root;password=1234; database=studiepunten";
        }
        public VakStudentMapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<VakStudent> getVakStudentFromDB()
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            MySqlCommand cmd = new MySqlCommand("SELECT vak.Naam as VakNaam, student.Naam as StudentNaam FROM studiepunten.vak_has_student INNER JOIN studiepunten.vak on vak_has_student.FKVak = vak.Naam INNER JOIN studiepunten.student on vak_has_student.FKStudent = student.Naam; ", conn);
            List<VakStudent> vakstudentLijst = new List<VakStudent>();
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                VakStudent vakstudent = new VakStudent(
                Convert.ToInt16(dataReader[0]),
                Convert.ToInt16(dataReader[1])
                );
                vakstudentLijst.Add(vakstudent);
            }
            conn.Close();
            return vakstudentLijst;
        }
        public void addVakStudentToDB(VakStudent vakstudent)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "INSERT INTO studiepunten.vak_has_student(FKVak, FKStudent) VALUES(@idvak, @idgebruiker)";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("idvak", vakstudent.IDVak);
            cmd.Parameters.AddWithValue("idgebruiker", vakstudent.IDGebruiker);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void removeVakStudentFromDB(int idvak, int idgebruiker)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "DELETE FROM studiepunten.vak_has_student where (idvak = @idvak, idgebruiker = @idgebruiker)";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval

            cmd.Parameters.AddWithValue("@idvak", idvak);
            cmd.Parameters.AddWithValue("@idgebruiker", idgebruiker);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        } 
    }
}
