using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Relative
{
	class Mouse : State
	{
		public delegate void WheelEvent(int i);

		public WheelEvent mOnWheelMove;
		public Vec mShift;
		public Vec mPos;
		public ButtonStateVar mLeft;
		public ButtonStateVar mRight;

		public Mouse()
		{
			mShift = new Vec(0, 0);
			mPos = new Vec(0, 0);
		}

		public void onWheelMove(int wheel)
		{
			if (wheel != 0 && mOnWheelMove != null)
				mOnWheelMove(wheel);
		}
		public State onMove(Vec pos)
		{
			mPos = pos.minus(mShift);

			mLeft.onMove(mPos);
			mRight.onMove(mPos);

			return this;
		}
		public State onDown(Vec pos, MouseButtons button)
		{
			mPos = pos.minus(mShift);

			mLeft.onDown(mPos, button);
			mRight.onDown(mPos, button);

			return this;
		}
		public State onUp(Vec pos, MouseButtons button)
		{
			mPos = pos.minus(mShift);

			mLeft.onUp(mPos, button);
			mRight.onUp(mPos, button);

			return this;
		}
		public void onPaint(DrawInfo e)
		{
			mLeft.onPaint(e);
			mRight.onPaint(e);
		}
	}
}
