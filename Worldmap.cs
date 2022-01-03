using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Bac3_Projet_Écosystème_195030
{
    public class Worldmap : Setup
    {
        
        public List<Element> elements = new();
        private int nb_lifeforms = 0;
        private int increment = 0;
        readonly Random random = new();
        public readonly int X_Length;
        public readonly int Y_Length;




        public Worldmap(int x_size, int y_size)
        {
            this.X_Length = x_size;
            this.Y_Length = y_size;
        }

        public void Add(Element NewElement, int x = -1, int y = -1)
        {
            bool isplant = typeof(Plants).IsAssignableFrom(NewElement.GetType());
            bool isanimal = typeof(Animals).IsAssignableFrom(NewElement.GetType());
            if (isplant || isanimal)
            {
                nb_lifeforms += 1;
            }
            elements.Add(NewElement);
            if (x == -1)
            {
                NewElement.SetPos(random.Next(X_Length), random.Next(Y_Length));
            }
            else
            {
                NewElement.SetPos(x, y);
            }
            NewElement.SetId(increment);
            increment += 1;
            Console.WriteLine(String.Format("{0} has been spawned", NewElement.GetName()));
        }



        public int Life_form_Number()
        {
            return nb_lifeforms;
        }

        public int GetIncrement()
        {
            return increment;
        }

        public bool Contains(Element element)
        {
            return elements.Contains(element);
        }


        public void Kill(Element dying_element, string reason = "", bool spawn = true)
        {
            if (Death_message && reason != "")
            {
                Message_in_Color(reason, ConsoleColor.Red);
            }
            elements.Remove(dying_element);
            int x = dying_element.GetPos().Item1;
            int y = dying_element.GetPos().Item2;
            switch (dying_element)
            {
                case Animals:
                    Add(new Meat(), x, y);
                    nb_lifeforms -= 1;
                    break;
                case Plants:
                    if (spawn) { Add(new OrganicWaste(), x, y); }
                    nb_lifeforms -= 1;
                    break;
            }
            Message_in_Color(String.Format("{0} organisms left", nb_lifeforms), ConsoleColor.Red);

        }

        
        private List<Element> CloseAnimals(Animals animal)
        {
            List<Element> CloseElements = new();
            foreach (Element element in elements.ToList())
            {
                if (element == animal)
                {
                    continue;
                }
                else
                {
                    if (animal.GetInRange(element, animal.SightRadius))
                    {
                        CloseElements.Add(element);
                        if (Closeto_Message)
                        {
                            Console.WriteLine(String.Format("{0} approaching {1}", animal.GetName(), element.GetName()));
                        }
                    }
                }
            }
            return CloseElements;
        }


        public void ActivityTracker(Animals animal)
        {
            List<Element> close_entities = CloseAnimals(animal);
            foreach (Element element in close_entities.ToList())
            {
                //Types of elements to determine types of interactions
                bool isplant = typeof(Plants).IsAssignableFrom(element.GetType());
                bool isanimal = typeof(Animals).IsAssignableFrom(element.GetType());
                bool ismeat = typeof(Meat).IsAssignableFrom(element.GetType());
                bool isherbivore = typeof(PlantEater).IsAssignableFrom(animal.GetType());
                bool iscarnivore = typeof(Meateater).IsAssignableFrom(animal.GetType());


                //Planteater and Plant
                if (isplant && isherbivore)
                {
                    if (animal.GetInRange(element, animal.ContactRadius))
                    {
                        (animal as PlantEater).Eat(element as Plants, this);
                        return;
                    }
                    else
                    {
                        animal.MoveTo(element);
                        return;
                    }
                }

                //Meateater and meat
                if (ismeat && iscarnivore)
                {
                    if (animal.GetInRange(element, animal.ContactRadius))
                    {
                        (animal as Meateater).Eat(element as Meat, this);
                        return;
                    }
                    else
                    {
                        animal.MoveTo(element);
                        return;
                    }
                }

                //Animals between themselves
                if (isanimal)
                {
                    bool Oppositgender = (element as Animals).sex != animal.sex;
                    bool sameFamily = element.GetType() == animal.GetType();
                    bool ispregnant = (element as Animals).isPregnant() || animal.isPregnant();
                    if (Oppositgender && sameFamily && !ispregnant)
                    {
                        if (animal.GetInRange(element, animal.ContactRadius))
                        {
                            animal.Impregnate(element as Animals);
                            return;
                        }
                        else
                        {
                            animal.MoveTo(element);
                            return;
                        }
                    }

                    //Predators fight
                    if (iscarnivore && !sameFamily)
                    {
                        if (animal.GetInRange(element, animal.ContactRadius))
                        {
                            animal.Fight(element as Animals, this);
                            return;
                        }
                        else
                        {
                            animal.MoveTo(element);
                            return;
                        }
                    }

                }
            }
            int dx = random.Next(100) <= 50 ? random.Next(MovementRange) : random.Next(MovementRange) * -1;
            int dy = random.Next(100) <= 50 ? random.Next(MovementRange) : random.Next(MovementRange) * -1;
            animal.Move(dx, dy, this);
        }


        public void Update()
        {
            int loop_cooldown = 100;
            foreach (Element element in elements.ToList())
            {
                if (typeof(OrganicWaste).IsAssignableFrom(element.GetType())) { continue; }
                Thread.Sleep(loop_cooldown);
                element.Update(this);
            }
        }
    }
}