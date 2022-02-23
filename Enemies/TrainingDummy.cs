using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoryLibrary;

namespace Enemies
{
    public class TrainingDummy : Opponent
    {
        public TrainingDummy()
        {
            MaxLife = 5;
            MaxDamage = 1;
            Name = "Training Dummy";
            Life = 5;
            HitChance = 15;
            Block = 5;
            MinDamage = 1;
            Description = "A standard training dummy. Designed to practice on without fear!";
        }
    }
}
