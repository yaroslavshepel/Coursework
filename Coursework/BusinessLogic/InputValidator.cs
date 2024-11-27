namespace BusinessLogic;
using System;
using System.Text.RegularExpressions;

public static class InputValidator
{
    private static string _input = "";
    public static string Validator(string request, string typeOfRequest)
    {
        while (true)
        {
            {
                switch (typeOfRequest)
                {
                    case "data":
                    {
                        Console.WriteLine(request);
                        _input = Console.ReadLine() ?? string.Empty;
                        if (!Regex.IsMatch(_input, @"^[a-zA-Z]+$") || string.IsNullOrEmpty(_input))
                        { WrongInput(typeOfRequest); }
                        else { return _input; }
                        break;
                    }
                    case "phone number":
                    {
                        Console.WriteLine(request);
                        _input = Console.ReadLine() ?? string.Empty;
                        if (Regex.IsMatch(_input, @"^(\+[0-9]{1,3})?[0-9]{9,10}$") || string.IsNullOrEmpty(_input))
                        { return _input; }
                        else { WrongInput(typeOfRequest); }
                        break;
                    }
                    case "email address":
                    {
                        Console.WriteLine(request);
                        _input = Console.ReadLine() ?? string.Empty;
                        if (Regex.IsMatch(_input, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") || string.IsNullOrEmpty(_input))
                        { return _input; }
                        else { WrongInput(typeOfRequest); }
                        break;
                    }
                    /*default:
                    {
                        if (string.IsNullOrEmpty(_input))
                        { WrongInput("data because this field cannot be empty"); }
                        else { return _input; }
                        break;
                    }*/
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