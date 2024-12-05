namespace BusinessLogic.Schedule;

public class ScheduleArray
{
    private static int _numberOfScheduleRecords;
    private static List<ScheduleClass> _schedule = new();

    public static int NumberOfScheduleRecords 
    { get => _numberOfScheduleRecords; set => _numberOfScheduleRecords = value; }
    public static List<ScheduleClass> Schedule { get => _schedule; set => _schedule = value; }
    
   public static void AddScheduleRecord(string doctorId, string patientId, DateTime date)
    {
        string newScheduleId = "";
        if (_schedule.Count == 0)
        {
            newScheduleId = "S001";
        }
        else
        {
            string scheduleRecordId = _schedule.Last().ScheduleRecordId;
            string scheduleTrimmed = scheduleRecordId.Trim('S');
            int recordIdNumber = int.Parse(scheduleTrimmed);
            if (recordIdNumber < 10)
            {
                newScheduleId = $"S00{recordIdNumber + 1}";
            }  else if (recordIdNumber < 100)
            {
                newScheduleId = $"S0{recordIdNumber + 1}";
            } else if (recordIdNumber < 1000)
            {
                newScheduleId = $"S{recordIdNumber + 1}";
            }
        }
        
        Schedule.Add(new ScheduleClass(newScheduleId, doctorId, patientId, date));
        _numberOfScheduleRecords++;
    }
   
    public static void RemoveScheduleRecord(string id)
    {
        var schedule = new ScheduleClass();
        if (id.Contains("D"))
        {
            schedule = Schedule.Find(s => s.DoctorId == id) ?? new ScheduleClass();
        } else if (id.Contains("P"))
        {
            schedule = Schedule.Find(s => s.PatientId == id) ?? new ScheduleClass();
        }
        Schedule.Remove(schedule);
        _numberOfScheduleRecords--;
    }
}