using BusinessLogic.Schedule;

namespace Coursework;
using BusinessLogic;
using BusinessLogic.Doctors;
using BusinessLogic.Patients;

public class Functions
{
    protected static async Task ManagementOfDoctors()
    {
        var isStopped = true;
        while (isStopped)
        {
            Console.WriteLine(ConsoleMenu.ManagementOfDoctorsMenu());
            var choice = Console.ReadKey().Key;
            // var choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                //case 1:
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    Console.Clear();
                    await DoctorsFunctions.AddDoctor();
                    break;
                // case 2:
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.Clear();
                    DoctorsFunctions.EditDoctor();
                    break;
                // case 3:
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.Clear();
                    DoctorsFunctions.RemoveDoctor();
                    break;
                // case 4:
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    Console.Clear();
                    DoctorsFunctions.PrintDoctors("all");
                    break;
                // case 5:
                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
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
    
    protected static async Task ManagementOfPatients()
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
                case ConsoleKey.D1:
                    Console.Clear();
                    await PatientFunctions.AddPatient();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.Clear();
                    PatientFunctions.RemovePatient();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.Clear();
                    PatientFunctions.EditPatient();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    Console.Clear();
                    PatientFunctions.PrintPatients();
                    break;
                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
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
                case ConsoleKey.D1:
                    Console.Clear();
                    // AddReceptionSchedule();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.Clear();
                    // DeleteReceptionSchedule();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.Clear();
                    // EditReceptionSchedule();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    Console.Clear();
                    ScheduleFunctions.PrintSchedule();
                    break;
                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
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
                case ConsoleKey.D1:
                    Console.Clear();
                    // SearchPatient();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.Clear();
                    // SearchDoctor();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.Clear();
                    // GetDoctorSchedule();
                    break;
                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
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