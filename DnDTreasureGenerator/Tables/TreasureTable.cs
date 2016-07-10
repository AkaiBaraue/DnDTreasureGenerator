using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DnDTreasureGenerator.Program;

namespace DnDTreasureGenerator.Tables
{
    /// <summary>
    /// A class that represents either an Individual Treasure or Treasure Hoard table.
    /// </summary>
    class TreasureTable : ATable
    {
        public List<CoinsTuple> Coins { get; private set; }

        public List<ValuablesTuple> Valuables { get; private set; }

        public List<MagicItemTuple> MagicItems { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"> A value that describes what type of valuable it is. </param>
        /// <param name="identifier"> The identifier that separates different tables of the same type from each other. </param>
        /// <param name="dieSides"> The number of sides on the die that is used to roll on the table. </param>
        public TreasureTable(TableType tableType)
        {
            this.TableType = tableType;
            this.DieSides = 100;
            this.Coins = new List<CoinsTuple>();
            this.Valuables = new List<ValuablesTuple>();
            this.MagicItems = new List<MagicItemTuple>();
        }

        /// <summary>
        /// Adds a list of coins to the treasure table within a certain die range.
        /// </summary>
        /// <param name="rangeStart"> The lower bound of the die range (inclusive) </param>
        /// <param name="rangeEnd"> The upper bound of the die range (inclusive) </param>
        /// <param name="coins"> The list of coins to add. </param>
        public void AddCoins(int rangeStart, int rangeEnd, List<Coins> coins)
        {
            this.Coins.Add(new CoinsTuple(rangeStart, rangeEnd, coins));
        }

        /// <summary>
        /// Adds a table of valuables to roll on within a given die range.
        /// </summary>
        /// <param name="rangeStart"> The lower bound of the die range (inclusive) </param>
        /// <param name="rangeEnd"> The upper bound of the die range (inclusive) </param>
        /// <param name="dieRolls"> The number of times to roll the die. </param>
        /// <param name="dieSides"> The number of sides on the die. </param>
        /// <param name="tableToRollOn"> The valuables table to roll on. </param>
        public void AddValuables(int rangeStart, int rangeEnd, int dieRolls, int dieSides, TableType tableToRollOn)
        {
            this.Valuables.Add(new ValuablesTuple(rangeStart, rangeEnd, dieRolls, dieSides, tableToRollOn));
        }

        /// <summary>
        /// Adds one (or two) magic item tables to roll on. 
        /// Yes, two because the treasure hoard with CR 11-16 wants to be a fucking snowflake.
        /// </summary>
        /// <param name="rangeStart"> The lower bound of the die range (inclusive) </param>
        /// <param name="rangeEnd"> The upper bound of the die range (inclusive) </param>
        /// <param name="firstTableDieRolls"> The number of times to roll the die. </param>
        /// <param name="firstTableDieSides"> The number of sides on the die. </param>
        /// <param name="firstTableToRollOn"> The magic item table to roll on. </param>
        /// <param name="secondTableDieRolls"> The number of times to roll the die. </param>
        /// <param name="secondTableDieSides"> The number of sides on the die. </param>
        /// <param name="secondTableToRollOn"> The magic item table to roll on. </param>
        public void AddMagicItems(int rangeStart, int rangeEnd, 
                int firstTableDieRolls, int firstTableDieSides, TableType firstTableToRollOn,
                int secondTableDieRolls = 0, int secondTableDieSides = 0, TableType secondTableToRollOn = null)
        {
            this.MagicItems.Add(new MagicItemTuple(rangeStart, rangeEnd, firstTableDieRolls, firstTableDieSides, firstTableToRollOn, secondTableDieRolls, secondTableDieSides, secondTableToRollOn));
        }

        /// <summary>
        /// Rolls a die for the table and then rolls to figure out coins/valuables/magic items.
        /// </summary>
        /// <returns> A string that contains the result of all the rolls. </returns>
        override public string Roll()
        {
            var roll = this.GetDiceRoll();
            var sb = new StringBuilder();

            sb.AppendLine(String.Format("Rolled a {0} on the table.", roll));
            sb.AppendLine();

            // Generate coins
            foreach (var ct in this.Coins.Where(x => roll >= x.RangeStart && roll <= x.RangeEnd))
            {
                foreach (var c in ct.Coins)
                {
                    sb.AppendLine(c.Roll());
                }
                sb.AppendLine();
                break;
            }

            // Generate valuable items (gems/art objects)
            foreach (var vt in this.Valuables.Where(x => roll >= x.RangeStart && roll <= x.RangeEnd))
            {
                var table = (ValuablesTable)TableCollection.FindTable(vt.TableToRollOn);
                var totalRolls = 0;

                for (int i = 0; i < vt.DieRolls; i++)
                    totalRolls += vt.Die.Roll();

                // TODO: Consider making it get different gems instead of just a ton of the same.
                sb.AppendLine(String.Format("{0}x {1} worth {2} each", totalRolls, table.Roll(), table.TableType.Identifier));
                sb.AppendLine();
                break;
            }

            // Generate valuable items (gems/art objects)
            foreach (var mit in this.MagicItems.Where(x => roll >= x.RangeStart && roll <= x.RangeEnd))
            {
                var table = (ItemsTable)TableCollection.FindTable(mit.FirstTableToRollOn);
                var totalRolls = 0;

                for (int i = 0; i < mit.FirstTableDieRolls; i++)
                    totalRolls += mit.FirstTableDie.Roll();

                for (int i = 0; i < totalRolls; i++)
                    sb.AppendLine(String.Format("{0}", table.Roll()));

                if (mit.SecondTableToRollOn == null) return sb.ToString();

                table = (ItemsTable)TableCollection.FindTable(mit.SecondTableToRollOn);
                totalRolls = 0;

                for (int i = 0; i < mit.SecondTableDieRolls; i++)
                    totalRolls += mit.SecondTableDie.Roll();

                for (int i = 0; i < totalRolls; i++)
                    sb.AppendLine(String.Format("{0}", table.Roll()));
            }

            return sb.ToString();
        }

        /// <summary>
        /// A class for making the list of coin rolls easier to manage.
        /// </summary>
        public class CoinsTuple
        {
            public int RangeStart { get; private set; }
            public int RangeEnd { get; private set; }
            public List<Coins> Coins { get; private set; }

            public CoinsTuple(int rangeStart, int rangeEnd, List<Coins> coins)
            {
                this.RangeStart = rangeStart;
                this.RangeEnd = rangeEnd;
                this.Coins = coins;
            }
        }

        /// <summary>
        /// A class for making the list of valuable item rolls easier to manage.
        /// </summary>
        public class ValuablesTuple
        {
            public int RangeStart { get; private set; }
            public int RangeEnd { get; private set; }
            public int DieRolls { get; private set; }
            public Die Die { get; private set; }
            public TableType TableToRollOn { get; private set; }

            public ValuablesTuple(int rangeStart, int rangeEnd, int dieRolls, int dieSides, TableType tableToRollOn)
            {
                this.RangeStart = rangeStart;
                this.RangeEnd = rangeEnd;
                this.DieRolls = dieRolls;
                this.Die = new Die(dieSides);
                this.TableToRollOn = tableToRollOn;
            }
        }

        /// <summary>
        /// A class for making the list of magic item rolls easier to manage.
        /// Yes, there are tables that can fucking roll on two different magic item tables (fuck you, hoard 11-16), which is why there's the First/Second crap here.
        /// </summary>
        public class MagicItemTuple
        {
            public int RangeStart { get; private set; }
            public int RangeEnd { get; private set; }

            public int FirstTableDieRolls { get; private set; }
            public Die FirstTableDie { get; private set; }
            public TableType FirstTableToRollOn { get; private set; }

            public int SecondTableDieRolls { get; private set; }
            public Die SecondTableDie { get; private set; }
            public TableType SecondTableToRollOn { get; private set; }

            public MagicItemTuple(int rangeStart, int rangeEnd, 
                int firstTableDieRolls, int firstTableDieSides, TableType firstTableToRollOn,
                int secondTableDieRolls = 0, int secondTableDieSides = 0, TableType secondTableToRollOn = null)
            {
                this.RangeStart = rangeStart;
                this.RangeEnd = rangeEnd;

                this.FirstTableDieRolls = firstTableDieRolls;
                this.FirstTableDie = new Die(firstTableDieSides);
                this.FirstTableToRollOn = firstTableToRollOn;

                this.SecondTableDieRolls = secondTableDieRolls;
                this.SecondTableDie = new Die(secondTableDieSides);
                this.SecondTableToRollOn = secondTableToRollOn;
            }
        }
    }
}
