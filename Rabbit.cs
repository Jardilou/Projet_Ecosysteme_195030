using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bac3_Projet_Écosystème_195030
{
    public class Rabbit : PlantEater
    {
        //params : string Name, int maxHP, int maxEnergy, int SightRadius, int ContactRadius, int damage, int MaternityRest = 0
        public Rabbit(int pregnancycd = 0) :
            base("Rabbit", 60, 55, 100, 3, 8, pregnancycd)
        {
        }
        public override void Reproduce(Worldmap board)
        {
            board.Add(new Rabbit(1000), Pos_x, Pos_y);
        }
    }
}