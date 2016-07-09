using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.JsonModels
{
    public class Gems2_Model
    {
        public List<G2Gp10> Gp10 { get; set; }
    }

    public class G2Gp10
    {
        public int Result { get; set; }
        public string Name { get; set; }
    }
}
