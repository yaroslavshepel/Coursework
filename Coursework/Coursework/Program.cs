namespace Coursework;
using BusinessLogic;

class Program : SecondaryMenus
{
    public static async Task Main()
    {
        var isStopped = true;
        await WorkWithFiles.ReadFiles();
        while (isStopped)
        {
            
            Console.WriteLine(ConsoleMenu.MainMenu());
            var choice = Console.ReadKey().Key;
            Console.Clear();
            switch (choice)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    Console.Clear();
                    await ManagementOfDoctors();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.Clear();
                    await ManagementOfPatients();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.Clear();
                    await ManagementOfReceptionSchedule();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    Console.Clear();
                    Search();
                    break;
                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
                    await WorkWithFiles.WriteToFiles();
                    isStopped = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please press a valid key.");
                    break;
            }
        }
    }
}