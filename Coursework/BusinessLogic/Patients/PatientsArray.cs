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
        string newPatientId = "";
        if (_numberOfPatients == 0)
        {
            newPatientId = "P001";
        }
        else
        {
            string patientId = _patients.Last().PatientId;
            string patientIdTrimmed = patientId.Trim('P');
            int patientIdNumber = int.Parse(patientIdTrimmed);
            
            if (patientIdNumber < 10)
            {
                newPatientId = $"P00{patientIdNumber + 1}";
            } else if (patientIdNumber < 100)
            {
                newPatientId = $"P0{patientIdNumber + 1}";
            }
            else if (patientIdNumber < 1000)
            {
                newPatientId = $"P{patientIdNumber + 1}";
            }
        }
        _patients.Add(new PatientClass(newPatientId, name, surname, address, phoneNumber, email, medicalRecord));
        _numberOfPatients++;
    }
    
    public static void RemovePatient(PatientClass patient)
    {
        _patients.Remove(patient);
        _numberOfPatients--;
    }
    
    public static PatientClass? FindPatientByName(string name, string surname)
    {
        return _patients.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && p.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));
    }
}
