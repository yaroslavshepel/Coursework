namespace Coursework;

class Program : Functions
{
    public static async Task Main()
    {
        var isStopped = true;
        while (isStopped)
        {
            Console.WriteLine(ConsoleMenu.MainMenu());
            // var choice = Console.ReadKey().Key;
            var choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1://ConsoleKey.NumPad1:
                    Console.Clear();
                    await ManagementOfDoctors();
                    break;
                // case ConsoleKey.NumPad2:
                //     Console.Clear();
                //     ManagementOfPatients();
                //     break;
                // case ConsoleKey.NumPad3:
                //     Console.Clear();
                //     ManagementOfReceptionSchedule();
                //     break;
                // case ConsoleKey.NumPad4:
                //     Console.Clear();
                //     Search();
                //     break;
                case 5: //ConsoleKey.NumPad5:
                    isStopped = false;
                    break;
                default:
                    Console.WriteLine("Please press a valid key.");
                    break;
            }
        }
    }
}