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
        string scheduleRecordId = _schedule.Last().ScheduleRecordId;
        string scheduleTrimmed = doctorId.Trim('S');
        int recordrIdNumber = int.Parse(scheduleTrimmed);
        int anotherNum = 00;
        if (recordrIdNumber >= 10)
        {
            anotherNum = 0;
        }
        string newScheduleId = $"S{anotherNum}{recordrIdNumber + 1}";
        Schedule.Add(new ScheduleClass(newScheduleId, doctorId, patientId, date));
        _numberOfScheduleRecords++;
    }

    public static void RemoveRecord(ScheduleClass record)
    {
        _schedule.Remove(record);
        _numberOfScheduleRecords--;
    }

    // public static bool EditScheduleRecord(int index, string doctorId, string patientId, DateTime date)
    // {
    //     if (index < 0 || index >= _numberOfScheduleRecords)
    //     {
    //         return false;
    //     }
    //     Schedule[index] = new ScheduleClass(doctorId, patientId, date);
    //     return true;
    // }

    public static bool MakeAppointment(string doctorId, string patientId, DateTime date)
    {
        var existingRecord = Schedule.FirstOrDefault(s => s.DoctorId == doctorId && s.RecordDate == date);
        if (existingRecord != null)
        {
            return false; // Appointment slot already taken
        }
        AddScheduleRecord(doctorId, patientId, date);
        return true;
    }
}