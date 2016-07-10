using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.Program
{
    /// <summary>
    /// A class that represents a group of dice.
    /// Don't think it's used anywhere, but oh well.
    /// </summary>
    class DiceGroup
    {
        private List<Die> dies;

        public List<Die> Dies { get { return this.dies; } private set { this.dies = value; } }

        public DiceGroup(int d4 = 0, int d6 = 0, int d8 = 0, int d10 = 0, int d12 = 0, int d20 = 0, int d100 = 0)
        {
            this.dies = new List<Die>();

            // Add D4s
            for (int i = 0; i < d4; i++) this.dies.Add(new Die(4));

            // Add D6s
            for (int i = 0; i < d4; i++) this.dies.Add(new Die(6));

            // Add D8s
            for (int i = 0; i < d4; i++) this.dies.Add(new Die(8));

            // Add D10s
            for (int i = 0; i < d4; i++) this.dies.Add(new Die(10));

            // Add D12s
            for (int i = 0; i < d4; i++) this.dies.Add(new Die(12));

            // Add D20s
            for (int i = 0; i < d4; i++) this.dies.Add(new Die(20));

            // Add D100s
            for (int i = 0; i < d4; i++) this.dies.Add(new Die(100));
        }

        /// <summary>
        /// Rolls all the dies in the group and returns the result.
        /// </summary>
        /// <returns></returns>
        public int RollDies()
        {
            int result = 0;

            foreach (var d in this.dies)
                result += d.Roll();

            return result;
        }

        public int RollMin()
        {
            return this.dies.Count;
        }

        public int RollMax()
        {
            int result = 0;

            foreach (var d in this.dies)
                result += d.Sides;

            return result;
        }

        /// <summary>
        /// Adds a dice to the group with the specified number of sides.
        /// </summary>
        /// <param name="sides"> The number of the sides of the dice to add. </param>
        public void AddDice(int sides)
        {
            if (sides <= 0) return;

            var newDice = new Die(sides);

            for (int i = 0; i < this.dies.Count; i++)
            {
                if (this.dies[i].Sides >= sides)
                {
                    this.dies.Insert(i, newDice);
                    return;
                }
            }

            this.dies.Add(newDice);
        }

        /// <summary>
        /// Removed a dice from the group with the specified number of sides.
        /// </summary>
        /// <param name="sides"> The number of sides of the dice to remove. </param>
        public void RemoveDice(int sides)
        {
            if (sides <= 0) return;

            for (int i = 0; i < this.dies.Count; i++)
            {
                if (this.dies[i].Sides == sides)
                {
                    this.dies.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
