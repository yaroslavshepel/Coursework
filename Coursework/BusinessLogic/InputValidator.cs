using BusinessLogic.Doctors;

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
            {
                switch (typeOfRequest)
                {
                    case "data":
                    {
                        if (!Regex.IsMatch(_input, @"^[a-zA-Z]+$") || string.IsNullOrEmpty(_input))
                        { WrongInput(whatIsAsked); }
                        else { return _input; }
                        break;
                    }
                    case "phone number":
                    {
                        if (!Regex.IsMatch(_input, @"^(\+[0-9]{1,3})?[0-9]{9,10}$") || string.IsNullOrEmpty(_input))
                        { WrongInput(whatIsAsked); }
                        else { return _input; }
                        break;
                    }
                    case "email address":
                    {
                        if (!Regex.IsMatch(_input, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") || string.IsNullOrEmpty(_input))
                        { WrongInput(whatIsAsked); }
                        else { return _input; }
                        break;
                    }
                    case "doctor ID":
                    {
                        if (!Regex.IsMatch(_input, @"^[0-9]+$") || string.IsNullOrEmpty(_input))
                        { WrongInput(whatIsAsked); }
                        else
                        {
                            if (DoctorsArray.Doctors.Find(d => d.DoctorId == Convert.ToInt32(_input)) == null)
                            { WrongInput(whatIsAsked); }
                            else { return _input; }
                        }
                        break;
                    }
                    default:
                        Console.WriteLine($"Please enter a valid {typeOfRequest}.");
                        break;
                }
            }
        }
    }
    
    private static void WrongInput(string reason)
    {
        Console.WriteLine($"Please enter a valid {reason}.");
        _input = Console.ReadLine() ?? string.Empty;
    }
}