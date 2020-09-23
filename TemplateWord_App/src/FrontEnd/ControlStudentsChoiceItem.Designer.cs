namespace FrontEnd
{
	partial class ControlStudentsChoiceItem
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
			this.OKButton = new System.Windows.Forms.Button();
			this.СoursePanel = new System.Windows.Forms.Panel();
			this.СourseСomboBox = new System.Windows.Forms.ComboBox();
			this.СourseLabel = new System.Windows.Forms.Label();
			this.FacultyPanel = new System.Windows.Forms.Panel();
			this.FacultyСomboBox = new System.Windows.Forms.ComboBox();
			this.FacultyLabel = new System.Windows.Forms.Label();
			this.MainPanel.SuspendLayout();
			this.СoursePanel.SuspendLayout();
			this.FacultyPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainPanel
			// 
			this.MainPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.MainPanel.Controls.Add(this.OKButton);
			this.MainPanel.Controls.Add(this.СoursePanel);
			this.MainPanel.Controls.Add(this.FacultyPanel);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(1032, 50);
			this.MainPanel.TabIndex = 0;
			// 
			// OKButton
			// 
			this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.OKButton.Location = new System.Drawing.Point(526, 7);
			this.OKButton.Margin = new System.Windows.Forms.Padding(0);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(137, 36);
			this.OKButton.TabIndex = 2;
			this.OKButton.Text = "Выбрать";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// СoursePanel
			// 
			this.СoursePanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.СoursePanel.Controls.Add(this.СourseСomboBox);
			this.СoursePanel.Controls.Add(this.СourseLabel);
			this.СoursePanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.СoursePanel.Location = new System.Drawing.Point(248, 0);
			this.СoursePanel.Name = "СoursePanel";
			this.СoursePanel.Size = new System.Drawing.Size(248, 50);
			this.СoursePanel.TabIndex = 1;
			// 
			// СourseСomboBox
			// 
			this.СourseСomboBox.BackColor = System.Drawing.SystemColors.HighlightText;
			this.СourseСomboBox.FormattingEnabled = true;
			this.СourseСomboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
			this.СourseСomboBox.Location = new System.Drawing.Point(115, 14);
			this.СourseСomboBox.Name = "СourseСomboBox";
			this.СourseСomboBox.Size = new System.Drawing.Size(121, 24);
			this.СourseСomboBox.TabIndex = 1;
			this.СourseСomboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.СourseСomboBox_KeyPress);
			this.СourseСomboBox.MouseEnter += new System.EventHandler(this.СourseСomboBox_MouseEnter);
			// 
			// СourseLabel
			// 
			this.СourseLabel.AutoSize = true;
			this.СourseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.СourseLabel.Location = new System.Drawing.Point(23, 17);
			this.СourseLabel.Name = "СourseLabel";
			this.СourseLabel.Size = new System.Drawing.Size(39, 17);
			this.СourseLabel.TabIndex = 0;
			this.СourseLabel.Text = "Курс";
			// 
			// FacultyPanel
			// 
			this.FacultyPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.FacultyPanel.Controls.Add(this.FacultyСomboBox);
			this.FacultyPanel.Controls.Add(this.FacultyLabel);
			this.FacultyPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.FacultyPanel.Location = new System.Drawing.Point(0, 0);
			this.FacultyPanel.Name = "FacultyPanel";
			this.FacultyPanel.Size = new System.Drawing.Size(248, 50);
			this.FacultyPanel.TabIndex = 0;
			// 
			// FacultyСomboBox
			// 
			this.FacultyСomboBox.FormattingEnabled = true;
			this.FacultyСomboBox.Items.AddRange(new object[] {
            "ФПМ",
            "ФИБ",
            "ФСТ",
            "ОТФ"});
			this.FacultyСomboBox.Location = new System.Drawing.Point(115, 14);
			this.FacultyСomboBox.Name = "FacultyСomboBox";
			this.FacultyСomboBox.Size = new System.Drawing.Size(121, 24);
			this.FacultyСomboBox.TabIndex = 1;
			this.FacultyСomboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FacultyСomboBox_KeyPress);
			this.FacultyСomboBox.MouseEnter += new System.EventHandler(this.FacultyСomboBox_MouseEnter);
			// 
			// FacultyLabel
			// 
			this.FacultyLabel.AutoSize = true;
			this.FacultyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FacultyLabel.Location = new System.Drawing.Point(23, 17);
			this.FacultyLabel.Name = "FacultyLabel";
			this.FacultyLabel.Size = new System.Drawing.Size(80, 17);
			this.FacultyLabel.TabIndex = 0;
			this.FacultyLabel.Text = "Факультет";
			// 
			// ControlStudentsChoiceItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.MainPanel);
			this.Name = "ControlStudentsChoiceItem";
			this.Size = new System.Drawing.Size(1032, 50);
			this.MainPanel.ResumeLayout(false);
			this.СoursePanel.ResumeLayout(false);
			this.СoursePanel.PerformLayout();
			this.FacultyPanel.ResumeLayout(false);
			this.FacultyPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Panel СoursePanel;
		private System.Windows.Forms.ComboBox СourseСomboBox;
		private System.Windows.Forms.Label СourseLabel;
		private System.Windows.Forms.Panel FacultyPanel;
		private System.Windows.Forms.ComboBox FacultyСomboBox;
		private System.Windows.Forms.Label FacultyLabel;
		private System.Windows.Forms.Button OKButton;
	}
}
