using System;
using System.Threading;

namespace CyberAwarenessBot
{
    public static class ConsoleUI
    {
        public static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
   ____                  _                      _   _             
  / ___|_ __ _   _ _ __ | |_ ___ _ __ ___   ___| |_| |_ ___  _ __ 
 | |   | '__| | | | '_ \| __/ _ \ '_ ` _ \ / _ \ __| __/ _ \| '__|
 | |___| |  | |_| | |_) | ||  __/ | | | | |  __/ |_| || (_) | |   
  \____|_|   \__, | .__/ \__\___|_| |_| |_|\___|\__|\__\___/|_|   
             |___/|_|                                             
");
            Console.ResetColor();

            // Online site
            //Title: ASCII Art Archive – Cybersecurity
            //Author: ASCII Art Archive
            //Date: 2023
            //URL: https://www.asciiart.eu/computers/security
            //Accessed: 20 April 2025.

        }

        public static void TypeEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(30);
            }
            Console.WriteLine();
        }

        public static void PrintDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("====================================================");
            Console.ResetColor();

        // Online site
        // Title: C# Guide – Console Class
        //Author: Microsoft
        //Date: 2024
        //URL: https://learn.microsoft.com/en-us/dotnet/api/system.console
        //Accessed: 20 April 2025.
        }
    }
}

