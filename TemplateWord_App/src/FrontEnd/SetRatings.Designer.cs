namespace FrontEnd
{
	partial class SetRatings
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
			this.main_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// main_flowLayoutPanel
			// 
			this.main_flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.main_flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.main_flowLayoutPanel.Name = "main_flowLayoutPanel";
			this.main_flowLayoutPanel.Size = new System.Drawing.Size(800, 565);
			this.main_flowLayoutPanel.TabIndex = 0;
			// 
			// SetRatings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 565);
			this.Controls.Add(this.main_flowLayoutPanel);
			this.Name = "SetRatings";
			this.Text = "SetRatings";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel main_flowLayoutPanel;
	}
}