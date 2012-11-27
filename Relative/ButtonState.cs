using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Relative
{
	class ButtonState : State 
	{
		public ButtonStateVar mStateVar;

		public ButtonState(ButtonStateVar stateVar)
		{
			mStateVar = stateVar;
		}

		public virtual State onDown(Vec pos, MouseButtons mb)
		{
			return this;
		}
		public virtual State onUp(Vec pos, MouseButtons mb)
		{
			return this;
		}
		public virtual State onMove(Vec pos)
		{
			return this;
		}
		public virtual void onPaint(DrawInfo e)
		{ 
		}

	}
}
