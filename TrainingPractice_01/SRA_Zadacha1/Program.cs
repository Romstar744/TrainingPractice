using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPractice_01
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Введите координаты ладьи x1 y1 и координаты фигуры x2 y2:");

				// Чтение координат ладьи и фигуры
				string[] input = Console.ReadLine().Split(' ');
				int x1 = Convert.ToInt32(input[0][0] - 'a' + 1);
				int y1 = Convert.ToInt32(input[0][1] - '0');
				int x2 = Convert.ToInt32(input[1][0] - 'a' + 1);
				int y2 = Convert.ToInt32(input[1][1] - '0');

				// Проверка корректности введенных координат
				if (x1 < 1 || x1 > 8 || y1 < 1 || y1 > 8 || x2 < 1 || x2 > 8 || y2 < 1 || y2 > 8)
				{
					Console.WriteLine("Введены некорректные координаты");
					return;
				}

				// Проверка, бьет ли ладья фигуру за один ход
				if (x1 == x2 || y1 == y2)
				{
					Console.WriteLine("Ладья сможет побить фигуру");
				}
				else
				{
					Console.WriteLine("Ладья не сможет побить фигуру");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ошибка: " + ex.Message);
			}
		}
	}
}
