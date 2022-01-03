using System;


namespace Bac3_Projet_Écosystème_195030
{
    public abstract class Meateater : Animals
    {
        public Meateater(string Name, int maxHP, int maxEnergy, int SightRadius, int ContactRadius, int damage, int MaternityRest = 0) :
            base(Name, maxHP, maxEnergy, SightRadius, ContactRadius, damage, MaternityRest)
        {
        }


        public void Eat(Meat meat, Worldmap map)
        {
            map.Kill(meat, String.Format("{0} has been eaten by {1}", meat.GetName(), this.GetName()));
            this.AddEnergy();
        }
    }
}