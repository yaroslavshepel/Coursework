namespace Coursework.Arrays;
using MainClasses;

public class PatientsArray
{
    // public static int NumberOfPatients { get; set; }
    private static readonly List<PatientClass> _patients = new List<PatientClass>();
    
    public PatientsArray() { }
    
    public static void AddPatient(PatientClass patient)
    {
        _patients.Add(patient);
        //return this;
    }
    
    public PatientsArray RemovePatient(PatientClass patient)
    {
        _patients.Remove(patient);
        return this;
    }
    
    public static List<PatientClass> GetPatients()
    {
        return _patients;
    }
    
    public static int GetNumberOfPatients()
    {
        return _patients.Count;
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
