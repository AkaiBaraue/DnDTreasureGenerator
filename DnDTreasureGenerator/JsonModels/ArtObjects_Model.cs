using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.JsonModels
{
    class ArtObjects_Model
    {
        public List<Gp25> ArtObjectsWorth25gp { get; set; }
        public List<Gp250> ArtObjectsWorth250gp { get; set; }
        public List<Gp750> ArtObjectsWorth750gp { get; set; }
        public List<Gp2500> ArtObjectsWorth2500gp { get; set; }
        public List<Gp7500> ArtObjectsWorth7500gp { get; set; }
    }

    public class Gp25
    {
        public int Result { get; set; }
        public string Name { get; set; }
    }

    public class Gp250
    {
        public int Result { get; set; }
        public string Name { get; set; }
    }

    public class Gp750
    {
        public int Result { get; set; }
        public string Name { get; set; }
    }

    public class Gp2500
    {
        public int Result { get; set; }
        public string Name { get; set; }
    }

    public class Gp7500
    {
        public int Result { get; set; }
        public string Name { get; set; }
    }
}
