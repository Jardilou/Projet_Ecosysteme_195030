using System;
using System.Threading;
namespace Bac3_Projet_Écosystème_195030

{
    public abstract class Animals : Life_Form
    {
        public readonly int SightRadius;
        public readonly int ContactRadius;
        public readonly int damage;
        public readonly string sex;
        protected bool IsPregnant = false;
        protected int PregnancyTime = 0;
        public int MaternityRest = 0;
        

        public Animals(string Name, int maxHP, int maxEnergy, int SightRadius, int ContactRadius, int damage, int MaternityRest = 0) :
            base(Name, maxHP, maxEnergy)
        {
            Random random = new();
            sex = random.Next(100) <= 50 ? "Male" : "Female";
            this.SightRadius = SightRadius;
            this.ContactRadius = ContactRadius;
            this.damage = damage;
            
            this.MaternityRest = MaternityRest;
        }
        public abstract void Reproduce(Worldmap map);

        public override string GetName()
        {
            return String.Format("{0}, id : {4}, {3}, ({1},{2}), hp :{5}, energie {6} ", Name, Pos_x, Pos_y, sex, id, HP, Energy);
        }
        
        public void Fight(Animals animal, Worldmap map)
        {
            animal.LoseHP(damage);
            if (animal.HP <= 0)
            {
                Message_in_Color(String.Format("{0} killed {1}", GetName(), animal.GetName()), ConsoleColor.Blue);

                map.Kill(animal);
                return;
            }
            else
            {
                Message_in_Color(String.Format("{0} attacked {1} and inflicted {2} damage ({3} health left)", GetName(), animal.GetName(), damage, animal.HP), ConsoleColor.Yellow);
                animal.Fight(this, map);
            }
        }
        public void Move(int x, int y, Worldmap map)
        {

            int old_x = Pos_x;
            int old_y = Pos_y;
            int new_x = x + old_x;
            int new_y = y + old_y;
            int x_max = map.X_Length;
            int y_max = map.Y_Length;
            
            if (new_x > x_max) { new_x = x_max; }
            if (new_x < 0) { new_x = 0; }
            if (new_y > y_max) { new_y = y_max; }
            if (new_y < 0) { new_y = 0; }
            SetPos(new_x, new_y);
        }


        private static int Hunt(int Hunter, int Prey)
        {
            if (Hunter > Prey)
            {
                if (Hunter - MovementRange < Prey) { return Prey; }
                return Hunter - MovementRange;
            }
            if (Hunter < Prey)
            {
                if (Hunter + MovementRange > Prey) { return Prey; }
                return Hunter + MovementRange;
            }
            return Hunter;
        }
        public void MoveTo(Element element)
        {
            int x = element.GetPos().Item1;
            int y = element.GetPos().Item2;
            SetPos(Hunt(Pos_x, x), Hunt(Pos_y, y));
            if (Approaching_Message)
            {
                Console.WriteLine(String.Format("{0} is getting close to {1}", GetName(), element.GetName()));
            }
        }

        public bool isPregnant()
        {
            return IsPregnant;
        }


        public void Impregnate(Animals animal)
        {
            if (MaternityRest > 0) { return; }
            Animals male = this;
            Animals female = animal;
            if (sex == "Female")
            {
                IsPregnant = true;
                female = this;
                male = animal;
            }
            else
            {
                animal.IsPregnant = true;
            }
            if (Setup.made_pregnant_message)
            {
                Setup.Message_in_Color(String.Format("[{0}] made [{1}] pregnant ", male.GetName(), female.GetName()), ConsoleColor.Blue);
            }
        }


        public override void Update(Worldmap map)
        {
            base.Update(map);
            if (map.Contains(this))
            {
                lifetime += 1;
                if (lifetime % 30 == 0)
                {
                    Message_in_Color(String.Format("{0} just pooped", GetName()), ConsoleColor.DarkYellow);
                    map.Add(new OrganicWaste());
                }
                if (IsPregnant)
                {
                    if (PregnancyTime == 70)
                    {
                        IsPregnant = false;
                        PregnancyTime = 0;
                        MaternityRest = 1000;
                        Random generator = new();
                        bool Miscarriage = generator.Next(100) <= 75;
                        if (Miscarriage)
                        {
                            Reproduce(map);
                            Message_in_Color(String.Format("{0} gave birth", GetName()), ConsoleColor.Green);
                        }
                        else
                        {
                            Message_in_Color(String.Format("{0} lost her baby", GetName()), ConsoleColor.Yellow);
                        }
                    }
                    else { PregnancyTime += 1; }
                }
                MaternityRest -= 1;
                map.ActivityTracker(this);
            }
        }
    }
}