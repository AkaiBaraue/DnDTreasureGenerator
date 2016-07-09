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
        public Gems2_Model DeserializeFile()
        {
            var items = new Gems2_Model();

            using (StreamReader r = new StreamReader("Data/Gems2.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<Gems2_Model>(json);
            }

            return items;
        }
    }
}
