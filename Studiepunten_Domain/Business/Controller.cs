using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studiepunten_Domain.Persistence;

namespace Studiepunten_Domain.Business
{
    public class Controller
    {
        private Persistence.Controller _persistController;
        private StudentRepository _studentRepository;
        private StudentStudierichtingRepository _studentStudierichtingRepository;
        private StudiejaarRepository _studiejaarRepository;
        private StudierichtingRepository _studierichtingRepository;
        private VakRepository _vakRepository;
        private VakStudentRepository _vakStudentRepository;
        private VakStudiejaarRepository _vakStudiejaarRepository;
        private Student _ingelogdeStudent;

        public Controller()
        {
            _persistController = new Persistence.Controller();
            _studentRepository = new StudentRepository();
            _studentStudierichtingRepository = new StudentStudierichtingRepository();
            _studiejaarRepository = new StudiejaarRepository();
            _studierichtingRepository = new StudierichtingRepository();
            _vakRepository = new VakRepository();
            _vakStudentRepository = new VakStudentRepository();
            _vakStudiejaarRepository = new VakStudiejaarRepository();

            _studentRepository.StudentLijst = _persistController.getStudent();
            _studentStudierichtingRepository.StudentStudierichtingLijst = _persistController.getStudentStudierichting();
            _studiejaarRepository.StudiejaarLijst = _persistController.getStudiejaar();
            _studierichtingRepository.StudierichtingLijst = _persistController.getStudierichting();
            _vakRepository.VakLijst = _persistController.getVak();
            _vakStudentRepository.VakStudentLijst = _persistController.getVakStudent();
            _vakStudiejaarRepository.VakStudiejaarLijst = _persistController.getVakStudiejaar();
            _ingelogdeStudent = null;
        }

        public Controller(string connectionstring)
        {
            _persistController = new Persistence.Controller(connectionstring);
            _studentRepository = new StudentRepository();
            _studentStudierichtingRepository = new StudentStudierichtingRepository();
            _studiejaarRepository = new StudiejaarRepository();
            _studierichtingRepository = new StudierichtingRepository();
            _vakRepository = new VakRepository();
            _vakStudentRepository = new VakStudentRepository();
            _vakStudiejaarRepository = new VakStudiejaarRepository();
            _ingelogdeStudent = null;

            _studentRepository.StudentLijst = _persistController.getStudent();
            _studentStudierichtingRepository.StudentStudierichtingLijst = _persistController.getStudentStudierichting();
            _studiejaarRepository.StudiejaarLijst = _persistController.getStudiejaar();
            _studierichtingRepository.StudierichtingLijst = _persistController.getStudierichting();
            _vakRepository.VakLijst = _persistController.getVak();
            _vakStudentRepository.VakStudentLijst = _persistController.getVakStudent();
            _vakStudiejaarRepository.VakStudiejaarLijst = _persistController.getVakStudiejaar();
        }

        public List<Student> GetStudents()
        {
            return _studentRepository.StudentLijst;
        }
        public void addStudent(Student student)
        {
            _persistController.addStudent(student);
            _studentRepository.StudentLijst = _persistController.getStudent();
        }
        public void removeStudent(int id)
        {
            _persistController.removeStudent(id);
            _studentRepository.StudentLijst = _persistController.getStudent();
        }
        public void AdjustStudent(Student student,  int id)
        {
            _persistController.adjustStudent(student, id);
            _studentRepository.StudentLijst = _persistController.getStudent();
        }

            public List<StudentStudierichting> GetStudentStudierichtings()
            {
                return _studentStudierichtingRepository.StudentStudierichtingLijst;
            }
            public void addStudentStudierichting(StudentStudierichting studentstudierichting)
            {
                _persistController.addStudentStudierichting(studentstudierichting);
                _studentStudierichtingRepository.StudentStudierichtingLijst = _persistController.getStudentStudierichting();
            }
            public void AdjustStudentStudierichting(StudentStudierichting studentstudierichting, int id)
            {
                _persistController.adjustStudentStudierichting(studentstudierichting, id);
                _studentStudierichtingRepository.StudentStudierichtingLijst = _persistController.getStudentStudierichting();
            }

        public List<Studiejaar> GetStudiejaars()
        {
            return _studiejaarRepository.StudiejaarLijst;
        }
        public void addStudiejaar(Studiejaar studiejaar)
        {
            _persistController.addStudiejaar(studiejaar);
            _studiejaarRepository.StudiejaarLijst = _persistController.getStudiejaar();
        }

            public List<Studierichting> GetStudierichtings()
            {
                return _studierichtingRepository.StudierichtingLijst;
            }
            public void addStudierichting(Studierichting studierichting)
            {
                _persistController.addStudierichting(studierichting);
                _studierichtingRepository.StudierichtingLijst = _persistController.getStudierichting();
            }
            public void removeStudierichting(int id)
            {
                _persistController.removeStudierichting(id);
                _studierichtingRepository.StudierichtingLijst = _persistController.getStudierichting();
            }
            public void AdjustStudierichting(Studierichting studierichting, int id)
            {
                _persistController.adjustStudierichting(studierichting, id);
                _studierichtingRepository.StudierichtingLijst = _persistController.getStudierichting();
            }

        public List<Vak> GetVaks()
        {
            return _vakRepository.VakLijst;
        }
        public void addVak(Vak vak)
        {
            _persistController.addVak(vak);
            _vakRepository.VakLijst = _persistController.getVak();
        }
        public void removeVak(int id)
        {
            _persistController.removeVak(id);
            _vakRepository.VakLijst = _persistController.getVak();
        }
        public void AdjustVak(Vak vak, int id)
        {
            _persistController.adjustVak(vak, id);
            _vakRepository.VakLijst = _persistController.getVak();
        }

            public List<VakStudent> GetVakStudents()
            {
                return _vakStudentRepository.VakStudentLijst;
            }
            public void addVakStudent(VakStudent vakstudent)
            {
                _persistController.addVakStudent(vakstudent);
                _vakStudentRepository.VakStudentLijst = _persistController.getVakStudent();
            }
            public void removeVakstudent(int idvak, int idgebruiker)
            {
                _persistController.removeVakStudent(idvak, idgebruiker);
                _vakStudentRepository.VakStudentLijst = _persistController.getVakStudent();
            }

        public List<VakStudiejaar> GetVakStudiejaars()
        {
            return _vakStudiejaarRepository.VakStudiejaarLijst;
        }
        public void addVakStudiejaar(VakStudiejaar vakstudiejaar)
        {
            _persistController.addVakStudiejaar(vakstudiejaar);
            _vakStudiejaarRepository.VakStudiejaarLijst = _persistController.getVakStudiejaar();
        }
        public void removeVakStudiejaar(int idvak, int idstudiejaar)
        {
            _persistController.removeVakStudiejaar(idvak, idstudiejaar);
            _vakStudiejaarRepository.VakStudiejaarLijst = _persistController.getVakStudiejaar();
        }

        public Student getStudentLogIn(string naam, string wachtwoord)
        {
            Student _ingelogdeStudent = _studentRepository.getStudentLogIn(naam, wachtwoord);
            return _ingelogdeStudent;
        }
    }
}
