using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace Relative
{
	class TimeSpace
	{
		List<Object> mObjectList;
		public Vec mCenter;
		public Vec mScale;
		public Mat mMat;
		public double mSpeed;
		public double mC;
		public double mZoom;
		public bool mEuklide;

		public TimeSpace()
		{
			mEuklide = false;
			mObjectList = new List<Object>();
			mCenter = new Vec(0, 0);
			mSpeed = 0;
			mZoom = 1;
			mC = 1;

			updateMat();
			updateScale();
		}

		void updateMat()
		{
			mMat = new Mat(mSpeed, mEuklide);
		}
		void updateScale()
		{
			mScale = new Vec(mZoom * mC, mZoom);
		}

		public void setEuklide(bool euklide)
		{
			mEuklide = euklide;
			mC = 1;
			updateMat();
			updateScale();
		}

		public void add(Object obj)
		{
			mObjectList.Add(obj);
			obj.mParent = this;
		}

		public void delete(Object obj)
		{
			mObjectList.Remove(obj);
		}

		public void draw(DrawInfo di, Object selectedLine)
		{
			foreach (Object point in mObjectList)
				point.draw(di, selectedLine);
		}

		public void setCenter(Vec vec)
		{
			mCenter = vec;
		}

		public void setSpeed(double speed)
		{
			mSpeed = speed;
			updateMat();
		}

		public double speedLeft()
		{
			mSpeed -= 0.1f / mC;
			updateMat();
			return mSpeed;
		}
		public double speedRight()
		{
			mSpeed += 0.1f / mC;
			updateMat();
			return mSpeed;
		}

		public void setC(double c)
		{
			mC = c;
			updateScale();
		}

		public void zoomChange(int c)
		{
			mZoom *= Math.Pow(1.05, c/10);
			updateScale();
		}

		public void clear()
		{
			mObjectList.Clear();
		}

		public Object selectObject(Vec screen)
		{
			Vec world = getWorldFromScreen(screen);
			foreach (Object obj in mObjectList)
				if (obj.select(world))
					return obj;
			return null;
		}

		public double getInvariant(Vec p0, Vec p1)
		{
			Vec delta = p0.minus(p1);
			if (mEuklide)
				return delta.mX * delta.mX + delta.mY * delta.mY;
			else
				return -delta.mX * delta.mX + delta.mY * delta.mY;
		}


		public Vec getScreenFromWorld(Vec world)
		{
//			screen = scale * (mat * (world - center))
			return mScale.scale(mMat.mult(world.minus(mCenter)));
		}
		public Vec getWorldFromScreen(Vec screen)
		{
//			world = (mat-1) * (scale-1 * screen) + center
			return mMat.multBack(mScale.scaleBack(screen)).plus(mCenter);
		}
		public Vec getCenterFromScreenAndWorld(Vec screen, Vec world)
		{
//			center = world - (mat-1) * (scale-1 * screen)
			return world.minus(mMat.multBack(mScale.scaleBack(screen)));
		}

	}
}
