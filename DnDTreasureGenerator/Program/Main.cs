using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DnDTreasureGenerator.JsonModels;
using DnDTreasureGenerator.Tables;

namespace DnDTreasureGenerator.Program
{
    class Main
    {
        private JsonParser parser;

        public Main()
        {
            RNG.Initialize();
            AllTables.Initialize();

            this.parser = new JsonParser();

            this.LoadTables();
        }

        public string Run()
        {
            var finalResult = new StringBuilder();

            //var diceGroup = new DiceGroup();
            //diceGroup.AddDice(6);
            //diceGroup.AddDice(4);
            //diceGroup.AddDice(8);
            //diceGroup.AddDice(6);
            //diceGroup.AddDice(12);
            //diceGroup.AddDice(10);
            //diceGroup.AddDice(20);

            //finalResult.AppendLine("Roll: " + diceGroup.RollDies().ToString());
            //finalResult.AppendLine("Max: " + diceGroup.RollMax().ToString());
            //finalResult.AppendLine("Min: " + diceGroup.RollMin().ToString());
            //finalResult.AppendLine();

            //foreach(var d in diceGroup.Dies)
            //{
            //    finalResult.AppendLine(d.Sides.ToString());
            //}

            foreach (var t in AllTables.ValuablesTable)
            {
                finalResult.AppendLine(String.Format("{0} worth {1} gp", t.Type, t.Value));
                foreach (var v in t.Valuables)
                {
                    finalResult.AppendLine(String.Format("{0} {1}", v.Item1, v.Item2));
                }
                finalResult.AppendLine();
            }

            return finalResult.ToString();
        }

        private void LoadTables()
        {
            var gemsData = this.parser.DeserializeGems();
            var gemsTables = new List<ValuablesTable>();

            var gems10 = new ValuablesTable("Gems", 10);
            foreach (var g in gemsData.Gp10)
                gems10.AddValuable(g.Result, g.Name);

            var gems50 = new ValuablesTable("Gems", 50);
            foreach (var g in gemsData.Gp50)
                gems50.AddValuable(g.Result, g.Name);

            var gems100 = new ValuablesTable("Gems", 100);
            foreach (var g in gemsData.Gp100)
                gems100.AddValuable(g.Result, g.Name);

            var gems500 = new ValuablesTable("Gems", 500);
            foreach (var g in gemsData.Gp500)
                gems500.AddValuable(g.Result, g.Name);

            var gems1000 = new ValuablesTable("Gems", 1000);
            foreach (var g in gemsData.Gp1000)
                gems1000.AddValuable(g.Result, g.Name);

            var gems5000 = new ValuablesTable("Gems", 5000);
            foreach (var g in gemsData.Gp5000)
                gems5000.AddValuable(g.Result, g.Name);

            AllTables.AddValuablesTable(gems10);
            AllTables.AddValuablesTable(gems50);
            AllTables.AddValuablesTable(gems100);
            AllTables.AddValuablesTable(gems500);
            AllTables.AddValuablesTable(gems1000);
            AllTables.AddValuablesTable(gems5000);
        }
    }
}
