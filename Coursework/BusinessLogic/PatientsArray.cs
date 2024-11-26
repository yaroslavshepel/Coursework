namespace BusinessLogic;
//using MainClasses;

public class PatientsArray
{
    // public static int NumberOfPatients { get; set; }
    private static readonly List<PatientClass> Patients = new List<PatientClass>();
    
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
    
    public static List<PatientClass> GetPatients()
    {
        return Patients;
    }
    
    public static int GetNumberOfPatients()
    {
        return Patients.Count;
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
