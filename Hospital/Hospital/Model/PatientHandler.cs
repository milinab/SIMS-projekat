using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.Model
{
    public class PatientHandler
   {

      public PatientHandler()
        {
            Patients = new ObservableCollection<Patient>();
        }
      public Patient ReadById(int id)
      {
            foreach (var patient in Patients)
            {
                if (patient.Id == id)
                {
                    return patient;
                }
            }
            return null;
        }
      
      public void Create(Patient newPatient)
      {
            Patients.Add(newPatient);
        }
      
      public void Edit(Patient newPatient)
      {
            var found = Patients.FirstOrDefault(x => x.IdNumber == newPatient.IdNumber);
            Patients.Remove(found);
            Create(newPatient);
        }
      
      public void Delete(Patient newPatient)
      {
            if (newPatient != null)
            {
                Patients.Remove(newPatient);
            }
        }

      public ObservableCollection<Patient> ReadAll()
            {
                return Patients;
            }

      public PatientFileHandler patientFileHandler { get; set; }

      private ObservableCollection<Patient> Patients;

    }
}