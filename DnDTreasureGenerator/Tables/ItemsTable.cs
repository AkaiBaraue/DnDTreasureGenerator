using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.Tables
{
    /// <summary>
    /// A table that represents one of the Magic Item tables.
    /// </summary>
    class ItemsTable : ATable
    {
        private List<ItemTuple> Items { get; set; }

        public ItemsTable(TableType tableType)
        {
            this.TableType = tableType;
            this.DieSides = 100;
            this.Items = new List<ItemTuple>();
        }

        /// <summary>
        /// Adds an item to the table.
        /// </summary>
        /// <param name="rangeStart"> The lower bound of the die range (inclusive) </param>
        /// <param name="rangeEnd"> The upper bound of the die range (inclusive) </param>
        /// <param name="itemName"> The name of the item to add. </param>
        public void AddItem(int rangeStart, int rangeEnd, string itemName)
        {
            this.Items.Add(new ItemTuple(rangeStart, rangeEnd, itemName));
        }

        /// <summary>
        /// Rolls the die for the table and returns the magic item corresponding to the roll.
        /// </summary>
        /// <returns> The magic item corresponding to the roll. </returns>
        public override string Roll()
        {
            var roll = this.GetDiceRoll();
            var sb = new StringBuilder();

            foreach (var t in this.Items.Where(x => roll >= x.RangeStart && roll <= x.RangeEnd))
            {
                sb.Append(t.ItemName);
            }

            return sb.ToString();
        }


        /// <summary>
        /// A class for making the list of item rolls easier to manage.
        /// </summary>
        protected class ItemTuple
        {
            public int RangeStart { get; private set; }
            public int RangeEnd { get; private set; }
            public string ItemName { get; private set; }

            public ItemTuple(int rangeStart, int rangeEnd, string itemName)
            {
                this.RangeStart = rangeStart;
                this.RangeEnd = rangeEnd;
                this.ItemName = itemName;
            }
        }
    }
}
