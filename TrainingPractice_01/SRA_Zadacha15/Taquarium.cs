using System;

namespace SRA_Zadacha15
{
	internal class Tkarp : TFish
	{
		private School school;

		public Tkarp(double xCoordinate, double yCoordinate, double speed, double size, string color, string direction, School school)
			: base(xCoordinate, yCoordinate, speed, size, color, direction)
		{
			this.school = school;
		}

		public override void Draw()
		{
			// Реализация рисования рыбы в виде красного треугольника
			Console.WriteLine("Drawing Tkarp at ({0}, {1}) as a red triangle", xCoordinate, yCoordinate);
		}

		public void ReactToPredator()
		{
			Console.WriteLine("Tkarp at ({0}, {1}) reacts to predator (pike). Accelerating and moving in a random direction.", xCoordinate, yCoordinate);

			// Ускорение стаи
			foreach (var fish in school.GetFishList())
			{
				if (fish is Tkarp tkarpFish)
				{
					tkarpFish.Accelerate();
				}
			}

			// Перемещение стаи в случайном направлении на случайное расстояние
			Random rand = new Random();
			double distance = rand.NextDouble() * (aquariumWidth / 2.0);
			double angle = rand.Next(0, 360);
			Move(distance, angle);
		}

		private void Accelerate()
		{
			// Ускорение карпа
			speed *= 2; // Пример: удвоение скорости
		}

		private void Move(double distance, double angle)
		{
			// Перемещение карпа в указанном направлении на указанное расстояние
			xCoordinate += distance * Math.Cos(DegreeToRadian(angle));
			yCoordinate += distance * Math.Sin(DegreeToRadian(angle));
		}
	}
}
