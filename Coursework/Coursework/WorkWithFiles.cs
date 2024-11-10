using System.Text.Json;
using Coursework.Arrays;

namespace Coursework;
using Coursework.MainClasses;

public class WorkWithFiles
{
    public static async Task ReadFiles()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        try 
        {
            await using (FileStream fs = new("./Doctors.json", FileMode.OpenOrCreate))
            {
                var loadedDoctors = await JsonSerializer.DeserializeAsync<DoctorsData>(fs, options);
                for (int i = 0; i < loadedDoctors.Doctors.Count; i++)
                {
                    DoctorsArray.AddDoctor(loadedDoctors.Doctors[i]);
                }
            }
            
            await using (FileStream fs = new("./Patients.json", FileMode.OpenOrCreate))
            {
                var loadedPatients = await JsonSerializer.DeserializeAsync<PatientsData>(fs, options);
                for (int i = 0; i < loadedPatients.Patients.Count; i++)
                {
                    PatientsArray.AddPatient(loadedPatients.Patients[i]);
                }
            }
            
            await using (FileStream fs = new("./Appointments.json", FileMode.OpenOrCreate))
            {
                var loadedAppointments = await JsonSerializer.DeserializeAsync<AppointmentsData>(fs, options);
                for (int i = 0; i < loadedAppointments.Appointments.Count; i++)
                {
                    AppointmentsArray.AddAppointment(loadedAppointments.Appointments[i]);
                }
            }
        } 
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}