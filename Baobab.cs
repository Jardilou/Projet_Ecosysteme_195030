using System;
namespace Bac3_Projet_Écosystème_195030

{
    public class Baobab : Plants
    {
        // paramètres : string Name, int maxHP, int maxEnergy, int RootRadius, int GrowingRadius, int Growth_Time
        public Baobab() :
            base("Baobab", 500, 300, 200, 600, 500)
        {
        }
        public override void Grow(Worldmap map)
        {
            map.Add(new Baobab());
        }
    }
}
