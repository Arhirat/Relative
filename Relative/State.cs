using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;


namespace Relative
{
	interface State
	{
		State onDown(Vec pos, MouseButtons mb);
		State onUp(Vec pos, MouseButtons mb);
		State onMove(Vec pos);
		void onPaint(DrawInfo e);
	}
}
