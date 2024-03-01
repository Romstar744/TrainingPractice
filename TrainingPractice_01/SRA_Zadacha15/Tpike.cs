using System;

namespace SRA_Zadacha15
{
	internal class Tpike : TFish
	{
		public Tpike(double xCoordinate, double yCoordinate, double speed, double size, string color, string direction)
			: base(xCoordinate, yCoordinate, speed, size, color, direction)
		{
		}

		public override void Draw()
		{
			// Реализация рисования рыбы в виде зеленой стрелки
			Console.WriteLine("Drawing Tpike at ({0}, {1}) as a green arrow", xCoordinate, yCoordinate);
		}

		public void Eat(School carpSchool, double minDistance)
		{
			TFish closestCarp = FindClosestCarp(carpSchool);
			if (closestCarp != null && CalculateDistance(closestCarp) < minDistance)
			{
				Console.WriteLine("Tpike at ({0}, {1}) ate a carp!", xCoordinate, yCoordinate);
				carpSchool.RemoveFish(closestCarp);
			}
		}

		private TFish FindClosestCarp(School carpSchool)
		{
			TFish closestCarp = null;
			double minDistance = double.MaxValue;

			TFish current = carpSchool.GetHead();
			while (current != null)
			{
				double distance = CalculateDistance(current);
				if (distance < minDistance)
				{
					minDistance = distance;
					closestCarp = current;
				}
				current = current.NextFish;
			}

			return closestCarp;
		}

		private double CalculateDistance(TFish otherFish)
		{
			double deltaX = xCoordinate - otherFish.xCoordinate;
			double deltaY = yCoordinate - otherFish.yCoordinate;
			return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
		}
	}
}
