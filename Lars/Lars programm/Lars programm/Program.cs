using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare variables and then initialize to zero.
            int num1 = 0; int num2 = 0;

            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            // Ask the user to type the first number.
            Console.WriteLine("Zahl eingeben, dann Enter drücken...");
            num1 = Convert.ToInt32(Console.ReadLine());

            // Ask the user to type the second number.
            Console.WriteLine("Noch eine Zahl eingeben, dann Enter drücken...");
            num2 = Convert.ToInt32(Console.ReadLine());

            // Ask the user to choose an option.
            Console.WriteLine("Wähle eine der folgenden Optionen:");
            Console.WriteLine("\ta - Addieren");
            Console.WriteLine("\ts - Subtrahieren");
            Console.WriteLine("\tm - Multiplizieren");
            Console.WriteLine("\td - Dividieren");
            Console.Write("Deine Auswahl? ");

            // Use a switch statement to do the math.
            switch (Console.ReadLine())
            {
                case "a":
                    Console.WriteLine($"Dein Ergebnis: {num1} + {num2} = " + (num1 + num2));
                    break;
                case "s":
                    Console.WriteLine($"Dein Ergebnis: {num1} - {num2} = " + (num1 - num2));
                    break;
                case "m":
                    Console.WriteLine($"Dein Ergebnis: {num1} * {num2} = " + (num1 * num2));
                    break;
                case "d":
                    Console.WriteLine($"Dein Ergebnis: {num1} / {num2} = " + (num1 / num2));
                    break;
            }
            // Wait for the user to respond before closing.
            Console.Write("Einen Knopf drücken, um fortzufahren und die Anwendung zu schließen...");
            Console.ReadKey();
        }
    }
}