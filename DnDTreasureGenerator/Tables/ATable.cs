using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DnDTreasureGenerator.Program;

namespace DnDTreasureGenerator.Tables
{
    /// <summary>
    /// An abstract class representing the basic version of a table.
    /// </summary>
    abstract class ATable
    {
        /// <summary>
        /// The type of the table.
        /// </summary>
        public TableType TableType { get; protected set; }

        /// <summary>
        /// The number of sides on the die that is used to roll on the table.
        /// </summary>
        public int DieSides { get; protected set; }

        /// <summary>
        /// Rolls on the table and returns the result as a string.
        /// </summary>
        /// <returns> The result of the roll. </returns>
        abstract public string Roll();

        /// <summary>
        /// Creates and rolls a die.
        /// </summary>
        /// <returns> A number between 1 and DieSides. </returns>
        protected int GetDiceRoll()
        {
            var die = new Die(this.DieSides);
            return die.Roll();
        }
    }
}
