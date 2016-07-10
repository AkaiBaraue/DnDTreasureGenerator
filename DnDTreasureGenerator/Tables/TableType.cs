using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DnDTreasureGenerator.Tables
{
    /// <summary>
    /// A class that represents the different types of tables.
    /// </summary>
    public class TableType
    {
        /// <summary>
        /// The type of the table.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// The identifier that separates different tables of the same type from each other.
        /// </summary>
        public string Identifier { get; private set; }

        public TableType(string type, string identifier)
        {
            this.Type = type;
            this.Identifier = identifier;
        }

        private static List<TableType> allTableTypes = new List<TableType>();

        public static TableType IndividualTreasure0_4   = new TableType("Individual Treasure", "0_4");
        public static TableType IndividualTreasure5_10  = new TableType("Individual Treasure", "5_10");
        public static TableType IndividualTreasure11_16 = new TableType("Individual Treasure", "11_16");
        public static TableType IndividualTreasure17    = new TableType("Individual Treasure", "17");

        public static TableType TreasureHoard0_4    = new TableType("Treasure Hoard", "0_4");
        public static TableType TreasureHoard5_10   = new TableType("Treasure Hoard", "5_10");
        public static TableType TreasureHoard11_16  = new TableType("Treasure Hoard", "11_16");
        public static TableType TreasureHoard17     = new TableType("Treasure Hoard", "17");

        public static TableType Gems10gp    = new TableType("Gems", "10gp");
        public static TableType Gems50gp    = new TableType("Gems", "50gp");
        public static TableType Gems100gp   = new TableType("Gems", "100gp");
        public static TableType Gems500gp   = new TableType("Gems", "500gp");
        public static TableType Gems1000gp  = new TableType("Gems", "1000gp");
        public static TableType Gems5000gp  = new TableType("Gems", "5000gp");

        public static TableType ArtObjects25gp      = new TableType("Art Objects", "25gp");
        public static TableType ArtObjects250gp     = new TableType("Art Objects", "250gp");
        public static TableType ArtObjects750gp     = new TableType("Art Objects", "750gp");
        public static TableType ArtObjects2500gp    = new TableType("Art Objects", "2500gp");
        public static TableType ArtObjects7500gp    = new TableType("Art Objects", "7500gp");

        public static TableType MagicItemsA = new TableType("Magic Items", "A");
        public static TableType MagicItemsB = new TableType("Magic Items", "B");
        public static TableType MagicItemsC = new TableType("Magic Items", "C");
        public static TableType MagicItemsD = new TableType("Magic Items", "D");
        public static TableType MagicItemsE = new TableType("Magic Items", "E");
        public static TableType MagicItemsF = new TableType("Magic Items", "F");
        public static TableType MagicItemsG = new TableType("Magic Items", "G");
        public static TableType MagicItemsH = new TableType("Magic Items", "H");
        public static TableType MagicItemsI = new TableType("Magic Items", "I");

        /// <summary>
        /// Initializes the tables.
        /// </summary>
        public static void Initialize()
        {
            allTableTypes.Add(IndividualTreasure0_4);
            allTableTypes.Add(IndividualTreasure5_10);
            allTableTypes.Add(IndividualTreasure11_16);
            allTableTypes.Add(IndividualTreasure17);

            allTableTypes.Add(TreasureHoard0_4);
            allTableTypes.Add(TreasureHoard5_10);
            allTableTypes.Add(TreasureHoard11_16);
            allTableTypes.Add(TreasureHoard17);

            allTableTypes.Add(Gems10gp);
            allTableTypes.Add(Gems50gp);
            allTableTypes.Add(Gems100gp);
            allTableTypes.Add(Gems500gp);
            allTableTypes.Add(Gems1000gp);
            allTableTypes.Add(Gems5000gp);

            allTableTypes.Add(ArtObjects25gp);
            allTableTypes.Add(ArtObjects250gp);
            allTableTypes.Add(ArtObjects750gp);
            allTableTypes.Add(ArtObjects2500gp);
            allTableTypes.Add(ArtObjects7500gp);

            allTableTypes.Add(MagicItemsA);
            allTableTypes.Add(MagicItemsB);
            allTableTypes.Add(MagicItemsC);
            allTableTypes.Add(MagicItemsD);
            allTableTypes.Add(MagicItemsE);
            allTableTypes.Add(MagicItemsF);
            allTableTypes.Add(MagicItemsG);
            allTableTypes.Add(MagicItemsH);
            allTableTypes.Add(MagicItemsI);
        }

        /// <summary>
        /// Finds a table that has the specified type and identifier.
        /// </summary>
        /// <param name="type"> The type to search for. </param>
        /// <param name="identifier"> The identifier to search for. </param>
        /// <returns> The table if it exists. Null otherwise. </returns>
        public static TableType FindTableType(string type, string identifier)
        {
            foreach (var tt in allTableTypes)
                if (tt.Type.Equals(type) && tt.Identifier.Equals(identifier))
                    return tt;

            return null;
        }
    }
}