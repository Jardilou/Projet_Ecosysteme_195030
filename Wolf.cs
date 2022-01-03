
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bac3_Projet_Écosystème_195030
{
    public class Wolf : Meateater
    {

        //paramètres : string Name, int maxHP, int maxEnergy, int SightRadius, int ContactRadius, int damage, int MaternityRest = 0
        public Wolf(int MaternityRest = 0) :
            base("Wolf", 350, 80, 100, 15, 100, MaternityRest)
        {
        }
        public override void Reproduce(Worldmap board)
        {
            board.Add(new Wolf(1000), Pos_x, Pos_y);
        }
    }
}