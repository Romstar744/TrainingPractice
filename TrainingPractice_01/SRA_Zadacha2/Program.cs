using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPractice_01
{
	// Основной класс программы
	class Program
	{
		// Основная функция для рассчета ходов слона
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Введите координаты слона x1 y1 и координаты фигуры x2 y2:");

				string[] input = Console.ReadLine().Split(' ');
				int x1 = Convert.ToInt32(input[0][0] - 'a' + 1);
				int y1 = Convert.ToInt32(input[0][1] - '0');
				int x2 = Convert.ToInt32(input[1][0] - 'a' + 1);
				int y2 = Convert.ToInt32(input[1][1] - '0');

				if (x1 < 1 || x1 > 8 || y1 < 1 || y1 > 8 || x2 < 1 || x2 > 8 || y2 < 1 || y2 > 8)
				{
					Console.WriteLine("Введены некорректные координаты");
					return;
				}

				bool canBishopBeat = CanBishopBeat(x1, y1, x2, y2);

				if (canBishopBeat)
				{
					Console.WriteLine("Слон сможет побить фигуру");
				}
				else
				{
					Console.WriteLine("Слон не сможет побить фигуру");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ошибка: " + ex.Message);
			}
		}

		// Проверка, может ли слон побить фигуру за один ход и проерка нахождения на одной диагонали со слоном
		static bool CanBishopBeat(int x1, int y1, int x2, int y2)
		{
			return Math.Abs(x1 - x2) == Math.Abs(y1 - y2);
		}
	}
}