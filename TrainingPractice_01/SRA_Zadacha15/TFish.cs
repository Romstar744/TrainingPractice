using System;

namespace SRA_Zadacha15
{
	internal class TFish
	{
		protected double xCoordinate;
		protected double yCoordinate;
		protected double speed;
		protected double size;
		protected string color;
		protected string direction;

		public TFish(double xCoordinate, double yCoordinate, double speed, double size, string color, string direction)
		{
			this.xCoordinate = xCoordinate;
			this.yCoordinate = yCoordinate;
			this.speed = speed;
			this.size = size;
			this.color = color;
			this.direction = direction;
		}

		public virtual void Draw()
		{
			// Пустой виртуальный метод, подлежащий переопределению
		}

		public string Look()
		{
			// Реализация проверки точек на линии движения рыбы
			// В данном случае, просто возвращаем цвет и расстояние до рыбы
			return $"Color: {color}, Distance: {Math.Sqrt(xCoordinate * xCoordinate + yCoordinate * yCoordinate)}";
		}

		public void Run()
		{
			// Реализация перемещения рыбы и изменения направления при необходимости
			double distance = speed; // Зависит от текущей скорости
			Move(distance);

			// Иногда случайным образом меняем направление движения рыбы
			Random rand = new Random();
			if (rand.Next(100) < 10) // Пример: смена направления с вероятностью 10%
			{
				ChangeDirection();
			}
		}

		protected void Move(double distance)
		{
			// Реализация перемещения рыбы в текущем направлении
			// В данном случае, просто обновляем координаты
			xCoordinate += distance * Math.Cos(DegreeToRadian(direction));
			yCoordinate += distance * Math.Sin(DegreeToRadian(direction));
		}

		protected void ChangeDirection()
		{
			// Реализация изменения направления рыбы
			Random rand = new Random();
			direction = rand.Next(0, 360).ToString();
		}

		private double DegreeToRadian(string angle)
		{
			// Преобразование градусов в радианы
			return Math.PI * double.Parse(angle) / 180.0;
		}
	}
}