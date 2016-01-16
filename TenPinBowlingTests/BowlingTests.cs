
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TenPinBowling;

namespace TenPinBowlingTests
{
	[TestClass]
	public class BowlingTests
	{

		Game game = new Game();

		private void RollManyTimes(int numberOfRolls, int numOfPinsHitEachRoll)
		{
			for (int i = 0; i < numberOfRolls; i++)
			{
				game.Roll(numOfPinsHitEachRoll);
			}
		}

		[TestMethod]
		public void DidntHitASinglePinTheWholeGame()
		{
			RollManyTimes(10, 0);
		}

		[TestMethod]
		public void SingleRollShouldReturn_5()
		{
			game.Roll(5);

			Assert.AreEqual(5, game.Score);
		}
	}
}
