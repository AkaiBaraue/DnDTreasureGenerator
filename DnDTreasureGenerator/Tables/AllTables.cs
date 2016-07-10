using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.Tables
{
    static class AllTables
    {
        public static List<ValuablesTable> ValuablesTable {get; private set;}
        
        public static void Initialize()
        {
            ValuablesTable = new List<ValuablesTable>();
        }

        public static void AddValuablesTable(ValuablesTable table)
        {
            ValuablesTable.Add(table);
        }
    }
}
