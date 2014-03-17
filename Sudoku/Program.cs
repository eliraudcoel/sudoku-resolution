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

        public static bool absentSurLaRegion(int[,] sudoku, int x, int y, double max)
        {
            int valeur = sudoku[x, y];
            bool estPresent = true;

            Console.WriteLine("X : " + x + " Y : " + y);

            int _x = quelMin(max, x);
            Console.WriteLine("min X :" + _x);

            int _y = quelMin(max, y);
            Console.WriteLine("min Y :" + _y);

            for (int i = _x; i < _x + 3; i++)
            {
                for (int j = _y; j < _y + 3; j++)
                {
                    if (i != x && j != y)
                    {
                        if (sudoku[i, j] == valeur)
                        {
                            estPresent = false;
                        }
                    }
                }
            }
            return estPresent;
        }

        public static int quelMin(double max, int valeur)
        {
            int min = 0;

            Console.WriteLine("Valeur : " + valeur);

            if (valeur < max && valeur >= 6)
            {
                min = 6;
            }
            if (valeur < 6 && valeur >= 3)
            {
                min = 3;
            }
            if (valeur < 3 && valeur >= 0)
            {
                min = 0;
            }

            return min;
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

            double maxXouY = Math.Sqrt(sudoku.Length);

            afficherSudoku(sudoku);

            Console.ReadLine();
        }
    }
}
