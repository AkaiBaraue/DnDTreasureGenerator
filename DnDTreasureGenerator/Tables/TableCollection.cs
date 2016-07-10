using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.Tables
{
    static class TableCollection
    {
        public static List<ATable> AllTables { get; private set; }

        public static List<ValuablesTable> ValuablesTables { get; private set; }

        public static List<ItemsTable> ItemTables { get; private set; }

        public static List<TreasureTable> TreasureTables { get; private set; }
        
        public static void Initialize()
        {
            AllTables = new List<ATable>();
            ValuablesTables = new List<ValuablesTable>();
            ItemTables = new List<ItemsTable>();
            TreasureTables = new List<TreasureTable>();
        }

        private static void AddTable(ATable table)
        {
            if (AllTables == null) AllTables = new List<ATable>();
            AllTables.Add(table);
        }

        public static void AddValuablesTable(ValuablesTable table)
        {
            if (ValuablesTables == null) ValuablesTables = new List<ValuablesTable>();
            ValuablesTables.Add(table);
            AddTable(table);
        }

        public static void AddItemTable(ItemsTable table)
        {
            if (ItemTables == null) ItemTables = new List<ItemsTable>();
            ItemTables.Add(table);
            AddTable(table);
        }

        public static void AddTreasureTable(TreasureTable table)
        {
            if (TreasureTables == null) TreasureTables = new List<TreasureTable>();
            TreasureTables.Add(table);
            AddTable(table);
        }

        public static ATable FindTable(TableType tableType)
        {
            foreach (var t in AllTables)
                if (t.TableType.Equals(tableType))
                    return t;

            return null;
        }

        //public static ValuablesTable FindValuablesTable(TableType tableType)
        //{
        //    foreach (var t in ValuablesTables)
        //        if (t.TableType.Equals(tableType))
        //            return t;

        //    return null;
        //}

        //public static ItemsTable FindItemTable(TableType tableType)
        //{
        //    foreach (var t in ItemTables)
        //        if (t.TableType.Equals(tableType))
        //            return t;

        //    return null;
        //}
    }
}
