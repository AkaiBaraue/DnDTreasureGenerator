using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.Program
{
    /// <summary>
    /// A class that represents a bunch of coins in a table.
    /// </summary>
    class Coins
    {
        /// <summary>
        /// The type of the coins (cp, sp, ep, gp, pp)
        /// </summary>
        private string type;

        /// <summary>
        /// The number of rolls to make.
        /// </summary>
        private int rolls;

        /// <summary>
        /// The number of sides on the die to roll.
        /// </summary>
        private int dieSides;

        /// <summary>
        /// The number to multiply the rolls with.
        /// </summary>
        private int multiplier;

        public Coins(string type, int rolls, int dieSides, int multiplier)
        {
            this.type = type;
            this.rolls = rolls;
            this.dieSides = dieSides;
            this.multiplier = multiplier;
        }

        /// <summary>
        /// Rolls the coins.
        /// </summary>
        /// <returns> The result of the coin roll. </returns>
        public string Roll()
        {
            var die = new Die(this.dieSides);
            var result = 0;

            for (int i = 0; i < rolls; i++)
                result += die.Roll();

            result *= this.multiplier;

            return String.Format("{0}{1}", result, this.type);
        }
    }
}
