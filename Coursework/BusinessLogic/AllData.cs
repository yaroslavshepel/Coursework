namespace BusinessLogic;
using Doctors;
using Patients;
using Schedule;

public class DoctorsData
{
    public int NumberOfDoctors { get; set; }
    public List<DoctorClass> Doctors { get; set; } = new List<DoctorClass>();
}

public class PatientsData
{
    public int NumberOfPatients { get; set; }
    public List<PatientClass> Patients { get; set; } = new List<PatientClass>();
}

public class ScheduleData
{
    public int NumberOfScheduleRecords { get; set; }
    public List<ScheduleClass> ScheduleRecords = new List<ScheduleClass>();
}