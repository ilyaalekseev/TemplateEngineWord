namespace FrontEnd
{
	partial class SetEstimationWindow
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.MainPanel = new System.Windows.Forms.Panel();
			this.MainFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.TopPanel = new System.Windows.Forms.Panel();
			this.CourseLabel = new System.Windows.Forms.Label();
			this.FacultyLabel = new System.Windows.Forms.Label();
			this.AllButton = new System.Windows.Forms.Button();
			this.AllMarksLabel = new System.Windows.Forms.Label();
			this.AllMarksComboBox = new System.Windows.Forms.ComboBox();
			this.BottomPanel = new System.Windows.Forms.Panel();
			this.CancelButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.MainPanel.SuspendLayout();
			this.TopPanel.SuspendLayout();
			this.BottomPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainPanel
			// 
			this.MainPanel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.MainPanel.Controls.Add(this.MainFlowLayoutPanel);
			this.MainPanel.Controls.Add(this.TopPanel);
			this.MainPanel.Controls.Add(this.BottomPanel);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(1032, 503);
			this.MainPanel.TabIndex = 0;
			// 
			// MainFlowLayoutPanel
			// 
			this.MainFlowLayoutPanel.AutoScroll = true;
			this.MainFlowLayoutPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.MainFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainFlowLayoutPanel.Location = new System.Drawing.Point(0, 50);
			this.MainFlowLayoutPanel.Name = "MainFlowLayoutPanel";
			this.MainFlowLayoutPanel.Size = new System.Drawing.Size(1032, 403);
			this.MainFlowLayoutPanel.TabIndex = 3;
			// 
			// TopPanel
			// 
			this.TopPanel.Controls.Add(this.CourseLabel);
			this.TopPanel.Controls.Add(this.FacultyLabel);
			this.TopPanel.Controls.Add(this.AllButton);
			this.TopPanel.Controls.Add(this.AllMarksLabel);
			this.TopPanel.Controls.Add(this.AllMarksComboBox);
			this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPanel.Location = new System.Drawing.Point(0, 0);
			this.TopPanel.Name = "TopPanel";
			this.TopPanel.Size = new System.Drawing.Size(1032, 50);
			this.TopPanel.TabIndex = 2;
			// 
			// CourseLabel
			// 
			this.CourseLabel.AutoSize = true;
			this.CourseLabel.Location = new System.Drawing.Point(212, 17);
			this.CourseLabel.Name = "CourseLabel";
			this.CourseLabel.Size = new System.Drawing.Size(46, 17);
			this.CourseLabel.TabIndex = 4;
			this.CourseLabel.Text = "label2";
			// 
			// FacultyLabel
			// 
			this.FacultyLabel.AutoSize = true;
			this.FacultyLabel.Location = new System.Drawing.Point(32, 17);
			this.FacultyLabel.Name = "FacultyLabel";
			this.FacultyLabel.Size = new System.Drawing.Size(46, 17);
			this.FacultyLabel.TabIndex = 3;
			this.FacultyLabel.Text = "label1";
			// 
			// AllButton
			// 
			this.AllButton.Location = new System.Drawing.Point(904, 10);
			this.AllButton.Name = "AllButton";
			this.AllButton.Size = new System.Drawing.Size(107, 31);
			this.AllButton.TabIndex = 2;
			this.AllButton.Text = "Выставить";
			this.AllButton.UseVisualStyleBackColor = true;
			this.AllButton.Click += new System.EventHandler(this.AllButton_Click);
			// 
			// AllMarksLabel
			// 
			this.AllMarksLabel.AutoSize = true;
			this.AllMarksLabel.Location = new System.Drawing.Point(592, 16);
			this.AllMarksLabel.Name = "AllMarksLabel";
			this.AllMarksLabel.Size = new System.Drawing.Size(113, 17);
			this.AllMarksLabel.TabIndex = 1;
			this.AllMarksLabel.Text = "Выставить всем";
			// 
			// AllMarksComboBox
			// 
			this.AllMarksComboBox.FormattingEnabled = true;
			this.AllMarksComboBox.Items.AddRange(new object[] {
            "отлично",
            "хорошо",
            "удовл",
            "неудовл"});
			this.AllMarksComboBox.Location = new System.Drawing.Point(723, 13);
			this.AllMarksComboBox.Name = "AllMarksComboBox";
			this.AllMarksComboBox.Size = new System.Drawing.Size(160, 24);
			this.AllMarksComboBox.TabIndex = 0;
			this.AllMarksComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllMarksComboBox_KeyPress);
			// 
			// BottomPanel
			// 
			this.BottomPanel.Controls.Add(this.CancelButton);
			this.BottomPanel.Controls.Add(this.SaveButton);
			this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.BottomPanel.Location = new System.Drawing.Point(0, 453);
			this.BottomPanel.Name = "BottomPanel";
			this.BottomPanel.Size = new System.Drawing.Size(1032, 50);
			this.BottomPanel.TabIndex = 1;
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(752, 6);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(124, 41);
			this.CancelButton.TabIndex = 1;
			this.CancelButton.Text = "Отмена";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(887, 6);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(124, 41);
			this.SaveButton.TabIndex = 0;
			this.SaveButton.Text = "Готово";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// SetEstimationWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.MainPanel);
			this.Name = "SetEstimationWindow";
			this.Size = new System.Drawing.Size(1032, 503);
			this.MainPanel.ResumeLayout(false);
			this.TopPanel.ResumeLayout(false);
			this.TopPanel.PerformLayout();
			this.BottomPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.FlowLayoutPanel MainFlowLayoutPanel;
		private System.Windows.Forms.Panel TopPanel;
		private System.Windows.Forms.Label AllMarksLabel;
		private System.Windows.Forms.ComboBox AllMarksComboBox;
		private System.Windows.Forms.Panel BottomPanel;
		private System.Windows.Forms.Button AllButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Label CourseLabel;
		private System.Windows.Forms.Label FacultyLabel;
	}
}
