using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.JsonModels
{
    public class Gems_Model
    {
        public List<Gp10> GemsWorth10gp { get; set; }
        public List<Gp50> GemsWorth50gp { get; set; }
        public List<Gp100> GemsWorth100gp { get; set; }
        public List<Gp500> GemsWorth500gp { get; set; }
        public List<Gp1000> GemsWorth1000gp { get; set; }
        public List<Gp5000> GemsWorth5000gp { get; set; }
    }

    public class Gp10111
    {
        public int Result { get; set; }
        public string Name { get; set; }
    }

    public class Gp50
    {
        public int Result { get; set; }
        public string Name { get; set; }
    }

    public class Gp100
    {
        public int Result { get; set; }
        public string Name { get; set; }
    }

    public class Gp500
    {
        public int Result { get; set; }
        public string Name { get; set; }
    }

    public class Gp1000
    {
        public int Result { get; set; }
        public string Name { get; set; }
    }

    public class Gp5000
    {
        public int Result { get; set; }
        public string Name { get; set; }
    }
}
