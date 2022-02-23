using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoryLibrary;

namespace Enemies
{
    public class Student : Opponent
    {
        public Student(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        { }

        public Student()
        {
            MaxLife = 8;
            MaxDamage = 3;
            Name = "Martial Art Student";
            Life = 8;
            HitChance = 35;
            Block = 20;
            MinDamage = 1;
            Description = "A student still in training for combat!";
        }
    }
}
