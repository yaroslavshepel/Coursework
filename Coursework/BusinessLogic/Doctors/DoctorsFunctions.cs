namespace BusinessLogic.Doctors;

public class DoctorsFunctions
{
    private static string _name = "";
    private static string _surname = "";
    private static string _specialization = "";
    private static string _phoneNumber = "";
    
    public static async Task AddDoctor()
    {
        Console.WriteLine("Adding a doctor.");
        _name = InputValidator.Validator("Enter the doctor's name: ", "name", "data");
        _surname = InputValidator.Validator("Enter the doctor's surname: ", "surname", "data");
        _specialization = InputValidator.Validator("Enter the doctor's specialization: ", "specialization", "data");
        _phoneNumber = InputValidator.Validator("Enter the doctor's phone number: ", "phone number", "phone number");
        
        DoctorsArray.AddDoctor(_name, _surname, _specialization, _phoneNumber);
        //DoctorsArray.SetNumberOfDoctors(DoctorsArray.GetNumberOfDoctors() + 1);
        //DoctorsArray.NumberOfDoctors++;
        Console.WriteLine("Doctor added successfully.");
    }
    
    public static void EditDoctor()
    {
        var doctors = DoctorsArray.Doctors;
        if (doctors.Count == 0) { Console.WriteLine("There are no doctors in the system."); return; }

        _name = InputValidator.Validator("Enter name of doctor to edit: ", "name", "data");
        _surname = InputValidator.Validator("Enter surname of doctor to edit: ", "surname", "data");

        DoctorClass doctor = doctors.Find(d => d.Name == _name && d.Surname == _surname);
                             //?? Console.WriteLine("Doctor not found."));
        if (doctor == null) { Console.WriteLine("Doctor not found."); return; }
        var newName = InputValidator.Validator("Enter the new name: ", "name", "data");
        var newSurname = InputValidator.Validator("Enter the new surname: ", "surname", "data");
        var newSpecialization = InputValidator.Validator("Enter the new specialization: ", "specialization", "data");
        var newPhoneNumber = InputValidator.Validator("Enter the new phone number: ", "phone number", "phone number");
        doctor.EditDoctor(doctor.DoctorId, newName, newSurname, newSpecialization, newPhoneNumber);
        Console.WriteLine("Doctor edited successfully.");
    }
    
    public static void RemoveDoctor()
    {
        //var doctors = DoctorsArray.GetDoctors();
        var doctors = DoctorsArray.Doctors;
        if (doctors.Count == 0)
        {
            Console.WriteLine("There are no doctors in the system.");
            return;
        }

        _name = InputValidator.Validator("Enter name of doctor to remove: ", "name", "data");
        _surname = InputValidator.Validator("Enter surname of doctor to remove: ", "surname", "data");

        var doctor = doctors.Find(d => d.Name == _name && d.Surname == _surname);
        if (doctor == null)
        {
            Console.WriteLine("Doctor not found.");
            return;
        }

        DoctorsArray.RemoveDoctor(doctor);
        //DoctorsArray.SetNumberOfDoctors(DoctorsArray.GetNumberOfDoctors() - 1);
        //DoctorsArray.NumberOfDoctors--;
        Console.WriteLine("Doctor removed successfully.");
    }
    
    public static void PrintDoctors()
    {
        //var doctors = DoctorsArray.GetDoctors();
        var doctors = DoctorsArray.Doctors;
        if (doctors.Count == 0) { Console.WriteLine("There are no doctors in the system."); return; }
        //for (int i = 0; i < DoctorsArray.GetNumberOfDoctors(); i++)
        for(int i = 0; i < DoctorsArray.NumberOfDoctors; i++)
        {
            Console.WriteLine($"ID: {doctors[i].DoctorId}, " +
                              $"Name: {doctors[i].Name}, " +
                              $"Surname: {doctors[i].Surname}, " +
                              $"Specialization: {doctors[i].Specialization}, " +
                              $"Phone Number: {doctors[i].PhoneNumber}");
        }
    }
}