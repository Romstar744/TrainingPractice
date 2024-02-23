using System;

namespace EX_4
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
					Console.WriteLine("Введите координаты короля x1 y1 и координаты фигуры x2 y2:");

					string[] arr = Console.ReadLine().Split(' ');

					if (arr.Length != 2 || arr[0].Length != 2 || arr[1].Length != 2)
					{
						Console.WriteLine("Введены некорректные координаты. Повторите ввод.");
						continue;
					}

					int x1 = Convert.ToInt32(arr[0][0] - 'a' + 1);
					int y1 = Convert.ToInt32(arr[0][1] - '0');
					int x2 = Convert.ToInt32(arr[1][0] - 'a' + 1);
					int y2 = Convert.ToInt32(arr[1][1] - '0');

					if (x1 < 1 || x1 > 8 || y1 < 1 || y1 > 8 || x2 < 1 || x2 > 8 || y2 < 1 || y2 > 8)
					{
						Console.WriteLine("Введены некорректные координаты. Повторите ввод.");
					}
					else if (Math.Abs(x1 - x2) <= 1 && Math.Abs(y1 - y2) <= 1)
					{
						Console.WriteLine("Король сможет побить фигуру");
						Console.ReadKey();
					}
					else
					{
						Console.WriteLine("Король не сможет побить фигуру");
						Console.ReadKey();
					}

					validInput = true;
				}
				catch (Exception ex)
				{
					Console.WriteLine("Ошибка: " + ex.Message);
				}
			} while (!validInput);
		}
	}
}