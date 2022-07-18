using System;

namespace MoviePlex
{
    internal class Password
    {
        public Password()
        {
        }
        public void checkPassword()
        {
            // Loop to enter correct password only for 4 times
            for (int i = 4; i > -1; i--)
            {
                var pass = string.Empty;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("\nPlease Enter Administrator Password or press C to go back to menu : ");
                
                //To enter password in '*' Form 
                ConsoleKey key;
                do
                {
                    var keyInfo = Console.ReadKey(intercept: true);
                    key = keyInfo.Key;

                    if (key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        Console.Write("\b \b");
                        pass = pass[0..^1];
                    }
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        Console.Write("*");
                        pass += keyInfo.KeyChar;
                    }
                } while (key != ConsoleKey.Enter);

                //To Check Password
                if (pass == "may")
                {
                    
                    break;
                }
                else if (i == 0)
                {
                    Main main = new Main();
                    main.Welcome();
                }
                else
                {
                    if (pass == "c")
                    {
                        Main main = new Main();
                        main.Welcome();
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease enter correct password");
                    Console.WriteLine("You have {0}", i + " more attempts to enter correct password or press C to go back to menu");
                }
            }
        }
    }
}