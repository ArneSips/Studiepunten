using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Studiepunten_Domain.Business;

namespace Tijdelijke_WPF_GIP
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private Controller _controller;
        public Register()
        {
            InitializeComponent();
            _controller = new Controller();
        }

        private void BtnRegisterAccount_Click(object sender, RoutedEventArgs e)
        {
            string naam = "";
            string wachtwoord = "";

            try
            {
                naam = txtRegisterNaam.Text;
                wachtwoord = txtRegisterWachtwoord.Password;
            }
            finally
            {
                Student student = new Student(naam, wachtwoord);
                _controller.addStudent(student);
            }
            MainWindow mainwindow = new MainWindow();
            Register_Window.Close();
            mainwindow.Show();

     
        }
    }
}
