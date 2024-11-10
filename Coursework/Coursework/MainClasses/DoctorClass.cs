namespace Coursework.MainClasses;

public class DoctorClass
{
    private string _name {get; set;}
    private string _surname {get; set;}
    private string _specialization {get; set;}
    private string _phoneNumber {get; set;}
    
    DoctorClass() { }
    
    public DoctorClass(string name, string surname, string specialization, string phoneNumber)
    {
        _name = name;
        _surname = surname;
        _specialization = specialization;
        _phoneNumber = phoneNumber;
    }
    
    public DoctorClass EditDoctor(string name, string surname, string specialization, string phoneNumber)
    {
        _name = name;
        _surname = surname;
        _specialization = specialization;
        _phoneNumber = phoneNumber;
        return this;
    }
}