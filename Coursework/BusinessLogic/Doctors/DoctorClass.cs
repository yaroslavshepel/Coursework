namespace BusinessLogic.Doctors;

public class DoctorClass
{
    private string _doctorId = "";
    private string _name = "";
    private string _surname = "";
    private string _specialization = "";
    private string _phoneNumber = "";
    private List<DateTime> _availableHours = new List<DateTime>();

    public string DoctorId { get => _doctorId; set => _doctorId = value; }
    public string Name { get => _name; set => _name = value; }
    public string Surname { get => _surname; set => _surname = value; }
    public string Specialization { get => _specialization; set => _specialization = value; }
    public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
    public List<DateTime> AvailableHours { get => _availableHours; set => _availableHours = value; }

    public DoctorClass(){}
    
    public DoctorClass(string doctorId, string name, string surname, string specialization, string phoneNumber, List<DateTime> availableHours)
    {
        _doctorId = doctorId;
        _name = name;
        _surname = surname;
        _specialization = specialization;
        _phoneNumber = phoneNumber;
        _availableHours = availableHours;
    }

    public static List<DateTime> GenerateDefaultAvailableHours()
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
       if (_availableHours.Count > 0)
       {
            string hours = "";

            for (int i = 0; i < _availableHours.Count - 1; i++)
            {
                hours += $"{_availableHours[i]}, \n";
            }

            hours += $"{_availableHours.Last()}.\n";
            return hours;
       }
       return "No available hours.";
    }
}