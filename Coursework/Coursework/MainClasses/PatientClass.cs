namespace Coursework.MainClasses;

public class PatientClass
{
    private string _name { get; set; }
    private string _surname { get; set; }
    private string _address { get; set; }
    private string _phoneNumber { get; set; }
    private string _email { get; set; }
    private string _medicalRecord { get; set; }
    
    public PatientClass() { }
    
    public PatientClass(string name, string surname, string address, string phoneNumber, string email, string medicalRecord)
    {
        _name = name;
        _surname = surname;
        _address = address;
        _phoneNumber = phoneNumber;
        _email = email;
        _medicalRecord = medicalRecord;
    }
    
    public PatientClass AddPatient(string name, string surname, string address, string phoneNumber, string email, string medicalRecord)
    {
        return new PatientClass(name, surname, address, phoneNumber, email, medicalRecord);
    }
    
    //TODO: Implement ElectronicMedicalRecord method
    //!public PatientClass ElectronicMedicalRecord()
}