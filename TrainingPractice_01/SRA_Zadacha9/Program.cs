using System;

namespace EX_9
{

	// Основной класс программы
	class Chess
	{
		// Основной метод программы
		// 1. Выбор фигуры
		// 2. Хождение фигуры по координатам
		static void Main()
		{
			Console.WriteLine("Введите исходные данные в формате (ферзь d3 слон e1 d8):");
			string input = Console.ReadLine();

			string[] inputArray = input.Split(' ');
			string whitePiece = inputArray[0];
			string whiteCoords = inputArray[1];
			string blackPiece = inputArray[2];
			string blackCoords = inputArray[3];
			string destCoords = inputArray[4];

			int x1 = whiteCoords[0] - 'a' + 1;
			int y1 = int.Parse(whiteCoords[1].ToString());
			int x2 = blackCoords[0] - 'a' + 1;
			int y2 = int.Parse(blackCoords[1].ToString());
			int x3 = destCoords[0] - 'a' + 1;
			int y3 = int.Parse(destCoords[1].ToString());

			string result = GetResult(whitePiece, x1, y1, blackPiece, x2, y2, x3, y3);

			Console.WriteLine($"Результат: {result}");
		}

		// Метод для получения результата хода фигуры
		static string GetResult(string whitePiece, int x1, int y1, string blackPiece, int x2, int y2, int x3, int y3)
		{
			if (!IsValidChessboardPosition(x1, y1) || !IsValidChessboardPosition(x2, y2) || !IsValidChessboardPosition(x3, y3))
			{
				return "Неверные координаты. Введите координаты от a1 до h8.";
			}

			switch (whitePiece.ToLower())
			{
				case "ладья":
					if (CanRookReachDestination(x1, y1, x3, y3))
					{
						if (CanBlackPieceCapture(whitePiece, x3, y3, blackPiece, x2, y2))
							return $"{whitePiece} дойдет до {GetChessCoordinates(x3, y3)}, но будет съеден фигурой {blackPiece} на следующем ходу";
						else
							return $"{whitePiece} дойдет до {GetChessCoordinates(x3, y3)}";
					}
					else
						return $"{whitePiece} не может дойти до {GetChessCoordinates(x3, y3)}";
				case "конь":
					if (CanKnightReachDestination(x1, y1, x3, y3))
					{
						if (CanBlackPieceCapture(whitePiece, x3, y3, blackPiece, x2, y2))
							return $"{whitePiece} дойдет до {GetChessCoordinates(x3, y3)}, но будет съеден фигурой {blackPiece} на следующем ходу";
						else
							return $"{whitePiece} дойдет до {GetChessCoordinates(x3, y3)}";
					}
					else
						return $"{whitePiece} не может дойти до {GetChessCoordinates(x3, y3)}";
				case "слон":
					if (CanBishopReachDestination(x1, y1, x3, y3))
					{
						if (CanBlackPieceCapture(whitePiece, x3, y3, blackPiece, x2, y2))
							return $"{whitePiece} дойдет до {GetChessCoordinates(x3, y3)}, но будет съеден фигурой {blackPiece} на следующем ходу";
						else
							return $"{whitePiece} дойдет до {GetChessCoordinates(x3, y3)}";
					}
					else
						return $"{whitePiece} не может дойти до {GetChessCoordinates(x3, y3)}";
				case "ферзь":
					if (CanQueenReachDestination(x1, y1, x3, y3))
					{
						if (CanBlackPieceCapture(whitePiece, x3, y3, blackPiece, x2, y2))
							return $"{whitePiece} дойдет до {GetChessCoordinates(x3, y3)}, но будет съеден фигурой {blackPiece} на следующем ходу";
						else
							return $"{whitePiece} дойдет до {GetChessCoordinates(x3, y3)}";
					}
					else
						return $"{whitePiece} не может дойти до {GetChessCoordinates(x3, y3)}";
				case "король":
					if (CanKingReachDestination(x1, y1, x3, y3))
					{
						if (CanBlackPieceCapture(whitePiece, x3, y3, blackPiece, x2, y2))
							return $"{whitePiece} дойдет до {GetChessCoordinates(x3, y3)}, но будет съеден фигурой {blackPiece} на следующем ходу";
						else
							return $"{whitePiece} дойдет до {GetChessCoordinates(x3, y3)}";
					}
					else
						return $"{whitePiece} не может дойти до {GetChessCoordinates(x3, y3)}";
				default:
					return "Неверное название белой фигуры.";
			}
		}

		// Проверка границ шахматной доски
		static bool IsValidChessboardPosition(int x, int y)
		{
			return x >= 1 && x <= 8 && y >= 1 && y <= 8;
		}

		// Метод для проверки возможности хода ладьи
		static bool CanRookReachDestination(int x1, int y1, int x3, int y3)
		{
			return x1 == x3 || y1 == y3;
		}

		// Метод для проверки возможности хода коня
		static bool CanKnightReachDestination(int x1, int y1, int x3, int y3)
		{
			return Math.Abs(x1 - x3) == 2 && Math.Abs(y1 - y3) == 1 || Math.Abs(x1 - x3) == 1 && Math.Abs(y1 - y3) == 2;
		}

		// Метод для проверки возможности хода слона
		static bool CanBishopReachDestination(int x1, int y1, int x3, int y3)
		{
			return Math.Abs(x1 - x3) == Math.Abs(y1 - y3);
		}

		// Метод для проверки возможности хода ферзя
		static bool CanQueenReachDestination(int x1, int y1, int x3, int y3)
		{
			return CanRookReachDestination(x1, y1, x3, y3) || CanBishopReachDestination(x1, y1, x3, y3);
		}

		// Метод для проверки возможности хода короля
		static bool CanKingReachDestination(int x1, int y1, int x3, int y3)
		{
			return Math.Abs(x1 - x3) <= 1 && Math.Abs(y1 - y3) <= 1;
		}

		// Метод для проверки возможности черной фигуры съесть белую
		static bool CanBlackPieceCapture(string whitePiece, int x, int y, string blackPiece, int x2, int y2)
		{
			switch (blackPiece.ToLower())
			{
				case "ладья":
					return CanRookReachDestination(x2, y2, x, y);
				case "конь":
					return CanKnightReachDestination(x2, y2, x, y);
				case "слон":
					return CanBishopReachDestination(x2, y2, x, y);
				case "ферзь":
					return CanQueenReachDestination(x2, y2, x, y);
				case "король":
					return CanKingReachDestination(x2, y2, x, y);
				default:
					return false;
			}
		}

		// Метод для получения строкового представления координат шахматной доски
		static string GetChessCoordinates(int x, int y)
		{
			char file = (char)('a' + x - 1);
			return $"{file}{y}";
		}
	}
}