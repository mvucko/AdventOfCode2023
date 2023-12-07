using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal static class Helpers
    {
        internal static string[] ReadAllFromInputFile(string file)
        {
            string basedir = "input";
            return File.ReadAllLines($"{basedir}/{file}.txt");
        }

        public static bool Between<T>(this T value, T min, T max) where T : INumber<T>
        {
            return value >= min && value <= max;
        }
    }
}
