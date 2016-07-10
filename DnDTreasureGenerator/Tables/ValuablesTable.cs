using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.Tables
{
    /// <summary>
    /// A class that represents either a Gem or an Art Object table. A gem/art object is referred to as a "valuable" here.
    /// </summary>
    class ValuablesTable : ATable
    {
        /// <summary>
        /// The valuables in the table.
        /// </summary>
        public List<Tuple<int, string>> Valuables { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"> A value that describes what type of valuable it is. </param>
        /// <param name="identifier"> The identifier that separates different tables of the same type from each other. </param>
        /// <param name="dieSides"> The number of sides on the die that is used to roll on the table. </param>
        public ValuablesTable(TableType tableType, int dieSides)
        {
            this.TableType = tableType;
            this.DieSides = dieSides;
            this.Valuables = new List<Tuple<int, string>>();
        }

        /// <summary>
        /// Adds a valuable to the list.
        /// </summary>
        /// <param name="roll"> A number that represents what roll on the table the item belongs to. </param>
        /// <param name="name"> The name of the item. </param>
        public void AddValuable(int roll, string name)
        {
            this.Valuables.Add(new Tuple<int, string>(roll, name));
        }

        /// <summary>
        /// Rolls the die for the table and returns the valuable corresponding to the roll.
        /// </summary>
        /// <returns> The valuable corresponding to the roll. </returns>
        override public string Roll()
        {
            var roll = this.GetDiceRoll();
            var sb = new StringBuilder();

            foreach (var t in this.Valuables.Where(x => x.Item1 == roll))
            {
                sb.Append(t.Item2);
            }

            return sb.ToString();
        }
    }
}
