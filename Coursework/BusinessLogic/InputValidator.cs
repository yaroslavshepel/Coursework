using BusinessLogic.Doctors;
using BusinessLogic.Patients;

namespace BusinessLogic;
using System;
using System.Text.RegularExpressions;

public static class InputValidator
{
    private static string _input = "";
    public static string Validator(string request, string whatIsAsked, string typeOfRequest)
    {
        
        Console.WriteLine(request);
        _input = Console.ReadLine() ?? string.Empty;
        while (true)
        {
            if (_input.Equals("STOP", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            switch (typeOfRequest)
            {
                case "data":
                    if (!Regex.IsMatch(_input, @"^[a-zA-Z\s]+$") || string.IsNullOrEmpty(_input))
                    {
                        WrongInput(whatIsAsked);
                    }
                    else
                    {
                        string firstLetter = _input.Substring(0, 1).ToUpper();
                        return firstLetter + _input.Substring(1);
                    }
                    break;
                
                case "phone number":
                    if (!Regex.IsMatch(_input, @"^(\+[0-9]{1,3})?[0-9]{10}$") || string.IsNullOrEmpty(_input))
                    {
                        WrongInput(whatIsAsked);
                    }
                    else
                    {
                        return _input;
                    }
                    break;
                
                case "email address":
                    if (!Regex.IsMatch(_input, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") ||
                        string.IsNullOrEmpty(_input))
                    {
                        WrongInput(whatIsAsked);
                    }
                    else
                    {
                        return _input;
                    }
                    break;
                
                case "ID":
                    if (!Regex.IsMatch(_input, @"^[DPdp][0-9]+$") || string.IsNullOrEmpty(_input))
                    {
                        WrongInput(whatIsAsked);
                    }
                    else
                    {
                        _input = _input.Substring(0, 1).ToUpper() + _input.Substring(1);
                        if (DoctorsArray.Doctors.Find(d => d.DoctorId == _input) == null && 
                            PatientsArray.Patients.Find(p => p.PatientId == _input) == null)
                        {
                            WrongInput(whatIsAsked);
                        }
                        else
                        {
                            return _input;
                        }
                    }
                    break;
                
                case "hour":
                    if (_input == "STOP")
                    {
                        return "STOP";
                    }
                    if (!DateTime.TryParse(_input, out DateTime inputTime) ||
                        inputTime.TimeOfDay < TimeSpan.FromHours(8) ||
                        inputTime.TimeOfDay > TimeSpan.FromHours(12) ||
                        (inputTime.Minute != 0 && inputTime.Minute != 30) || inputTime < DateTime.Now)
                    {
                        WrongInput(whatIsAsked);
                    }
                    else
                    {
                        return _input;
                    }

                    break;
                
                default:
                    Console.WriteLine($"Please enter a valid {typeOfRequest}.");
                    break;
            }
        }
        return "0";
    }

    public static DateTime ValidatorDate(string request, string typeOfRequest)
    {
        Console.WriteLine(request);
        _input = Console.ReadLine() ?? string.Empty;
        while (true)
        {
            if (!DateTime.TryParse(_input, out DateTime inputDate))
            {
                WrongInput(typeOfRequest);
            }
            else
            {
                return inputDate;
            }
        }
    }
    
    private static void WrongInput(string reason)
    {
        Console.WriteLine($"Please enter a valid {reason}.");
        _input = Console.ReadLine() ?? string.Empty;
    }
}