namespace AdventOfCode2023.Solutions
{
    internal class Day03 : ISolution
    {
        public int TaskNumber => 3;

        public void Solve()
        {
            try
            {
                var data = Helpers.ReadAllFromInputFile("task3");
                var symbols = GetSymbols(data);
                var numbers = GetNumbers(data);
                List<int> result = CheckAdjacency(symbols, numbers);
                List<int> solutionPart2 = CheckPart2(symbols, numbers);
                Console.WriteLine($"Part 1: {result.Sum()}\nPart 2: {solutionPart2.Sum()}");
            }
            catch (Exception ex) { }



        }

        private List<int> CheckPart2(List<Vector2IntWithChar> symbols, List<Vector2IntWithLengthAndNumber> numbers)
        {
            var result = new List<int>();
            var stars = symbols.Where(x => x.Char == '*').ToList();
            foreach (var star in stars)
            {
                var adjacent = numbers.Where(num => star.X.Between(num.X - 1, num.X + num.Length) && star.Y.Between(num.Y - 1, num.Y + 1));
                if (adjacent.Count() == 2)
                {
                    result.Add(adjacent.First().Number * adjacent.Last().Number);
                }
            }
            return result;
        }

        private List<int> CheckAdjacency(List<Vector2IntWithChar> symbols, List<Vector2IntWithLengthAndNumber> numbers)
        {
            var result = new List<int>();
            numbers = numbers.OrderBy(x => x.Y).ToList();
            foreach (var item in numbers)
            {
                var adjacent = symbols.Where(sym => sym.X.Between(item.X - 1, item.X + item.Length) && sym.Y.Between(item.Y - 1, item.Y + 1));
                if (adjacent.Any())
                {
                    result.Add(item.Number);
                }
            }
            return result;

        }

        private List<Vector2IntWithChar> GetSymbols(string[] data)
        {
            List<Vector2IntWithChar> symbols = new();
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    if (data[i][j] != '.' && !char.IsNumber(data[i][j]))
                    {
                        symbols.Add(new() { X = j, Y = i, Char = data[i][j] });
                    }
                }
            }
            return symbols;
        }

        private List<Vector2IntWithLengthAndNumber> GetNumbers(string[] data)
        {
            List<Vector2IntWithLengthAndNumber> numbers = new List<Vector2IntWithLengthAndNumber>();
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    if (char.IsNumber(data[i][j]))
                    {
                        Vector2IntWithLengthAndNumber toAdd = new Vector2IntWithLengthAndNumber()
                        {
                            X = j,
                            Y = i
                        };
                        string number = data[i][j].ToString();
                        bool hasMore = true;
                        int length = 1;
                        while (hasMore)
                        {
                            if (j + 1 < data[i].Length)
                            {
                                if (char.IsNumber(data[i][j + 1]))
                                {
                                    length++;
                                    number += data[i][j + 1].ToString();
                                    j++;
                                }
                                else
                                {
                                    hasMore = false;
                                }
                            }
                            else
                            {
                                hasMore = false;
                            }
                        }
                        toAdd.Length = length;
                        toAdd.Number = int.Parse(number);
                        numbers.Add(toAdd);
                    }
                }
            }
            return numbers;
        }

        private class Vector2Int()
        {
            public int X;
            public int Y;
        }
        private class Vector2IntWithChar() : Vector2Int
        {
            public char Char;
        }

        private class Vector2IntWithLengthAndNumber() : Vector2Int
        {
            public int Length;
            public int Number;
        }
    }
}
