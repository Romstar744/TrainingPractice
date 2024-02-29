using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRA_Zadacha16
{
	public partial class Form1 : Form
	{
		private Canvas c;
				
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!this.timer1.Enabled)
				this.timer1.Start();
			else
				this.timer1.Stop();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Settings.Visible = !Settings.Visible;
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.Settings.Hide();
			this.c = new Canvas((Form)sender, 0, 0, this.Width, this.Height);
			this.c.GenerateNewDots();
			this.dotsCountNUD.Value = (Decimal)this.c.dotCount;
			this.lengthBetweenNUD.Value = (Decimal)(int)this.c.legthBetween;
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			this.c.SecondDot.x = (double)this.Width;
			this.c.SecondDot.y = (double)this.Height;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.c.Step();
			this.c.draw_points();

		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.c.legthBetween = (double)(int)this.lengthBetweenNUD.Value;
			this.c.dotCount = (int)this.dotsCountNUD.Value;
			this.c.GenerateNewDots();
		}
	}
}
