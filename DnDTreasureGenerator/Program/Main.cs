using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DnDTreasureGenerator.JsonModels;

namespace DnDTreasureGenerator.Program
{
    class Main
    {
        public Main()
        {
            RNG.Initialize();
        }

        public string Run()
        {
            var test = new JsonParser();
            var result = test.DeserializeFile();

            var finalResult = new StringBuilder();
            foreach (var t in result.Gp10)
            {
                finalResult.AppendLine(String.Format("{0} {1}", t.Result, t.Name));
            }

            return finalResult.ToString();
        }
    }
}
