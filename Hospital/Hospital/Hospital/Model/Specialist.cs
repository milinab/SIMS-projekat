using System;

namespace Hospital.Model
{
    public enum SpecializationType
    {
        AllergyAndImmunology,
        Anesthesiology,
        Dermatology,
        DiagnosticRadiology,
        EmergencyMedicine,
        FamilyMedicine,
        InternalMedicine,
        MedicalGenetics,
        Neurology,
        NuclearMedicine,
        ObstetricsAndGynecology,
        Ophthalmology,
        Pathology,
        Pediatrics,
        PhysicalMedicineAndRehabilitation,
        PreventiveMedicine,
        Psychiatry,
        RadiationOncology,
        Surgery,
        Urology
    }
   public class Specialist : Doctor
   {
      public SpecializationType Specialization;
   
   }
}