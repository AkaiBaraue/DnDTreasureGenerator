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
    }
}
