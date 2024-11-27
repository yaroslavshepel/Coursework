namespace Coursework;
using BusinessLogic;

public class Functions
{
    protected static async Task ManagementOfDoctors()
    {
        var isStopped = true;
        while (isStopped)
        {
            // await WorkWithFiles.ReadFiles();
            Console.WriteLine(ConsoleMenu.ManagementOfDoctorsMenu());
            //var choice = Console.ReadKey().Key;
            var choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1://ConsoleKey.NumPad1:
                    Console.Clear();
                    await AddDoctor();
                    await WorkWithFiles.WriteToFiles();
                    break;
                case 2://ConsoleKey.NumPad2:
                    Console.Clear();
                    await WorkWithFiles.ReadFiles();
                    //EditDoctor();
                    break;
                case 3://ConsoleKey.NumPad3:
                    Console.Clear();
                    DeleteDoctor();
                    break;
                case 4://ConsoleKey.NumPad4:
                    Console.Clear();
                    
                    PrintDoctors();
                    break;
                case 5://ConsoleKey.NumPad5:
                    Console.Clear();
                    isStopped = false;
                    break;
                default:
                    Console.WriteLine("Please press a valid key.");
                    break;
            }
        }
    }
    
    protected static void ManagementOfPatients()
    {
        var isStopped = true;
        while (isStopped)
        {
            Console.WriteLine(ConsoleMenu.ManagementOfPatientsMenu());
            var choice = Console.ReadKey().Key;
            Console.Clear();
            switch (choice)
            {
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    // AddPatient();
                    break;
                case ConsoleKey.NumPad2:
                    Console.Clear();
                    // DeletePatient();
                    break;
                case ConsoleKey.NumPad3:
                    Console.Clear();
                    // ElectronicMedicalRecord();
                    break;
                case ConsoleKey.NumPad4:
                    Console.Clear();
                    isStopped = false;
                    break;
                default:
                    Console.WriteLine("Please press a valid key.");
                    break;
            }
        }
    }
    
    protected static void ManagementOfReceptionSchedule()
    {
        var isStopped = true;
        while (isStopped)
        {
            Console.WriteLine(ConsoleMenu.ManagementOfReceptionScheduleMenu());
            var choice = Console.ReadKey().Key;
            Console.Clear();
            switch (choice)
            {
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    // AddReceptionSchedule();
                    break;
                case ConsoleKey.NumPad2:
                    Console.Clear();
                    // DeleteReceptionSchedule();
                    break;
                case ConsoleKey.NumPad3:
                    Console.Clear();
                    // EditReceptionSchedule();
                    break;
                case ConsoleKey.NumPad4:
                    Console.Clear();
                    // MakeAppointment();
                    break;
                case ConsoleKey.NumPad5:
                    Console.Clear();
                    isStopped = false;
                    break;
                default:
                    Console.WriteLine("Please press a valid key.");
                    break;
            }
        }
    }
    
    protected static void Search()
    {
        var isStopped = true;
        while (isStopped)
        {
            Console.WriteLine(ConsoleMenu.SearchMenu());
            var choice = Console.ReadKey().Key;
            Console.Clear();
            switch (choice)
            {
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    // SearchPatient();
                    break;
                case ConsoleKey.NumPad2:
                    Console.Clear();
                    // SearchDoctor();
                    break;
                case ConsoleKey.NumPad3:
                    Console.Clear();
                    // GetDoctorSchedule();
                    break;
                case ConsoleKey.NumPad4:
                    Console.Clear();
                    isStopped = false;
                    break;
                default:
                    Console.WriteLine("Please press a valid key.");
                    break;
            }
        }
    }

    private static string _name = "";
    private static string _surname = "";
    private static string _specialization = "";
    private static string _phoneNumber = "";
    
    /*private static async Task AddDoctor()
    {
        Console.WriteLine("Adding a doctor.");
        _name = InputValidator.Validator("Enter the doctor's name: ", "data");
        _surname = InputValidator.Validator("Enter the doctor's surname: ", "data");
        _specialization = InputValidator.Validator("Enter the doctor's specialization: ", "data");
        _phoneNumber = InputValidator.Validator("Enter the doctor's phone number: ", "phone number");
        DoctorsArray.AddDoctor(_name, _surname, _specialization, _phoneNumber);
        DoctorsArray.SetNumberOfDoctors(DoctorsArray.GetNumberOfDoctors() + 1);
        Console.WriteLine("Doctor added successfully.");
        await WorkWithFiles.WriteToFiles();
    }*/
    
    private static async Task AddDoctor()
    {
        Console.WriteLine("Adding a doctor.");
        _name = InputValidator.Validator("Enter the doctor's name: ", "data");
        _surname = InputValidator.Validator("Enter the doctor's surname: ", "data");
        _specialization = InputValidator.Validator("Enter the doctor's specialization: ", "data");
        _phoneNumber = InputValidator.Validator("Enter the doctor's phone number: ", "phone number");
        
        DoctorsArray.AddDoctor(_name, _surname, _specialization, _phoneNumber);
        DoctorsArray.SetNumberOfDoctors(DoctorsArray.GetNumberOfDoctors() + 1);
        Console.WriteLine("Doctor added successfully.");
        
        await WorkWithFiles.WriteToFiles(); // Ensure this line is present
    }
    
    private static void EditDoctor()
    {
        var doctors = DoctorsArray.GetDoctors();
        if (doctors.Count == 0) { Console.WriteLine("There are no doctors in the system."); return; }
        _name = InputValidator.Validator("Enter name of doctor to edit: ", "data");
        _surname = InputValidator.Validator("Enter surname of doctor to edit: ", "data");
        DoctorClass doctor = doctors.Find(d => d.Name == _name && d.Surname == _surname)
        ?? throw new ArgumentNullException(nameof(doctor), "Doctor not found.");
        var newName = InputValidator.Validator("Enter the new name: ", "data");
        var newSurname = InputValidator.Validator("Enter the new surname: ", "data");
        var newSpecialization = InputValidator.Validator("Enter the new specialization: ", "data");
        var newPhoneNumber = InputValidator.Validator("Enter the new phone number: ", "phone number");
        DoctorsArray.EditDoctor(doctor, newName, newSurname, newSpecialization, newPhoneNumber);
        Console.WriteLine("Doctor edited successfully.");
    }
    
    private static void DeleteDoctor()
    {
        var doctors = DoctorsArray.GetDoctors();
        if (doctors.Count == 0) { Console.WriteLine("There are no doctors in the system."); return; }
        _name = InputValidator.Validator("Enter name of doctor to delete: ", "data");
        _surname = InputValidator.Validator("Enter surname of doctor to delete: ", "data");
        DoctorClass doctor = doctors.Find(d => d.Name == _name && d.Surname == _surname)
        ?? throw new ArgumentNullException(nameof(doctor), "Doctor not found.");
        DoctorsArray.RemoveDoctor(doctor);
        Console.WriteLine("Doctor deleted successfully.");
    }
    
    private static void PrintDoctors()
    {
        var doctors = DoctorsArray.GetDoctors();
        if (doctors.Count == 0) { Console.WriteLine("There are no doctors in the system."); return; }
        for (int i = 0; i < DoctorsArray.GetNumberOfDoctors(); i++)
        {
            Console.WriteLine($"Name: {doctors[i].Name}, Surname: {doctors[i].Surname}, Specialization: {doctors[i].Specialization}, Phone Number: {doctors[i].PhoneNumber}");
        }/*
        {
            Console.WriteLine($"Name: {d.Name}, Surname: {d.Surname}, Specialization: {d.Specialization}, Phone Number: {d.PhoneNumber}");
        }*/
    }
}