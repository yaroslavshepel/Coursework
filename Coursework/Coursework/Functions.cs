﻿namespace Coursework;
using MainClasses;
using Arrays;

public class Functions
{
    
    protected static int ChoiceCheck()
    {
        var choice = -1;
        try
        {
            choice = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            throw new CustomException("Invalid input format. Please enter a number.");
        }
        catch (Exception e)
        {
            throw new CustomException("An unexpected error occurred.", e);
        }
        Console.WriteLine(ConsoleMenu.PrintLongThing());
        return choice;
    }
    
    protected static void ManagementOfDoctors()
    {
        var isStopped = true;
        while (isStopped)
        {
            Console.WriteLine(ConsoleMenu.ManagementOfDoctorsMenu());
            var choice = ChoiceCheck();
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    AddDoctor();
                    break;
                case 2:
                    Console.Clear();
                    EditDoctor();
                    break;
                case 3:
                    Console.Clear();
                    DeleteDoctor();
                    break;
                case 4:
                    Console.Clear();
                    PrintDoctors();
                    break;
                case 5:
                    Console.Clear();
                    isStopped = false;
                    break;
            }
        }
    }
    
    protected static void ManagementOfPatients()
    {
        var isStopped = true;
        while (isStopped)
        {
            Console.WriteLine(ConsoleMenu.ManagementOfPatientsMenu());
            var choice = ChoiceCheck();
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    AddPatient();
                    break;
                case 2:
                    Console.Clear();
                    DeletePatient();
                    break;
                case 3:
                    Console.Clear();
                    // ElectronicMedicalRecord();
                    break;
                case 4:
                    Console.Clear();
                    isStopped = false;
                    break;
            }
        }
    }
    
    protected static void ManagementOfReceptionSchedule()
    {
        var isStopped = true;
        while (isStopped)
        {
            Console.WriteLine(ConsoleMenu.ManagementOfReceptionScheduleMenu());
            var choice = ChoiceCheck();
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    // AddReceptionSchedule();
                    break;
                case 2:
                    Console.Clear();
                    // DeleteReceptionSchedule();
                    break;
                case 3:
                    Console.Clear();
                    // EditReceptionSchedule();
                    break;
                case 4:
                    Console.Clear();
                    // MakeAppointment();
                    break;
                case 5:
                    Console.Clear();
                    isStopped = false;
                    break;
            }
        }
    }
    
    protected static void Search()
    {
        var isStopped = true;
        while (isStopped)
        {
            Console.WriteLine(ConsoleMenu.SearchMenu());
            var choice = ChoiceCheck();
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    // SearchPatient();
                    break;
                case 2:
                    Console.Clear();
                    // SearchDoctor();
                    break;
                case 3:
                    Console.Clear();
                    // GetDoctorSchedule();
                    break;
                case 4:
                    Console.Clear();
                    isStopped = false;
                    break;
            }
        }
    }
    
    private static string name, surname, specialization, phoneNumber;
    private static DoctorClass doctor;
    
    private static void AddDoctor()
    {
        name = InputValidator.Validator("Enter the doctor's name: ", "data");
        surname = InputValidator.Validator("Enter the doctor's surname: ", "data");
        specialization = InputValidator.Validator("Enter the doctor's specialization: ", "data");
        phoneNumber = InputValidator.Validator("Enter the doctor's phone number: ", "phone number");
        doctor = new DoctorClass(name, surname, specialization, phoneNumber);
        DoctorsArray.AddDoctor(doctor);
        Console.WriteLine("Doctor added successfully.");
    }
    
    private static void EditDoctor()
    {
        var doctors = DoctorsArray.GetDoctors();
        if (doctors.Count == 0) { Console.WriteLine("There are no doctors in the system."); return; }
        name = InputValidator.Validator("Enter name of doctor to edit: ", "data");
        surname = InputValidator.Validator("Enter surname of doctor to edit: ", "data");
        doctor = doctors.Find(d => d.Name == name && d.Surname == surname);
        if (doctor == null) { Console.WriteLine("Doctor not found."); return; }
        var newName = InputValidator.Validator("Enter the new name: ", "data");
        var newSurname = InputValidator.Validator("Enter the new surname: ", "data");
        var newSpecialization = InputValidator.Validator("Enter the new specialization: ", "data");
        var newPhoneNumber = InputValidator.Validator("Enter the new phone number: ", "phone number");
        DoctorsArray.EditDoctor(doctor, newName, newSurname, newSpecialization, newPhoneNumber);
        Console.WriteLine("Doctor edited successfully.");
    }
    
    private static void DeleteDoctor()
    {
        var doctors = DoctorsArray.GetDoctors();
        if (doctors.Count == 0) { Console.WriteLine("There are no doctors in the system."); return; }
        name = InputValidator.Validator("Enter name of doctor to delete: ", "data");
        surname = InputValidator.Validator("Enter surname of doctor to delete: ", "data");
        doctor = doctors.Find(d => d.Name == name && d.Surname == surname);
        if (doctor == null) { Console.WriteLine("Doctor not found."); return; }
        DoctorsArray.RemoveDoctor(doctor);
        Console.WriteLine("Doctor deleted successfully.");
    }
    
    private static void PrintDoctors()
    {
        var doctors = DoctorsArray.GetDoctors();
        if (doctors.Count == 0) { Console.WriteLine("There are no doctors in the system."); return; }
        foreach (var d in doctors)
        {
            Console.WriteLine($"Name: {d.Name}, Surname: {d.Surname}, Specialization: {d.Specialization}, Phone Number: {d.PhoneNumber}");
        }
    }
}