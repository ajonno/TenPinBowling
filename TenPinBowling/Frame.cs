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

		public bool IsLastRoll {
			get
			{
				return (_numberOfBallsRolled == 2);
			}
		}

		public bool IsStrike {
			get {
				return _rollScores[0] == 10;
			}
		}

		public bool IsSpare {
			get
			{
				return (_rollScores[0] + _rollScores[1] == 10);
			}
		}

		public bool IsOpen {
			get
			{
				return (_rollScores[0] + _rollScores[1] < 10);
			}
		}

		public bool IsComplete {
			get
			{
				bool isComplete = false;
				if (IsStrike || IsSpare && _numberOfBallsRolled == 3)
					isComplete = true;
				else if (IsOpen && IsLastRoll)
					isComplete = true;
				else
					isComplete = false;

				return isComplete;
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
				_numberOfBallsRolled++;
			}
		}



	}
}
