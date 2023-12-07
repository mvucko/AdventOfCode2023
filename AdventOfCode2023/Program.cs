
using AdventOfCode2023.Solutions;

namespace AdventOfCode2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Get result for task number: ");
                var key = Console.ReadLine();
                try
                {
                    var input = Convert.ToInt32(key);
                    if (input == 0)
                    {
                        break;
                    }
                    Solve(input);

                }
                catch (Exception e)
                {
                    Console.WriteLine("not a number :)");
                }
            }

        }

        private static void Solve(int input)
        {
            var handlers = AppDomain.CurrentDomain.GetAssemblies()
                           .SelectMany(s => s.GetTypes())
                           .Where(p => typeof(ISolution).IsAssignableFrom(p) && p.IsClass);
            foreach (var handler in handlers)
            {
                var handlerInstance = (ISolution)Activator.CreateInstance(handler);
                if (handlerInstance.TaskNumber == input)
                {
                    handlerInstance.Solve();
                }
            }

        }
    }
}
