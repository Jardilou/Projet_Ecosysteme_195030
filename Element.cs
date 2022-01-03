
using System.Collections.Generic;
using System;
namespace Bac3_Projet_Écosystème_195030
{
    public abstract class Element : Setup
    {
        public readonly string Name;
        protected int Pos_x;
        protected int Pos_y;
        protected int id;
        public Element(string Name)
        {
            this.Name = Name;

        }

        public virtual string GetName()
        {
            return String.Format("{0}, id : {3},  ({1},{2})", Name, Pos_x, Pos_y, id);
        }


        public void SetId(int id)
        {
            this.id = id;
        }


        public (int, int) GetPos()
        {
            return (this.Pos_x, this.Pos_y);
        }
        
        public void SetPos(int x, int y)
        {
            this.Pos_x = x;
            this.Pos_y = y;
        }
        public bool GetInRange(Element entity, int range)
        {
            int x = entity.Pos_x;
            int y = entity.Pos_y;
            int xmin = this.Pos_x - range;
            int xmax = this.Pos_x + range;
            int ymin = this.Pos_y - range;
            int ymax = this.Pos_y + range;
            if ((x > xmin) && (x < xmax) && (y > ymin) && (y < ymax))
            {
                return true;
            }
            return false;
        }

        public abstract void Update(Worldmap board);
    }
}