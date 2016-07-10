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

        public static void Initialize(int seed)
        {
            RANDOM = new Random(seed);
        }

        public static void Initialize()
        {
            RANDOM = new Random();
        }
    }
}
