namespace BusinessLogic;
using System.Text.Json;
using Doctors;

public class WorkWithFiles
{
    private static readonly JsonSerializerOptions Options = new JsonSerializerOptions { WriteIndented = true };
    public static async Task ReadFiles()
    {
        //var options = new JsonSerializerOptions { WriteIndented = true };
        try
        {
            await using (FileStream fs = new FileStream("Doctors.json", FileMode.OpenOrCreate))
            {
                var loadedDoctors = await JsonSerializer.DeserializeAsync<DoctorsData>(fs, Options);
                if (loadedDoctors != null)
                {
                    //DoctorsArray.SetNumberOfDoctors(loadedDoctors.NumberOfDoctors);
                    DoctorsArray.NumberOfDoctors = loadedDoctors.NumberOfDoctors;
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
    
    
    public static async Task WriteToFiles()
    {
        var doctorsToWrite = new List<DoctorClass>(DoctorsArray.Doctors);
        //var combinedData = new DoctorsData { NumberOfDoctors = doctorsToWrite.Count, Doctors = doctorsToWrite };
        var combinedData = new DoctorsData { NumberOfDoctors = DoctorsArray.NumberOfDoctors, Doctors = doctorsToWrite };
        try
        {
            await using (FileStream fs = new FileStream("Doctors.json", FileMode.Create))
            { await JsonSerializer.SerializeAsync(fs, combinedData, Options); }
        }
        catch (Exception e) { Console.WriteLine(e); }
    }
}