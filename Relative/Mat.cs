using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Relative
{
	struct Mat
	{
		Vec mAxisX;
		Vec mAxisY;

		Mat(Vec ax, Vec ay)
		{
			mAxisX = ax;
			mAxisY = ay;
		}

		public Mat(double speed, bool euklide)
		{
			if (euklide)
			{
				double sin = Math.Sin(speed);
				double cos = Math.Cos(speed);

				mAxisX = new Vec(cos, sin);
				mAxisY = new Vec(-sin, cos);
			}
			else
			{
				double sh = Math.Sinh(speed);
				double ch = Math.Cosh(speed);

				mAxisX = new Vec(ch, -sh);
				mAxisY = new Vec(-sh, ch);
			}
		}

		public Vec mult(Vec pos)
		{
			return mAxisX.mult(pos.mX).plus(mAxisY.mult(pos.mY));
		}
		public Vec multBack(Vec pos)
		{
			return new Mat(
				new Vec(+mAxisX.mX, -mAxisX.mY),
				new Vec(-mAxisY.mX, +mAxisY.mY)).mult(pos);
		}
	}
}
