namespace BusinessLogic.Doctors;

public class DoctorClass
{
    private int _doctorId = 0;
    private string _name = "";
    private string _surname = "";
    private string _specialization = "";
    private string _phoneNumber = "";
    
    public int DoctorId { get => _doctorId; set => _doctorId = value; }
    public string Name { get => _name; set => _name = value; }
    public string Surname { get => _surname; set => _surname = value; }
    public string Specialization { get => _specialization; set => _specialization = value; }
    public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
    
    public DoctorClass(int doctorId, string name, string surname, string specialization, string phoneNumber)
    {
        DoctorId = doctorId;
        Name = name;
        Surname = surname;
        Specialization = specialization;
        PhoneNumber = phoneNumber;
    }
    
    public DoctorClass EditDoctor(int doctorId, string name, string surname, string specialization, string phoneNumber)
    {
        DoctorId = doctorId;
        Name = name;
        Surname = surname;
        Specialization = specialization;
        PhoneNumber = phoneNumber;
        return new DoctorClass(doctorId, name, surname, specialization, phoneNumber);
    }
}