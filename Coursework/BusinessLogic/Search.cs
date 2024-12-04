namespace BusinessLogic;
using Doctors;
using Patients;
using Schedule;

public class Search
{
    private static string _doctorId = "";
    private static string _doctorName = "";
    private static string _doctorSurname = "";
    private static string _patientName = "";
    private static string _patientSurname = "";
    private static DateTime _date;
    
    public static void SearchPatient()
    {
        _patientName = InputValidator.Validator("Enter patient's name: ", "name", "name");
        _patientSurname = InputValidator.Validator("Enter patient's surname: ", "surname", "surname");

        var patient = PatientsArray.FindPatientByName(_patientName, _patientSurname);
        if (patient != null)
        {
            Console.WriteLine($"Patient found: {patient.Name} {patient.Surname}, ID: {patient.PatientId}");
        }
        else
        {
            Console.WriteLine("Patient not found.");
        }
    }

    public static void SearchDoctor()
    {
        _doctorName = InputValidator.Validator("Enter doctor's name: ", "name", "name");
        _doctorSurname = InputValidator.Validator("Enter doctor's surname: ", "surname", "surname");
        
        var doctor = DoctorsArray.FindDoctorByName(_doctorName, _doctorSurname);
        
        if (doctor != null)
        {
            Console.WriteLine($"Doctor found: {doctor.Name} {doctor.Surname}, ID: {doctor.DoctorId}");
        }
        else
        {
            Console.WriteLine("Doctor not found.");
        }
    }

    public static void GetDoctorSchedule()
    {
        _doctorId = InputValidator.Validator("Enter doctor's ID: ", "ID", "doctor ID");
        _date = InputValidator.ValidatorDate("Enter the date (e.g., 2024-12-31): ", "date");
        
        var schedule = ScheduleArray.GetDoctorSchedule(_doctorId, _date);
        
        if (schedule.Any())
        {
            Console.WriteLine($"Schedule for Doctor ID {_doctorId} on {_date.ToShortDateString()}:");
            foreach (var record in schedule)
            {
                Console.WriteLine($"Patient ID: {record.PatientId}, Date: {record.RecordDate}");
            }
        }
        else
        {
            Console.WriteLine("No schedule found for the specified date.");
        }
    }
}