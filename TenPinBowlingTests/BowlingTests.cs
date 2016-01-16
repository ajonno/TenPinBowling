
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

		[TestMethod]
		public void RollA_2_ThenA_7_IsOpen()
		{
			game.Roll(2);
			game.Roll(7);

			Assert.AreEqual(9, game.Score);

			var frame = new Frame();
			frame.Score = 2;
			frame.Score = 7;
			Assert.AreEqual(true, frame.IsOpen);
			Assert.AreEqual(true, frame.IsLastRoll);
			Assert.AreEqual(true, frame.IsComplete);
		}

		[TestMethod]
		public void RollATenIsAStrike()
		{
			var frame = new Frame();
			frame.Score = 10;

			game.Roll(10);

			Assert.AreEqual(10, game.Score);
			Assert.AreEqual(true, frame.IsStrike);
		}


		[TestMethod]
		public void RollA_6_ThenA_4_IsASpare()
		{
			game.Roll(6);
			game.Roll(4);

			Assert.AreEqual(10, game.Score);

			var frame = new Frame();
			frame.Score = 6;
			frame.Score = 4;

			Assert.AreEqual(true, frame.IsSpare);
			Assert.AreEqual(true, frame.IsLastRoll);
			Assert.AreEqual(false, frame.IsComplete);
		}

		[TestMethod]
		public void RollA_6_Then_4_Then_2_CompletesTheFrameScore()
		{
			var frame = new Frame();
			frame.Score = 6;
			frame.Score = 4;
			frame.Score = 2;

			Assert.AreEqual(true, frame.IsSpare);
			Assert.AreEqual(true, frame.IsComplete);
			Assert.AreEqual(12, frame.Score);
		}

	}

}
