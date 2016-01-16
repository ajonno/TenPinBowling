using System.Collections.Generic;
using System.Linq;

namespace TenPinBowling
{
	public class Game
	{
		private List<Frame> _frames;
		private Frame _frame;
		

		public Game()
		{
			_frames = new List<Frame>();
			_frame = new Frame();
			_frames.Add(_frame);
		}

		public void Roll(int numberOfPinsHit)
		{
			if (_frames.Count < 10)
				_frame.AddScore = numberOfPinsHit;

			if (_frames.Count > 1)
				LookBack(numberOfPinsHit);

			if (_frame.IsLastRoll)
				IncrementFrame();


		}

		private void IncrementFrame()
		{
			if (_frames.Count < 10 && _frame.IsLastRoll)
			{
				_frame = null;
				_frame = new Frame();
				_frames.Add(_frame);
			}

			if (_frames.Count == 10 && _frame.IsComplete)
				System.Console.WriteLine("Thank you for playing."); 
		}

		public int GetFrameNumber {
			get
			{
				return _frames.Count;
			}
		}

		private void LookBack(int numberOfPinsHit)
		{
			//linq query to get any frames that have open status
			var incompleteFrames = from frame in _frames
									where !frame.IsComplete && (frame.IsSpare || frame.IsStrike)
									select frame;

			foreach (var frame in incompleteFrames)
			{
				if (frame.IsComplete == false)
					frame.AddScore = numberOfPinsHit;
			}


		}

		private int _score;
		public int Score
		{
			get {
				//var total = 0;
				foreach (var frame in _frames)
				{
					_score += frame.AddScore;
				}
				return _score;
			}
			set {
				_score = value;
			}
		}



	}
}
