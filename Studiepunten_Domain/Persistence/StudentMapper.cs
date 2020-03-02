using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studiepunten_Domain.Business;
using MySql.Data.MySqlClient;

namespace Studiepunten_Domain.Persistence
{
    class StudentMapper
    {
        private string _connectionString;
        public StudentMapper()
        {
            _connectionString = "server = localhost; user id = root;password=1234; database=rapport";
        }
        public StudentMapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Student> getStudentFromDB()
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM studiepunten.student", conn);
            List<Student> studentLijst = new List<Student>();
            conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Student student = new Student(
                Convert.ToInt16(dataReader[0]),
                Convert.ToString(dataReader[1]),
                Convert.ToString(dataReader[2]),
                Convert.ToInt32(dataReader[3])
                );
                studentLijst.Add(student);
            }
            conn.Close();
            return studentLijst;
        }
        public void addStudentToDB(Student student)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "INSERT INTO studiepunten.student(Naam, Wachtwoord, Punten) VALUES(@naam, @ww, @pt)";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("naam", student.Naam);
            cmd.Parameters.AddWithValue("ww", student.Wachtwoord);
            cmd.Parameters.AddWithValue("pt", student.Punten);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void removeStudentFromDB(int id)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "DELETE FROM studiepunten.student where (id = @id)";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval

            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void AdjustStudentFromDB(Student student, int id)
        {
            //de connectie met de databank maken
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //Het SQL-commando definiëren
            string opdracht = "UPDATE studiepunten.student SET Naam = @naam, Wachtwoord = @ww, punten = @pt, where (id = @id)";
            MySqlCommand cmd = new MySqlCommand(opdracht, conn);

            //voeg de waarden toe, je haalt ze uit het object eval
            cmd.Parameters.AddWithValue("@ond", student.Naam);
            cmd.Parameters.AddWithValue("@dat", student.Wachtwoord);
            cmd.Parameters.AddWithValue("@pt", student.Punten);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
