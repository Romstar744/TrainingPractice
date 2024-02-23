using System;

namespace EX_8
{
	class Program
	{
		// Запрос координат полей, проверка на корректность введенных координат и цвета полей
		static void Main()
		{
			Console.WriteLine("Введите координаты первого поля (например, a1):");
			string field1 = Console.ReadLine();

			Console.WriteLine("Введите координаты второго поля (например, b2):");
			string field2 = Console.ReadLine();

			if (IsValidField(field1) && IsValidField(field2))
			{
				if (IsSameColor(field1, field2))
				{
					Console.WriteLine("Поля одного цвета.");
				}
				else
				{
					Console.WriteLine("Поля разного цвета.");
				}
			}
			else
			{
				Console.WriteLine("Некорректные координаты полей. Введите корректные значения от a1 до h8.");
			}
		}

		// Проверка корректности координат поля
		static bool IsValidField(string field)
		{
			if (field.Length == 2)
			{
				char letter = field[0];
				char digit = field[1];

				return (letter >= 'a' && letter <= 'h') && (digit >= '1' && digit <= '8');
			}

			return false;
		}

		// Проверка, являются ли поля одного цвета
		static bool IsSameColor(string field1, string field2)
		{
			int sum1 = field1[0] + field1[1];
			int sum2 = field2[0] + field2[1];

			return sum1 % 2 == sum2 % 2;
		}
	}
}