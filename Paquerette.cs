using System;
namespace Bac3_Projet_Écosystème_195030
{
    public class Paquerette : Plants
    {
        // paramètres : string Name, int maxHP, int maxEnergy, int RootRadius, int GrowingRadius, int Growth_Time
        public Paquerette() :
            base("Paquerette", 10, 4, 10, 20, 50)
        {
        }
        public override void Grow(Worldmap map)
        {
            map.Add(new Paquerette());
        }
    }
}

