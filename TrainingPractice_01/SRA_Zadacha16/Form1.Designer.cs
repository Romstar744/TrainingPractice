namespace SRA_Zadacha16
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.lengthBetweenNUD = new System.Windows.Forms.NumericUpDown();
			this.dotsCountNUD = new System.Windows.Forms.NumericUpDown();
			this.button3 = new System.Windows.Forms.Button();
			this.Settings = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.lengthBetweenNUD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dotsCountNUD)).BeginInit();
			this.Settings.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Interval = 5;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(614, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(84, 27);
			this.button1.TabIndex = 0;
			this.button1.Text = "Вкл/выкл";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(704, 4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(84, 27);
			this.button2.TabIndex = 1;
			this.button2.Text = "Настройки";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// lengthBetweenNUD
			// 
			this.lengthBetweenNUD.Location = new System.Drawing.Point(169, 44);
			this.lengthBetweenNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.lengthBetweenNUD.Name = "lengthBetweenNUD";
			this.lengthBetweenNUD.Size = new System.Drawing.Size(120, 20);
			this.lengthBetweenNUD.TabIndex = 2;
			// 
			// dotsCountNUD
			// 
			this.dotsCountNUD.Location = new System.Drawing.Point(169, 3);
			this.dotsCountNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.dotsCountNUD.Name = "dotsCountNUD";
			this.dotsCountNUD.Size = new System.Drawing.Size(120, 20);
			this.dotsCountNUD.TabIndex = 3;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(191, 80);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(84, 27);
			this.button3.TabIndex = 4;
			this.button3.Text = "Применить";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Settings
			// 
			this.Settings.Controls.Add(this.label2);
			this.Settings.Controls.Add(this.label1);
			this.Settings.Controls.Add(this.dotsCountNUD);
			this.Settings.Controls.Add(this.lengthBetweenNUD);
			this.Settings.Controls.Add(this.button3);
			this.Settings.Location = new System.Drawing.Point(484, 56);
			this.Settings.Name = "Settings";
			this.Settings.Size = new System.Drawing.Size(304, 134);
			this.Settings.TabIndex = 5;
			this.Settings.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(62, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Макс длина линии";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(102, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Кол. точек";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.Settings);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			((System.ComponentModel.ISupportInitialize)(this.lengthBetweenNUD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dotsCountNUD)).EndInit();
			this.Settings.ResumeLayout(false);
			this.Settings.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.NumericUpDown lengthBetweenNUD;
		private System.Windows.Forms.NumericUpDown dotsCountNUD;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Panel Settings;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

