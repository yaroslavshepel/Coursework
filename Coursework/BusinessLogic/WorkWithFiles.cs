namespace BusinessLogic;
using System.Text.Json;
using Doctors;
using Patients;
using Schedule;

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
            { //! Read doctors from file
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
            
            await using (FileStream fs = new FileStream("Patients.json", FileMode.OpenOrCreate))
            { //! Read patients from file
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

            await using (FileStream fs = new FileStream("Schedule.json", FileMode.OpenOrCreate))
            { //! Read schedule from file
                var loadedSchedule = await JsonSerializer.DeserializeAsync<ScheduleData>(fs, Options);
                if (loadedSchedule != null)
                {
                    ScheduleArray.NumberOfScheduleRecords = loadedSchedule.NumberOfScheduleRecords;
                    ScheduleArray.Schedule.Clear();
                    foreach (var record in loadedSchedule.ScheduleRecords)
                    {
                        ScheduleArray.Schedule.Add(record);
                    }
                }
            }
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
            //! Write doctors to file
            var doctorsToWrite = new List<DoctorClass>(DoctorsArray.Doctors);
            var newDoctorData = new DoctorsData { NumberOfDoctors = DoctorsArray.NumberOfDoctors, Doctors = doctorsToWrite };
            await using (FileStream fs = new FileStream("Doctors.json", FileMode.Create))
            { await JsonSerializer.SerializeAsync(fs, newDoctorData, Options); }
            
            //! Write patients to file
            var patientsToWrite = new List<PatientClass>(PatientsArray.Patients);
            var newPatientData = new PatientsData { NumberOfPatients = PatientsArray.NumberOfPatients, Patients = patientsToWrite };
            await using (FileStream fs = new FileStream("Patients.json", FileMode.Create))
            { await JsonSerializer.SerializeAsync(fs, newPatientData, Options); }
            
            //! Write schedule to file
            var scheduleToWrite = new List<ScheduleClass>(ScheduleArray.Schedule);
            var newScheduleData = new ScheduleData { NumberOfScheduleRecords = ScheduleArray.NumberOfScheduleRecords, ScheduleRecords = scheduleToWrite };
            await using (FileStream fs = new FileStream("Schedule.json", FileMode.Create))
            { await JsonSerializer.SerializeAsync(fs, newScheduleData, Options); }
        }
        catch (Exception e) { Console.WriteLine(e); }
    }
}