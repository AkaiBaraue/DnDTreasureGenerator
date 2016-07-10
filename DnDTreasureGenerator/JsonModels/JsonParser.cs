using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;

using DnDTreasureGenerator.JsonModels;

namespace DnDTreasureGenerator.Program
{
    class JsonParser
    {
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
