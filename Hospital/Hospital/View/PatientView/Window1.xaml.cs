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

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private readonly object _content;
        public Window1()
        {
            InitializeComponent();
            _content = Content;
        }

        private void AppointmentsClick(object sender, RoutedEventArgs e)
        {
            PatientWindow appointmentsPage = new PatientWindow(this);
            Content = appointmentsPage;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void BackToWindow()
        {
            Content = _content;
        }
    }
}
