namespace BusinessLogic;

public class DoctorsArray
{
    private static int _numberOfDoctors;
    public static List<DoctorClass> Doctors = new List<DoctorClass>();

    //public DoctorsArray() { }

    // public static void AddDoctor(DoctorClass doctor)
    // {
    //     _doctors.Add(doctor);
    // }
    
    public static void AddDoctor(string name, string surname, string specialization, string phoneNumber)
    {
        //return new DoctorClass(name, surname, specialization, phoneNumber);
        Doctors.Add(new DoctorClass(name, surname, specialization, phoneNumber));
    }

    public static void RemoveDoctor(DoctorClass doctor)
    {
        Doctors.Remove(doctor);
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
        return Doctors;
    }
    
    public static void SetNumberOfDoctors(int number)
    {
        _numberOfDoctors = number;
        //Doctors = new List<DoctorClass>(number);
        //return _numberOfDoctors;
    }
    
    public static int GetNumberOfDoctors()
    {
        return _numberOfDoctors;
    }
}