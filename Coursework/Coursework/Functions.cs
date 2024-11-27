namespace Coursework;
using BusinessLogic;
using BusinessLogic.Doctors;

public class Functions
{
    protected static async Task ManagementOfDoctors()
    {
        var isStopped = true;
        while (isStopped)
        {
            Console.WriteLine(ConsoleMenu.ManagementOfDoctorsMenu());
            //var choice = Console.ReadKey().Key;
            var choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1://ConsoleKey.NumPad1:
                    Console.Clear();
                    await DoctorsFunctions.AddDoctor();
                    break;
                case 2://ConsoleKey.NumPad2:
                    Console.Clear();
                    // await WorkWithFiles.ReadFiles();
                    DoctorsFunctions.EditDoctor();
                    break;
                case 3://ConsoleKey.NumPad3:
                    Console.Clear();
                    DoctorsFunctions.RemoveDoctor();
                    break;
                case 4://ConsoleKey.NumPad4:
                    Console.Clear();
                    DoctorsFunctions.PrintDoctors();
                    break;
                case 5://ConsoleKey.NumPad5:
                    await WorkWithFiles.WriteToFiles();
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
}