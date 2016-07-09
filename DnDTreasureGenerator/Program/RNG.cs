using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.Program
{
    public static class RNG
    {
        public static Random RANDOM { get; private set; }

        public static void Initialize(int seed = null)
        {
            if (seed = null) RANDOM = new Random();
            else RANDOM = new Random(seed);
        }
    }
}
