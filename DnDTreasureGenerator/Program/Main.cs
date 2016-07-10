using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DnDTreasureGenerator.JsonModels;
using DnDTreasureGenerator.Tables;

namespace DnDTreasureGenerator.Program
{
    /// <summary>
    /// A class that lies between the GUI and the backend code.
    /// </summary>
    class Main
    {
        /// <summary>
        /// The constructor. Ensures that important classes have been initialized.
        /// </summary>
        public Main()
        {
            RNG.Initialize();
            TableType.Initialize();
            TableCollection.Initialize();
        }

        /// <summary>
        /// Generates loot for the chosen type of table.
        /// </summary>
        /// <param name="tableType"> The tableType to generate loot for. </param>
        /// <returns> A string representing the loot that has been generated. </returns>
        public string Generate(TableType tableType)
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
    }
}
