using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Helpers
    {
        internal static string[] ReadAllFromInputFile(string file)
        {
            string basedir = "input";
            return File.ReadAllLines($"{basedir}/{file}.txt");
        }
    }
}
