using Hospital.Controller;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DataVis = System.Windows.Forms.DataVisualization;

namespace Hospital.View.ManagerView
{
    /// <summary>
    /// Interaction logic for SurveySelect.xaml
    /// </summary>
    public partial class SurveySelect : Window
    {

        private App _app;
        private readonly object _content;
        private DoctorSurveyResponseController DoctorSurveyResponseController;
        private HospitalSurveyResponse HospitalSurveyResponseController;
        public SurveySelect()
        {
            _app = Application.Current as App;
            this.WindowStartupLocation= WindowStartupLocation.CenterScreen;
            InitializeComponent();
            List<HospitalSurveyResponse>hospitalSurveyResponsesList = _app._hospitalSurveyResponseController.Read();
            ObservableCollection<HospitalSurveyResponse> hospitalSurveyResponses = new ObservableCollection<HospitalSurveyResponse>(hospitalSurveyResponsesList);
            ObservableCollection<int> gradeHospital = new ObservableCollection<int>();
            List<DoctorSurveyResponse> doctorSurveyResponsesList = _app._doctorSurveyResponseController.Read();
            ObservableCollection<DoctorSurveyResponse> doctorSurveyResponse = new ObservableCollection<DoctorSurveyResponse>(doctorSurveyResponsesList);
            ObservableCollection<int> grade = new ObservableCollection<int>();
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            double avg = 0;
            double sum = 0;
            int i = 0;
            foreach (DoctorSurveyResponse doctorSurveyResponseItem in doctorSurveyResponse)
            {
                i++;
                Chart1.Series[0].Points.Add(doctorSurveyResponseItem.Grade).AxisLabel = "";
                if (doctorSurveyResponseItem.Grade == 1)
                    num1 ++;
                if (doctorSurveyResponseItem.Grade == 2)
                    num2++;
                if (doctorSurveyResponseItem.Grade == 3)
                    num3++;
                if (doctorSurveyResponseItem.Grade == 4)
                    num4++;
                if (doctorSurveyResponseItem.Grade == 5)
                    num5++;
                sum += doctorSurveyResponseItem.Grade;
            }

            avg = sum / i;
            this.jedinice.Text = num1.ToString();
            this.dvojke.Text = num2.ToString();
            this.trojke.Text = num3.ToString();
            this.cetvorke.Text = num4.ToString();
            this.petice.Text = num5.ToString();
            this.prosek.Text = avg.ToString("n2");


            int num12 = 0;
            int num22 = 0;
            int num32 = 0;
            int num42 = 0;
            int num52 = 0;
            double avg2 = 0;
            double sum2 = 0;
            int j = 0;
            foreach (HospitalSurveyResponse hospitalSurveyResponseItem in hospitalSurveyResponses)
            {
                j++;
                Chart2.Series[0].Points.Add(hospitalSurveyResponseItem.Grade).AxisLabel = "";

                if (hospitalSurveyResponseItem.Grade == 1)
                    num12++;
                if (hospitalSurveyResponseItem.Grade == 2)
                    num22++;
                if (hospitalSurveyResponseItem.Grade == 3)
                    num32++;
                if (hospitalSurveyResponseItem.Grade == 4)
                    num42++;
                if (hospitalSurveyResponseItem.Grade == 5)
                    num52++;
                sum2 += hospitalSurveyResponseItem.Grade;
            }
            _content = Content;
            avg2 = sum2 / j;

            this.jediniceHospital.Text = num12.ToString();
            this.dvojkeHospital.Text = num22.ToString();
            this.trojkeHospital.Text = num32.ToString();
            this.cetvorkeHospital.Text = num42.ToString();
            this.peticeHospital.Text = num52.ToString();
            this.prosekHospital.Text = avg2.ToString("n2");

        }



        private void EquipmentClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.EquipmentWindow equipmentWindow = new View.ManagerView.EquipmentWindow(_app._equipmentController);
            equipmentWindow.Show();
            Close();
        }
        private void RoomClick(object sender, RoutedEventArgs e)
        {

            View.ManagerView.ManagerWindow roomWindow = new View.ManagerView.ManagerWindow(_app._roomController);
            roomWindow.Show();
            Close();
        }

        private void OccupancyClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.RoomOccupancy roomOccupancy = new View.ManagerView.RoomOccupancy(_app._appointmentController, _app._roomController);
            roomOccupancy.Show();
            Close();
        }
        private void HomeClick(object sender, RoutedEventArgs e)
        {
            View.ManagerView.ManagerHomeWindow managerHomeWindow = new ManagerHomeWindow();
            managerHomeWindow.Show();
            Close();
        }
        private void MedicineClick(object sender, RoutedEventArgs e)
        {
            MedicineWindow medicine = new MedicineWindow(_app._medicineController);
            medicine.Show();
            Close();
        }
        public void BackToHomeWindow()
        {
            Content = _content;
        }

        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            Close();
        }
        private void SurveyClick(object sender, RoutedEventArgs e)
        {
            SurveySelect surveySelect = new SurveySelect();
            surveySelect.Show();
            Close();
        }
    }
}
