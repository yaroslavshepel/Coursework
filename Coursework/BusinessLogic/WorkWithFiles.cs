using System.Text.Json;
namespace BusinessLogic;

//namespace Coursework;
//using Coursework.MainClasses;

public class WorkWithFiles
{
    public static async Task ReadFiles()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        try
        {
            await using (FileStream fs = new FileStream("Doctors.json", FileMode.OpenOrCreate))
            {
                var loadedDoctors = await JsonSerializer.DeserializeAsync<DoctorsData>(fs, options);
                if (loadedDoctors != null)
                {
                    DoctorsArray.SetNumberOfDoctors(loadedDoctors.NumberOfDoctors);
                    DoctorsArray.Doctors.Clear();
                    foreach (var doctor in loadedDoctors.Doctors)
                    {
                        DoctorsArray.Doctors.Add(doctor);
                    }
                }
            }
        
            /*
            await using (FileStream fs = new("Patients.json", FileMode.OpenOrCreate))
            {
                var loadedPatients = await JsonSerializer.DeserializeAsync<PatientsData>(fs, options);
                for (int i = 0; i < loadedPatients.Patients.Count; i++)
                {
                    PatientsArray.AddPatient(loadedPatients.Patients[i]);
                }
            }
            
            await using (FileStream fs = new("Schedule.json", FileMode.OpenOrCreate))
            {
                var loadedSchedule = await JsonSerializer.DeserializeAsync<ScheduleData>(fs, options);
                for (int i = 0; i < loadedSchedule.Records.Count; i++)
                {
                    ScheduleArray.AddRecord(loadedSchedule.Records[i]);
                }
            }
            */
        } 
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    // public static async Task WriteFiles()
    // {
    //     var options = new JsonSerializerOptions { WriteIndented = true };
    //     try
    //     {
    //         await using (FileStream fs = new("Doctors.json", FileMode.OpenOrCreate))
    //         {
    //             await JsonSerializer.SerializeAsync(fs, new DoctorsData { NumberOfDoctors = DoctorsArray.GetNumberOfDoctors(), Doctors = DoctorsArray.GetDoctors() }, options);
    //         }
    //         
    //         await using (FileStream fs = new("Patients.json", FileMode.OpenOrCreate))
    //         {
    //             await JsonSerializer.SerializeAsync(fs, new PatientsData { NumberOfPatients = PatientsArray.GetNumberOfPatients(), Patients = PatientsArray.GetPatients() }, options);
    //         }
    //         
    //         await using (FileStream fs = new("Schedule.json", FileMode.OpenOrCreate))
    //         {
    //             await JsonSerializer.SerializeAsync(fs, new ScheduleData { NumberOfRecords = ScheduleArray.GetNumberOfRecords(), Records = ScheduleArray.GetRecords() }, options);
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //     }
    // }
}