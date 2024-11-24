namespace Coursework;
using System;
using System.Text.RegularExpressions;

public static class InputValidator
{
    private static string input;
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
        
        input = Console.ReadLine();

        while (true)
        {
            Console.WriteLine(request);
            if (string.IsNullOrEmpty(input))
            { WrongInput("data because this field cannot be empty"); }
            else
            {
                switch (typeOfRequest)
                {
                    case "data":
                    {
                        if (!Regex.IsMatch(input, @"^[a-zA-Z]+$"))
                        { WrongInput(typeOfRequest); }
                        else { return input; }
                        break;
                    }
                    case "phone number":
                    {
                        if (Regex.IsMatch(input, @"^(\+[0-9]{1,3})?[0-9]{9,10}$"))
                        { return input; }
                        else { WrongInput(typeOfRequest); }
                        break;
                    }
                    case "email address":
                    {
                        if (Regex.IsMatch(input, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                        { return input; }
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
        input = Console.ReadLine();
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