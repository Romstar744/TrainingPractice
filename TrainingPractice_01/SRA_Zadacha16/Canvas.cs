using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRA_Zadacha16
{
	internal class Canvas
	{
		public Canvas.Point FirstDot;
		public Canvas.Point SecondDot;
		private List<Dot> dots = new List<Dot>();
		public int dotCount;
		public bool[,] tri;
		public double legthBetween = 100.0;
		public Form canv;

		public Canvas(Form graph, int x1, int y1, int x2, int y2, int dotCount = 100)
		{
			this.canv = graph;
			this.FirstDot = new Canvas.Point(Math.Min(x1, x2), Math.Min(y1, y2));
			this.SecondDot = new Canvas.Point(Math.Max(x1, x2), Math.Max(y1, y2));
			this.dotCount = dotCount;
		}

		public void Step()
		{
			foreach (Dot dot in this.dots)
			{
				dot.Position.x += dot.Vector.x;
				dot.Position.y += dot.Vector.y;
				double num1 = dot.Position.x + dot.Vector.x;
				double num2 = dot.Position.y + dot.Vector.y;
				if (num1 <= this.FirstDot.x)
				{
					dot.Vector.x = Math.Abs(dot.Vector.x);
					dot.Position.x += dot.Vector.x;
				}
				if (this.SecondDot.x - (double)dot.diam - 10.0 <= num1)
				{
					dot.Vector.x = -Math.Abs(dot.Vector.x);
					dot.Position.x += dot.Vector.x;
				}
				if (num2 <= this.FirstDot.y)
				{
					dot.Vector.y = Math.Abs(dot.Vector.y);
					dot.Position.y += dot.Vector.y;
				}
				if (this.SecondDot.y - (double)dot.diam - 40.0 <= num2)
				{
					dot.Vector.y = -Math.Abs(dot.Vector.y);
					dot.Position.y += dot.Vector.y;
				}
			}
		}

		public void GenerateNewDots()
		{
			Random r = new Random();
			this.dots.Clear();
			for (int index = 0; index < this.dotCount; ++index)
				this.dots.Add(new Dot(r, (int)this.FirstDot.x, (int)this.FirstDot.y, (int)this.SecondDot.x, (int)this.SecondDot.y, 10, true, true));
		}

		public void draw_points()
		{
			int width = (int)(this.SecondDot.x - this.FirstDot.x);
			int height = (int)(this.SecondDot.y - this.FirstDot.y);
			Bitmap bitmap = new Bitmap(width, height);
			Graphics gr = Graphics.FromImage((Image)bitmap);
			gr.FillRectangle(Brushes.White, (int)this.FirstDot.x, (int)this.FirstDot.y, width, height);
			Pen pen = new Pen(Color.Red, 1f);
			Brush brush = (Brush)new SolidBrush(Color.Red);
			this.drawLines(gr);
			foreach (Dot dot in this.dots)
			{
				gr.FillEllipse(brush, (float)dot.Position.x, (float)dot.Position.y, (float)dot.diam, (float)dot.diam);
				gr.DrawEllipse(pen, (float)dot.Position.x, (float)dot.Position.y, (float)dot.diam, (float)dot.diam);
			}
			this.canv.CreateGraphics().DrawImageUnscaled((Image)bitmap, (int)this.FirstDot.x, (int)this.FirstDot.y);
		}

		public void SetTrigonTable()
		{
			this.tri = new bool[this.dotCount, this.dotCount];
			for (int index1 = 0; index1 < this.dotCount; ++index1)
			{
				for (int index2 = 0; index2 < index1; ++index2)
				{
					if (this.lengthBetweenDots(this.dots[index1], this.dots[index2]) < this.legthBetween)
						this.tri[index1, index2] = true;
				}
			}
		}

		public double lengthBetweenDots(Dot d1, Dot d2)
		{
			double num1 = d2.Position.x - d1.Position.x;
			double num2 = d2.Position.y - d1.Position.y;
			return Math.Sqrt(num1 * num1 + num2 * num2);
		}

		public void drawLines(Graphics gr)
		{
			this.SetTrigonTable();
			Pen pen = new Pen(Color.Blue, 1f);
			for (int index1 = 0; index1 < this.dotCount; ++index1)
			{
				for (int index2 = 0; index2 < index1; ++index2)
				{
					if (this.tri[index1, index2])
					{
						float x1 = (float)this.dots[index1].Position.x;
						float y1 = (float)this.dots[index1].Position.y;
						float x2 = (float)this.dots[index2].Position.x;
						float y2 = (float)this.dots[index2].Position.y;
						gr.DrawLine(pen, x1, y1, x2, y2);
					}
				}
			}
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
		}
	}
}