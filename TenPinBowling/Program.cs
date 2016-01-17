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

			game.Roll(10);

			game.Roll(8);
			game.Roll(2);

			game.Roll(3);

			Console.WriteLine(game.Score());
			
			Console.ReadLine();
		}
	}
}
