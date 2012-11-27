using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Relative
{
	class ButtonStateNone : ButtonState, State
	{
		MouseButtons mButton;

		public ButtonStateNone(ButtonStateVar stateVar, MouseButtons button) : base(stateVar)
		{
			mButton = button;
		}

		override public State onDown(Vec pos, MouseButtons mb)
		{
			if (mb == mButton)
				return new ButtonStateDown(mStateVar, mb, pos);
				
			return this;
		}
		override public State onMove(Vec pos)
		{
			mStateVar.logState("none ", pos);
			return this;
		}

	}
}
