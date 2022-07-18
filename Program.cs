using System;
using System.Collections;
using System.Collections.Generic;
namespace MoviePlex
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Instance to call Welcome Part of our Project
            Main main = new Main();
            main.Welcome();
            //--------------------------------------------------------------------------
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nPress enter to Exit : ");
            Console.ReadLine();
        }
        
    }
}