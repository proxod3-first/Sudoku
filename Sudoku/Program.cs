using System;

namespace Sudoku.Make
{
	class Program
	{
		private static Random rnd = new Random();

		static void Main(string[] args)
		{
			Console.WriteLine("   Sudoku\n\n");

			int[,] sudoku = new int[9, 9];
			int mode_nums = default;

			Console.WriteLine("1. Easy\n2. Medium\n3. Hard\n");
			switch (Console.ReadKey().Key)
			{
				case ConsoleKey.D1:
					mode_nums = rnd.Next(35, 39); // Easy: 35-38 чисел
					break;
				case ConsoleKey.D2:
					mode_nums = rnd.Next(30, 34); // Medium: 30-33 чисел
					break;
				case ConsoleKey.D3:
					mode_nums = rnd.Next(21, 29); // Hard: 25-28 чисел
					break;
				default:
					Environment.Exit(0);
					break;
			}

			Console.WriteLine();

			// Начальная расстановка 
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					sudoku[i, j] = (i * 3 + i / 3 + j) % 9 + 1;
				}
			}

			//Swaps
			for (int i = 0; i <= 5; i++)
				Swaps(ref sudoku);

			Generator_Sudoku(ref sudoku, mode_nums);

			PrintSudoku(sudoku);
			Console.WriteLine($"nums = {mode_nums}");

			Console.ReadLine();
		}

		private static void Generator_Sudoku(ref int[,] sudoku, int mode_nums)
		{
			int count_nums = 0;
			while(count_nums != mode_nums)
			{
				sudoku[rnd.Next(0, 9), rnd.Next(0, 9)] = 0;
				count_nums++;
			}
		}

		private static void Swaps(ref int[,] sudoku)
		{
			int temp;

			#region 1. Swap: rows->columns and columns->rows
			int step = 8;
			for (int i = 0; i < 9; i++)
			{
				for (int j = i, k = i; j <= step - i; j++, k++)
				{
					temp = sudoku[k, i];
					sudoku[k, i] = sudoku[i, j];
					sudoku[i, j] = temp;
				}
				step++;
			}
			#endregion

			#region 2. Swap two rows-lines
			int num_line1 = rnd.Next(0, 9);
			int num_line2 = rnd.Next(0, 9);
			if (num_line1 == num_line2)
			{
				while (num_line1 != num_line2)
					num_line2 = rnd.Next(0, 9);
			}

			for (int j = 0; j < 9; j++)
			{
				temp = sudoku[num_line1, j];
				sudoku[num_line1, j] = sudoku[num_line2, j];
				sudoku[num_line2, j] = temp;
			}
			#endregion

			#region 3. Swap two rows-areas
			int area1 = rnd.Next(0, 3);
			int area2 = rnd.Next(0, 3);

			if (area1 == area2)
			{
				while (area1 != area2)
					area2 = rnd.Next(0, 3);
			}

			int num_lines1, num_lines2;
			for (int i = 0; i < 3; i++)
			{
				num_lines1 = area1 * 3 + i;
				num_lines2 = area2 * 3 + i;
				for (int j = 0; j < 9; j++)
				{
					temp = sudoku[num_lines1, j];
					sudoku[num_lines1, j] = sudoku[num_lines2, j];
					sudoku[num_lines2, j] = temp;
				}
			}
			#endregion

			#region 4. Swap two vertical rows-lines
			int num_vert_line1 = rnd.Next(0, 9);
			int num_vert_line2 = rnd.Next(0, 9);

			if (num_vert_line1 == num_vert_line2)
			{
				while (num_vert_line1 != num_vert_line2)
					num_vert_line2 = rnd.Next(0, 9);
			}

			for (int i = 0; i < 9; i++)
			{
				temp = sudoku[i, num_vert_line1];
				sudoku[i, num_vert_line1] = sudoku[i, num_vert_line2];
				sudoku[i, num_vert_line2] = temp;
			}
			#endregion

			#region 5. Swap two vertical rows-areas
			int vert_area1 = rnd.Next(0, 3);
			int vert_area2 = rnd.Next(0, 3);

			if (vert_area1 == vert_area2)
			{
				while (vert_area1 != vert_area2)
					vert_area2 = rnd.Next(0, 3);
			}

			int num_vert_lines1, num_vert_lines2;
			for (int i = 0; i < 3; i++)
			{
				num_vert_lines1 = vert_area1 * 3 + i;
				num_vert_lines2 = vert_area2 * 3 + i;
				for (int j = 0; j < 9; j++)
				{
					temp = sudoku[num_vert_lines1, j];
					sudoku[num_vert_lines1, j] = sudoku[num_vert_lines2, j];
					sudoku[num_vert_lines2, j] = temp;
				}
			}
			#endregion

		}

		private static void PrintSudoku(int[,] sudoku)
		{
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
		}

	}
}
