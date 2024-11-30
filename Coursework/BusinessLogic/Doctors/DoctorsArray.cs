namespace BusinessLogic.Doctors;

public class DoctorsArray
{
    private static int _numberOfDoctors;
    private static List<DoctorClass> _doctors = new();
    
    public static List<DoctorClass> Doctors { get => _doctors; set => _doctors = value; }
    public static int NumberOfDoctors { get => _numberOfDoctors; set => _numberOfDoctors = value; }
    
    public static void AddDoctor(string name, string surname, string specialization, string phoneNumber)
    {
        //DoctorClass doctorTmp = _doctors.Last();
        
        //int doctorId = _doctors.Last().DoctorId + 1;
        Doctors.Add(new DoctorClass(_doctors.Last().DoctorId + 1, name, surname, specialization, phoneNumber));
        _numberOfDoctors++;
    }

    public static void RemoveDoctor(DoctorClass doctor)
    {
        Doctors.Remove(doctor);
        _numberOfDoctors--;
    }

    /*public static void EditDoctor(DoctorClass doctor, string name, string surname, string specialization, string phoneNumber)
    {
        doctor.Name = name;
        doctor.Surname = surname;
        doctor.Specialization = specialization;
        doctor.PhoneNumber = phoneNumber;
    }

    public static DoctorClass FindDoctor(string name, string surname)
    {
        return Doctors.Find(doctor => doctor.Name == name && doctor.Surname == surname) 
               ?? throw new Exception();
    }*/

    public static List<DoctorClass> GetDoctors()
    {
        return Doctors;
    }
    
    
}