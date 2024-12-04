namespace BusinessLogic.Schedule;

public class ScheduleClass
{
    private string _scheduleRecordId = "";
    private string _doctorId = "";
    private string _patientId = "";
    private DateTime _recordDate;
    
    public string ScheduleRecordId { get => _scheduleRecordId; set => _scheduleRecordId = value; }
    public string DoctorId { get => _doctorId; set => _doctorId = value; }
    public string PatientId { get => _patientId; set => _patientId = value; }
    public DateTime RecordDate { get => _recordDate; set => _recordDate = value; }
    
    public ScheduleClass(string scheduleRecordId, string doctorId, string patientId, DateTime recordDate)
    {
        _scheduleRecordId = scheduleRecordId;
        _doctorId = doctorId;
        _patientId = patientId;
        _recordDate = recordDate;
    }
    
    public ScheduleClass EditScheduleRecord(string scheduleId, string doctorId, string patientId, DateTime scheduleDate)
    {
        _scheduleRecordId = scheduleId;
        _doctorId = doctorId;
        _patientId = patientId;
        _recordDate = scheduleDate;
        return new ScheduleClass(scheduleId, doctorId, patientId, scheduleDate);
    }
}