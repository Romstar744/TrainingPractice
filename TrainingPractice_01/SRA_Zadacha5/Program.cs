using System;

namespace EX_5
{

	// Основной класс программы
	class Program
	{
		// Основной метод программы
		static void Main(string[] args)
		{
			bool validInput = false;

			do
			{
				try
				{
					Console.WriteLine("Введите координаты коня x1 y1 и координаты фигуры x2 y2:");

					string[] arr_cord = Console.ReadLine().Split(' ');

					if (arr_cord.Length != 2 || arr_cord[0].Length != 2 || arr_cord[1].Length != 2)
					{
						Console.WriteLine("Введены некорректные координаты. Повторите ввод.");
						continue;
					}

					int cord_x1 = Convert.ToInt32(arr_cord[0][0] - 'a' + 1);
					int cord_y1 = Convert.ToInt32(arr_cord[0][1] - '0');
					int cord_x2 = Convert.ToInt32(arr_cord[1][0] - 'a' + 1);
					int cord_y2 = Convert.ToInt32(arr_cord[1][1] - '0');

					if (cord_x1 < 1 || cord_x1 > 8 || cord_y1 < 1 || cord_y1 > 8 || cord_x2 < 1 || cord_x2 > 8 || cord_y2 < 1 || cord_y2 > 8)
					{
						Console.WriteLine("Введены некорректные координаты. Повторите ввод.");
					}
					else if (cord_x1 == cord_x2 && cord_y1 == cord_y2)
					{
						Console.WriteLine("Конь и фигура не могут стоять на одной клетке. Повторите ввод.");
					}
					else
					{
						validInput = true;

						if (IsKnightMove(cord_x1, cord_y1, cord_x2, cord_y2))
						{
							Console.WriteLine("Конь сможет побить фигуру");
						}
						else
						{
							Console.WriteLine("Конь не сможет побить фигуру");
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Ошибка: " + ex.Message);
				}
			} while (!validInput);

			Console.ReadKey();
		}
		// Ход конем
		static bool IsKnightMove(int cord_x1, int cord_y1, int cord_x2, int cord_y2)
		{
			int deltaX = Math.Abs(cord_x1 - cord_x2);
			int deltaY = Math.Abs(cord_y1 - cord_y2);

			return (deltaX == 2 && deltaY == 1) || (deltaX == 1 && deltaY == 2);
		}
	}
}