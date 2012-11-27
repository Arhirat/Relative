namespace Relative
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mSpeedTextBox = new System.Windows.Forms.TextBox();
			this.mSpeedLeftButton = new System.Windows.Forms.Button();
			this.mSpeedRight = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.mConeCheckBox = new System.Windows.Forms.CheckBox();
			this.mGridCheckBox = new System.Windows.Forms.CheckBox();
			this.mPointButton = new System.Windows.Forms.Button();
			this.mLineButton = new System.Windows.Forms.Button();
			this.mLineLightButton = new System.Windows.Forms.Button();
			this.mCTextBox = new System.Windows.Forms.TextBox();
			this.mClearButton = new System.Windows.Forms.Button();
			this.mSegTextBox = new System.Windows.Forms.TextBox();
			this.mEuklideCheckBox = new System.Windows.Forms.CheckBox();
			this.mButtonInvariant = new System.Windows.Forms.Button();
			this.mButtonDelete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// mSpeedTextBox
			// 
			this.mSpeedTextBox.Location = new System.Drawing.Point(41, 12);
			this.mSpeedTextBox.Name = "mSpeedTextBox";
			this.mSpeedTextBox.Size = new System.Drawing.Size(100, 20);
			this.mSpeedTextBox.TabIndex = 0;
			this.mSpeedTextBox.Text = "0";
			this.mSpeedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mSpeedTextBox_KeyUp);
			// 
			// mSpeedLeftButton
			// 
			this.mSpeedLeftButton.Location = new System.Drawing.Point(12, 12);
			this.mSpeedLeftButton.Name = "mSpeedLeftButton";
			this.mSpeedLeftButton.Size = new System.Drawing.Size(23, 23);
			this.mSpeedLeftButton.TabIndex = 1;
			this.mSpeedLeftButton.Text = "<";
			this.mSpeedLeftButton.UseVisualStyleBackColor = true;
			this.mSpeedLeftButton.Click += new System.EventHandler(this.mSpeedLeftButton_Click);
			// 
			// mSpeedRight
			// 
			this.mSpeedRight.Location = new System.Drawing.Point(151, 12);
			this.mSpeedRight.Name = "mSpeedRight";
			this.mSpeedRight.Size = new System.Drawing.Size(23, 23);
			this.mSpeedRight.TabIndex = 2;
			this.mSpeedRight.Text = ">";
			this.mSpeedRight.UseVisualStyleBackColor = true;
			this.mSpeedRight.Click += new System.EventHandler(this.mSpeedRight_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 421);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "label1";
			// 
			// mConeCheckBox
			// 
			this.mConeCheckBox.AutoSize = true;
			this.mConeCheckBox.Location = new System.Drawing.Point(12, 113);
			this.mConeCheckBox.Name = "mConeCheckBox";
			this.mConeCheckBox.Size = new System.Drawing.Size(105, 17);
			this.mConeCheckBox.TabIndex = 4;
			this.mConeCheckBox.Text = "световой конус";
			this.mConeCheckBox.UseVisualStyleBackColor = true;
			this.mConeCheckBox.Click += new System.EventHandler(this.mConeCheckBox_Click);
			// 
			// mGridCheckBox
			// 
			this.mGridCheckBox.AutoSize = true;
			this.mGridCheckBox.Location = new System.Drawing.Point(12, 136);
			this.mGridCheckBox.Name = "mGridCheckBox";
			this.mGridCheckBox.Size = new System.Drawing.Size(55, 17);
			this.mGridCheckBox.TabIndex = 5;
			this.mGridCheckBox.Text = "сетка";
			this.mGridCheckBox.UseVisualStyleBackColor = true;
			this.mGridCheckBox.CheckedChanged += new System.EventHandler(this.mGridCheckBox_CheckedChanged);
			// 
			// mPointButton
			// 
			this.mPointButton.Location = new System.Drawing.Point(12, 195);
			this.mPointButton.Name = "mPointButton";
			this.mPointButton.Size = new System.Drawing.Size(87, 23);
			this.mPointButton.TabIndex = 6;
			this.mPointButton.Text = "точка";
			this.mPointButton.UseVisualStyleBackColor = true;
			this.mPointButton.Click += new System.EventHandler(this.mPointButton_Click);
			// 
			// mLineButton
			// 
			this.mLineButton.Location = new System.Drawing.Point(12, 224);
			this.mLineButton.Name = "mLineButton";
			this.mLineButton.Size = new System.Drawing.Size(87, 23);
			this.mLineButton.TabIndex = 7;
			this.mLineButton.Text = "линия";
			this.mLineButton.UseVisualStyleBackColor = true;
			this.mLineButton.Click += new System.EventHandler(this.mLineButton_Click);
			// 
			// mLineLightButton
			// 
			this.mLineLightButton.Location = new System.Drawing.Point(12, 253);
			this.mLineLightButton.Name = "mLineLightButton";
			this.mLineLightButton.Size = new System.Drawing.Size(87, 23);
			this.mLineLightButton.TabIndex = 8;
			this.mLineLightButton.Text = "линия света";
			this.mLineLightButton.UseVisualStyleBackColor = true;
			this.mLineLightButton.Click += new System.EventHandler(this.mLineLightButton_Click);
			// 
			// mCTextBox
			// 
			this.mCTextBox.Location = new System.Drawing.Point(41, 38);
			this.mCTextBox.Name = "mCTextBox";
			this.mCTextBox.Size = new System.Drawing.Size(100, 20);
			this.mCTextBox.TabIndex = 9;
			this.mCTextBox.Text = "1";
			this.mCTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mCTextBox_KeyUp);
			// 
			// mClearButton
			// 
			this.mClearButton.Location = new System.Drawing.Point(12, 373);
			this.mClearButton.Name = "mClearButton";
			this.mClearButton.Size = new System.Drawing.Size(87, 23);
			this.mClearButton.TabIndex = 10;
			this.mClearButton.Text = "очистить все";
			this.mClearButton.UseVisualStyleBackColor = true;
			this.mClearButton.Click += new System.EventHandler(this.mClearButton_Click);
			// 
			// mSegTextBox
			// 
			this.mSegTextBox.Location = new System.Drawing.Point(41, 64);
			this.mSegTextBox.Name = "mSegTextBox";
			this.mSegTextBox.Size = new System.Drawing.Size(100, 20);
			this.mSegTextBox.TabIndex = 11;
			this.mSegTextBox.Visible = false;
			this.mSegTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mSegTextBox_KeyUp);
			// 
			// mEuklideCheckBox
			// 
			this.mEuklideCheckBox.AutoSize = true;
			this.mEuklideCheckBox.Location = new System.Drawing.Point(12, 159);
			this.mEuklideCheckBox.Name = "mEuklideCheckBox";
			this.mEuklideCheckBox.Size = new System.Drawing.Size(137, 17);
			this.mEuklideCheckBox.TabIndex = 12;
			this.mEuklideCheckBox.Text = "евклидова геометрия";
			this.mEuklideCheckBox.UseVisualStyleBackColor = true;
			this.mEuklideCheckBox.Click += new System.EventHandler(this.mEuklideCheckBox_Click);
			// 
			// mButtonInvariant
			// 
			this.mButtonInvariant.Location = new System.Drawing.Point(12, 282);
			this.mButtonInvariant.Name = "mButtonInvariant";
			this.mButtonInvariant.Size = new System.Drawing.Size(87, 23);
			this.mButtonInvariant.TabIndex = 13;
			this.mButtonInvariant.Text = "инвариант";
			this.mButtonInvariant.UseVisualStyleBackColor = true;
			this.mButtonInvariant.Click += new System.EventHandler(this.mButtonInvariant_Click);
			// 
			// mButtonDelete
			// 
			this.mButtonDelete.Location = new System.Drawing.Point(12, 344);
			this.mButtonDelete.Name = "mButtonDelete";
			this.mButtonDelete.Size = new System.Drawing.Size(87, 23);
			this.mButtonDelete.TabIndex = 14;
			this.mButtonDelete.Text = "удалить";
			this.mButtonDelete.UseVisualStyleBackColor = true;
			this.mButtonDelete.Click += new System.EventHandler(this.mButtonDelete_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(656, 485);
			this.Controls.Add(this.mButtonDelete);
			this.Controls.Add(this.mButtonInvariant);
			this.Controls.Add(this.mEuklideCheckBox);
			this.Controls.Add(this.mSegTextBox);
			this.Controls.Add(this.mClearButton);
			this.Controls.Add(this.mCTextBox);
			this.Controls.Add(this.mLineLightButton);
			this.Controls.Add(this.mLineButton);
			this.Controls.Add(this.mPointButton);
			this.Controls.Add(this.mGridCheckBox);
			this.Controls.Add(this.mConeCheckBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mSpeedRight);
			this.Controls.Add(this.mSpeedLeftButton);
			this.Controls.Add(this.mSpeedTextBox);
			this.Name = "Form1";
			this.Text = "Relative";
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox mSpeedTextBox;
		private System.Windows.Forms.Button mSpeedLeftButton;
		private System.Windows.Forms.Button mSpeedRight;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox mConeCheckBox;
		private System.Windows.Forms.CheckBox mGridCheckBox;
		private System.Windows.Forms.Button mPointButton;
		private System.Windows.Forms.Button mLineButton;
		private System.Windows.Forms.Button mLineLightButton;
		private System.Windows.Forms.TextBox mCTextBox;
		private System.Windows.Forms.Button mClearButton;
		private System.Windows.Forms.TextBox mSegTextBox;
		private System.Windows.Forms.CheckBox mEuklideCheckBox;
		private System.Windows.Forms.Button mButtonInvariant;
		private System.Windows.Forms.Button mButtonDelete;
	}
}

