using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryLibrary
{
    public class Weapon
    {
        //FIELDS
        private int _minDamage;

        //PROPERTIES
        public int MaxDamage { get; set; }

        public string Name { get; set; }

        public int BonusHitChance { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

        //CONSTRUCTORS
        public Weapon(int minDamage, int maxDamage, string name, int bonusHitChance)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
        }

        public Weapon() { }


        //METHODS

        public override string ToString()
        {
            //return base.ToString(); 
            return string.Format("{0}\nDamage : {1} to {2}\nBonus Hit: {3}", Name, MinDamage, MaxDamage, BonusHitChance);
        }
    }
}
