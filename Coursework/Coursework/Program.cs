namespace Coursework;
using BusinessLogic;

class Program : Functions
{
    public static async Task Main()
    {
        var isStopped = true;
        while (isStopped)
        {
            await WorkWithFiles.ReadFiles();
            Console.WriteLine(ConsoleMenu.MainMenu());
            var choice = Console.ReadKey().Key;
            // var choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                // case 1:
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    Console.Clear();
                    await ManagementOfDoctors();
                    break;
                // case 2:
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.Clear();
                    await ManagementOfPatients();
                    break;
                // case 3:
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.Clear();
                    ManagementOfReceptionSchedule();
                    break;
                // case 4:
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    Console.Clear();
                    Search();
                    break;
                // case 5:
                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
                    await WorkWithFiles.WriteToFiles();
                    isStopped = false;
                    break;
                default:
                    Console.WriteLine("Please press a valid key.");
                    break;
            }
        }
    }
}