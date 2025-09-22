using System;

class Program
{
    static void Main(string[] args)
    {

        string userName = GetUserName();


        int userAge = GetUserAge();


        double originalPrice;
        string ticketType;
        (ticketType, originalPrice) = SelectTicketAndCalculatePrice(userAge);


        double finalPrice = ApplyDiscount(originalPrice);


        PrintSummary(userName, ticketType, originalPrice, finalPrice);
    }


    static string GetUserName()
    {
        string name = "";
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty. Please try again.");
            }
        }
        return name;
    }


    static int GetUserAge()
    {
        int age = 0;
        while (age <= 0)
        {
            Console.Write("Please enter your age: ");
            string ageInput = Console.ReadLine();
            if (int.TryParse(ageInput, out age) && age > 0)
            {
                
            }
            else
            {
                Console.WriteLine("Invalid age. Please enter a positive number.");
                age = 0; 
            }
        }
        return age;
    }


    static (string, double) SelectTicketAndCalculatePrice(int age)
    {
        double price = 0;
        string ticketType = "";
        bool isValidSelection = false;

        while (!isValidSelection)
        {
            Console.WriteLine("\n--- Available Tickets ---");
            Console.WriteLine("1: Child's Ticket (€5) - under 12 years old");
            Console.WriteLine("2: Adult Ticket (€10) - 12 to 64 years old");
            Console.WriteLine("3: Senior Ticket (€7) - 65 years and older");
            Console.Write("Enter your choice (1, 2, or 3): ");
            string choiceInput = Console.ReadLine();

            if (int.TryParse(choiceInput, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        if (age < 12)
                        {
                            ticketType = "Child's Ticket";
                            price = 5.0;
                            isValidSelection = true;
                        }
                        else
                        {
                            Console.WriteLine("Error: Your age does not match the Child's Ticket criteria. Please select again.");
                        }
                        break;
                    case 2:
                        if (age >= 12 && age <= 64)
                        {
                            ticketType = "Adult Ticket";
                            price = 10.0;
                            isValidSelection = true;
                        }
                        else
                        {
                            Console.WriteLine("Error: Your age does not match the Adult Ticket criteria. Please select again.");
                        }
                        break;
                    case 3:
                        if (age >= 65)
                        {
                            ticketType = "Senior Ticket";
                            price = 7.0;
                            isValidSelection = true;
                        }
                        else
                        {
                            Console.WriteLine("Error: Your age does not match the Senior Ticket criteria. Please select again.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        return (ticketType, price);
    }


    static double ApplyDiscount(double currentPrice)
    {
        double finalPrice = currentPrice;
        bool tryingCode = true;

        while (tryingCode)
        {
            Console.Write("\nDo you have a discount code? (yes/no): ");
            string hasCode = Console.ReadLine().ToLower();

            if (hasCode == "yes")
            {
                Console.Write("Please enter your discount code: ");
                string code = Console.ReadLine();
                const string validCode = "SALE20";

                if (code.Equals(validCode, StringComparison.OrdinalIgnoreCase))
                {
                    double discountAmount = currentPrice * 0.20;
                    finalPrice = currentPrice - discountAmount;
                    Console.WriteLine("Discount applied! You saved 20%.");
                    tryingCode = false;
                }
                else
                {
                    Console.WriteLine("Incorrect discount code.");
                    Console.Write("Do you want to try another code? (yes/no): ");
                    string tryAgain = Console.ReadLine().ToLower();
                    if (tryAgain != "yes")
                    {
                        tryingCode = false;
                    }
                }
            }
            else
            {
                finalPrice = currentPrice;
                tryingCode = false;
            }
        }
        return finalPrice;
    }


    static void PrintSummary(string name, string ticketType, double originalPrice, double finalPrice)
    {
        Console.WriteLine("\n--- Purchase Summary ---");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Ticket Type: {ticketType}");
        Console.WriteLine($"Original Price: €{originalPrice:F2}");

        if (originalPrice > finalPrice)
        {
            double discountApplied = originalPrice - finalPrice;
            Console.WriteLine($"Discount Applied: -€{discountApplied:F2}");
        }
        else
        {
            Console.WriteLine("No Discount Applied.");
        }

        Console.WriteLine($"Final Price: €{finalPrice:F2}");
        Console.WriteLine("------------------------");
    }
}