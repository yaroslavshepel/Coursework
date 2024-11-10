namespace Coursework;

public class Functions
{
    
    protected static int ChoiceCheck()
    {
        var choice = -1;
        try
        {
            choice = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            throw new CustomException("Invalid input format. Please enter a number.");
        }
        catch (Exception e)
        {
            throw new CustomException("An unexpected error occurred.", e);
        }
        Console.WriteLine(ConsoleMenu.PrintLongThing());
        return choice;
    }
    
    protected static void ManagementOfDoctors()
    {
        var isStopped = true;
        while (isStopped)
        {
            Console.WriteLine(ConsoleMenu.ManagementOfDoctorsMenu());
            var choice = ChoiceCheck();
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    AddDoctor();
                    break;
                case 2:
                    Console.Clear();
                    EditDoctor();
                    break;
                case 3:
                    Console.Clear();
                    DeleteDoctor();
                    break;
                case 4:
                    Console.Clear();
                    PrintDoctors();
                    break;
                case 5:
                    Console.Clear();
                    isStopped = false;
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
            var choice = ChoiceCheck();
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    AddPatient();
                    break;
                case 2:
                    Console.Clear();
                    DeletePatient();
                    break;
                case 3:
                    Console.Clear();
                    ElectronicMedicalRecord();
                    break;
                case 4:
                    Console.Clear();
                    isStopped = false;
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
            var choice = ChoiceCheck();
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    AddReceptionSchedule();
                    break;
                case 2:
                    Console.Clear();
                    DeleteReceptionSchedule();
                    break;
                case 3:
                    Console.Clear();
                    EditReceptionSchedule();
                    break;
                case 4:
                    Console.Clear();
                    MakeAppointment();
                    break;
                case 5:
                    Console.Clear();
                    isStopped = false;
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
            var choice = ChoiceCheck();
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    SearchPatient();
                    break;
                case 2:
                    Console.Clear();
                    SearchDoctor();
                    break;
                case 3:
                    Console.Clear();
                    GetDoctorSchedule();
                    break;
                case 4:
                    Console.Clear();
                    isStopped = false;
                    break;
            }
        }
    }
}