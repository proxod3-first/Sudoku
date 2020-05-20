using System;

namespace Sudoku.Make
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("   Sudoku\n\n");

			int[,] sudoku = new int[9, 9];
			Random rnd = new Random();
			int mode_nums = default;

			Console.WriteLine("1. Easy\n2. Medium\n3. Hard\n");
			switch (Console.ReadKey().Key)
			{
				case ConsoleKey.D1:
					mode_nums = rnd.Next(36, 40);
					break;
				case ConsoleKey.D2:
					mode_nums = rnd.Next(27, 31);
					break;
				case ConsoleKey.D3:
					mode_nums = rnd.Next(24, 26);
					break;
				default:
					Environment.Exit(0);
					break;
			}

			Console.WriteLine();

			int count_nums = 0; // счетчик кол-ва всех чисел
			int num_rnd; // рандом. число для добавления
			int i_rnd, j_rnd; // рандом. позиция числа
			int i_min_square, j_min_square; // начальная позиция квадрата
			bool isAdded = true; //добавить ли число в судоку?

			while (count_nums != mode_nums)
			{
				num_rnd = rnd.Next(1, 10);
				i_rnd = rnd.Next(0, 9);
				j_rnd = rnd.Next(0, 9);

				for (int i = 0; i < sudoku.GetLength(0); i++)
				{
					if (sudoku[i, j_rnd] == num_rnd)
					{
						isAdded = false;
						break;
					}
				}

				for (int j = 0; j < sudoku.GetLength(1); j++)
				{
					if (sudoku[i_rnd, j] == num_rnd)
					{
						isAdded = false;
						break;
					}
				}

				i_min_square = GetMinPozSquare(i_rnd);
				j_min_square = GetMinPozSquare(j_rnd);
				for (int i = i_min_square; i <= i_min_square + 2; i++)
				{
					for (int j = j_min_square; j <= j_min_square + 2; j++)
					{
						if (sudoku[i, j] == num_rnd)
						{
							isAdded = false;
							break;
						}
					}
				}

				if (sudoku[i_rnd, j_rnd] == 0 && isAdded)
				{
					sudoku[i_rnd, j_rnd] = num_rnd;
					count_nums++;
				}
				else
				{
					isAdded = true;
				}

			}//while

			Console.WriteLine("\n\n -----------------------------------");

			for (int i = 0; i < sudoku.GetLength(0); i++)
			{
				Console.Write("| ");
				for (int j = 0; j < sudoku.GetLength(1); j++)
				{
					Console.Write($"{ sudoku[i, j]} | ");
				}
				Console.WriteLine("\n-------------------------------------");
			}

			Console.WriteLine();
			Console.ReadLine();
		}

		private static int GetMinPozSquare(int num)
		{
			if (num <= 2)
				return 0;
			else if (num >= 3 && num <= 5)
				return 3;
			else
				return 6;
		}
	}
}
