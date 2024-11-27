namespace Coursework;

public static class ConsoleMenu
{
    public static string PrintLongThing() { return "------------------------------------------------------------"; }
    
    public static string MainMenu()
    {
        return "1. Management of doctors\n" +
               "2. Management of patients\n" +
               "3. Management of the reception schedule\n" +
               "4. Search\n" +
               "5. Exit";
    }

    public static string ManagementOfDoctorsMenu()
    {
        return "1. Add a doctor\n" +
               "2. Edit data about doctor\n" +
               "3. Remove a doctor\n" +
               "4. View all doctors and their specializations\n" +
               "5. Back to main menu";
    }
    
    public static string ManagementOfPatientsMenu()
    {
        return "1. Add a patient\n" +
               "2. Remove a patient\n" +
               "3. Electronic medical record\n" +
               "4. Back to main menu";
    }
    
    public static string ManagementOfReceptionScheduleMenu()
    {
        return "1. Add a reception schedule\n" +
               "2. Remove a reception schedule\n" +
               "3. Edit a reception schedule\n" +
               "4. Make an appointment with a doctor\n" +
               "5. Back to main menu";
    }
    
    public static string SearchMenu()
    {
        return "1. Search for a patient by name or surname\n" +
               "2. Search for a doctor by name or surname\n" +
               "3. Get doctor's schedule\n" +
               "4. Back to main menu";
    }
}