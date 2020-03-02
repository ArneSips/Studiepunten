using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studiepunten_Domain.Business;
using MySql.Data.MySqlClient;

namespace Studiepunten_Domain.Persistence
{
    class StudentStudierichtingMapper
    {
        private string _connectionString;
        public StudentStudierichtingMapper()
        {
            _connectionString = "server = localhost; user id = root;password=1234; database=rapport";
        }
        public StudentStudierichtingMapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<StudentStudierichting> getStudentStudierichtingFromDB()
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM studiepunten.student_has_studierichting", conn);
            List<StudentStudierichting> studentStudierichtingLijst = new List<StudentStudierichting>();
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                StudentStudierichting studentstudierichting = new StudentStudierichting(
                Convert.ToInt32(dataReader[0]),
                Convert.ToInt32(dataReader[1]),
                Convert.ToInt32(dataReader[2]),
                Convert.ToDateTime(dataReader[3]),
                Convert.ToDateTime(dataReader[4])
                );
                studentStudierichtingLijst.Add(studentstudierichting);
            }
            conn.Close();
            return studentStudierichtingLijst;
        }
        public void addStudentStudierichtingToDB(StudentStudierichting studentstudierichting)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "INSERT INTO studiepunten.student_has_studierichting(idStudentVolgtRichting,fkStudent, fkStudierichting, startDatum, eindDatum) VALUES(@idstudentvolgtrichting, @fkstudent, @fkstudierichting, @startdatum, @einddatum)"; 
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("idstudentvolgtstudierichting", studentstudierichting.IDStudentStudierichting);
            cmd.Parameters.AddWithValue("fkstudent", studentstudierichting.FKStudent);
            cmd.Parameters.AddWithValue("fkstudierichting", studentstudierichting.FKStudierichting);
            cmd.Parameters.AddWithValue("startdatum", studentstudierichting.StartDatum);
            cmd.Parameters.AddWithValue("einddatum", studentstudierichting.EindDatum);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void AdjustStudentStudierichtingFromDB(StudentStudierichting studentstudierichting, int id)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "UPDATE studiepunten.student_has_studierichting SET fkStudent = @fkstudent, fkStudierichting = @fkstudierichting, startDatum = @startdatum, eindDatum = @einddatum where (id = @id)";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("@fkstudent", studentstudierichting.FKStudent);
            cmd.Parameters.AddWithValue("@fkstudierichting", studentstudierichting.FKStudierichting);
            cmd.Parameters.AddWithValue("@startdatum", studentstudierichting.StartDatum);
            cmd.Parameters.AddWithValue("@einddatum", studentstudierichting.EindDatum);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
