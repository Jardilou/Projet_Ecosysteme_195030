using System;
namespace Bac3_Projet_Écosystème_195030

{
    public abstract class PlantEater : Animals
    {
        public PlantEater(string Name, int maxHP, int maxEnergy, int SightRadius, int ContactRadius, int damage, int MaternityRest = 0) :
            base(Name, maxHP, maxEnergy, SightRadius, ContactRadius, damage, MaternityRest)
        {
        }

        public void Eat(Plants plant, Worldmap map)
        {
            map.Kill(plant, String.Format("{0} has been eaten by {1}", plant.GetName(), GetName()), false);
            this.AddEnergy();
        }
    }
}