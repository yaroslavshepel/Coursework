namespace Coursework.Arrays;
using MainClasses;
using Coursework;

public class DoctorsArray
{
    private int _numberOfDoctors { get; set; }
    private static readonly List<DoctorClass> _doctors = new List<DoctorClass>();

    public DoctorsArray() { }

    public static void AddDoctor(DoctorClass doctor)
    {
        _doctors.Add(doctor);
        //return;
    }

    public static void RemoveDoctor(DoctorClass doctor)
    {
        _doctors.Remove(doctor);
        //return this;
    }

    public static void EditDoctor(DoctorClass doctor, string name, string surname, string specialization, string phoneNumber)
    {
        //doctor.EditDoctor(name, surname, specialization, phoneNumber);
        doctor.Name = name;
        doctor.Surname = surname;
        doctor.Specialization = specialization;
        doctor.PhoneNumber = phoneNumber;
        
    }

    public static List<DoctorClass> GetDoctors()
    {
        return _doctors;
    }
}