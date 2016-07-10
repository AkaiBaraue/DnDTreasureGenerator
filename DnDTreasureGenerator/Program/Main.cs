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
            TableCollection.Initialize();
            TableType.Initialize();

            this.parser = new JsonParser();

            this.LoadTables();
        }

        public string Run(TableType tableType)
        {
            var sb = new StringBuilder();

            foreach (var t in TableCollection.TreasureTables)
            {
                if (t.TableType.Equals(tableType))
                {
                    sb.AppendLine(String.Format("----- {0} CR {1} -----", t.TableType.Type, tableType.Identifier.Replace('_', '-')));
                    sb.Append(t.Roll());
                }
            }

            return sb.ToString();
        }

        public string Run()
        {
            var sb = new StringBuilder();

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


            foreach (var t in TableCollection.TreasureTables)
            {
                if (t.TableType.Equals(TableType.TreasureHoard0_4))
                {
                    sb.AppendLine(String.Format("----- {0} -----", t.TableType.Type));
                    sb.Append(t.Roll());
                }
            }
            //sb.AppendLine();

            //foreach (var t in AllTables.ValuablesTables)
            //{
            //    if (t.TableType.Equals(TableType.Gems10gp))
            //    {
            //        sb.AppendLine(String.Format("----- {0} -----", t.TableType.Type));
            //        sb.AppendLine(t.Roll());
            //    }
            //}
            //sb.AppendLine();

            //foreach (var t in AllTables.ValuablesTables)
            //{
            //    sb.AppendLine(String.Format("{0} worth {1}", t.TableType.Type, t.TableType.Identifier));
            //    foreach (var v in t.Valuables)
            //    {
            //        sb.AppendLine(String.Format("{0} {1}", v.Item1, v.Item2));
            //    }
            //    sb.AppendLine();
            //}

            return sb.ToString();
        }

        private void LoadTables()
        {
            this.LoadGems();
            this.LoadArtObjects();
            this.LoadMagicItems();
            this.LoadIndividualTreasure();
            this.LoadTreasureHoard();
        }

        private void LoadGems()
        {
            var gemsData = this.parser.DeserializeGems();

            var gems10 = new ValuablesTable(TableType.Gems10gp, gemsData.Gp10.Count);
            foreach (var g in gemsData.Gp10)
                gems10.AddValuable(g.Result, g.Name);

            var gems50 = new ValuablesTable(TableType.Gems50gp, gemsData.Gp50.Count);
            foreach (var g in gemsData.Gp50)
                gems50.AddValuable(g.Result, g.Name);

            var gems100 = new ValuablesTable(TableType.Gems100gp, gemsData.Gp100.Count);
            foreach (var g in gemsData.Gp100)
                gems100.AddValuable(g.Result, g.Name);

            var gems500 = new ValuablesTable(TableType.Gems500gp, gemsData.Gp500.Count);
            foreach (var g in gemsData.Gp500)
                gems500.AddValuable(g.Result, g.Name);

            var gems1000 = new ValuablesTable(TableType.Gems1000gp, gemsData.Gp1000.Count);
            foreach (var g in gemsData.Gp1000)
                gems1000.AddValuable(g.Result, g.Name);

            var gems5000 = new ValuablesTable(TableType.Gems5000gp, gemsData.Gp5000.Count);
            foreach (var g in gemsData.Gp5000)
                gems5000.AddValuable(g.Result, g.Name);

            TableCollection.AddValuablesTable(gems10);
            TableCollection.AddValuablesTable(gems50);
            TableCollection.AddValuablesTable(gems100);
            TableCollection.AddValuablesTable(gems500);
            TableCollection.AddValuablesTable(gems1000);
            TableCollection.AddValuablesTable(gems5000);
        }

        private void LoadArtObjects()
        {
            var aoData = this.parser.DeserializeArtObjects();

            var ao25 = new ValuablesTable(TableType.ArtObjects25gp, aoData.Gp25.Count);
            foreach (var g in aoData.Gp25)
                ao25.AddValuable(g.Result, g.Name);

            var ao250 = new ValuablesTable(TableType.ArtObjects250gp, aoData.Gp250.Count);
            foreach (var g in aoData.Gp250)
                ao250.AddValuable(g.Result, g.Name);

            var ao750 = new ValuablesTable(TableType.ArtObjects750gp, aoData.Gp750.Count);
            foreach (var g in aoData.Gp750)
                ao750.AddValuable(g.Result, g.Name);

            var ao2500 = new ValuablesTable(TableType.ArtObjects2500gp, aoData.Gp2500.Count);
            foreach (var g in aoData.Gp2500)
                ao2500.AddValuable(g.Result, g.Name);

            var ao7500 = new ValuablesTable(TableType.ArtObjects7500gp, aoData.Gp7500.Count);
            foreach (var g in aoData.Gp7500)
                ao7500.AddValuable(g.Result, g.Name);

            TableCollection.AddValuablesTable(ao25);
            TableCollection.AddValuablesTable(ao250);
            TableCollection.AddValuablesTable(ao750);
            TableCollection.AddValuablesTable(ao2500);
            TableCollection.AddValuablesTable(ao7500);
        }

        private void LoadMagicItems()
        {
            var miData = this.parser.DeserializeMagicItems();

            var miA = new ItemsTable(TableType.MagicItemsA);
            foreach (var mi in miData.A)
                miA.AddItem(mi.RangeStart, mi.RangeEnd, mi.Item);

            var miB = new ItemsTable(TableType.MagicItemsB);
            foreach (var mi in miData.B)
                miB.AddItem(mi.RangeStart, mi.RangeEnd, mi.Item);

            var miC = new ItemsTable(TableType.MagicItemsC);
            foreach (var mi in miData.C)
                miC.AddItem(mi.RangeStart, mi.RangeEnd, mi.Item);

            var miD = new ItemsTable(TableType.MagicItemsD);
            foreach (var mi in miData.D)
                miD.AddItem(mi.RangeStart, mi.RangeEnd, mi.Item);

            var miE = new ItemsTable(TableType.MagicItemsE);
            foreach (var mi in miData.E)
                miE.AddItem(mi.RangeStart, mi.RangeEnd, mi.Item);

            var miF = new ItemsTable(TableType.MagicItemsF);
            foreach (var mi in miData.F)
                miF.AddItem(mi.RangeStart, mi.RangeEnd, mi.Item);

            var miG = new ItemsTable(TableType.MagicItemsG);
            foreach (var mi in miData.G)
                miG.AddItem(mi.RangeStart, mi.RangeEnd, mi.Item);

            var miH = new ItemsTable(TableType.MagicItemsH);
            foreach (var mi in miData.H)
                miH.AddItem(mi.RangeStart, mi.RangeEnd, mi.Item);

            var miI = new ItemsTable(TableType.MagicItemsI);
            foreach (var mi in miData.I)
                miI.AddItem(mi.RangeStart, mi.RangeEnd, mi.Item);

            TableCollection.AddItemTable(miA);
            TableCollection.AddItemTable(miB);
            TableCollection.AddItemTable(miC);
            TableCollection.AddItemTable(miD);
            TableCollection.AddItemTable(miE);
            TableCollection.AddItemTable(miF);
            TableCollection.AddItemTable(miG);
            TableCollection.AddItemTable(miH);
            TableCollection.AddItemTable(miI);
        }

        private void LoadIndividualTreasure()
        {
            var itData = this.parser.DeserializeIndividualTreasure();

            var it0_4 = new TreasureTable(TableType.IndividualTreasure0_4);
            foreach (var c in itData.ITCh0_4)
            {
                var coins = new List<Coins>();

                if (c.CPRolls != null)
                    coins.Add(new Coins("cp", c.CPRolls.Value, c.CPDieSides.Value, c.CPMultiplier.Value));
                if (c.SPRolls != null)
                    coins.Add(new Coins("sp", c.SPRolls.Value, c.SPDieSides.Value, c.SPMultiplier.Value));
                if (c.EPRolls != null)
                    coins.Add(new Coins("ep", c.EPRolls.Value, c.EPDieSides.Value, c.EPMultiplier.Value));
                if (c.GPRolls != null)
                    coins.Add(new Coins("gp", c.GPRolls.Value, c.GPDieSides.Value, c.GPMultiplier.Value));
                if (c.PPRolls != null)
                    coins.Add(new Coins("pp", c.PPRolls.Value, c.PPDieSides.Value, c.PPMultiplier.Value));

                it0_4.AddCoins(c.RangeStart, c.RangeEnd, coins);
            }

            var it5_10 = new TreasureTable(TableType.IndividualTreasure5_10);
            foreach (var c in itData.ITCh5_10)
            {
                var coins = new List<Coins>();

                if (c.CPRolls != null)
                    coins.Add(new Coins("cp", c.CPRolls.Value, c.CPDieSides.Value, c.CPMultiplier.Value));
                if (c.SPRolls != null)
                    coins.Add(new Coins("sp", c.SPRolls.Value, c.SPDieSides.Value, c.SPMultiplier.Value));
                if (c.EPRolls != null)
                    coins.Add(new Coins("ep", c.EPRolls.Value, c.EPDieSides.Value, c.EPMultiplier.Value));
                if (c.GPRolls != null)
                    coins.Add(new Coins("gp", c.GPRolls.Value, c.GPDieSides.Value, c.GPMultiplier.Value));
                if (c.PPRolls != null)
                    coins.Add(new Coins("pp", c.PPRolls.Value, c.PPDieSides.Value, c.PPMultiplier.Value));

                it5_10.AddCoins(c.RangeStart, c.RangeEnd, coins);
            }

            var it11_16 = new TreasureTable(TableType.IndividualTreasure11_16);
            foreach (var c in itData.ITCh11_16)
            {
                var coins = new List<Coins>();

                if (c.CPRolls != null)
                    coins.Add(new Coins("cp", c.CPRolls.Value, c.CPDieSides.Value, c.CPMultiplier.Value));
                if (c.SPRolls != null)
                    coins.Add(new Coins("sp", c.SPRolls.Value, c.SPDieSides.Value, c.SPMultiplier.Value));
                if (c.EPRolls != null)
                    coins.Add(new Coins("ep", c.EPRolls.Value, c.EPDieSides.Value, c.EPMultiplier.Value));
                if (c.GPRolls != null)
                    coins.Add(new Coins("gp", c.GPRolls.Value, c.GPDieSides.Value, c.GPMultiplier.Value));
                if (c.PPRolls != null)
                    coins.Add(new Coins("pp", c.PPRolls.Value, c.PPDieSides.Value, c.PPMultiplier.Value));

                it11_16.AddCoins(c.RangeStart, c.RangeEnd, coins);
            }

            var it17 = new TreasureTable(TableType.IndividualTreasure17);
            foreach (var c in itData.ITCh17)
            {
                var coins = new List<Coins>();

                if (c.CPRolls != null)
                    coins.Add(new Coins("cp", c.CPRolls.Value, c.CPDieSides.Value, c.CPMultiplier.Value));
                if (c.SPRolls != null)
                    coins.Add(new Coins("sp", c.SPRolls.Value, c.SPDieSides.Value, c.SPMultiplier.Value));
                if (c.EPRolls != null)
                    coins.Add(new Coins("ep", c.EPRolls.Value, c.EPDieSides.Value, c.EPMultiplier.Value));
                if (c.GPRolls != null)
                    coins.Add(new Coins("gp", c.GPRolls.Value, c.GPDieSides.Value, c.GPMultiplier.Value));
                if (c.PPRolls != null)
                    coins.Add(new Coins("pp", c.PPRolls.Value, c.PPDieSides.Value, c.PPMultiplier.Value));

                it17.AddCoins(c.RangeStart, c.RangeEnd, coins);
            }

            TableCollection.AddTreasureTable(it0_4);
            TableCollection.AddTreasureTable(it5_10);
            TableCollection.AddTreasureTable(it11_16);
            TableCollection.AddTreasureTable(it17);
        }

        private void LoadTreasureHoard()
        {
            var thData = this.parser.DeserializeTreasureHoard();

            var th0_4 = new TreasureTable(TableType.TreasureHoard0_4);
            foreach (var c in thData.THCh0_4)
            {
                if (c.Type.Equals("Coins"))
                {
                    var coins = new List<Coins>();

                    if (c.CPRolls != null)
                        coins.Add(new Coins("cp", c.CPRolls.Value, c.CPDieSides.Value, c.CPMultiplier.Value));
                    if (c.SPRolls != null)
                        coins.Add(new Coins("sp", c.SPRolls.Value, c.SPDieSides.Value, c.SPMultiplier.Value));
                    if (c.EPRolls != null)
                        coins.Add(new Coins("ep", c.EPRolls.Value, c.EPDieSides.Value, c.EPMultiplier.Value));
                    if (c.GPRolls != null)
                        coins.Add(new Coins("gp", c.GPRolls.Value, c.GPDieSides.Value, c.GPMultiplier.Value));
                    if (c.PPRolls != null)
                        coins.Add(new Coins("pp", c.PPRolls.Value, c.PPDieSides.Value, c.PPMultiplier.Value));

                    th0_4.AddCoins(c.RangeStart, c.RangeEnd, coins);
                }
                else
                {
                    if (c.VRolls != null)
                        th0_4.AddValuables(c.RangeStart, c.RangeEnd, c.VRolls.Value, c.VDieSides.Value, TableType.FindTableType(c.VTableType, c.VIdentifier));

                    if (c.MIOneRolls != null && c.MITwoRolls == null)
                        th0_4.AddMagicItems(c.RangeStart, c.RangeEnd,
                            c.MIOneRolls.Value, c.MIOneDieSides.Value, TableType.FindTableType(c.MIOneTableType, c.MIOneIdentifier));

                    if (c.MIOneRolls != null && c.MITwoRolls != null)
                        th0_4.AddMagicItems(c.RangeStart, c.RangeEnd,
                            c.MIOneRolls.Value, c.MIOneDieSides.Value, TableType.FindTableType(c.MIOneTableType, c.MIOneIdentifier),
                            c.MITwoRolls.Value, c.MITwoDieSides.Value, TableType.FindTableType(c.MITwoTableType, c.MITwoIdentifier));
                }
            }

            TableCollection.AddTreasureTable(th0_4);
        }
    }
}
