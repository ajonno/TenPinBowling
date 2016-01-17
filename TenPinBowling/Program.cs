using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinBowling
{
	class Program
	{
		static void Main(string[] args)
		{
			var game = new Game();

			for (int roll = 0; roll < 22; roll++)
			{
				game.Roll(10);
			}

			Console.WriteLine($"Game Score: {game.Score()}");

			Console.ReadLine();
		}
	}
}
