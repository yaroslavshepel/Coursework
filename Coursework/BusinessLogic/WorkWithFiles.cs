using System.Text.Json;
namespace BusinessLogic;

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
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine($"JSON Error: {jsonEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Error: {ex.Message}");
        }
    }
    /*
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
        /*} 
        catch (Exception e)
        {
            Console.WriteLine(e);
        }*/
    //}
    
    /*public static async Task WriteToFiles()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        DoctorsData existingData;
        
        if (File.Exists("Students.json"))
        {
            using (FileStream fs = new FileStream("Students.json", FileMode.Open))
            {
                existingData = await JsonSerializer.DeserializeAsync<DoctorsData>(fs, options);
            }
        }
        else
        {
            existingData = new DoctorsData() { NumberOfDoctors = 0, Doctors = new List<DoctorClass>() };
        }
        
        //var combinedDoctors = new DoctorClass[existingData.Doctors.Count + 1];
        var combinedDoctors = new List<DoctorClass>(existingData.Doctors);
        //existingData.Doctors.CopyTo(combinedDoctors, 0);
        //combinedDoctors[existingData.Doctors.Count()] = DoctorsArray.GetDoctors().Last();
        combinedDoctors.Add(DoctorsArray.GetDoctors().Last());
        
       
        var combinedData = new DoctorsData()
        {
            NumberOfDoctors = combinedDoctors.Count(),
            Doctors = combinedDoctors.ToList()
        };
        try
        {
            await using (FileStream fs = new FileStream("Doctors.json", FileMode.OpenOrCreate))
            {
                //await JsonSerializer.SerializeAsync(fs, new DoctorsData { NumberOfDoctors = DoctorsArray.GetNumberOfDoctors(), Doctors = DoctorsArray.GetDoctors() }, options);
                await JsonSerializer.SerializeAsync(fs, combinedData, options);
            }
            /*
            await using (FileStream fs = new FileStream("Patients.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, new PatientsData { NumberOfPatients = PatientsArray.GetNumberOfPatients(), Patients = PatientsArray.GetPatients() }, options);
            }
            
            await using (FileStream fs = new FileStream("Schedule.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, new ScheduleData { NumberOfRecords = ScheduleArray.GetNumberOfRecords(), Records = ScheduleArray.GetRecords() }, options);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }*/
    
    public static async Task WriteToFiles()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        DoctorsData existingData;

        if (File.Exists("Doctors.json"))
        {
            using (FileStream fs = new FileStream("Doctors.json", FileMode.Open))
            {
                existingData = await JsonSerializer.DeserializeAsync<DoctorsData>(fs, options);
            }
        }
        else
        {
            existingData = new DoctorsData() { NumberOfDoctors = 0, Doctors = new List<DoctorClass>() };
        }

        var combinedDoctors = new List<DoctorClass>(DoctorsArray.Doctors);
        //combinedDoctors.Add(DoctorsArray.GetDoctors().Last());

        
        var combinedData = new DoctorsData()
        {
        NumberOfDoctors = combinedDoctors.Count,
        Doctors = combinedDoctors
        };

        try
        {
            await using (FileStream fs = new FileStream("Doctors.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, combinedData, options);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}