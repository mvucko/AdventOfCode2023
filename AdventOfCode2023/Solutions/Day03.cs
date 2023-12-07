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
                Console.WriteLine(result.Sum());
            }
            catch (Exception ex) { }



        }

        private List<int> CheckAdjacency(List<Vector2Int> symbols, List<Vector2IntWithLengthAndNumber> numbers)
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

        private List<Vector2Int> GetSymbols(string[] data)
        {
            List<Vector2Int> symbols = new();
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    if (data[i][j] != '.' && !char.IsNumber(data[i][j]))
                    {
                        symbols.Add(new() { X = j, Y = i });
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

        private class Vector2IntWithLengthAndNumber() : Vector2Int
        {
            public int Length;
            public int Number;
        }
    }
}
