using System;
namespace Bac3_Projet_Écosystème_195030

{
    public class Meat : Element
    {
        private int lifetime = 0;
        public Meat() :
            base("Meat")
        {
        }



        private void MeatToWaste(Worldmap map)
        {
            map.Kill(this, String.Format("Expired {0} is becoming organic waste.", this.GetName()));
            map.Add(new OrganicWaste(), this.Pos_x, this.Pos_y);
        }


        public override void Update(Worldmap map)
        {
            lifetime += 1;
            if (lifetime == 5)
            {
                MeatToWaste(map);
            }
        }
    }
}