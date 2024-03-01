using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SRA_Zadacha12
{
	public partial class Form1 : Form
	{

		// Массив цветов для каждого блока 3x3
		Color[,] blockColors = {
			{ Color.LightBlue, Color.LightCoral, Color.LightGreen },
			{ Color.LightGoldenrodYellow, Color.LightPink, Color.LightSalmon },
			{ Color.LightSkyBlue, Color.LightGray, Color.LightSeaGreen }
		};

		private TextBox[,] textBoxes;
		List<int> nonEmptyRows = new List<int>();
		List<int> nonEmptyColumns = new List<int>();
		private List<Point> changedCells = new List<Point>();
		bool isMessageBoxShown_vvod_dan, knopka_proverki_vseg_sud = false;
		int chet_iter = 1;

		private Timer saveTimer;
		private bool[,] isTextBoxLocked = new bool[9, 9];
		bool hasDuplicates;

		public Form1()
		{
			saveTimer = new Timer();
			saveTimer.Interval = 60000;
			saveTimer.Tick += SaveTimer_Tick;
			saveTimer.Start();

			InitializeComponent();
			InitializeTextBoxes();
			LoadSavedData();
			ColorAllBlocks();
		}

		private void SaveTimer_Tick(object sender, EventArgs e)
		{
			using (StreamWriter writer = new StreamWriter("savedData.txt"))
			{
				for (int i = 0; i < 9; i++)
				{
					for (int j = 0; j < 9; j++)
					{
						string textToWrite = textBoxes[i, j].Text;
						string lockStatus = textBoxes[i, j].Enabled ? "Unlocked" : "Locked";

						// Сохраняем как текст, так и статус блокировки
						writer.Write($"{textToWrite},{lockStatus} ");
					}
					writer.WriteLine(); // добавляем переход на новую строку после каждой строки в файле
				}

				// Теперь также сохраняем статус блокировки btn
				string btnLockStatus = btn.Enabled ? "Unlocked" : "Locked";
				writer.WriteLine($"Btn,{btnLockStatus}");
			}
			MessageBox.Show("Данные сохранены!");
		}

		private void LoadSavedData()
		{
			if (File.Exists("savedData.txt"))
			{
				string[] lines = File.ReadAllLines("savedData.txt");

				for (int i = 0; i < Math.Min(lines.Length, 9); i++)
				{
					string[] cellData = lines[i].Split(' ');

					for (int j = 0; j < Math.Min(cellData.Length, 9); j++)
					{
						string[] parts = cellData[j].Split(',');

						// Устанавливаем текст для ячейки
						if (parts.Length >= 1)
						{
							textBoxes[i, j].Text = parts[0];
						}

						// Устанавливаем статус блокировки для ячейки
						if (parts.Length >= 2)
						{
							isTextBoxLocked[i, j] = parts[1] == "Locked";
							textBoxes[i, j].Enabled = !isTextBoxLocked[i, j];
						}
					}
				}

				// Загружаем статус блокировки btn в конце файла
				if (lines.Length > 9)
				{
					string btnStatus = lines[9].Split(',')[1];
					btn.Enabled = btnStatus == "Unlocked";
				}
			}
		}

		private void InitializeTextBoxes()
		{
			// Создаем и располагаем TextBox'ы на форме
			textBoxes = new TextBox[9, 9];
			int textBoxSize = 30;

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					TextBox textBox = new TextBox();
					textBox.Size = new System.Drawing.Size(textBoxSize, textBoxSize);
					textBox.Location = new System.Drawing.Point(j * (textBoxSize + 3), i * (textBoxSize + 3));
					textBox.TextAlign = HorizontalAlignment.Center;

					textBox.Multiline = true;

					textBox.Font = new Font(textBox.Font.FontFamily, 16);

					// Добавляем обработчик события KeyPress для каждого TextBox
					textBox.KeyPress += TextBox_KeyPress;

					// Добавляем TextBox на форму и в массив textBoxes
					this.Controls.Add(textBox);
					textBoxes[i, j] = textBox;
				}
			}
		}
		private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			TextBox textBox = (TextBox)sender;

			// Проверяем, является ли введенный символ числом от 1 до 9 или является ли это клавишей Backspace (удаление)
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true; // Предотвращаем добавление символа в TextBox
			}
			else if (!char.IsControl(e.KeyChar))
			{
				// Если введенный символ - цифра, проверяем, что это число от 1 до 9
				string newText = textBox.Text + e.KeyChar;
				if (!int.TryParse(newText, out int value) || value < 1 || value > 9)
				{
					e.Handled = true; // Предотвращаем добавление символа в TextBox
				}
			}
		}

		// Метод для установки цвета внутри блока 3x3
		private void ColorBlock(int blockRow, int blockCol)
		{
			for (int i = blockRow * 3; i < (blockRow + 1) * 3; i++)
			{
				for (int j = blockCol * 3; j < (blockCol + 1) * 3; j++)
				{
					textBoxes[i, j].BackColor = blockColors[blockRow, blockCol];
					textBoxes[i, j].BorderStyle = BorderStyle.FixedSingle; // Стиль границы между ячейками
				}
			}
		}

		// Метод для перекраски всех блоков
		private void ColorAllBlocks()
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					ColorBlock(i, j);
				}
			}
		}
		

		private void Prov_Vvod()
		{
			// Очистим списки перед каждой проверкой, чтобы избежать накопления предыдущих данных
			nonEmptyRows.Clear();
			nonEmptyColumns.Clear();
			changedCells.Clear(); // Очистим список измененных ячеек перед новой проверкой

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					if (!string.IsNullOrEmpty(textBoxes[i, j].Text))
					{
						nonEmptyRows.Add(i);
						nonEmptyColumns.Add(j);
						chet_iter++;
						CheckDuplicates(i, j, chet_iter);
					}
				}
			}
			if (chet_iter == 1 && !isMessageBoxShown_vvod_dan)
			{
				MessageBox.Show("Ячейки не должны быть пустыми ");
				isMessageBoxShown_vvod_dan = true;
			}

			if (chet_iter < 81 && !isMessageBoxShown_vvod_dan && knopka_proverki_vseg_sud)
			{
				MessageBox.Show($"Вы не заполнили все поля");
				isMessageBoxShown_vvod_dan = true;
				knopka_proverki_vseg_sud = false;
			}

			// Возвращаем цвет для измененных ячеек
			foreach (var cell in changedCells)
			{
				textBoxes[cell.X, cell.Y].BackColor = blockColors[cell.X / 3, cell.Y / 3];
			}
		}

		private void CheckDuplicates(int row, int column, int chet_iter)
		{
			string currentNumber = textBoxes[row, column].Text;

			// Проверка по горизонтали (строке)
			for (int i = 0; i < 9; i++)
			{
				if (i != column && textBoxes[row, i].Text == currentNumber)
				{
					MarkDuplicateCells(row, i, row, column);
					hasDuplicates = true;
				}
			}

			// Проверка по вертикали (столбцу)
			for (int j = 0; j < 9; j++)
			{
				if (j != row && textBoxes[j, column].Text == currentNumber)
				{
					MarkDuplicateCells(j, column, row, column);
					hasDuplicates = true;
				}
			}

			// Проверка в квадрате 3x3
			int squareStartRow = (row / 3) * 3;
			int squareStartColumn = (column / 3) * 3;

			for (int i = squareStartRow; i < squareStartRow + 3; i++)
			{
				for (int j = squareStartColumn; j < squareStartColumn + 3; j++)
				{
					if ((i != row || j != column) && textBoxes[i, j].Text == currentNumber)
					{
						MarkDuplicateCells(i, j, row, column);
						hasDuplicates = true;
					}
				}
			}

			if (hasDuplicates && !isMessageBoxShown_vvod_dan)
			{
				MessageBox.Show($"Ошибка: Дубликат числа {currentNumber} в строке, столбце или квадрате 3x3");
				isMessageBoxShown_vvod_dan = true;
			}
			if (!hasDuplicates && chet_iter < 81 && !isMessageBoxShown_vvod_dan && !knopka_proverki_vseg_sud)
			{
				MessageBox.Show("Данные были внесены");
				isMessageBoxShown_vvod_dan = true;
				for (int i = 0; i < 9; i++)
				{
					for (int j = 0; j < 9; j++)
					{
						if (!string.IsNullOrEmpty(textBoxes[i, j].Text))
						{
							textBoxes[i, j].Enabled = false;
						}
					}
				}

				btn.Enabled = false;
			}
			if (!hasDuplicates && chet_iter == 81 && !isMessageBoxShown_vvod_dan && !knopka_proverki_vseg_sud)
			{
				MessageBox.Show("Все ячейки не должны быть заполнены, нужно ввести меньше исходных данных");
				isMessageBoxShown_vvod_dan = true;
			}
			if (!hasDuplicates && chet_iter == 81 && !isMessageBoxShown_vvod_dan && knopka_proverki_vseg_sud)
			{
				MessageBox.Show($"Поздравляю с решением судоку");
				isMessageBoxShown_vvod_dan = true;
				knopka_proverki_vseg_sud = false;
			}

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void btn_resh_Click(object sender, EventArgs e)
		{
			isMessageBoxShown_vvod_dan = false;
			knopka_proverki_vseg_sud = true;
			hasDuplicates = false;
			chet_iter = 1;
			ColorAllBlocks();
			Prov_Vvod();
		}

		private void btn_Click(object sender, EventArgs e)
		{
			isMessageBoxShown_vvod_dan = false;
			hasDuplicates = false;
			chet_iter = 1;
			ColorAllBlocks();
			Prov_Vvod();
		}

		private void MarkDuplicateCells(int row1, int col1, int row2, int col2)
		{
			// Выделяем красным цветом ячейки с дубликатами
			textBoxes[row1, col1].BackColor = Color.Red;
			textBoxes[row2, col2].BackColor = Color.Red;
		}
	}
}