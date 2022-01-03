using System;
using System.Collections.Generic;
using System.Threading;

namespace Bac3_Projet_Écosystème_195030
{
    class Program : Setup
    {
        static void Main()
        {

            Worldmap map = new(100, 100);

            List<string> elements = new();


            elements.Add("Rabbit");
            elements.Add("Bear");
            elements.Add("Baobab");
            elements.Add("Chardon");
            elements.Add("Wolf");
            elements.Add("Moose");
            elements.Add("Paquerette");


            for (int i = 0; i < start_counter; i++)
            {
                Random random = new();
                switch (random.Next(elements.Count))
                {
                    case 0:
                        map.Add(new Chardon());
                        break;
                    case 1:
                        map.Add(new Baobab());
                        break;
                    case 2:
                        map.Add(new Paquerette());
                        break;
                    case 3:
                        map.Add(new Wolf());
                        break;
                    case 4:
                        map.Add(new Moose());
                        break;
                    case 5:
                        map.Add(new Bear());
                        break;
                    case 6:
                        map.Add(new Rabbit());
                        break;
                }
            }




            int MaxTime = 0;
            while (map.Life_form_Number() > 0 && MaxTime < loop_stop)
            {
                MaxTime += 1;
                map.Update();

                //tourne en boucle tant que des animaux/plantes sont en vie
            }

            if (MaxTime == loop_stop)
            {
                
                Message_in_Color(String.Format("{1} life forms are therefore living for eternity ", MaxTime, map.GetIncrement()), ConsoleColor.Red);
                
            }
            else
            {
                
                Message_in_Color("Everyone is dead", ConsoleColor.Red);
                Message_in_Color(String.Format("Life lasted for {0} timeunits and {1} life forms were alive during that time", MaxTime, map.GetIncrement()), ConsoleColor.Red);
                
            }
        }
    }
}