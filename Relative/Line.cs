using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace Relative
{
	class Line : Object
	{
		public Vec mPos0;
		public Vec mPos1;
		Color mColor;
		public int mSeg;

		public Line(Vec pos0, Vec pos1, Color color)
		{
			mSeg = 3;
			mPos0 = pos0;
			mPos1 = pos1;
			mColor = color;
		}
		
		override public void draw(DrawInfo di, Object selected)
		{
			Pen pen = new Pen(mColor);
			if (this == selected)
				pen = new Pen(Color.Blue);

			di.drawEllipse(pen,
				mParent.getScreenFromWorld(mPos0), 10, 10);
			di.drawEllipse(pen,
				mParent.getScreenFromWorld(mPos1), 10, 10);
			di.drawLine(pen, 
				mParent.getScreenFromWorld(mPos0), 
				mParent.getScreenFromWorld(mPos1));
			for (int i = 0; i < mSeg - 1; i++)
			{ 
				double alpha = (double)(i+1) / (mSeg);
				Vec pos = mPos0.mult(alpha).plus(mPos1.mult(1 - alpha));
				di.drawEllipse(pen, mParent.getScreenFromWorld(pos), 5, 5);
			}
		}

		override public bool select(Vec pos)
		{
			Vec delta = pos.minus(mPos0);
			Vec len = mPos1.minus(mPos0);
			double proj1 = delta.dot(len) / len.lenghtSquare();
			double proj2 = delta.perp().dot(len) / len.lenghtSquare();


			return proj1 > 0 && proj1 < 1 && proj2 > -0.05 && proj2 < 0.05;
		}

		override public String getParam()
		{
			return mSeg.ToString();
		}
		override public void setParam(String value)
		{
			mSeg = int.Parse(value);
		}

	}
}
