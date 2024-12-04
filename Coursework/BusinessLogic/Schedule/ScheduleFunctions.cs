namespace BusinessLogic.Schedule;
using Doctors;
using Patients;

public class ScheduleFunctions
{
    private static string _scheduleRecordId = "";
    private static string _doctorId = "";
    private static string _patientId = "";
    private static DateTime _recordDate;
    
    public static Task AddRecord()
    {
        Console.WriteLine("Adding a new schedule record.");
        _doctorId = InputValidator.Validator("Enter the doctor's ID: ", "ID", "doctor ID");
        _patientId = InputValidator.Validator("Enter the patient's ID: ", "ID", "patient ID");
        while (true)
        {
            string inputHour = InputValidator.Validator("Enter a date and time (e.g., 2024-12-31 14:30) or type 'STOP' to finish: ", "time", "hour"); ;
            if (inputHour == "0")
            {
                break;
            }
            else if (DateTime.TryParse(inputHour, out DateTime inputTime))
            {
                _recordDate = inputTime;
            }
        }
        ScheduleArray.AddScheduleRecord(_doctorId, _patientId, _recordDate);
        return Task.CompletedTask;
    }

    public static void EditScheduleRecord()
    {
        var schedule = ScheduleArray.Schedule;
        if (schedule.Count == 0) { Console.WriteLine("No schedule records found."); return; }
        _scheduleRecordId = InputValidator.Validator("Enter ID of the record to edit: ", "ID", "schedule record ID");
        ScheduleClass record = schedule.Find(s => s.ScheduleRecordId == _scheduleRecordId);
        if (record == null) { Console.WriteLine("Record not found."); return; }
        var newDoctorId = InputValidator.Validator("Enter the new doctor's ID: ", "ID", "doctor ID");
        var newPatientId = InputValidator.Validator("Enter the new patient's ID: ", "ID", "patient ID");
        while (true)
        {
            string inputHour = InputValidator.Validator("Enter a date and time (e.g., 2024-12-31 14:30) or type 'STOP' to finish: ", "time", "hour");
            if (inputHour == "0")
            {
                break;
            }
            else if (DateTime.TryParse(inputHour, out DateTime inputTime))
            {
                _recordDate = inputTime;
            }
        }
        record.EditScheduleRecord(record.ScheduleRecordId, newDoctorId, newPatientId, _recordDate);
        Console.Clear();
        Console.WriteLine("Record edited successfully.");
    }
    
    public static void MakeAppointment()
    {
        Console.WriteLine("Making an appointment.");
        _doctorId = InputValidator.Validator("Enter the doctor's ID: ", "ID", "doctor ID");
        _patientId = InputValidator.Validator("Enter the patient's ID: ", "ID", "patient ID");
        while (true)
        {
            string inputHour = InputValidator.Validator("Enter a date and time (e.g., 2024-12-31 14:30) or type 'STOP' to finish: ", "time", "hour");
            if (inputHour == "0")
            {
                break;
            }
            else if (DateTime.TryParse(inputHour, out DateTime inputTime))
            {
                _recordDate = inputTime;
            }
        }
        if (ScheduleArray.MakeAppointment(_doctorId, _patientId, _recordDate))
        {
            Console.Clear();
            Console.WriteLine("Appointment made successfully.");
        }
        else
        {
            Console.WriteLine("Appointment slot already taken.");
        }
    }
    
    public static void PrintSchedule()
    {
        var schedule = ScheduleArray.Schedule;
        if (schedule.Count == 0)
        {
            Console.WriteLine("No schedule records found.");
            return;
        }
        
        Console.WriteLine("Schedule records:");
        for (int i = 0; i < ScheduleArray.NumberOfScheduleRecords; i++)
        {
            Console.WriteLine($"Doctor ID: {schedule[i].DoctorId}, " +
                              $"Doctor's Surname: {DoctorsArray.Doctors.Find(d => d.DoctorId == schedule[i].DoctorId)?.Surname}, " +
                              $"Patient ID: {schedule[i].PatientId}, " +
                              $"Patient's Surname: {PatientsArray.Patients.Find(p => p.PatientId == schedule[i].PatientId)?.Surname}, " +
                              $"Date: {schedule[i].RecordDate}");
        }
    }
}