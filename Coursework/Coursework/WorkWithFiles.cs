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
            
            await using (FileStream fs = new("./Schedule.json", FileMode.OpenOrCreate))
            {
                var loadedSchedule = await JsonSerializer.DeserializeAsync<ScheduleData>(fs, options);
                for (int i = 0; i < loadedSchedule.Records.Count; i++)
                {
                    ScheduleArray.AddRecord(loadedSchedule.Records[i]);
                }
            }
        } 
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}