using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Relative
{
	class ButtonStateDown : ButtonState
	{
		Vec mPos;
		MouseButtons mButton;
		public ButtonStateDown(ButtonStateVar stateVar, MouseButtons button, Vec pos) : base(stateVar)
		{
			mPos = pos;
			mButton = button;
		}

		override public State onUp(Vec pos, MouseButtons mb)
		{
			if (mb == mButton)
			{
				if(mStateVar.mOnClick != null)
					mStateVar.mOnClick(pos);
				return new ButtonStateNone(mStateVar, mb);
			}


			return this;
		}
		override public State onMove(Vec pos)
		{
			if (mStateVar.mOnStartDrag != null)
			{
				ButtonStateVar.DragRezult rezult = mStateVar.mOnStartDrag(mPos);
				switch (rezult.mRezult)
				{
					case ButtonStateVar.DragRezult.Rezult.Nodrag:
						return new ButtonStateNone(mStateVar, mButton);

					case ButtonStateVar.DragRezult.Rezult.Drag:
						return new ButtonStateDrag(
							mStateVar, 
							mButton, 
							rezult.mOnDrag, 
							rezult.mOnEndDrag, 
							rezult.mOnPaint);
				}
			}
			else
			{
				return new ButtonStateNone(mStateVar, mButton);
			}

			mStateVar.logState("down ", pos);
			return this;
		}

	}
}
