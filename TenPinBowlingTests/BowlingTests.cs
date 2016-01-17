
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
		public void SingleRollShouldReturn_5()
		{
			game.Roll(5);

			Assert.AreEqual(5, game.Score());
		}

		[TestMethod]
		public void DidntHitASinglePinTheWholeGame()
		{
			RollManyTimes(10, 0);
			Assert.AreEqual(0, game.Score());
		}


		[TestMethod]
		public void RollA_2_ThenA_7_IsOpen()
		{
			game.Roll(2);
			game.Roll(7);

			Assert.AreEqual(9, game.Score());

			var frame = new Frame();
			frame.AddScore = 2;
			frame.AddScore = 7;
			Assert.AreEqual(true, frame.IsOpen);
		}

		[TestMethod]
		public void RollATenIsAStrike()
		{
			var frame = new Frame();
			frame.AddScore = 10;

			game.Roll(10);

			Assert.AreEqual(10, game.Score());
			Assert.AreEqual(true, frame.IsStrike);
		}


		[TestMethod]
		public void RollA_6_ThenA_4_IsASpare()
		{
			game.Roll(6);
			game.Roll(4);

			Assert.AreEqual(10, game.Score());

			var frame = new Frame();
			frame.AddScore = 6;
			frame.AddScore = 4;

			Assert.AreEqual(true, frame.IsSpare);
			Assert.AreEqual(true, frame.IsLastRoll);
			Assert.AreEqual(false, frame.IsComplete);
		}

		[TestMethod]
		public void RollA_6_Then_4_Then_2_CompletesTheFrameScore()
		{
			var frame = new Frame();
			frame.AddScore = 6;
			frame.AddScore = 4;
			frame.AddScore = 2;

			Assert.AreEqual(true, frame.IsComplete);
			Assert.AreEqual(12, frame.AddScore);
		}

		[TestMethod]
		public void RollA_STRIKE_Then_4_Then_2_CompletesTheFrameScore()
		{
			var frame = new Frame();
			frame.AddScore = 10;
			frame.AddScore = 4;
			frame.AddScore = 2;

			Assert.AreEqual(true, frame.IsStrike);
			Assert.AreEqual(true, frame.IsComplete);
			Assert.AreEqual(16, frame.AddScore);
		}

		[TestMethod]
		public void RollA_STRIKE_then_STRIKE_then_2()
		{
			var frame = new Frame();
			frame.AddScore = 10;
			frame.AddScore = 10;
			frame.AddScore = 2;

			Assert.AreEqual(true, frame.IsStrike);
			Assert.AreEqual(true, frame.IsComplete);
			Assert.AreEqual(22, frame.AddScore);
		}

		[TestMethod]
		public void CheckScore_Roll_STRIKE_6_2()
		{
			game.Roll(10);

			game.Roll(6);
			game.Roll(2);

			Assert.AreEqual(26, game.Score());
		}

		[TestMethod]
		public void CheckScore_Roll_STRIKE_STRIKE_6_4_3_2()
		{
			game.Roll(10);

			game.Roll(10);

			game.Roll(6);
			game.Roll(4);

			game.Roll(3);
			game.Roll(2);

			Assert.AreEqual(64, game.Score());
		}

		[TestMethod]
		public void Every_Roll_Is_A_2()
		{
			RollManyTimes(20, 2);
			Assert.AreEqual(40, game.Score());
		}

		[TestMethod]
		public void PerfectScoreIs300()
		{
			RollManyTimes(12, 10);

			Assert.AreEqual(300, game.Score());
		}
	}

}
