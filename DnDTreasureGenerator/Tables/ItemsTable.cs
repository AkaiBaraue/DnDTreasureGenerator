using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.Tables
{
    class ItemsTable : ATable
    {
        private List<ItemTuple> Items { get; set; }

        public ItemsTable(TableType tableType)
        {
            this.TableType = tableType;
            this.DieSides = 100;
            this.Items = new List<ItemTuple>();
        }

        public void AddItem(int rangeStart, int rangeEnd, string itemName)
        {
            this.Items.Add(new ItemTuple(rangeStart, rangeEnd, itemName));
        }

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
