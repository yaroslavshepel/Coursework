namespace Coursework.Arrays;
using MainClasses;
using Coursework;

public class ScheduleArray
{
    private int _numberOfRecords { get; set; }
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
}