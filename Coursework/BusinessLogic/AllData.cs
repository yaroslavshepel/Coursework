namespace BusinessLogic;
using Doctors;
using Patients;
using Schedule;
// All Classes in this file are used to store data from JSON files before these data are added to the arrays in the main program.
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
    public List<ScheduleClass> Schedule { get; set; } = new List<ScheduleClass>();
}