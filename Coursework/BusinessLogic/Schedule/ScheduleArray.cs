namespace BusinessLogic.Schedule;

public class ScheduleArray
{
    private static int _numberOfScheduleRecords;
    private static List<ScheduleClass> _schedule = new List<ScheduleClass>();

    public static int NumberOfScheduleRecords 
    { get => _numberOfScheduleRecords; set => _numberOfScheduleRecords = value; }
    public static List<ScheduleClass> Schedule { get => _schedule; set => _schedule = value; }

   public static void AddScheduleRecord(string doctorId, string patientId, DateTime date)
    {
        Schedule.Add(new ScheduleClass(doctorId, patientId, date));
        _numberOfScheduleRecords++;
    }

    public static void RemoveRecord(ScheduleClass record)
    {
        _schedule.Remove(record);
        _numberOfScheduleRecords--;
    }
    
    
}