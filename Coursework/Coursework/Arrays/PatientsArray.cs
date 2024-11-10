namespace Coursework.Arrays;
using MainClasses;

public class PatientsArray
{
    public int NumberOfPatients { get; set; }
    public static List<PatientClass> Patients { get; set; }
    
    public PatientsArray() { }
    
    public static void AddPatient(PatientClass patient)
    {
        Patients.Add(patient);
        //return this;
    }
    
    public PatientsArray RemovePatient(PatientClass patient)
    {
        Patients.Remove(patient);
        return this;
    }
    //TODO: Implement the following methods
    //! public PatientsArray ElectronicMedicalRecord(PatientClass patient)
    // {
    //     patient.ElectronicMedicalRecord();
    //     return this;
    // }
    
    // public PatientsData MakeAppointment(PatientClass patient, DoctorClass doctor, DateTime date)
    // {
    //     patient.MakeAppointment(doctor, date);
    //     return this;
    // }
}
