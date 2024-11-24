namespace Coursework.Arrays;
using MainClasses;
using Coursework;

public class DoctorsArray
{
    private static int _numberOfDoctors { get; set; }
    public static List<DoctorClass> _doctors = new List<DoctorClass>();

    //public DoctorsArray() { }

    // public static void AddDoctor(DoctorClass doctor)
    // {
    //     _doctors.Add(doctor);
    // }
    
    public static DoctorClass AddDoctor(string name, string surname, string specialization, string phoneNumber)
    {
        return new DoctorClass(name, surname, specialization, phoneNumber);
    }

    public static void RemoveDoctor(DoctorClass doctor)
    {
        _doctors.Remove(doctor);
    }

    public static void EditDoctor(DoctorClass doctor, string name, string surname, string specialization, string phoneNumber)
    {
        doctor.Name = name;
        doctor.Surname = surname;
        doctor.Specialization = specialization;
        doctor.PhoneNumber = phoneNumber;
    }

    public static List<DoctorClass> GetDoctors()
    {
        return _doctors;
    }
    
    public static void SetNumberOfDoctors(int number)
    {
        _numberOfDoctors = number;
        //return _numberOfDoctors;
    }
    
    public static int GetNumberOfDoctors()
    {
        return _numberOfDoctors;
    }
}