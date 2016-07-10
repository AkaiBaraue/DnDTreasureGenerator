using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.JsonModels
{
    public class Gems_Model
    {
        public List<Gp10> Gp10 { get; set; }
        public List<Gp50> Gp50 { get; set; }
        public List<Gp100> Gp100 { get; set; }
        public List<Gp500> Gp500 { get; set; }
        public List<Gp1000> Gp1000 { get; set; }
        public List<Gp5000> Gp5000 { get; set; }
    }

    public class Gp10
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
