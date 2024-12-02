namespace BusinessLogic.Schedule;

public class ScheduleClass
{
    private string _doctorId = "";
    private string _patientId = "";
    private DateTime _Scheduledate;
    
    public string DoctorId { get => _doctorId; set => _doctorId = value; }
    public string PatientId { get => _patientId; set => _patientId = value; }
    public DateTime Date { get => _Scheduledate; set => _Scheduledate = value; }
    
    public ScheduleClass(string doctorId, string patientId, DateTime scheduleDate)
    {
        DoctorId = doctorId;
        PatientId = patientId;
        Date = scheduleDate;
    }
    
    public ScheduleClass EditSchedule(string doctorId, string patientId, DateTime scheduleDate)
    {
        DoctorId = doctorId;
        PatientId = patientId;
        Date = scheduleDate;
        return new ScheduleClass(doctorId, patientId, scheduleDate);
    }
}