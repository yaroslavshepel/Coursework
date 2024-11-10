namespace Coursework;

class Program : Functions
{
    public static void Main()
    {
        var isStopped = true;
        while (isStopped)
        {
            Console.WriteLine(ConsoleMenu.MainMenu());
            var choice = ChoiceCheck();
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    ManagementOfDoctors();
                    break;
                case 2:
                    Console.Clear();
                    ManagementOfPatients();
                    break;
                case 3:
                    Console.Clear();
                    ManagementOfReceptionSchedule();
                    break;
                case 4:
                    Console.Clear();
                    Search();
                    break;
                case 5:
                    isStopped = false;
                    break;
            }
        }
    }
}