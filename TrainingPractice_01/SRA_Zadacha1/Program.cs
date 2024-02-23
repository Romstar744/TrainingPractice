using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_1
{
	// Основной класс программы
	internal class Program
	{
		// Метод для основных расчетов программы
		static void Main(string[] args)
		{
			bool validInput = false;

			do
			{
				try
				{
					Console.WriteLine("Введите координаты ладьи x1 y1 и координаты фигуры x2 y2:");

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
					else if (x1 == x2 && y1 == y2)
					{
						Console.WriteLine("Ладья и фигура не могут стоять на одной клетке. Повторите ввод.");
					}
					else
					{
						validInput = true;

						if (x1 == x2 || y1 == y2)
						{
							Console.WriteLine("Ладья сможет побить фигуру");
							Console.ReadKey();
						}
						else
						{
							Console.WriteLine("Ладья не сможет побить фигуру");
							Console.ReadKey();
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Ошибка: " + ex.Message);
				}
			} while (!validInput);
		}
	}
}
