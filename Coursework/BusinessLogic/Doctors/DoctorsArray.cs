namespace BusinessLogic.Doctors;

public class DoctorsArray
{
    private static int _numberOfDoctors;
    private static List<DoctorClass> _doctors = new();
    
    public static int NumberOfDoctors { get => _numberOfDoctors; set => _numberOfDoctors = value; }
    public static List<DoctorClass> Doctors { get => _doctors; set => _doctors = value; }
    
    public static void AddDoctor(string name, string surname, string specialization, string phoneNumber, List<DateTime> availableHours)
    {
        string newDoctorId = "";
        if (_doctors.Count == 0)
        {
            newDoctorId = "D001";
        }
        else
        {
            string doctorId = _doctors.Last().DoctorId;
            string doctorIdTrimmed = doctorId.Trim('D');
            int doctorIdNumber = int.Parse(doctorIdTrimmed);
            
            if (doctorIdNumber < 10)
            {
                newDoctorId = $"D00{doctorIdNumber + 1}";
            } else if (doctorIdNumber < 100)
            {
                newDoctorId = $"D0{doctorIdNumber + 1}";
            }
            else if (doctorIdNumber < 1000)
            {
                newDoctorId = $"D{doctorIdNumber + 1}";
            }
        }
        Doctors.Add(new DoctorClass(newDoctorId, name, surname, specialization, phoneNumber, availableHours));
        _numberOfDoctors++;
    }

    public static void RemoveDoctor(DoctorClass doctor)
    {
        Doctors.Remove(doctor);
        _numberOfDoctors--;
    }

    public static List<DoctorClass> GetDoctors()
    {
        return Doctors;
    }
    public static DoctorClass? FindDoctorByName(string name, string surname)
    {
        return _doctors.FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && d.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));
    }
}