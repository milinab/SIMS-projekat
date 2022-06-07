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

        public static void troll(PatientWindow _patientWindow, App app) {

            Trol troll = app._trolController.ReadByPatientId(_patientWindow.patient.Id);
            if (troll == null)
            {
                Trol tr = new Trol(_patientWindow.patient.Id, DateTime.Now, 1);
                app._trolController.Create(tr);
            }
            else
            {
                if ((DateTime.Now - troll.StartDate).TotalDays < 30)
                {
                    //ovo je okej, dozvoli
                    troll.NumberOfCancellations += 1;
                    app._trolController.Edit(troll);
                    Trol newTroll = app._trolController.ReadById(troll.Id);
                    if (newTroll.NumberOfCancellations >= 5)
                    {
                        _patientWindow.patient.IsActive = false;

                        app._patientController.Edit(_patientWindow.patient);
                        app._trolController.Delete(troll.Id);
                        PopupNotification.sendPopupNotification("Warning", "Your account is banned due to..");
                        LogIn logIn = new LogIn();
                        logIn.Show();
                        _patientWindow.Close();
                    }
                }
                else
                {
                    app._trolController.Delete(troll.Id);
                    Trol tr = new Trol(_patientWindow.patient.Id, DateTime.Now, 1);
                    app._trolController.Create(tr);
                }
            }

        } 

        
    }
}
