using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;

using DnDTreasureGenerator.JsonModels;

namespace DnDTreasureGenerator.JsonModels
{
    /// <summary>
    /// A class that deserializes the various Json data files.
    /// </summary>
    class JsonParser
    {
        /// <summary>
        /// Deserializes the Gems file.
        /// </summary>
        /// <returns> A model containing the data from the file. </returns>
        public Gems_Model DeserializeGems()
        {
            var items = new Gems_Model();

            using (StreamReader r = new StreamReader("Data/Gems.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<Gems_Model>(json);
            }

            return items;
        }

        /// <summary>
        /// Deserializes the ArtObjects file.
        /// </summary>
        /// <returns> A model containing the data from the file. </returns>
        public ArtObjects_Model DeserializeArtObjects()
        {
            var items = new ArtObjects_Model();

            using (StreamReader r = new StreamReader("Data/ArtObjects.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<ArtObjects_Model>(json);
            }

            return items;
        }

        /// <summary>
        /// Deserializes the MagicItems file.
        /// </summary>
        /// <returns> A model containing the data from the file. </returns>
        public MagicItems_Model DeserializeMagicItems()
        {
            var items = new MagicItems_Model();

            using (StreamReader r = new StreamReader("Data/MagicItems.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<MagicItems_Model>(json);
            }

            return items;
        }

        /// <summary>
        /// Deserializes the IndividualTreasure file.
        /// </summary>
        /// <returns> A model containing the data from the file. </returns>
        public IndividualTreasure_Model DeserializeIndividualTreasure()
        {
            var items = new IndividualTreasure_Model();

            using (StreamReader r = new StreamReader("Data/IndividualTreasure.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<IndividualTreasure_Model>(json);
            }

            return items;
        }

        /// <summary>
        /// Deserializes the TreasureHoard file.
        /// </summary>
        /// <returns> A model containing the data from the file. </returns>
        public TreasureHoard_Model DeserializeTreasureHoard()
        {
            var items = new TreasureHoard_Model();

            using (StreamReader r = new StreamReader("Data/TreasureHoard.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<TreasureHoard_Model>(json);
            }

            return items;
        }
    }
}
