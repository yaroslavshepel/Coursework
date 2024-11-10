namespace Coursework;
using MainClasses;

public class DoctorsData
{
    public int NumberOfDoctors { get; set; }
    public List<DoctorClass> Doctors = new List<DoctorClass>();
}

public class PatientsData
{
    public int NumberOfPatients { get; set; }
    public List<PatientClass> Patients = new List<PatientClass>();
}

public class AppointmentsData
{
    public int NumberOfAppointments { get; set; }
    public List<AppointmentClass> Appointments = new List<AppointmentClass>();
}