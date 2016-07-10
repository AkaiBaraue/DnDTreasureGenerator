using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDTreasureGenerator.Program
{
    /// <summary>
    /// A class that holds the random generator. Ensures that the same Random is always used in every part of the program.
    /// </summary>
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
