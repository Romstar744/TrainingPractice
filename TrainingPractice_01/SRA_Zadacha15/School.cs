using System;
using System.Collections.Generic;

namespace SRA_Zadacha15
{
	internal class School
	{
		private TFish head;
		private TFish tail;

		public void AddFish(TFish fish)
		{
			if (head == null)
			{
				head = tail = fish;
			}
			else
			{
				tail.NextFish = fish;
				tail = fish;
			}
		}

		public void RemoveFish(TFish fishToRemove)
		{
			TFish current = head;
			TFish previous = null;

			while (current != null)
			{
				if (current == fishToRemove)
				{
					if (previous != null)
					{
						previous.NextFish = current.NextFish;
						if (current == tail)
						{
							tail = previous;
						}
					}
					else
					{
						head = current.NextFish;
						if (head == null)
						{
							tail = null;
						}
					}

					Console.WriteLine("Fish removed from the school.");
					return;
				}

				previous = current;
				current = current.NextFish;
			}

			Console.WriteLine("Fish not found in the school.");
		}

		public void Draw()
		{
			TFish current = head;
			while (current != null)
			{
				current.Draw();
				current = current.NextFish;
			}
		}

		public List<TFish> GetFishList()
		{
			// Возвращаем список рыб в стае
			List<TFish> fishList = new List<TFish>();
			TFish current = head;

			while (current != null)
			{
				fishList.Add(current);
				current = current.NextFish;
			}

			return fishList;
		}

		public TFish GetHead()
		{
			return head;
		}
	}
}
