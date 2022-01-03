using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bac3_Projet_Écosystème_195030
{
    public class Setup
    {
        public const int loop_cooldown = 0;
        public const int start_counter = 40;
        public const int loop_stop = 2000;


        public const bool Death_message = true;
        public const bool Closeto_Message = false;
        
        public const bool HPToEnergy_Message = false;
        public const bool Approaching_Message = false;
        public const int MovementRange = 10;
       
        public const bool made_pregnant_message = true;

        public static void Message_in_Color(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}