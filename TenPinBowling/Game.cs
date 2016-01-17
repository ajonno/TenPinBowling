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
			IncrementFrame();

			if (_frames.Count <= 10)
			{
				_frame.AddScore = numberOfPinsHit;
			}

			if (_frames.Count > 1)
				LookBack(numberOfPinsHit);
		}

		private void IncrementFrame()
		{
			if (_frames.Count <= 10 && _frame.IsLastRoll)
			{
				_frame = new Frame();
				_frames.Add(_frame);
			}
		}

		private int GetFrameIndex {
			get
			{
				return _frames.Count - 1;
			}
		}

		private void LookBack(int numberOfPinsHit)
		{
			//get any PREVIOUS strike or spare Frame(s), that should be updated with this rolls num. pins 
			var bonusFrames = from frame in _frames
							  where !frame.IsComplete 
							  && (frame.IsSpare || frame.IsStrike) && IsPreviousFrame(frame)
							  select frame;

			foreach (var frame in bonusFrames)
			{
				if (frame.IsComplete == false)
					frame.AddScore = numberOfPinsHit;
			}
		}

		private bool IsPreviousFrame(Frame frame) {
			return _frames.IndexOf(frame) < _frames.Count - 1;
		}

		public int Score()
		{
			int score = 0;
			foreach (var frame in _frames)
			{
				score += frame.AddScore;
			}
			return score;
		}
	}
}
