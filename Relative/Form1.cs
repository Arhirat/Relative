using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Relative
{
	public partial class Form1 : Form
	{
		enum Insert {None, Point, Line, LineLight, Invariant};

		Mouse mMouse;
		TimeSpace mTimeSpace;
		Insert mInsert;
		Object mSelectedObject;
		const int GRID = 40;

		public Form1()
		{
			InitializeComponent();
			this.DoubleBuffered = true;
			this.MouseWheel += Form1_MouseWheel;

			mInsert = Insert.None;
			mTimeSpace = new TimeSpace();

			mMouse = new Mouse();
			initMouseShift();
			mMouse.mOnWheelMove = onWheelMove;
			mMouse.mLeft = new ButtonStateVar(MouseButtons.Left, null);
			mMouse.mLeft.mOnClick = onClickL;
			mMouse.mLeft.mOnStartDrag = onStartDragL;
			mMouse.mRight = new ButtonStateVar(MouseButtons.Right, null);
			mMouse.mRight.mOnStartDrag = onStartDragR;
		}
		void initMouseShift()
		{
			mMouse.mShift = new Vec(this.Width / 2, this.Height / 2);
		}

		void onWheelMove(int wheel)
		{
			mTimeSpace.zoomChange(wheel);
			Invalidate();
		}

		void onClickL(Vec pos)
		{
			switch (mInsert)
			{
				case Insert.Point:
					insert(new Point(mTimeSpace.getWorldFromScreen(pos)));
					mInsert = Insert.None;
					break;
				default:
					mSelectedObject = mTimeSpace.selectObject(pos);
					updateParam();
					Invalidate();
					break;
			}
		}

		void insert(Object obj)
		{
			mSelectedObject = obj;
			mTimeSpace.add(obj);
			updateParam();
			Invalidate();
		}

		void updateParam()
		{
			mSegTextBox.Visible = mSelectedObject != null;
			if (mSelectedObject == null)
				mSegTextBox.Visible = false;
			else
			{
				String param = mSelectedObject.getParam();
				if (param == null)
					mSegTextBox.Visible = false;
				else
				{
					mSegTextBox.Text = param;
					mSegTextBox.Visible = true;
				}
			}
		}


		ButtonStateVar.DragRezult onStartDragR(Vec posScreen)
		{
			Vec posWorld = mTimeSpace.getWorldFromScreen(posScreen);

			return new ButtonStateVar.DragRezult(
				delegate(Vec posScreenNew)
				{
					mTimeSpace.setCenter(
						mTimeSpace.getCenterFromScreenAndWorld(posScreenNew, posWorld));
					Invalidate();
				}, 
				null, 
				null);
		}
		ButtonStateVar.DragRezult onStartDragL(Vec posScreen)
		{
			switch (mInsert)
			{
				case Insert.Line:
					{
						Vec world = mTimeSpace.getWorldFromScreen(posScreen);
						Line line = new Line(world, world.plus(new Vec(20, 20)), Color.Black);
						insert(line);
						mInsert = Insert.None;

						return new ButtonStateVar.DragRezult(
							delegate(Vec posScreenNew)
							{
								Vec world2 = mTimeSpace.getWorldFromScreen(posScreenNew);
								line.mPos1 = world2;
								Invalidate();
							},
							null,
							null);
						
					}
				case Insert.LineLight:
					{
						Vec world = mTimeSpace.getWorldFromScreen(posScreen);
						Line line = new Line(world, world.plus(new Vec(20, 20)), Color.Orange);
						mTimeSpace.add(line);
						mInsert = Insert.None;
						Invalidate();

						return new ButtonStateVar.DragRezult(
							delegate(Vec posScreenNew)
							{
								Vec delta = posScreenNew.minus(posScreen);
								delta.lightCorect();
								Vec world2 = mTimeSpace.getWorldFromScreen(posScreen.plus(delta));
								line.mPos1 = world2;
								Invalidate();
							},
							null, 
							null);
					}
				case Insert.Invariant:
					{
						mInsert = Insert.None;
						Invalidate();

						return new ButtonStateVar.DragRezult(
							delegate(Vec posScreenNew)
							{
								Invalidate();
							},
							delegate(Vec posScreenNew)
							{
								Invalidate();
							},
							delegate(Vec posScreenNew, DrawInfo di)
							{
								Pen pen = new Pen(Color.LimeGreen);
								pen.Width = 1;
								di.drawLine(pen, posScreen, posScreenNew);

								Vec world = mTimeSpace.getWorldFromScreen(posScreen);
								Vec worldNew = mTimeSpace.getWorldFromScreen(posScreenNew);
								double invariant = mTimeSpace.getInvariant(world, worldNew) / (GRID*GRID);
								di.drawText(invariant.ToString(), posScreenNew.plus(new Vec(10, -10)));
							});
					}
				default:
					return new ButtonStateVar.DragRezult(true);
			}
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			int width = this.Width;
			int height = this.Height;
			g.Clear(Color.White);

			Pen pen = new Pen(Color.LightGray);
			pen.Width = 2;
			g.DrawLine(pen, 0, height / 2, width, height / 2);
			g.DrawLine(pen, width / 2, 0, width / 2, height);

			double zoom = mTimeSpace.mZoom;
			while (zoom < 0.5)
				zoom *= 10;
			while (zoom > 5)
				zoom /= 10;
			double grid = GRID * zoom;

			if (mGridCheckBox.Checked)
			{
				pen.Width = 1;
				int w = (int)(width / grid);
				for (int i = 0; i < w; i++)
					g.DrawLine(pen,
						(float)(width / 2 + (i - w / 2) * grid), 0,
						(float)(width / 2 + (i - w / 2) * grid), height);

				int h = (int)(height / grid);
				for (int i = 0; i < w; i++)
					g.DrawLine(pen,
						0,     (float)(height / 2 + (i - h / 2) * grid),
						width, (float)(height / 2 + (i - h / 2) * grid));
			}

			if (mConeCheckBox.Checked)
			{
				Pen pen2 = new Pen(Color.Yellow);
				g.DrawLine(pen2,
					width / 2 - (float)(height / 2 * mTimeSpace.mC), height, 
					width / 2 + (float)(height / 2 * mTimeSpace.mC), 0);
				g.DrawLine(pen2,
					width / 2 - (float)(height / 2 * mTimeSpace.mC), 0,
					width / 2 + (float)(height / 2 * mTimeSpace.mC), height);
			}


			mTimeSpace.draw(new DrawInfo(width/2, height/2, g), mSelectedObject);
			mMouse.onPaint(new DrawInfo(width / 2, height / 2, g));

		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			mMouse.onDown(new Vec(e.X, e.Y), e.Button);
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			mMouse.onUp(new Vec(e.X, e.Y), e.Button);
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			mMouse.onMove(new Vec(e.X, e.Y));

			Vec world = mTimeSpace.getWorldFromScreen(mMouse.mPos);
			label1.Text = ((int)(world.mX*10/GRID)/10.0f) + " x " + -((int)(world.mY*10/GRID)/10.0f);

		}
		private void Form1_MouseWheel(object sender, MouseEventArgs e)
		{
			mMouse.onWheelMove(e.Delta);
			label1.Text = e.Delta.ToString();
		}

		private void mSpeedTextBox_Enter(object sender, EventArgs e)
		{

		}

		private void mSpeedTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 13)
			{
				try
				{
					mTimeSpace.setSpeed(float.Parse(mSpeedTextBox.Text));
					Invalidate();
				}
				catch (FormatException)
				{ }
			}
		}

		private void mSpeedLeftButton_Click(object sender, EventArgs e)
		{
			mSpeedTextBox.Text = mTimeSpace.speedLeft().ToString();
			Invalidate();
		}

		private void mSpeedRight_Click(object sender, EventArgs e)
		{
			mSpeedTextBox.Text = mTimeSpace.speedRight().ToString();
			Invalidate();
		}

		private void mConeCheckBox_Click(object sender, EventArgs e)
		{
			Invalidate();
		}

		private void mGridCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			Invalidate();
		}

		private void mPointButton_Click(object sender, EventArgs e)
		{
			mInsert = Insert.Point;
		}

		private void mLineButton_Click(object sender, EventArgs e)
		{
			mInsert = Insert.Line;
		}

		private void mLineLightButton_Click(object sender, EventArgs e)
		{
			mInsert = Insert.LineLight;
		}

		private void mCTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 13)
			{
				try
				{
					mTimeSpace.setC(float.Parse(mCTextBox.Text));
					Invalidate();
				}
				catch (FormatException)
				{ }
			}
		}

		private void mClearButton_Click(object sender, EventArgs e)
		{
			mTimeSpace.clear();
			mSelectedObject = null;
			updateParam();
			Invalidate();
		}

		private void mSegTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 13)
			{
				try
				{
					mSelectedObject.setParam(mSegTextBox.Text);
					Invalidate();
				}
				catch (FormatException)
				{ }
			}
		}

		private void mEuklideCheckBox_Click(object sender, EventArgs e)
		{
			mTimeSpace.setEuklide(mEuklideCheckBox.Checked);
			Invalidate();
		}

		private void mButtonInvariant_Click(object sender, EventArgs e)
		{
			mInsert = Insert.Invariant;
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			initMouseShift();
			Invalidate();
		}

		private void mButtonDelete_Click(object sender, EventArgs e)
		{
			mTimeSpace.delete(mSelectedObject);
			mSelectedObject = null;
			updateParam();
			Invalidate();
		}
	}
}
