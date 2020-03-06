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
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        Controller _controller;
        public Info()
        {
            InitializeComponent();
            _controller = new Controller();
            lbxVak.ItemsSource = _controller.GetVaks();
            lbxStudierichtingStudiejaar.ItemsSource = _controller.GetStudierichtings();
            lbxStudierichtingStudiejaar.ItemsSource = _controller.GetStudiejaars();
        }

        private void BtnVak_Click(object sender, RoutedEventArgs e)
        {
            Vak vak = new Vak(txtVak.Text, Convert.ToInt32(txtUren), Convert.ToInt32(txtPunten.Text));
            _controller.addVak(vak);
            lbxVak.ItemsSource = _controller.GetVaks();
            lbxVak.Items.Refresh();
        }

        private void BtnStudierichting_Click(object sender, RoutedEventArgs e)
        {
            Studierichting studierichting = new Studierichting(Convert.ToString(cbxStudierichting.SelectedItem));
            Studiejaar studiejaar = new Studiejaar(Convert.ToString(cbxStudiejaar.SelectedItem));
            _controller.addStudierichting(studierichting);
            _controller.addStudiejaar(studiejaar);
            lbxStudierichtingStudiejaar.ItemsSource = _controller.GetStudierichtings();
            lbxStudierichtingStudiejaar.ItemsSource = _controller.GetStudiejaars();
            lbxStudierichtingStudiejaar.Items.Refresh();

        }
    }
}
