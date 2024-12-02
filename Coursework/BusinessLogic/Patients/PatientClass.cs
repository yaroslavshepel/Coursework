using BusinessLogic.MedicalRecords;

namespace BusinessLogic.Patients;

public class PatientClass
{
    private string _patientId;
    private string _name;
    private string _surname;
    private string _address;
    private string _phoneNumber;
    private string _email;
    //private string _medicalRecord;
    private MedicalRecordClass _medicalRecord;
    
    public string PatientId { get => _patientId; set => _patientId = value; }
    public string Name { get => _name; set => _name = value; }
    public string Surname { get => _surname; set => _surname = value; }
    public string Address { get => _address; set => _address = value; }
    public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
    public string Email { get => _email; set => _email = value; }
    //public string MedicalRecord { get => _medicalRecord; set => _medicalRecord = value; }
    public MedicalRecordClass MedicalRecord { get => _medicalRecord; set => _medicalRecord = value; }

    public PatientClass(string patientId, string name, string surname, string address, string phoneNumber, string email, MedicalRecordClass medicalRecord)
    {
        _patientId = patientId;
        _name = name;
        _surname = surname;
        _address = address;
        _phoneNumber = phoneNumber;
        _email = email;
        _medicalRecord = medicalRecord;
    }

    public void EditPatient(string name, string surname, string address, string phoneNumber, string email, MedicalRecordClass medicalRecord)
    {
        _name = name;
        _surname = surname;
        _address = address;
        _phoneNumber = phoneNumber;
        _email = email;
        _medicalRecord = medicalRecord;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Surname: {Surname}, Address: {Address}, Phone Number: {PhoneNumber}, Email: {Email}, Medical Record: {MedicalRecord}";
    }
}