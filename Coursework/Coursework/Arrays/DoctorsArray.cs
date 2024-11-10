namespace Coursework.Arrays;
using MainClasses;
using Coursework;

public class DoctorsArray
{
    private int _numberOfDoctors { get; set; }
    private static List<DoctorClass> _doctors = new List<DoctorClass>();

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

    public DoctorsArray EditDoctor(DoctorClass doctor, string name, string surname, string specialization, string phoneNumber)
    {
        doctor.EditDoctor(name, surname, specialization, phoneNumber);
        return this;
    }

    public List<DoctorClass> GetDoctors()
    {
        return _doctors;
    }
}