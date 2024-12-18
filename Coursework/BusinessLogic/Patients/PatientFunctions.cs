using BusinessLogic.Schedule;

namespace BusinessLogic.Patients;
using MedicalRecords;
using Doctors;

public class PatientFunctions
{
    private static string _patientName = "";
    private static string _patientSurname = "";
    private static string _patientAddress = "";
    private static string _patientPhoneNumber = "";
    private static string _patientEmail = "";
    private static string _patientDiagnosis = "";
    private static string _patientTreatment = "";
    private static string _doctorId = "";
    private static string _patientId = "";

    public static Task AddPatient()
    {
        Console.WriteLine("Adding a patient.");
        
        _patientName = InputValidator.Validator("Enter the patient's name: ", "name", "data");
        _patientSurname = InputValidator.Validator("Enter the patient's surname: ", "surname", "data");
        _patientAddress = InputValidator.Validator("Enter the patient's address: ", "address", "data");
        _patientPhoneNumber = InputValidator.Validator("Enter the patient's phone number: ", "phone number", "phone number");
        _patientEmail = InputValidator.Validator("Enter the patient's email: ", "email", "email address");
        _patientDiagnosis = InputValidator.Validator("Enter the patient's diagnosis: ", "diagnosis", "data");
        
        DoctorsFunctions.PrintDoctors("IDs, Surname and specializations");
        _doctorId = InputValidator.Validator("Enter the doctor's ID: ", "ID", "ID");
        _patientTreatment = InputValidator.Validator("Enter the patient's treatment: ", "treatment", "data");
        
        PatientsArray.AddPatient(_patientName, _patientSurname, _patientAddress, _patientPhoneNumber, _patientEmail, 
        MedicalRecordClass.AddRecord( _doctorId, _patientDiagnosis, _patientTreatment));
        Console.Clear();
        Console.WriteLine("Patient added successfully.");
        return Task.CompletedTask;
    }
    
    public static void EditPatient()
    {
        var patients = PatientsArray.Patients;
        if (patients.Count == 0)
        {
            Console.WriteLine("There are no patients in the system.");
            return;
        }
        PrintPatients("task");
        
        _patientId = InputValidator.Validator("Enter the patient's ID: ", "ID", "ID");

        PatientClass patient = patients.Find(p => p.PatientId == _patientId) ?? new PatientClass();

        var newName = InputValidator.Validator("Enter the new name: ", "name", "data");
        var newSurname = InputValidator.Validator("Enter the new surname: ", "surname", "data");
        var newAddress = InputValidator.Validator("Enter the new address: ", "address", "data");
        var newPhoneNumber = InputValidator.Validator("Enter the new phone number: ", "phone number", "phone number");
        var newEmail = InputValidator.Validator("Enter the new email: ", "email", "email address");
        Console.WriteLine("New medical record is optional. Press Enter to skip. or press anything to continue.");
        if (Console.ReadKey().Key != ConsoleKey.Enter)
        {
            var newDiagnosis = InputValidator.Validator("Enter the new diagnosis: ", "diagnosis", "data");
            DoctorsFunctions.PrintDoctors("IDs, Surname and specializations");
            _doctorId = InputValidator.Validator("Enter the doctor's ID: ", "ID", "doctor ID");
            var newTreatment = InputValidator.Validator("Enter the new treatment: ", "treatment", "data");

            var medicalRecord = new MedicalRecordClass();
            medicalRecord.EditRecord(patient.MedicalRecord.RecordId, _doctorId, newDiagnosis, newTreatment);

            patient.EditPatient(newName, newSurname, newAddress, newPhoneNumber, newEmail, medicalRecord);
            Console.Clear();
            Console.WriteLine("Patient edited successfully.");
        }
        else
        {
            patient.EditPatient(newName, newSurname, newAddress, newPhoneNumber, newEmail, patient.MedicalRecord);
            Console.Clear();
            Console.WriteLine("Patient edited successfully.");
        }
    }

    public static void RemovePatient()
    {
        var patients = PatientsArray.Patients;
        if (patients.Count == 0)
        {
            Console.WriteLine("There are no patients in the system.");
            return;
        }
        
        PrintPatients("task");
        
        _patientId = InputValidator.Validator("Enter the patient's ID: ", "patient's ID", "ID");
        
        PatientClass patient = patients.Find(p => p.PatientId == _patientId) ?? new PatientClass();
        
        PatientsArray.RemovePatient(patient);
        ScheduleArray.RemoveScheduleRecord(_patientId);
        Console.Clear();
        Console.WriteLine("Patient removed successfully.");
    }

    public static void PrintPatients(string request)
    {
        var patients = PatientsArray.Patients;
        if (patients.Count == 0) {Console.WriteLine("There are no patients in the system."); return;}
        Console.ForegroundColor = ConsoleColor.Blue; 
        switch (request)
        {
            case "Task":
            {
                for(int i = 0; i < PatientsArray.NumberOfPatients; i++)
                {
                    Console.WriteLine($"ID: {patients[i].PatientId}, " +
                                      $"Name: {patients[i].Name}, " +
                                      $"Surname: {patients[i].Surname}, " +
                                      $"Address: {patients[i].Address}, " +
                                      $"Phone Number: {patients[i].PhoneNumber}, " +
                                      $"Email: {patients[i].Email}\n" +
                                      $"Medical Record: {patients[i].MedicalRecord.PrintRecord()}\n", Console.ForegroundColor);
                }
                break;
            }
            case "ID and Diagnosis":
            {
                for(int i = 0; i < PatientsArray.NumberOfPatients; i++)
                {
                    Console.WriteLine($"ID: {patients[i].PatientId}, " +
                                      $"Diagnosis: {patients[i].MedicalRecord.Diagnosis}", Console.ForegroundColor);
                }
                Console.WriteLine();
                break;
            }
        }
        Console.ResetColor();
    }
}