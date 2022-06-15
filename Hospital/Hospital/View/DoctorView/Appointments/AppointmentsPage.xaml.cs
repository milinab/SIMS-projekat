using System.Windows;
using System.Windows.Media;
using Syncfusion.SfSkinManager;
using Syncfusion.Themes.FluentDark.WPF;
using Syncfusion.UI.Xaml.Scheduler;

namespace Hospital.View.DoctorView.Appointments
{
    /// <summary>
    /// Interaction logic for AppointmentsPage.xaml
    /// </summary>
    public partial class AppointmentsPage
    {
        public AppointmentsPage()
        {
            FluentDarkThemeSettings themeSettings = new FluentDarkThemeSettings();
            var sfScheduler = new SfScheduler();
            // ReSharper disable PossibleNullReferenceException
            var primaryColor = (Color)ColorConverter.ConvertFromString("#9FA8DA");
            var themeColor = (Color)ColorConverter.ConvertFromString("#121212");
            themeSettings.PrimaryBackground = new SolidColorBrush(primaryColor);
            themeSettings.PrimaryForeground = new SolidColorBrush(themeColor);
            themeSettings.BodyFontSize = 15;
            themeSettings.HeaderFontSize = 18;
            themeSettings.SubHeaderFontSize = 17;
            themeSettings.TitleFontSize = 17;
            themeSettings.SubTitleFontSize = 16;
            themeSettings.BodyAltFontSize = 15;
            themeSettings.FontFamily = new FontFamily("Roboto");
            SfSkinManager.RegisterThemeSettings("FluentDark", themeSettings);
            SfSkinManager.SetTheme(sfScheduler, new Theme
            {
                ThemeName = "FluentDark", 
                ScrollBarMode = ScrollBarMode.Compact
            });
            InitializeComponent();
        }
        
        /// <summary>
        /// Sets custom page for Appointment editing
        /// </summary>
        private void AppointmentsCalendar_OnAppointmentEditorOpening(object sender, AppointmentEditorOpeningEventArgs e)
        {
            e.Cancel = true;
            var date = e.DateTime;
            var app = Application.Current as App;
            // ReSharper disable once PossibleNullReferenceException
            foreach (var appointment in app?._appointmentController.Read())
            {
                if (appointment.Date == date)
                {
                    MainWindow.MainFrame.Navigate(new Edit(appointment));
                }
            }
        }

        /// <summary>
        /// Disables Appointment dragging
        /// </summary>
        private void AppointmentsCalendar_OnAppointmentDragStarting(object sender, AppointmentDragStartingEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// Disables Appointment resizing
        /// </summary>
        private void AppointmentsCalendar_OnAppointmentResizing(object sender, AppointmentResizingEventArgs e)
        {
            e.CanContinueResize = false;
        }
    }
}
