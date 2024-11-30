namespace BusinessLogic;
using System.Text.Json;
using Doctors;
using Patients;

public class WorkWithFiles
{
    private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true
    };
    public static async Task ReadFiles()
    {
        try
        {
            await using (FileStream fs = new FileStream("Doctors.json", FileMode.OpenOrCreate))
            { // Read doctors from file
                var loadedDoctors = await JsonSerializer.DeserializeAsync<DoctorsData>(fs, Options);
                if (loadedDoctors != null)
                {
                    DoctorsArray.NumberOfDoctors = loadedDoctors.NumberOfDoctors;
                    DoctorsArray.Doctors.Clear();
                    foreach (var doctor in loadedDoctors.Doctors)
                    {
                        DoctorsArray.Doctors.Add(doctor);
                    }
                }
            }
            
            // await using (FileStream fs = new FileStream("Patients.json", FileMode.OpenOrCreate))
            // { // Read patients from file
            //     var loadedPatients = await JsonSerializer.DeserializeAsync<PatientsData>(fs, Options);
            //     if (loadedPatients != null)
            //     {
            //         PatientsArray.NumberOfPatients = loadedPatients.NumberOfPatients;
            //         PatientsArray.Patients.Clear();
            //         foreach (var patient in loadedPatients.Patients)
            //         {
            //             PatientsArray.Patients.Add(patient);
            //         }
            //     }
            // }
            await using (FileStream fs = new FileStream("Patients.json", FileMode.OpenOrCreate))
            { // Read patients from file
                var loadedPatients = await JsonSerializer.DeserializeAsync<PatientsData>(fs, Options);
                if (loadedPatients != null)
                {
                    PatientsArray.NumberOfPatients = loadedPatients.NumberOfPatients;
                    PatientsArray.Patients.Clear();
                    for (int i = 0; i < PatientsArray.NumberOfPatients; i++)
                    {
                        PatientsArray.Patients.Add(loadedPatients.Patients[i]);
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
        try
        {
            var doctorsToWrite = new List<DoctorClass>(DoctorsArray.Doctors);
            var newDoctorData = new DoctorsData { NumberOfDoctors = DoctorsArray.NumberOfDoctors, Doctors = doctorsToWrite };
            await using (FileStream fs = new FileStream("Doctors.json", FileMode.Create))
            { await JsonSerializer.SerializeAsync(fs, newDoctorData, Options); }
            
            var patientsToWrite = new List<PatientClass>(PatientsArray.Patients);
            var newPatientData = new PatientsData { NumberOfPatients = PatientsArray.NumberOfPatients, Patients = patientsToWrite };
            await using (FileStream fs = new FileStream("Patients.json", FileMode.Create))
            { await JsonSerializer.SerializeAsync(fs, newPatientData, Options); }
        }
        catch (Exception e) { Console.WriteLine(e); }
    }
}