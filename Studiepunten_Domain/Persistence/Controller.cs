using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studiepunten_Domain.Business;


namespace Studiepunten_Domain.Persistence
{
    class Controller
    {
         private string _connectionString;
        public Controller()
        {
            _connectionString = "server = localhost; user id = root;password=1234; database=rapport";
        }
        public Controller(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Student> getStudent()
        {
            StudentMapper mapper = new StudentMapper(_connectionString);
            return mapper.getStudentFromDB();
        }
        public void addStudent(Student student)
        {
            StudentMapper mapper = new StudentMapper(_connectionString);
            mapper.addStudentToDB(student);
        }
        public void removeStudent(int id)
        {
            StudentMapper mapper = new StudentMapper(_connectionString);
            mapper.removeStudentFromDB(id);
        }
        public void adjustStudent(Student student, int id)
        {
            StudentMapper mapper = new StudentMapper(_connectionString);
            mapper.AdjustStudentFromDB(student, id);
        }

            public List<Studiejaar> getStudiejaar()
            {
                StudiejaarMapper mapper = new StudiejaarMapper(_connectionString);
                return mapper.getStudiejaarFromDB();
            }
            public void addStudiejaar(Studiejaar studiejaar)
            {
                StudiejaarMapper mapper = new StudiejaarMapper(_connectionString);
                mapper.addStudiejaarToDB(studiejaar);
            }

        public List<Studierichting> getStudierichting()
        {
            StudierichtingMapper mapper = new StudierichtingMapper(_connectionString);
            return mapper.getStudierichtingFromDB();
        }
        public void addStudierichting(Studierichting studierichting)
        {
            StudierichtingMapper mapper = new StudierichtingMapper(_connectionString);
            mapper.addStudierichtingToDB(studierichting);
        }
        public void removeStudierichting(int id)
        {
            StudierichtingMapper mapper = new StudierichtingMapper(_connectionString);
            mapper.removeStudierichtingFromDB(id);
        }
        public void adjustStudierichting(Studierichting studierichting, int id)
        {
            StudierichtingMapper mapper = new StudierichtingMapper(_connectionString);
            mapper.AdjustStudentFromDB(studierichting, id);
        }

            public List<Vak> getVak()
            {
                VakMapper mapper = new VakMapper(_connectionString);
                return mapper.getVakFromDB();
            }
            public void addVak(Vak vak)
            {
                VakMapper mapper = new VakMapper(_connectionString);
                mapper.addVakToDB(vak);
            }
            public void removeVak(int id)
            {
                VakMapper mapper = new VakMapper(_connectionString);
                mapper.removeVakFromDB(id);
            }
            public void adjustVak(Vak vak, int id)
            {
                VakMapper mapper = new VakMapper(_connectionString);
                mapper.AdjustVakFromDB(vak, id);
            }

        public List<StudentStudierichting> getStudentStudierichting()
        {
            StudentStudierichtingMapper mapper = new StudentStudierichtingMapper(_connectionString);
            return mapper.getStudentStudierichtingFromDB();
        }
        public void addStudentStudierichting(Student student)
        {
            StudentMapper mapper = new StudentMapper(_connectionString);
            mapper.addStudentToDB(student);
        }
        public void adjustStudentStudierichting(StudentStudierichting studentstudierichting, int id)
        {
            StudentStudierichtingMapper mapper = new StudentStudierichtingMapper(_connectionString);
            mapper.AdjustStudentStudierichtingFromDB(studentstudierichting, id);
        }
    }
}
