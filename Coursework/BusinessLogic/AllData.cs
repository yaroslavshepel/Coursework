namespace BusinessLogic;
//using MainClasses;

public class DoctorsData
{
    public int NumberOfDoctors { get; set; }
    public List<DoctorClass> Doctors {get; set; }
}

public class PatientsData
{
    public int NumberOfPatients { get; set; }
    public List<PatientClass> Patients = new List<PatientClass>();
}

public class ScheduleData
{
    public int NumberOfRecords { get; set; }
    public List<ScheduleClass> Records = new List<ScheduleClass>();
}