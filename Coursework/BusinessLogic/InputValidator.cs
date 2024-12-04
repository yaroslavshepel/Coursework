// using BusinessLogic.Doctors;
//
// namespace BusinessLogic;
// using System;
// using System.Text.RegularExpressions;
//
// public static class InputValidator
// {
//     private static string _input = "";
//     public static string Validator(string request, string whatIsAsked, string typeOfRequest)
//     {
//         Console.WriteLine(request);
//         _input = Console.ReadLine() ?? string.Empty;
//         while (true)
//         {
//             {
//                 switch (typeOfRequest)
//                 {
//                     case "data":
//                     {
//                         if (!Regex.IsMatch(_input, @"^[a-zA-Z]+$") || string.IsNullOrEmpty(_input))
//                         { WrongInput(whatIsAsked); }
//                         else { return _input; }
//                         break;
//                     }
//                     case "phone number":
//                     {
//                         if (!Regex.IsMatch(_input, @"^(\+[0-9]{1,3})?[0-9]{9,10}$") || string.IsNullOrEmpty(_input))
//                         { WrongInput(whatIsAsked); }
//                         else { return _input; }
//                         break;
//                     }
//                     case "email address":
//                     {
//                         if (!Regex.IsMatch(_input, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") || string.IsNullOrEmpty(_input))
//                         { WrongInput(whatIsAsked); }
//                         else { return _input; }
//                         break;
//                     }
//                     case "doctor ID":
//                     {
//                         if (!Regex.IsMatch(_input, @"^D[0-9]+$") || string.IsNullOrEmpty(_input))
//                         { WrongInput(whatIsAsked); }
//                         else
//                         {
//                             if (DoctorsArray.Doctors.Find(d => d.DoctorId == _input) == null)
//                             { WrongInput(whatIsAsked); }
//                             else { return _input; }
//                         }
//                         break;
//                     }
//                     case "hour":
//                         if (!DateTime.TryParse(_input, out DateTime inputTime) || 
//                             inputTime.TimeOfDay < TimeSpan.FromHours(8) || 
//                             inputTime.TimeOfDay > TimeSpan.FromHours(12) || 
//                             (inputTime.Minute != 0 && inputTime.Minute != 30))
//                         {
//                             WrongInput(whatIsAsked);
//                         }
//                         else
//                         {
//                             return _input;
//                         }
//                         break;
//                     default:
//                         Console.WriteLine($"Please enter a valid {typeOfRequest}.");
//                         break;
//                 }
//             }
//         }
//     }
//     
//     private static void WrongInput(string reason)
//     {
//         Console.WriteLine($"Please enter a valid {reason}.");
//         _input = Console.ReadLine() ?? string.Empty;
//     }
// }

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
                    if (!Regex.IsMatch(_input, @"^[a-zA-Z]+$") || string.IsNullOrEmpty(_input))
                    {
                        WrongInput(whatIsAsked);
                    }
                    else
                    {
                        return _input;
                    }

                    break;
                case "phone number":
                    if (!Regex.IsMatch(_input, @"^(\+[0-9]{1,3})?[0-9]{9,10}$") || string.IsNullOrEmpty(_input))
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
                    if (!Regex.IsMatch(_input, @"^[DP][0-9]+$") || string.IsNullOrEmpty(_input))
                    {
                        WrongInput(whatIsAsked);
                    }
                    else
                    {
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
                        (inputTime.Minute != 0 && inputTime.Minute != 30))
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

            //_input = Console.ReadLine() ?? string.Empty; // Read input again if the previous input was invalid
        }

        return "0"; // Return an empty string if "STOP" is entered
    }

    public static DateTime ValidatorDate(string request, string typeOfRequest)
    {
        Console.WriteLine(request);
        _input = Console.ReadLine() ?? string.Empty;
        while (true)
        {
            if (DateTime.TryParse(_input, out DateTime inputDate))
            {
                return inputDate;
            }
            else
            {
                WrongInput(typeOfRequest);
            }
        }
    }
    
         private static void WrongInput(string reason)
     {
         Console.WriteLine($"Please enter a valid {reason}.");
         _input = Console.ReadLine() ?? string.Empty;
     }

     
}