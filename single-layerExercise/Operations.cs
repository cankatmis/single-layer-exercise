using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace single_layerExercise
{
    public static class Operations
    {
        public static void ToConsole<T>(this IEnumerable<T> input, string header)
        {
            Console.WriteLine($"-----------{header}-----------");
            foreach (var item in input)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
