using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Relative
{
	class Point : Object
	{
		Vec mPos;

		public Point(Vec pos)
		{
			mPos = pos;
		}

		override public void draw(DrawInfo di, Object selected)
		{
			Pen pen = new Pen(Color.Black);
			if (this == selected)
				pen = new Pen(Color.Blue);

			di.drawEllipse(pen,
				mParent.getScreenFromWorld(mPos), 10, 10);
		}

		override public bool select(Vec pos)
		{
			Vec delta = pos.minus(mPos);
			return Math.Sqrt(delta.mX * delta.mX + delta.mY * delta.mY) < 5/mParent.mZoom;
		}

		override public String getParam()
		{
			return null;
		}
		override public void setParam(String value)
		{
		}

	}
}
