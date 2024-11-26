namespace BusinessLogic;
using System;
using System.Text.RegularExpressions;

public static class InputValidator
{
    private static string _input = "";
    public static string Validator(string request, string typeOfRequest)
    {
        //string input = Console.ReadLine();
        // switch (typeOfRequest)
        // {
        //     case 0:
        //     {
        //         while (true)
        //         {
        //             Console.WriteLine(request);
        //             if (string.IsNullOrEmpty(input))
        //             {
        //                 Console.WriteLine("Please enter a valid input.");
        //                 input = Console.ReadLine();
        //             }
        //             else
        //             {
        //                 return input;
        //             }
        //         }
        //     }
        //         break;
        // }
        
        _input = Console.ReadLine() ?? string.Empty;

        while (true)
        {
            Console.WriteLine(request);
            if (string.IsNullOrEmpty(_input))
            { WrongInput("data because this field cannot be empty"); }
            else
            {
                switch (typeOfRequest)
                {
                    case "data":
                    {
                        if (!Regex.IsMatch(_input, @"^[a-zA-Z]+$"))
                        { WrongInput(typeOfRequest); }
                        else { return _input; }
                        break;
                    }
                    case "phone number":
                    {
                        if (Regex.IsMatch(_input, @"^(\+[0-9]{1,3})?[0-9]{9,10}$"))
                        { return _input; }
                        else { WrongInput(typeOfRequest); }
                        break;
                    }
                    case "email address":
                    {
                        if (Regex.IsMatch(_input, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                        { return _input; }
                        else { WrongInput(typeOfRequest); }
                        break;
                    }
                }
            }
        }
    }
    
    private static void WrongInput(string reason)
    {
        Console.WriteLine($"Please enter a valid {reason}.");
        _input = Console.ReadLine() ?? string.Empty;
    }
    
    // public static string EmailValidator(string request)
    // {
    //     string input = Console.ReadLine();
    //     while (true)
    //     {
    //         Console.WriteLine(request);
    //         if (string.IsNullOrEmpty(input) || !Regex.IsMatch(input, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
    //         {
    //             Console.WriteLine("Please enter a valid email address.");
    //             input = Console.ReadLine();
    //         }
    //         else
    //         {
    //             return input;
    //         }
    //     }
    // }
    //
    // public static string PhoneNumberValidator(string request)
    // {
    //     string input = Console.ReadLine();
    //     while (true)
    //     {
    //         Console.WriteLine(request);
    //         if (string.IsNullOrEmpty(input) || !Regex.IsMatch(input, @"^(\+[0-9]{1,3})?[0-9]{9,10}$"))
    //         {
    //             Console.WriteLine("Please enter a valid phone number.");
    //             input = Console.ReadLine();
    //         }
    //         else
    //         {
    //             return input;
    //         }
    //     }
    // }
}