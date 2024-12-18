namespace BusinessLogic.DataOperations;
using Doctors;
using Patients;

public class SearchClass
{
    private static string _doctorId = "";
    private static string _doctorName = "";
    private static string _doctorSurname = "";
    private static string _patientName = "";
    private static string _patientSurname = "";
    private static DateTime _date;
    
    public static void SearchPatient()
    {
        _patientName = InputValidator.Validator("Enter patient's name: ", "name", "data");
        _patientSurname = InputValidator.Validator("Enter patient's surname: ", "surname", "data");

        var patient = PatientsArray.FindPatientByName(_patientName, _patientSurname);
        if (patient != null)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Patient found: ID: {patient.PatientId}, " +
                              $"{patient.Name} {patient.Surname}, " +
                              $"Diagnosis: {patient.MedicalRecord.Diagnosis}", Console.ForegroundColor);
            Console.ResetColor();
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Patient not found.");
        }
    }

    public static void SearchDoctor()
    {
        _doctorName = InputValidator.Validator("Enter doctor's name: ", "name", "data");
        _doctorSurname = InputValidator.Validator("Enter doctor's surname: ", "surname", "data");
        
        var doctor = DoctorsArray.FindDoctorByName(_doctorName, _doctorSurname);
        
        if (doctor != null)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Doctor found: {doctor.Name} {doctor.Surname}, " +
                              $"ID: {doctor.DoctorId}", Console.ForegroundColor);
            Console.ResetColor();
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Doctor not found.");
        }
    }

    public static void GetDoctorSchedule()
    {
        DoctorsFunctions.PrintDoctors("IDs, Surname and specializations");
        _doctorId = InputValidator.Validator("\nEnter doctor's ID: ", "ID", "ID");
        _date = InputValidator.ValidatorDate("\nEnter the date (e.g., 2024-12-31): ", "date");
        
        var doctor = DoctorsArray.Doctors.Find(d => d.DoctorId == _doctorId) ?? new DoctorClass();
        var availableHours = doctor.AvailableHours.FindAll(h => h.Date == _date);
        
        if (availableHours.Count != 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Doctor {doctor.Name} {doctor.Surname} is available at:");
            
            foreach (var hour in doctor.AvailableHours)
            {
                if (hour.Date == _date)
                {
                    Console.WriteLine(hour.TimeOfDay);
                }
            }
            Console.WriteLine();
            Console.ResetColor();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("No available hours found.");
        }
    }
}