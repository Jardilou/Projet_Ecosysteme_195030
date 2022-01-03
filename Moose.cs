using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bac3_Projet_Écosystème_195030
{
    public class Moose : PlantEater
    {
        //params : string Name, int maxHP, int maxEnergy, int SightRadius, int ContactRadius, int damage, int MaternityRest = 0
        public Moose(int pregnancycd = 0) :
            base("Moose", 95, 45, 30, 12, 60, pregnancycd)
        {
        }
        public override void Reproduce(Worldmap board)
        {
            board.Add(new Moose(1000), Pos_x, Pos_y);
        }
    }
}