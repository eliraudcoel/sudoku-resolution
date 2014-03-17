using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        public static void afficherSudoku(int[,] sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(sudoku[i, j]);
                }
                Console.Write("\n");
            }
        }

        public static bool absentSurLaLigne(int[,] sudoku, int x, int y)
        {
            int valeur = sudoku[x, y];
            bool estPresent = true;

            for (int i = 0; i < 9; i++)
            {
                if (i != y)
                {
                    if (sudoku[x, i] == valeur && sudoku[x,i] != 0)
                    {
                        estPresent = false;
                    }
                }
            }
            return estPresent;
        }

        public static bool absentSurLaColonne(int[,] sudoku, int x, int y)
        {
            int valeur = sudoku[x, y];
            bool estPresent = true;

            for (int i = 0; i < 9; i++)
            {
                if (i != x)
                {
                    if (sudoku[i, y] == valeur && sudoku[i, y] != 0)
                    {
                        estPresent = false;
                    }
                }
            }
            return estPresent;
        }

        public static bool absentSurLaRegion(int[,] sudoku, int x, int y)
        {
            int valeur = sudoku[x, y];
            bool estPresent = true;

            int _x = x - (x % 3);
            // 1
            int _y = y - (y % 3);
            // 0

            for (x = _x; x < _x + 3; x++)
            {
                for (y = _y; y < _y + 3; y++)
                {
                    if (sudoku[x, y] == valeur)
                    {
                        estPresent = false;
                    }
                }
            }
            return estPresent;
        }

        public static bool quelRegion(int[,] sudoku, int x, int y)
        {
            //x = 3
            //y = 2

            if (x < Math.Sqrt(sudoku.Length)) { 

            }

            return true;
        }

        static void Main(string[] args)
        {
            int[,] sudoku =
                      {
                       {0,0,0, 3,0,0, 0,5,0},
                       {0,0,5, 4,0,6, 0,0,2},
                       {2,7,0, 0,1,0, 3,6,0},

                       {7,0,4, 2,3,0, 0,0,0},
                       {5,1,0, 0,0,0, 0,3,7},
                       {0,0,0, 0,4,7, 9,0,1},

                       {0,4,6, 0,9,0, 0,1,5},
                       {1,0,0, 6,0,8, 7,0,0},
                       {0,5,0, 0,0,4, 0,0,0}
                      };
            afficherSudoku(sudoku);

            bool resultat = absentSurLaColonne(sudoku, 1, 3);

            Console.WriteLine(sudoku[1,3]+" est-il absent sur la région? "+ resultat);

            Console.WriteLine("taille :" + Math.Sqrt(sudoku.Length));

            Console.ReadLine();
        }
    }
}
