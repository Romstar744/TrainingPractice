using System;

namespace EX_6
{

	// Основной класс программы
	class Program
	{
		static int playerHealth = 500;
		static int bossHealth = 1000;
		static bool shadowShieldActive = false;
		static bool interdimensionalRiftActive = false;
		static bool icyShacklesActive = false;
		static bool bossFrozen = false;
		static bool previousActionWasShadowShield = false;

		// Основной метод для выбора определенного заклинания
		static void Main()
		{
			Console.WriteLine("Добро пожаловать, теневой маг!");
			Console.WriteLine("Босс появился! Начинаем бой!");

			while (playerHealth > 0 && bossHealth > 0)
			{
				Console.WriteLine($"Текущее здоровье игрока: {playerHealth}");
				Console.WriteLine($"Текущее здоровье босса: {bossHealth}");

				Console.WriteLine("Выберите заклинание:");
				Console.WriteLine("1. Пламя Адского Дыхания - наносит 120 урона боссу");
				Console.WriteLine("2. Теневой Щит - уменьшает получаемый урон на 50% на следующем ходу");
				Console.WriteLine("3. Темный Переворот - меняет местами ваше и здоровье босса");
				Console.WriteLine("4. Ледяные Оковы - замораживает босса, лишая его хода на следующем раунде");
				Console.WriteLine("5. Мистическое Исцеление - восстанавливает 200 здоровья и наносит 50 урона боссу (босс не атакует)");
				Console.WriteLine("6. Пропустить ход");

				int choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						HellfireBreath();
						break;

					case 2:
						ShadowShield();
						break;

					case 3:
						DarkReversal();
						break;

					case 4:
						IcyShackles();
						break;

					case 5:
						MysticalHealing();
						break;

					case 6:
						SkipTurn();
						break;

					default:
						Console.WriteLine("Неверный выбор. Пропуск хода.");
						break;
				}
				previousActionWasShadowShield = (choice == 2);
				BossAttack();
			}

			if (playerHealth <= 0)
			{
				Console.WriteLine("Вы проиграли. Босс победил.");
			}
			else
			{
				Console.WriteLine("Поздравляем! Вы победили босса и освободили мир от его тьмы.");
			}
		}
		// Заклинание Пламя Адского Дыхания
		static void HellfireBreath()
		{
			int damage = 120;
			if (previousActionWasShadowShield)
			{
				damage *= 2;
				Console.WriteLine("Пасхалка: Ваш Теневой Щит усилил Пламя Адского Дыхания!");
				previousActionWasShadowShield = false;
			}

			Console.WriteLine($"Вы использовали Пламя Адского Дыхания и нанесли боссу {damage} урона.");
			bossHealth -= damage;
		}

		// Заклинание Теневой Щит
		static void ShadowShield()
		{
			Console.WriteLine("Вы создали Теневой Щит. Получаемый урон уменьшен на 50% на следующем ходу.");
			shadowShieldActive = true;
		}

		// Заклинание Темный Переворот
		static void DarkReversal()
		{
			Console.WriteLine("Вы совершили Темный Переворот, меняясь здоровьем с боссом.");
			int temp = playerHealth;
			playerHealth = bossHealth;
			bossHealth = temp;

			Console.WriteLine("Босс потерял ориентацию и не атакует в этот раунд.");

			bossFrozen = true;
		}

		// Заклинание Ледяные Оковы
		static void IcyShackles()
		{
			Console.WriteLine("Вы наложили Ледяные Оковы, замораживая босса. Он лишается хода на следующем раунде.");
			icyShacklesActive = true;
			bossFrozen = true;
		}

		// Заклинание Мистическое Исцеление
		static void MysticalHealing()
		{
			Console.WriteLine("Вы провели Мистическое Исцеление, восстанавливая 200 здоровья и нанося 50 урона боссу. Босс не атакует.");
			playerHealth += 200;
			bossHealth -= 50;
			interdimensionalRiftActive = true;
		}

		// Заклинание Пропустить ход
		static void SkipTurn()
		{
			Console.WriteLine("Вы пропускаете ход.");
		}

		// Атака босса
		static void BossAttack()
		{
			if (!interdimensionalRiftActive)
			{
				if (!icyShacklesActive)
				{
					if (!bossFrozen)
					{
						int bossDamage = 150;

						if (shadowShieldActive)
						{
							Console.WriteLine("Босс атакует вас, но урон уменьшен на 50% из-за Теневого Щита.");
							bossDamage /= 2;
							shadowShieldActive = false;
						}
						else
						{
							Console.WriteLine($"Босс атакует вас и наносит {bossDamage} урона.");
						}

						playerHealth -= bossDamage;
					}
					else
					{
						Console.WriteLine("Босс не атакует из-за эффекта Ледяных Оков.");
						bossFrozen = false;
					}
				}
				else
				{
					Console.WriteLine("Босс не атакует из-за эффекта Ледяных Оков.");
					icyShacklesActive = false;
				}
			}
			else
			{
				Console.WriteLine("Босс не атакует из-за эффекта заклинания.");
			}
			interdimensionalRiftActive = false;
		}
	}
}