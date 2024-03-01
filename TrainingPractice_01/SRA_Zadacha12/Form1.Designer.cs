namespace SRA_Zadacha12
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
			this.btn_resh = new System.Windows.Forms.Button();
			this.btn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_resh
			// 
			this.btn_resh.BackColor = System.Drawing.Color.PaleVioletRed;
			this.btn_resh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_resh.Location = new System.Drawing.Point(157, 379);
			this.btn_resh.Name = "btn_resh";
			this.btn_resh.Size = new System.Drawing.Size(83, 23);
			this.btn_resh.TabIndex = 4;
			this.btn_resh.Text = "Проверить";
			this.btn_resh.UseVisualStyleBackColor = false;
			this.btn_resh.Click += new System.EventHandler(this.btn_resh_Click);
			// 
			// btn
			// 
			this.btn.BackColor = System.Drawing.Color.PaleVioletRed;
			this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn.Location = new System.Drawing.Point(55, 379);
			this.btn.Name = "btn";
			this.btn.Size = new System.Drawing.Size(84, 23);
			this.btn.TabIndex = 3;
			this.btn.Text = "Ввести значения";
			this.btn.UseVisualStyleBackColor = false;
			this.btn.Click += new System.EventHandler(this.btn_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btn_resh);
			this.Controls.Add(this.btn);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn_resh;
		private System.Windows.Forms.Button btn;
	}
}

