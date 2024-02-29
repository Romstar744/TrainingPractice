namespace SRA_Zadacha14
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
			this.buttonSetInterval = new System.Windows.Forms.Button();
			this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDownFieldSize = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFieldSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonSetInterval
			// 
			this.buttonSetInterval.Location = new System.Drawing.Point(20, 50);
			this.buttonSetInterval.Name = "buttonSetInterval";
			this.buttonSetInterval.Size = new System.Drawing.Size(75, 23);
			this.buttonSetInterval.TabIndex = 1;
			this.buttonSetInterval.Text = "Применить";
			this.buttonSetInterval.UseVisualStyleBackColor = true;
			this.buttonSetInterval.Click += new System.EventHandler(this.buttonSetInterval_Click);
			// 
			// numericUpDownInterval
			// 
			this.numericUpDownInterval.Location = new System.Drawing.Point(6, 24);
			this.numericUpDownInterval.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numericUpDownInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownInterval.Name = "numericUpDownInterval";
			this.numericUpDownInterval.Size = new System.Drawing.Size(120, 20);
			this.numericUpDownInterval.TabIndex = 2;
			this.numericUpDownInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownInterval.ValueChanged += new System.EventHandler(this.numericUpDownInterval_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Время 1-5000 мс";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(184, 52);
			this.label2.TabIndex = 4;
			this.label2.Text = "Зеленые - здоровые клетки\r\nКрасные - зараженные клетки\r\nСиние - клетки с иммуните" +
    "том\r\nЗеленые - востановленные клетки\r\n";
			// 
			// numericUpDownFieldSize
			// 
			this.numericUpDownFieldSize.Location = new System.Drawing.Point(6, 159);
			this.numericUpDownFieldSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numericUpDownFieldSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDownFieldSize.Name = "numericUpDownFieldSize";
			this.numericUpDownFieldSize.Size = new System.Drawing.Size(120, 20);
			this.numericUpDownFieldSize.TabIndex = 5;
			this.numericUpDownFieldSize.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 143);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(118, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Размер поля: 100-500";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(21, 185);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Применить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(283, 159);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(118, 119);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numericUpDownFieldSize);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDownInterval);
			this.Controls.Add(this.buttonSetInterval);
			this.Controls.Add(this.pictureBox1);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFieldSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button buttonSetInterval;
		private System.Windows.Forms.NumericUpDown numericUpDownInterval;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericUpDownFieldSize;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}

