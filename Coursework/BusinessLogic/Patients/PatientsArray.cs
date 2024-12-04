using BusinessLogic.MedicalRecords;

namespace BusinessLogic.Patients;

public class PatientsArray
{
    private static int _numberOfPatients;
    private static List<PatientClass> _patients = new();
    
    public static List<PatientClass> Patients { get => _patients; set => _patients = value; }
    
    public static int NumberOfPatients { get => _numberOfPatients; set => _numberOfPatients = value; }
    
    public static void AddPatient(string name, string surname, string address, string phoneNumber, string email, MedicalRecordClass medicalRecord)
    {
        string patientId = _patients.Last().PatientId;
        string patientIdTrimmed = patientId.Trim('P');
        int patientIdNumber = int.Parse(patientIdTrimmed);
        int anotherNum = 00;
        if (patientIdNumber >= 10)
        {
            anotherNum = 0;
        }
        string newPatientId = $"P{anotherNum}{patientIdNumber + 1}";
        _patients.Add(new PatientClass(newPatientId, name, surname, address, phoneNumber, email, medicalRecord));
        _numberOfPatients++;
    }
    
    public static void RemovePatient(PatientClass patient)
    {
        _patients.Remove(patient);
        _numberOfPatients--;
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
