using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solutions
{
    internal class DayOne :ISolution
    {
        public DayOne() { }

        public int TaskNumber => 1;

        public void Solve()
        {
            var result = 0;
            var file = File.ReadAllLines("input/task1.txt");

            foreach (var line in file)
            {
                var numbers= line.Where(x => char.IsNumber(x)).ToList();
                if (numbers.Any())
                {
                    if(numbers.FirstOrDefault()!=null && numbers.LastOrDefault() != null)
                    {
                        string found= numbers.First().ToString()+ numbers.Last().ToString();
                        result += int.Parse(found);
                    }
                }
            }
            Console.WriteLine(result);  
        }
    }
}
