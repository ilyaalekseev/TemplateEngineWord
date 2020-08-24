namespace FrontEnd
{
	partial class SetRatingsControl
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
			this.label_FIO = new System.Windows.Forms.Label();
			this.label_group = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label_FIO
			// 
			this.label_FIO.AutoSize = true;
			this.label_FIO.Location = new System.Drawing.Point(24, 10);
			this.label_FIO.Name = "label_FIO";
			this.label_FIO.Size = new System.Drawing.Size(30, 17);
			this.label_FIO.TabIndex = 0;
			this.label_FIO.Text = "FIO";
			// 
			// label_group
			// 
			this.label_group.AutoSize = true;
			this.label_group.Location = new System.Drawing.Point(442, 10);
			this.label_group.Name = "label_group";
			this.label_group.Size = new System.Drawing.Size(59, 17);
			this.label_group.TabIndex = 1;
			this.label_group.Text = " Группа";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5"});
			this.comboBox1.Location = new System.Drawing.Point(538, 7);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 24);
			this.comboBox1.TabIndex = 2;
			// 
			// SetRatingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label_group);
			this.Controls.Add(this.label_FIO);
			this.Name = "SetRatingsControl";
			this.Size = new System.Drawing.Size(682, 43);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label_FIO;
		private System.Windows.Forms.Label label_group;
		private System.Windows.Forms.ComboBox comboBox1;
	}
}
