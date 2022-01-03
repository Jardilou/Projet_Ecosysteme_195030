using System;
namespace Bac3_Projet_Écosystème_195030
{
    public class Chardon : Plants
    {
        // paramètres : string Name, int maxHP, int maxEnergy, int RootRadius, int GrowingRadius, int Growth_Time
        public Chardon() :
            base("Chardon", 100, 15, 45, 65, 10)
        {
        }
        public override void Grow(Worldmap board)
        {
            board.Add(new Chardon());
        }
    }
}