namespace BusinessLogic.Schedule;
using Doctors;
using Patients;

public class ScheduleFunctions
{
    private static string _doctorId = "";
    private static string _patientId = "";
    private static DateTime _recordDate;
    
    public static Task AddScheduleToDoctor()
    {
        var doctors = DoctorsArray.Doctors;
        if (doctors.Count == 0) { Console.WriteLine("No doctors found."); return Task.CompletedTask; }
        for (int i = 0; i < DoctorsArray.NumberOfDoctors; i++)
        {
            Console.WriteLine($"Doctor ID: {doctors[i].DoctorId}, " +
                              $"Doctor's Surname: {doctors[i].Surname}, " +
                              $"Specialization: {doctors[i].Specialization}");
        }
        
        _doctorId = InputValidator.Validator("Enter the doctor's ID: ", "ID", "ID");
        DoctorClass doctor = doctors.Find(d => d.DoctorId == _doctorId) ?? throw new CustomException("Doctor not found.");
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
        
        doctor.AvailableHours.Clear();
        doctor.AvailableHours.Add(_recordDate);
        return Task.CompletedTask;
    }

    public static void EditDoctorsSchedule()
    {
        var doctors = DoctorsArray.Doctors;
        if (doctors.Count == 0) { Console.WriteLine("No doctors found."); return; }

        PrintDoctorsSchedule();
        _doctorId = InputValidator.Validator("Enter the doctor's ID: ", "ID", "doctor ID");
        var doctor = doctors.Find(d => d.DoctorId == _doctorId) ?? new DoctorClass();
        
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
        
        doctor.AvailableHours.Clear();
        doctor.AvailableHours.Add(_recordDate);
        
    }
    
    public static Task MakeAppointment()
    {
        var doctors = DoctorsArray.Doctors;
        if (doctors.Count == 0) { Console.WriteLine("No doctors found."); return Task.CompletedTask; }
        for (int i = 0; i < DoctorsArray.NumberOfDoctors; i++)
        {
            if (doctors[i].AvailableHours.Count > 0){
                Console.WriteLine($"Doctor ID: {doctors[i].DoctorId}, " +
                                  $"Sp: {doctors[i].Specialization}" +
                                  $"Available hours: {doctors[i].GetAvailableHours()}");
            }
        }
        _doctorId = InputValidator.Validator("Enter the doctor's ID: ", "ID", "ID");
        var doctor = doctors.Find(d => d.DoctorId == _doctorId) ?? new DoctorClass();
        if (doctor.AvailableHours.Count == 0) { Console.WriteLine("Doctor has no available hours."); return Task.CompletedTask; }
        var patients = PatientsArray.Patients;
        if (patients.Count == 0) { Console.WriteLine("No patients found."); return Task.CompletedTask; }
        for (int i = 0; i < PatientsArray.NumberOfPatients; i++)
        {
            Console.WriteLine($"Patient ID: {patients[i].PatientId}, " +
                              $"Diagnosis: {patients[i].MedicalRecord.Diagnosis}");
        }
        
        _patientId = InputValidator.Validator("Enter the patient's ID: ", "ID", "ID");
        
        while (true)
        {
            string inputHour = InputValidator.Validator("Enter a date and time (e.g., 31.12.2024 14:30): ", "time", "hour");
        
            if (DateTime.TryParse(inputHour, out DateTime inputTime))
            {
                _recordDate = inputTime;
            } 
            if (!doctor.AvailableHours.Contains(_recordDate))
            {
                Console.WriteLine("Doctor is not available at this time.");
            }
            else { break; }
        }
        ScheduleArray.AddScheduleRecord(_doctorId, _patientId, _recordDate);
        doctor.AvailableHours.Remove(_recordDate);
        if (doctor.AvailableHours.Count == 0)
        {
            doctor.AvailableHours = new List<DateTime>(0);
        }
        Console.WriteLine("Appointment made successfully.");
        
        return Task.CompletedTask;
    }
    
    public static void PrintSchedule()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        var schedule = ScheduleArray.Schedule;
        if (schedule.Count == 0)
        { Console.WriteLine("No schedule records found."); return; }
        
        Console.WriteLine("Schedule records:");
        for (int i = 0; i < ScheduleArray.NumberOfScheduleRecords; i++)
        {
            Console.WriteLine($"Doctor ID: {schedule[i].DoctorId}, " +
                              $"Doctor's Surname: {DoctorsArray.Doctors.Find(d => d.DoctorId == schedule[i].DoctorId)?.Surname}, " +
                              $"Patient ID: {schedule[i].PatientId}, " +
                              $"Patient's Surname: {PatientsArray.Patients.Find(p => p.PatientId == schedule[i].PatientId)?.Surname}, " +
                              $"Date: {schedule[i].RecordDate}\n" + schedule[i].ScheduleRecordId, Console.ForegroundColor);
        }
        Console.ResetColor();
    }
    
    public static void PrintDoctorsSchedule()
    {
        Console.ForegroundColor = ConsoleColor.Blue; 
        var doctors = DoctorsArray.Doctors;
        if (doctors.Count == 0) { Console.WriteLine("No doctors found."); return; }
        for (int i = 0; i < DoctorsArray.NumberOfDoctors; i++)
        {
            Console.WriteLine($"Doctor ID: {doctors[i].DoctorId}, " +
                              $"Doctor's Surname: {doctors[i].Surname}\n" +
                              $"Schedule:\n{doctors[i].GetAvailableHours()}", Console.ForegroundColor);
        }
        Console.ResetColor();
    }
}