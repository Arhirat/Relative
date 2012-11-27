using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace Relative
{
	struct DrawInfo
	{
		public int mWidth;
		public int mHeight;
		public Graphics mGraphics;

		public DrawInfo(int w, int h, Graphics g)
		{
			mWidth = w;
			mHeight = h;
			mGraphics = g;
		}


		public void drawEllipse(Pen pen, Vec pos, double width, double height)
		{
			mGraphics.DrawEllipse(pen, (float)(mWidth + pos.mX - width / 2), (float)(mHeight + pos.mY - height / 2), (float)width, (float)height);
		}
		public void drawLine(Pen pen, Vec pos0, Vec pos1)
		{
			mGraphics.DrawLine(pen,
				(float)(mWidth + pos0.mX),
				(float)(mHeight + pos0.mY),
				(float)(mWidth + pos1.mX),
				(float)(mHeight + pos1.mY));
		}
		public void drawText(String text, Vec pos)
		{
			mGraphics.DrawString(text,
				new Font("Arial", 16),
				new SolidBrush(Color.Black),
				new PointF(
					(float)(mWidth + pos.mX),
					(float)(mHeight + pos.mY)));
		}

	}
}
