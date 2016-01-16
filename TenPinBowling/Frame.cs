using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinBowling
{
	public class Frame
	{
		int _numberOfBallsRolled = 0;
		int[] _rollScores = new int[3];

		public bool IsLastRoll {
			get
			{
				return (_numberOfBallsRolled == 2 || IsStrike);
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
				return ( (_rollScores[0] + _rollScores[1] == 10) && !IsStrike);
			}
		}

		public bool IsOpen {
			get
			{
				//return (_rollScores[0] + _rollScores[1] < 10);
				return (_numberOfBallsRolled == 2 && (_rollScores[0] + _rollScores[1] < 10));
			}
		}

		private bool _isComplete;
		public bool IsComplete {
			get
			{
				//if ( (IsStrike || IsSpare) && _numberOfBallsRolled == 3)
				if ((IsStrike || IsSpare) && _numberOfBallsRolled == 3)
						_isComplete = true;
				else if (IsOpen && IsLastRoll)
					_isComplete = true;
				if (_numberOfBallsRolled == 3)
					_isComplete = true;

				return _isComplete;
			}
		}

		private int myVar;

		public int MyProperty
		{
			get { return myVar; }
			set { myVar = value; }
		}


		private int _addScore;
		public int AddScore
		{
			get {
				_addScore = _rollScores.Sum();
				return _addScore;
			}
			set {
				_addScore = value;
				_rollScores[_numberOfBallsRolled] = _addScore;
				_numberOfBallsRolled++;
			}
		}
	}
}
