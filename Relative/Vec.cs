using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Relative
{
	struct Vec
	{
		public double mX;
		public double mY;

		public Vec(double x, double y)
		{
			mX = x;
			mY = y;
		}

		public Vec plus(Vec vec)
		{
			return new Vec(mX + vec.mX, mY + vec.mY);
		}
		public Vec minus(Vec vec)
		{
			return new Vec(mX - vec.mX, mY - vec.mY);
		}
		public Vec mult(double a)
		{
			return new Vec(mX * a, mY * a);
		}
		public Vec scale(Vec vec)
		{
			return new Vec(vec.mX * mX, vec.mY * mY);
		}
		public Vec scaleBack(Vec vec)
		{
			return new Vec(vec.mX / mX, vec.mY / mY);
		}

		public void lightCorect()
		{
			double len = (Math.Abs(mX) + Math.Abs(mY)) / 2;
			mX = len * Math.Sign(mX);
			mY = len * Math.Sign(mY);
		}

		public double dot(Vec vec)
		{
			return mX * vec.mX + mY * vec.mY;
		}
		public Vec perp()
		{ 
			return new Vec(mY, -mX);
		}

		public double lenghtSquare()
		{
			return mX * mX + mY * mY;
		}
	}
}

