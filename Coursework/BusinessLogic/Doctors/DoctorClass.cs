// namespace BusinessLogic.Doctors;
//
// public class DoctorClass
// {
//     private string _doctorId = "";
//     private string _name = "";
//     private string _surname = "";
//     private string _specialization = "";
//     private string _phoneNumber = "";
//     
//     public string DoctorId { get => _doctorId; set => _doctorId = value; }
//     public string Name { get => _name; set => _name = value; }
//     public string Surname { get => _surname; set => _surname = value; }
//     public string Specialization { get => _specialization; set => _specialization = value; }
//     public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
//     
//     public DoctorClass(string doctorId, string name, string surname, string specialization, string phoneNumber)
//     {
//         DoctorId = doctorId;
//         Name = name;
//         Surname = surname;
//         Specialization = specialization;
//         PhoneNumber = phoneNumber;
//     }
//     
//     public DoctorClass EditDoctor(string doctorId, string name, string surname, string specialization, string phoneNumber)
//     {
//         DoctorId = doctorId;
//         Name = name;
//         Surname = surname;
//         Specialization = specialization;
//         PhoneNumber = phoneNumber;
//         return new DoctorClass(doctorId, name, surname, specialization, phoneNumber);
//     }
// }

namespace BusinessLogic.Doctors;

public class DoctorClass
{
    private string _doctorId = "";
    private string _name = "";
    private string _surname = "";
    private string _specialization = "";
    private string _phoneNumber = "";
    private List<DateTime> _availableHours;

    public string DoctorId { get => _doctorId; set => _doctorId = value; }
    public string Name { get => _name; set => _name = value; }
    public string Surname { get => _surname; set => _surname = value; }
    public string Specialization { get => _specialization; set => _specialization = value; }
    public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
    public List<DateTime> AvailableHours { get => _availableHours; set => _availableHours = value; }

    public DoctorClass(string doctorId, string name, string surname, string specialization, string phoneNumber, List<DateTime> availableHours)
    {
        _doctorId = doctorId;
        _name = name;
        _surname = surname;
        _specialization = specialization;
        _phoneNumber = phoneNumber;
        _availableHours = availableHours;
    }
    // {
    //     _doctorId = doctorId;
    //     _name = name;
    //     _surname = surname;
    //     _specialization = specialization;
    //     _phoneNumber = phoneNumber;
    //     _availableHours = GenerateDefaultAvailableHours();
    // }

    public List<DateTime> GenerateDefaultAvailableHours()
    {
        var hours = new List<DateTime>();
        DateTime start = DateTime.Today.AddHours(8);
        DateTime end = DateTime.Today.AddHours(12);
        while (start < end)
        {
            hours.Add(start);
            start = start.AddMinutes(30);
        }
        return hours;
    }

    public void AddAvailableHour(DateTime hour)
    {
        _availableHours.Add(hour);
    }

    public void RemoveAvailableHour(DateTime hour)
    {
        _availableHours.Remove(hour);
    }
    
    public DoctorClass EditDoctor(string doctorId, 
    string name, string surname, string specialization, string phoneNumber, List<DateTime> availableHours)
    {
        _doctorId = doctorId;
        _name = name;
        _surname = surname;
        _specialization = specialization;
        _phoneNumber = phoneNumber;
        _availableHours = availableHours;
        return new DoctorClass(doctorId, name, surname, specialization, phoneNumber, availableHours);
    }
    
    public string GetAvailableHours()
    {
        string hours = "";
        foreach (var hour in _availableHours)
        {
            hours += $"{hour}, \n";
        }
        return hours;
    }
}