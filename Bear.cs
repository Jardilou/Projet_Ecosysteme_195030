
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bac3_Projet_Écosystème_195030
{
    public class Bear : Meateater
    {
        //paramètres : string Name, int maxHP, int maxEnergy, int SightRadius, int ContactRadius, int damage, int MaternityRest = 0
        public Bear(int MaternityRest = 0) :
            base("Bear", 600, 35, 50, 5, 200, MaternityRest)
        {
        }
        public override void Reproduce(Worldmap map)
        {
            map.Add(new Bear(1000), Pos_x, Pos_y);
        }
    }
}
