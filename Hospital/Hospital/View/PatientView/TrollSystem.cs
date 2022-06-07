using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.View.PatientView
{
    internal class TrollSystem
    {
        PatientWindow _patientWindow;
        App app;

        public TrollSystem(PatientWindow _patientWindow, App app) {
            this._patientWindow = _patientWindow;
            this.app = app;
        }

        public void troll() {

            Trol troll = app._trolController.ReadByPatientId(_patientWindow.patient.Id);
            if (troll == null) {
                createTroll(_patientWindow.patient.Id, DateTime.Now, 1, app);
            }
            else {
                if ((DateTime.Now - troll.StartDate).TotalDays < 30) {
                    increaseNumberOfCancelation(troll);
                } else {
                    deleteTrollPastDate(troll);
                }
            }

        }

        private void createTroll(int patientId, DateTime date, int counter, App app) {

            Trol tr = new Trol(patientId, date, counter);
            app._trolController.Create(tr);
        }

        private void deleteTrollPastDate(Trol troll) {

            app._trolController.Delete(troll.Id);
            Trol tr = new Trol(_patientWindow.patient.Id, DateTime.Now, 1);
            app._trolController.Create(tr);
        }

        private void increaseNumberOfCancelation(Trol troll) {

            troll.NumberOfCancellations += 1;
            app._trolController.Edit(troll);

            checkNumberOfCancelation(troll);

        }

        private void checkNumberOfCancelation(Trol troll) {

            Trol newTroll = app._trolController.ReadById(troll.Id);
            if (newTroll.NumberOfCancellations >= 5) {
                _patientWindow.patient.IsActive = false;

                app._patientController.Edit(_patientWindow.patient);
                app._trolController.Delete(troll.Id);

                PopupNotification.sendPopupNotification("Warning", "Your account is banned due to..");
                logut();
            }

        }

        private void logut() {

            LogIn logIn = new LogIn();
            logIn.Show();
            _patientWindow.Close();
        }

    }
}
