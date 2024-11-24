namespace Coursework.Arrays;
using MainClasses;
using Coursework;

public class ScheduleArray
{
    // public static int NumberOfRecords { get; set; }
    private static List<ScheduleClass> _schedule = new List<ScheduleClass>();

    public ScheduleArray() { }

    public static void AddRecord(ScheduleClass record)
    {
        _schedule.Add(record);
        //return;
    }

    public static void RemoveRecord(ScheduleClass record)
    {
        _schedule.Remove(record);
        //return this;
    }
    
    public static List<ScheduleClass> GetRecords()
    {
        return _schedule;
    }
    
    public static int GetNumberOfRecords()
    {
        return _schedule.Count;
    }
}