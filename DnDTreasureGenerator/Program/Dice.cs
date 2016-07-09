using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.Program
{
    /// <summary>
    /// A class that represents an N-sided dice.
    /// </summary>
    class Dice
    {
        private int sides = 4;

        /// <summary>
        /// Gets the number of sides on the dice.
        /// </summary>
        private int Sides { get; private set; }

        public Dice(int sides)
        {
            if (sides <= 0) this.sides = 1;
            else this.sides = sides;
        }

        /// <summary>
        /// Returns a number between 1 and the number of side on the dice.
        /// </summary>
        /// <returns> A number between 1 and the number of side on the dice. </returns>
        public int Roll()
        {
            return (RNG.RANDOM.Next(sides) + 1);
        }
    }
}
