using System;
namespace Bac3_Projet_Écosystème_195030

{
    public abstract class Plants : Life_Form
    {
        public readonly int RootRadius;
        public readonly int GrowingRadius;
        protected int Growth_Time;
        public Plants(string Name, int maxHP, int maxEnergy, int RootRadius, int GrowingRadius, int Growth_Time) :
            base(Name, maxHP, maxEnergy)
        {
            this.RootRadius = RootRadius;
            this.GrowingRadius = GrowingRadius;
            this.Growth_Time = Growth_Time;
        }
        public override string GetName()
        {
            return String.Format("{0}, id : {3}, ({1},{2}), hp :{4}, energie {5} ", Name, Pos_x, Pos_y, id, HP, Energy);
        }
        public void Eat(OrganicWaste organicwaste, Worldmap map)
        {
            map.Kill(organicwaste, String.Format("{0} has been eaten by {1}", organicwaste.GetName(), GetName()));
            this.AddEnergy();
        }
        public abstract void Extend(Worldmap map);
        public override void Update(Worldmap map)
        {
            base.Update(map);
            if (map.Contains(this))
            {
                lifetime += 1;
                if (lifetime % Growth_Time == 0)
                {
                    Random generator = new();
                    bool Growing = generator.Next(100) <= 50;
                    if (Growing)
                    {
                        Message_in_Color(String.Format("{0} has extended ", GetName()), ConsoleColor.Green);
                        Extend(map);
                    }
                }

            }
        }
    }
}