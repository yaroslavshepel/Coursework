﻿using BusinessLogic.MedicalRecords;
using System.Globalization;

namespace BusinessLogic.Patients;

public class PatientClass
{
    private string _patientId = "";
    private string _name = "";
    private string _surname = "";
    private string _address = "";
    private string _phoneNumber = "";
    private string _email = "";
    private MedicalRecordClass _medicalRecord = new MedicalRecordClass();
    
    public string PatientId { get => _patientId; set => _patientId = value; }
    public string Name { get => _name; set => _name = value; }
    public string Surname { get => _surname; set => _surname = value; }
    public string Address { get => _address; set => _address = value; }
    public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
    public string Email { get => _email; set => _email = value; }
    public MedicalRecordClass MedicalRecord { get => _medicalRecord; set => _medicalRecord = value; }

    public PatientClass(){}
    
    public PatientClass(string patientId, string name, string surname, string address, string phoneNumber, string email, MedicalRecordClass medicalRecord)
    {
        _patientId = patientId;
        _name = name;
        _surname = surname;
        _address = address;
        _phoneNumber = phoneNumber;
        _email = email;
        _medicalRecord = medicalRecord;
    }

    public void EditPatient(string name, string surname, string address, string phoneNumber, string email, MedicalRecordClass medicalRecord)
    {
        _name = name;
        _surname = surname;
        _address = address;
        _phoneNumber = phoneNumber;
        _email = email;
        _medicalRecord = medicalRecord;
    }
}
public class PatientSurnameComparer : IComparer<PatientClass>
{
    
    public int Compare(PatientClass? x, PatientClass? y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        return string.Compare(x.Surname, y.Surname, CultureInfo.InvariantCulture, CompareOptions.None);
    }
}