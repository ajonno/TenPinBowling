using System.Collections.Generic;

namespace TenPinBowling
{
	public class Game
	{
		List<Frame> _frames;
		Frame _frame;

		public Game()
		{
			_frames = new List<Frame>();
		}

		public void Roll(int numberOfPinsHit)
		{
			_frame = new Frame();
			_frames.Add(_frame);

			_frame.Score = numberOfPinsHit;
		}

		private void LookBack()
		{

		}

		private int _gameScore;
		public int Score
		{
			get {
				//var total = 0;
				foreach (var frame in _frames)
				{
					_gameScore += frame.Score;
				}
				return _gameScore;
			}
			set {
				_gameScore = value;
			}
		}



	}
}
