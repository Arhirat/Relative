using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Windows.Forms;

namespace Relative
{
	abstract class StateVar
	{
		public State mState;

		public StateVar()
		{
		}

		public void onDown(Vec pos, MouseButtons mb)
		{
			State s = mState.onDown(pos, mb);
			mState = s;
		}
		public void onUp(Vec pos, MouseButtons mb)
		{
			State s = mState.onUp(pos, mb);
			mState = s;
		}
		public void onMove(Vec pos)
		{
			State s = mState.onMove(pos);
			mState = s;
		}
		public void onPaint(DrawInfo e)
		{
			mState.onPaint(e);
		}

	}
}
