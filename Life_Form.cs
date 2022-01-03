using System;

namespace Bac3_Projet_Écosystème_195030
{
    public abstract class Life_Form : Element
    {
        protected int HP;
        protected int Energy;
        public readonly int maxHP;
        public readonly int maxEnergy;
        protected int lifetime = 0;
        public Life_Form(string Name, int maxHP, int maxEnergy) :
            base(Name)
        {
            HP = maxHP;
            Energy = maxEnergy;
            this.maxHP = maxHP;
            this.maxEnergy = maxEnergy;
        }
        
        public int GetHP()
        {
            return HP;
        }
        public void LoseHP(int damage)
        {
            HP -= damage;
        }
        public void HPToEnergy(Worldmap map)
        {
            const int amount = 5;
            this.HP -= amount;
            if (this.HP <= 1)
            {
                map.Kill(this, String.Format("{0} died due to a lack of energy", this.GetName()));
                return;
            }
            this.Energy += amount;
            if (HPToEnergy_Message)
            {
                Console.WriteLine(String.Format("{0} has converted {1} health ({2} left) into {1} energy", this.GetName(), amount, HP));
            }
        }
        public void LoseEnergy(Worldmap map)
        {
            this.Energy -= 1;
            if (this.Energy == 0)
            {
                this.HPToEnergy(map);
            }
        }
        public void AddEnergy()
        {
            this.Energy = this.maxEnergy;

        }

        public override void Update(Worldmap map)
        {
            LoseEnergy(map);
        }
    }
}
