namespace Coursework;
using BusinessLogic;
using BusinessLogic.Doctors;
using BusinessLogic.Patients;
using BusinessLogic.Schedule;   
using BusinessLogic.DataOperations;

public class SecondaryMenus
{
    protected static async Task ManagementOfDoctors()
    {
        var isStopped = true;
        while (isStopped)
        {
            Console.WriteLine(ConsoleMenu.ManagementOfDoctorsMenu());
            var choice = Console.ReadKey().Key;
            Console.Clear();
            switch (choice)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    Console.Clear();
                    await DoctorsFunctions.AddDoctor();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.Clear();
                    DoctorsFunctions.EditDoctor();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.Clear();
                    DoctorsFunctions.RemoveDoctor();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    Console.Clear();
                    DoctorsFunctions.PrintDoctors("all");
                    break;
                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
                    await WorkWithFiles.WriteToFiles();
                    Console.Clear();
                    isStopped = false;
                    break;
                default:
                    Console.Clear();
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
                    Console.Clear();
                    Console.WriteLine("Please press a valid key.");
                    break;
            }
        }
    }
    
    protected static async Task ManagementOfReceptionSchedule()
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
                    await ScheduleFunctions.AddScheduleToDoctor();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.Clear();
                    await ScheduleFunctions.MakeAppointment();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.Clear();
                    ScheduleFunctions.EditDoctorsSchedule();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    Console.Clear();
                    ScheduleFunctions.PrintSchedule();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    Console.Clear();
                    ScheduleFunctions.PrintDoctorsSchedule();
                    break;
                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
                    Console.Clear();
                    isStopped = false;
                    break;
                default:
                    Console.Clear();
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
                    SearchClass.SearchPatient();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.Clear();
                    SearchClass.SearchDoctor();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.Clear();
                    SearchClass.GetDoctorSchedule();
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