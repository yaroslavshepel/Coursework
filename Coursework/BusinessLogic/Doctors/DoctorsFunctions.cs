namespace BusinessLogic.Doctors;

public class DoctorsFunctions
{
    private static string _doctorId = "";
    private static string _name = "";
    private static string _surname = "";
    private static string _specialization = "";
    private static string _phoneNumber = "";
    private static List<DateTime> _hours = new();
    
    public static Task AddDoctor()
    {
        Console.WriteLine("Adding a doctor.");
        
        _name = InputValidator.Validator("Enter the doctor's name: ", "name", "data");
        _surname = InputValidator.Validator("Enter the doctor's surname: ", "surname", "data");
        _specialization = InputValidator.Validator("Enter the doctor's specialization: ", "specialization", "data");
        _phoneNumber = InputValidator.Validator("Enter the doctor's phone number: ", "phone number", "phone number");
        _hours = DoctorClass.GenerateDefaultAvailableHours();
        
        DoctorsArray.AddDoctor(_name, _surname, _specialization, _phoneNumber, _hours);
        Console.WriteLine("Doctor added successfully.");
        return Task.CompletedTask;
    }
    
    public static void EditDoctor()
    {
        var doctors = DoctorsArray.Doctors;
        if (doctors.Count == 0) { Console.WriteLine("There are no doctors in the system."); return; }
        
        PrintDoctors("task");
        
        _doctorId = InputValidator.Validator("Enter the doctor's ID: ", "ID", "ID");
        DoctorClass doctor = doctors.Find(d => d.DoctorId == _doctorId) ?? new DoctorClass();
        
        var newName = InputValidator.Validator("Enter the new name: ", "name", "data");
        var newSurname = InputValidator.Validator("Enter the new surname: ", "surname", "data");
        var newSpecialization = InputValidator.Validator("Enter the new specialization: ", "specialization", "data");
        var newPhoneNumber = InputValidator.Validator("Enter the new phone number: ", "phone number", "phone number");
        
        doctor.EditDoctor(doctor.DoctorId, newName, newSurname, newSpecialization, newPhoneNumber, doctor.AvailableHours);
        Console.Clear();
        Console.WriteLine("Doctor edited successfully.");
    }
    
    public static void RemoveDoctor()
    {
        var doctors = DoctorsArray.Doctors;
        if (doctors.Count == 0)
        {
            Console.WriteLine("There are no doctors in the system.");
            return;
        }

        PrintDoctors("task");
        
        _doctorId = InputValidator.Validator("Enter the doctor's ID: ", "ID", "ID");
        DoctorClass doctor = doctors.Find(d => d.DoctorId == _doctorId) ?? new DoctorClass();

        DoctorsArray.RemoveDoctor(doctor);
        Console.Clear();
        Console.WriteLine("Doctor removed successfully.");
    }
    
    public static void PrintDoctors(string request)
    {
        Console.ForegroundColor = ConsoleColor.Blue; 
        var doctors = DoctorsArray.Doctors;
        if (doctors.Count == 0) { Console.WriteLine("There are no doctors in the system."); return; }
        switch (request)
        {
            case "task":
            {
                for(int i = 0; i < DoctorsArray.NumberOfDoctors; i++)
                {
                    Console.WriteLine($"ID: {doctors[i].DoctorId}, " +
                                      $"Name: {doctors[i].Name}, " +
                                      $"Surname: {doctors[i].Surname}, " +
                                      $"Specialization: {doctors[i].Specialization}, " +
                                      $"Phone Number: {doctors[i].PhoneNumber}", Console.ForegroundColor);
                }
                Console.WriteLine();
                break;
            }
            case "IDs, Surname and specializations":
            {
                for(int i = 0; i < DoctorsArray.NumberOfDoctors; i++)
                {
                    Console.WriteLine($"ID: {doctors[i].DoctorId}, " +
                                      $"Surname: {doctors[i].Surname}, " +
                                      $"Specialization: {doctors[i].Specialization}", Console.ForegroundColor);
                }
                Console.WriteLine();
                break;
            }
            case "ID, Specialization and Available Hours":
            {
                for(int i = 0; i < DoctorsArray.NumberOfDoctors; i++)
                {
                    if (doctors[i].AvailableHours.Count == 0) { continue; }
                    Console.WriteLine($"ID: {doctors[i].DoctorId}, " +
                                      $"Sp: {doctors[i].Specialization}\n" +
                                      $"Available Hours:\n{doctors[i].GetAvailableHours()}", Console.ForegroundColor);
                }
                Console.WriteLine();
                break;
            }
        }
        Console.ResetColor();
    }
}