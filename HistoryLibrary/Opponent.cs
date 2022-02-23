using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryLibrary
{
    public class Opponent : Character
    {
        //FIELDS
        private int _minDamage;

        //PROPERTIES

        public int MaxDamage { get; set; }

        public string Description { get; set; }

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

        public Opponent(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
        {
            MaxDamage = maxDamage;
            Description = description;
            MaxLife = maxLife;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
        }

        public Opponent() { }

        //METHODS

        public override string ToString()
        {
            //return base.ToString(); 

            return string.Format($"\n***** NEW OPPONENT HAS ARRIVED *****\n" +
                "Description \n{Description}\n" +
                "{Name}\nLife: {Life} of {MaxLife}\nDamage: {MinDamage} to {MaDamage}\n" +
                "Block: {Block}");
        }

        public override int CalcDamage()
        {
            Random rand = new Random();

            return rand.Next(MinDamage, MaxDamage + 1);
        }

    }
}
