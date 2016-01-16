using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinBowling
{
	public class Frame
	{
		int _numberOfBallsRolled;
		int[] _rollScores = new int[3];

		public bool IsLastRoll { get; set; }

		public bool IsStrike {
			get {
				return false;
			}
		}

		public bool IsSpare {
			get
			{
				return false;
			}
		}

		public bool IsOpen {
			get
			{
				return false;
			}
		}

		public bool IsComplete {
			get
			{
				return false;
			}
		}

		public void UpdateScore(int rollScore)
		{

		}

		private int _score;
		public int Score
		{
			get {
				_score = _rollScores.Sum();
				return _score;

			}
			set {
				_score = value;
				_rollScores[_numberOfBallsRolled] = _score;
			}
		}




		public void BonusPoint(int rollScore)
		{

		}



	}
}
