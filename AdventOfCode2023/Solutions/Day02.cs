using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solutions
{
    internal class Day02 : ISolution
    {
        public int TaskNumber => 2;

        public void Solve()
        {
            var data = Helpers.ReadAllFromInputFile("task2");
            List<GameResult> results = new List<GameResult>();
            List<int> ids = new List<int>();
            foreach (var item in data)
            {
                results.Add(Parse(item));
            }

            Dictionary<string, int> mustHave = new Dictionary<string, int>()
            {
                {"red", 12 },
                {"green", 13 },
                {"blue", 14 }
            };
            foreach (var item in results)
            {
                bool shouldAdd = true;
                foreach (var game in item.GameDraws)
                {
                    var hasMandatoryKeys = game.Keys.Where(key => mustHave.ContainsKey(key));
                    if (hasMandatoryKeys.Any())
                    {
                        var toCheck = game.Where(x => mustHave.ContainsKey(x.Key)).ToDictionary();
                        foreach (var kvp in toCheck)
                        {
                            var valueToCheck = mustHave[kvp.Key];
                            if (kvp.Value > valueToCheck)
                            {
                                shouldAdd = false;
                                break;
                            }

                        }
                        if (shouldAdd == false)
                        {
                            break;
                        }
                    }
                }
                if (shouldAdd)
                {
                    ids.Add(item.GameNumber);
                }
            }
            Console.WriteLine(ids.Sum());
        }

        private GameResult Parse(string item)
        {
            var gameNumber = int.Parse(item.Split(':').First().Remove(0, 5));
            var result = new GameResult(gameNumber);
            var games = item.Split(':').Last().Split(';');
            foreach (var game in games)
            {
                result.AddDraw(game.Split(',')
                   .Select(item => item.Trim().Split(' '))
                   .Where(parts => parts.Length == 2 && int.TryParse(parts[0], out int quantity))
                   .ToDictionary(parts => parts[1], parts => int.Parse(parts[0])));
            }
            return result;
        }

        private class GameResult
        {
            public int GameNumber;
            public List<Dictionary<string, int>> GameDraws;
            public GameResult(int num)
            {
                GameNumber = num;
                GameDraws = new List<Dictionary<string, int>>();
            }
            public void AddDraw(Dictionary<string, int> draw)
            {
                GameDraws.Add(draw);
            }
        }
    }
}
