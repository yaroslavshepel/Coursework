namespace Coursework.MainClasses;

public class ScheduleClass
{
    private DoctorClass doctor;
    private PatientClass patient;
    private DateTime date;
    private string time;
    
    public ScheduleClass() { }
    
    public ScheduleClass(DoctorClass doctor, PatientClass patient, DateTime date, string time)
    {
        this.doctor = doctor;
        this.patient = patient;
        this.date = date;
        this.time = time;
    }
    
    public ScheduleClass AddRecord(DoctorClass doctor, PatientClass patient, DateTime date, string time)
    {
        return new ScheduleClass(doctor, patient, date, time);
    }
}