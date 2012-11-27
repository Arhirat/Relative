using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Relative
{
	class ButtonStateVar : StateVar
	{

		public delegate void Event(Vec pos);
		public delegate void EventPaint(Vec pos, DrawInfo e);
		public delegate DragRezult DragRequest(Vec pos);
		public struct DragRezult
		{
			public enum Rezult { Nodrag, Drag };
			public Rezult mRezult;
			public Event mOnDrag;
			public Event mOnEndDrag;
			public EventPaint mOnPaint;

			public DragRezult(bool e)
			{
				mRezult = Rezult.Nodrag;
				mOnEndDrag = null;
				mOnDrag = null;
				mOnPaint = null;
			}
			public DragRezult(Event onDrag, Event onEndDrag, EventPaint onPaint)
			{
				mRezult = Rezult.Drag;
				mOnDrag = onDrag;
				mOnEndDrag = onEndDrag;
				mOnPaint = onPaint;
			}
		}


		Label mLabel;
		public Event mOnClick;
		public DragRequest mOnStartDrag;

		public void logState(String state, Vec pos)
		{
			if (mLabel != null)
				mLabel.Text = state + " " + pos.mX + "x" + pos.mY;
		}

		public ButtonStateVar(MouseButtons button, Label label)
		{
			mLabel = label;
			mState = new ButtonStateNone(this, button);
		}
	}
}
