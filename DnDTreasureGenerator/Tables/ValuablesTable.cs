using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.Tables
{
    class ValuablesTable
    {
        /// <summary>
        /// The type of valuable that is contained in this table (eg. gems, art objects)
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// The value of the items in the table.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// The valuables in the table.
        /// </summary>
        public List<Tuple<int, string>> Valuables { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"> A value that describes what type of valuable it is. </param>
        /// <param name="value"> The value (in gp) of the items in the table. </param>
        public ValuablesTable(string type, int value)
        {
            this.Type = type;
            this.Value = value;
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
    }
}
