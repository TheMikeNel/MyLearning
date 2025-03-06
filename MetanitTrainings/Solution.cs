using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitTrainings
{
    internal class Solution
    {
        public static int IslandPerimeter(int[][] grid)
        {
            ushort perimeter = 0;
            for (byte i = 0; i < grid.Length; i++)
            {
                for (byte j = 0; j < grid[i].Length; j++)
                {
                    byte total = 4;

                    if (i > 0 && grid[i - 1][j] == 1) total--;
                    if (i < grid.Length - 1 && grid[i + 1][j] == 1) total--;
                    if (j > 0 && grid[i][j - 1] == 1) total--;
                    if (j < grid[i].Length - 1 && grid[i][j + 1] == 1) total--;

                    perimeter += total;
                }
            }
            return perimeter;
        }

    }
}
