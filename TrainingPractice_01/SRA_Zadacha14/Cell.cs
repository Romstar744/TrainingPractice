using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRA_Zadacha14
{
	public class Cell
	{
		public enum CellState { Healthy, Infected, Immune, Recovered }
		public CellState State { get; set; }
		public int TimeSinceInfected { get; set; } = 0;

		public Cell(CellState initialState = CellState.Healthy)
		{
			State = initialState;
		}

		public void Update()
		{
			if (State == CellState.Infected)
			{
				TimeSinceInfected++;
				if (TimeSinceInfected > 6) 
				{
					State = CellState.Immune;
					TimeSinceInfected = 0; 
				}
			}
			else if (State == CellState.Immune)
			{
				TimeSinceInfected++;
				if (TimeSinceInfected > 4) 
				{
					State = CellState.Healthy;
					TimeSinceInfected = 0; 
				}
			}
		}

	}
}
