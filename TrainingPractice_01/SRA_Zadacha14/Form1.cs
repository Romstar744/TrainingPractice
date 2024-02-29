using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRA_Zadacha14
{
	public partial class Form1 : Form
	{
		private int N = 100;
		private Cell[,] field;
		private Bitmap bitmap;
		private Timer timer = new Timer();
		private Random random = new Random();

		public Form1()
		{
			InitializeComponent();
			numericUpDownFieldSize.Minimum = 100;
			numericUpDownFieldSize.Maximum = 400;
			numericUpDownFieldSize.Value = 100; 
			numericUpDownInterval.Minimum = 1;
			numericUpDownInterval.Maximum = 5000;
			numericUpDownInterval.Value = 100; 
			InitializeField(N); 
			timer.Interval = (int)numericUpDownInterval.Value;
			timer.Tick += Timer_Tick;
			timer.Start();
			CenterPictureBox(N);
		}
		private void InitializeField(int size)
		{
			N = size;
			field = new Cell[N, N];
			bitmap = new Bitmap(N, N);
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					field[i, j] = new Cell();
				}
			}
			
			field[N / 2, N / 2].State = Cell.CellState.Infected;
			DrawField();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			UpdateField();
			DrawField();
		}

		private void UpdateField()
		{
			Cell[,] nextField = new Cell[N, N];
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					nextField[i, j] = new Cell(field[i, j].State)
					{
						TimeSinceInfected = field[i, j].TimeSinceInfected
					};

					nextField[i, j].Update();
				}
			}

			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					if (field[i, j].State == Cell.CellState.Infected)
					{
						TryInfect(i - 1, j, nextField);
						TryInfect(i + 1, j, nextField);
						TryInfect(i, j - 1, nextField);
						TryInfect(i, j + 1, nextField);
					}
				}
			}

			field = nextField; 
		}

		private void TryInfect(int x, int y, Cell[,] nextField)
		{
			if (x >= 0 && x < N && y >= 0 && y < N && field[x, y].State == Cell.CellState.Healthy)
			{
				if (random.NextDouble() < 0.5)
				{
					nextField[x, y].State = Cell.CellState.Infected;
				}
			}
		}

		private void DrawField()
		{
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					Color color;
					switch (field[i, j].State)
					{
						case Cell.CellState.Healthy:
							color = Color.Green;
							break;
						case Cell.CellState.Infected:
							color = Color.Red;
							break;
						case Cell.CellState.Immune:
							color = Color.Blue;
							break;
						case Cell.CellState.Recovered:
							color = Color.Yellow;
							break;
						default:
							color = Color.Black;
							break;
					}
					bitmap.SetPixel(i, j, color);
				}
			}
			pictureBox1.Image = bitmap;
		}

		private void numericUpDownInterval_ValueChanged(object sender, EventArgs e)
		{

		}

		private void buttonSetInterval_Click(object sender, EventArgs e)
		{
			timer.Interval = (int)numericUpDownInterval.Value;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int newSize = (int)numericUpDownFieldSize.Value;
			InitializeField(newSize);
			CenterPictureBox(newSize);
		}

		private void CenterPictureBox(int size)
		{
			pictureBox1.Size = new Size(size, size);
			pictureBox1.Location = new Point(
				(this.ClientSize.Width - pictureBox1.Width) / 2,
				(this.ClientSize.Height - pictureBox1.Height) / 2);
		}
	}
}
