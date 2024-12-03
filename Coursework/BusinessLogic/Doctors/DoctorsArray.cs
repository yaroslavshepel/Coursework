namespace BusinessLogic.Doctors;

public class DoctorsArray
{
    private static int _numberOfDoctors;
    private static List<DoctorClass> _doctors = new();
    
    public static int NumberOfDoctors { get => _numberOfDoctors; set => _numberOfDoctors = value; }
    public static List<DoctorClass> Doctors { get => _doctors; set => _doctors = value; }
    
    public static void AddDoctor(string name, string surname, string specialization, string phoneNumber, List<DateTime> availableHours)
    {
        string doctorId = _doctors.Last().DoctorId;
        string doctorIdTrimmed = doctorId.Trim('D');
        int doctorIdNumber = int.Parse(doctorIdTrimmed);
        int anotherNum = 00;
        if (doctorIdNumber >= 10)
        {
            anotherNum = 0;
        }
        string newDoctorId = $"D{anotherNum}{doctorIdNumber + 1}";
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
    
    
}