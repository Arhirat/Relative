using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Relative
{
	abstract class Object
	{
		public TimeSpace mParent;

		public abstract void draw(DrawInfo di, Object selectedLine);
		public abstract bool select(Vec pos);

		public abstract String getParam();
		public abstract void setParam(String value);

	}
}
