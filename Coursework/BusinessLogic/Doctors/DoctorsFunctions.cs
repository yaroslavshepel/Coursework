namespace BusinessLogic.Doctors;

public class DoctorsFunctions
{
    private static string _name = "";
    private static string _surname = "";
    private static string _specialization = "";
    private static string _phoneNumber = "";
    private static List<DateTime> hours = new();
    
    public static Task AddDoctor()
    {
        Console.WriteLine("Adding a doctor.");
        _name = InputValidator.Validator("Enter the doctor's name: ", "name", "data");
        _surname = InputValidator.Validator("Enter the doctor's surname: ", "surname", "data");
        _specialization = InputValidator.Validator("Enter the doctor's specialization: ", "specialization", "data");
        _phoneNumber = InputValidator.Validator("Enter the doctor's phone number: ", "phone number", "phone number");
        /*while (true)
        {
            string inputHour = InputValidator.Validator("Enter a date and time (e.g., 2023-12-31 14:30) or type 'STOP' to finish: ", "time", "hour");
            if (inputHour == "0")
            {
                break;
            }
            else if (DateTime.TryParse(inputHour, out DateTime inputTime))
            {
                hours.Add(inputTime);
            }
        }*/
        
        //hours = DoctorClass.GenerateDefaultAvailableHours();
        hours = DoctorClass.GenerateDefaultAvailableHours();
        DoctorsArray.AddDoctor(_name, _surname, _specialization, _phoneNumber, hours);
        //DoctorsArray.SetNumberOfDoctors(DoctorsArray.GetNumberOfDoctors() + 1);
        //DoctorsArray.NumberOfDoctors++;
        Console.WriteLine("Doctor added successfully.");
        return Task.CompletedTask;
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
        doctor.EditDoctor(doctor.DoctorId, newName, newSurname, newSpecialization, newPhoneNumber, doctor.AvailableHours);
        Console.Clear();
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
        Console.Clear();
        Console.WriteLine("Doctor removed successfully.");
    }
    
    public static void PrintDoctors(string request)
    {
        var doctors = DoctorsArray.Doctors;
        if (doctors.Count == 0) { Console.WriteLine("There are no doctors in the system."); return; }
        switch (request)
        {
            case "all":
            {
                for(int i = 0; i < DoctorsArray.NumberOfDoctors; i++)
                {
                    Console.WriteLine($"ID: {doctors[i].DoctorId}, " +
                                      $"Name: {doctors[i].Name}, " +
                                      $"Surname: {doctors[i].Surname}, " +
                                      $"Specialization: {doctors[i].Specialization}, " +
                                      $"Phone Number: {doctors[i].PhoneNumber}\n" + doctors[i].GetAvailableHours());          }
                break;
            }
            case "IDs and specializations":
            {
                for(int i = 0; i < DoctorsArray.NumberOfDoctors; i++)
                {
                    Console.WriteLine($"ID: {doctors[i].DoctorId}, " +
                                      $"Specialization: {doctors[i].Specialization}");
                }
                break;
            }
        }
    }
}