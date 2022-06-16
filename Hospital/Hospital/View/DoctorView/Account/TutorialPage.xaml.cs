using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.View.DoctorView.Account
{
    public partial class TutorialPage : Page
    {
        public TutorialPage()
        {
            InitializeComponent();
            var sep = Path.DirectorySeparatorChar;
            var path = AppContext.BaseDirectory + ".." + sep + ".." + sep + "View" + sep +
                       "DoctorView" + sep + "Resources" + sep + "tutorial.mp4";
            MessageBox.Show(path);
            VideoMediaElement.Source = new Uri(path);
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.GoBack();
        }
    }
}