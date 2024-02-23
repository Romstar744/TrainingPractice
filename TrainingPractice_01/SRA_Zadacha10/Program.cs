using System;

// Основной класс программы
class Program
{
	// Основной метод программы
	static void Main()
	{
		Console.WriteLine("Введите тип фигуры (ладья, слон, король, ферзь):");
		string figureType = Console.ReadLine().ToLower();

		Random random = new Random();
		char letter1 = (char)('a' + random.Next(8));
		char digit1 = (char)('1' + random.Next(8));

		char letter2 = (char)('a' + random.Next(8));
		char digit2 = (char)('1' + random.Next(8));

		string field1 = $"{letter1}{digit1}";
		string field2 = $"{letter2}{digit2}";

		Console.WriteLine($"Сгенерированы координаты полей: {field1}, {field2}");

		switch (figureType)
		{
			case "ладья":
				CheckRook(field1, field2);
				break;

			case "слон":
				CheckBishop(field1, field2);
				break;

			case "король":
				CheckKing(field1, field2);
				break;

			case "ферзь":
				CheckQueen(field1, field2);
				break;

			default:
				Console.WriteLine("Некорректный тип фигуры.");
				break;
		}

		Console.ReadLine();
	}

	// Проверка для ладьи
	static void CheckRook(string field1, string field2)
	{
		if (field1[0] != field2[0] && field1[1] != field2[1])
		{
			Console.WriteLine("Ладья не угрожает полю.");
		}
		else
		{
			Console.WriteLine("Ладья угрожает полю.");
		}
	}

	// Проверка для слона
	static void CheckBishop(string field1, string field2)
	{
		int diff1 = Math.Abs(field1[0] - field2[0]);
		int diff2 = Math.Abs(field1[1] - field2[1]);

		if (diff1 != diff2)
		{
			Console.WriteLine("Слон не угрожает полю.");
		}
		else
		{
			Console.WriteLine("Слон угрожает полю.");
		}
	}

	// Проверка для короля
	static void CheckKing(string field1, string field2)
	{
		int diff1 = Math.Abs(field1[0] - field2[0]);
		int diff2 = Math.Abs(field1[1] - field2[1]);

		if (diff1 <= 1 && diff2 <= 1)
		{
			Console.WriteLine("Король может попасть на поле.");
		}
		else
		{
			Console.WriteLine("Король не может попасть на поле одним ходом.");
		}
	}

	// Проверка для ферзя
	static void CheckQueen(string field1, string field2)
	{
		int diff1 = Math.Abs(field1[0] - field2[0]);
		int diff2 = Math.Abs(field1[1] - field2[1]);

		if (field1[0] != field2[0] && field1[1] != field2[1] && diff1 != diff2)
		{
			Console.WriteLine("Ферзь не угрожает полю.");
		}
		else
		{
			Console.WriteLine("Ферзь угрожает полю.");
		}
	}
}
