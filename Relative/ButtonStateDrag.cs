using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Relative
{
	class ButtonStateDrag : ButtonState
	{

		MouseButtons mButton;
		public ButtonStateVar.Event mOnMove;
		public ButtonStateVar.Event mOnEndDrag;
		public ButtonStateVar.EventPaint mOnPaint;
		Vec mPos;

		public ButtonStateDrag(
			ButtonStateVar stateVar, 
			MouseButtons button, 
			ButtonStateVar.Event onMove, 
			ButtonStateVar.Event onEndDrag,
			ButtonStateVar.EventPaint onPaint)
			: base(stateVar)
		{
			mButton = button;
			mOnMove = onMove;
			mOnEndDrag = onEndDrag;
			mOnPaint = onPaint;
		}

		override public State onDown(Vec pos, MouseButtons mb)
		{
			return this;
		}
		override public State onUp(Vec pos, MouseButtons mb)
		{
			if (mb == mButton)
			{
				if (mOnEndDrag != null)
					mOnEndDrag(pos);
				return new ButtonStateNone(mStateVar, mb);
			}


			return this;
		}
		override public State onMove(Vec pos)
		{
			mPos = pos;
			mOnMove(pos);
			mStateVar.logState("drag ", pos);
			return this;
		}
		override public void onPaint(DrawInfo e)
		{
			if (mOnPaint != null)
				mOnPaint(mPos, e);
		}

	}
}
