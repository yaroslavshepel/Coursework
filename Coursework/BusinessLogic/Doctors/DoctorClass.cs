﻿namespace BusinessLogic.Doctors;

public class DoctorClass
{
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public string Specialization { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    
    //public DoctorClass() { }
    
    public DoctorClass(string name, string surname, string specialization, string phoneNumber)
    {
        Name = name;
        Surname = surname;
        Specialization = specialization;
        PhoneNumber = phoneNumber;
    }
    
    public DoctorClass EditDoctor(string name, string surname, string specialization, string phoneNumber)
    {
        Name = name;
        Surname = surname;
        Specialization = specialization;
        PhoneNumber = phoneNumber;
        return new DoctorClass(name, surname, specialization, phoneNumber);
    }
}