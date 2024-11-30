﻿namespace BusinessLogic.Patients;
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
    private static int _doctorId = 0;

    public static Task AddPatient()
    {
        Console.WriteLine("Adding a patient.");
        _patientName = InputValidator.Validator("Enter the patient's name: ", "name", "data");
        _patientSurname = InputValidator.Validator("Enter the patient's surname: ", "surname", "data");
        _patientAddress = InputValidator.Validator("Enter the patient's address: ", "address", "data");
        _patientPhoneNumber = InputValidator.Validator("Enter the patient's phone number: ", "phone number", "phone number");
        _patientEmail = InputValidator.Validator("Enter the patient's email: ", "email", "email address");
        
        _patientDiagnosis = InputValidator.Validator("Enter the patient's diagnosis: ", "diagnosis", "data");
        DoctorsFunctions.PrintDoctors("IDs and specializations");
        _doctorId = Convert.ToInt32(InputValidator.Validator("Enter the doctor's ID: ", "ID", "doctor ID"));
        
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

        _patientName = InputValidator.Validator("Enter name of patient to edit: ", "name", "data");
        _patientSurname = InputValidator.Validator("Enter surname of patient to edit: ", "surname", "data");

        PatientClass patient = patients.Find(p => p.Name == _patientName && p.Surname == _patientSurname);
        if (patient == null)
        {
            Console.WriteLine("Patient not found.");
            return;
        }

        var newName = InputValidator.Validator("Enter the new name: ", "name", "data");
        var newSurname = InputValidator.Validator("Enter the new surname: ", "surname", "data");
        var newAddress = InputValidator.Validator("Enter the new address: ", "address", "data");
        var newPhoneNumber = InputValidator.Validator("Enter the new phone number: ", "phone number", "phone number");
        var newEmail = InputValidator.Validator("Enter the new email: ", "email", "email address");
        Console.WriteLine("New medical record is optional. Press Enter to skip. or press anything to continue.");
        if (Console.ReadKey().Key != ConsoleKey.Enter)
        {
            var newDiagnosis = InputValidator.Validator("Enter the new diagnosis: ", "diagnosis", "data");
            DoctorsFunctions.PrintDoctors("IDs and specializations");
            _doctorId = Convert.ToInt32(InputValidator.Validator("Enter the doctor's ID: ", "ID", "doctor ID"));
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

        _patientName = InputValidator.Validator("Enter name of patient to remove: ", "name", "data");
        _patientSurname = InputValidator.Validator("Enter surname of patient to remove: ", "surname", "data");

        var patient = patients.Find(p => p.Name == _patientName && p.Surname == _patientSurname);
        if (patient == null)
        {
            Console.WriteLine("Patient not found.");
            return;
        }
        PatientsArray.RemovePatient(patient);
        Console.Clear();
        Console.WriteLine("Patient removed successfully.");
    }

    public static void PrintPatients()
    {
        var patients = PatientsArray.Patients;
        if (patients.Count == 0) {Console.WriteLine("There are no patients in the system."); return;}
        Console.ForegroundColor = ConsoleColor.Blue; 
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
        Console.ResetColor();
    }
}