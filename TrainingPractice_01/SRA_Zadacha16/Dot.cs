using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRA_Zadacha16
{
	internal class Dot
	{
		public Dot.Point Position;
		public Dot.Point Vector;
		public Dot.Point FirstDot;
		public Dot.Point SecondDot;
		public int diam = 1;
		public double spead = 100.0;

		public Dot(
		  Random r,
		  int x1,
		  int y1,
		  int x2,
		  int y2,
		  int diam,
		  bool pos = false,
		  bool vec = false,
		  double spead = 100.0)
		{
			this.FirstDot = new Dot.Point(Math.Min(x1, x2), Math.Min(y1, y2));
			this.SecondDot = new Dot.Point(Math.Max(x1, x2), Math.Max(y1, y2));
			this.spead = spead;
			this.diam = diam;
			this.Position = new Dot.Point();
			this.Vector = new Dot.Point();
			if (pos)
			{
				this.Position = new Dot.Point();
				this.Position.RandPos(r, diam, (int)this.FirstDot.x, (int)this.FirstDot.y, (int)this.SecondDot.x, (int)this.SecondDot.y);
			}
			if (!vec)
				return;
			this.Vector = new Dot.Point();
			this.Vector.RandVec(r, spead / 100.0);
		}
		public class Point
		{
			public double x = 0.0;
			public double y = 0.0;

			public Point(int x, int y)
			{
				this.x = (double)x;
				this.y = (double)y;
			}

			public Point(double x, double y)
			{
				this.x = x;
				this.y = y;
			}

			public Point()
			{
				this.x = 0.0;
				this.y = 0.0;
			}

			public void RandPos(Random r, int diam, int x1, int y1, int x2, int y2)
			{
				this.x = (double)r.Next(x1, x2 - diam);
				this.y = (double)r.Next(y1, y2 - diam);
			}

			public void RandVec(Random r, double spead = 1.0)
			{
				int num1 = r.Next(-10, 10);
				int num2 = r.Next(-10, 10);
				double num3 = Math.Sqrt((double)(num1 * num1 + num2 * num2));
				double num4 = (double)num1 / num3;
				double num5 = (double)num2 / num3;
				this.x = spead * num4;
				this.y = spead * num5;
			}
		}
	}
}
