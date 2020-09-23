namespace FrontEnd
{
	partial class ChoiceDocumentsSubwindow
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
			this.MainflowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.BottomPanel = new System.Windows.Forms.Panel();
			this.OKButton = new System.Windows.Forms.Button();
			this.MainPanel.SuspendLayout();
			this.BottomPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainPanel
			// 
			this.MainPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.MainPanel.Controls.Add(this.MainflowLayoutPanel);
			this.MainPanel.Controls.Add(this.BottomPanel);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(1032, 456);
			this.MainPanel.TabIndex = 0;
			// 
			// MainflowLayoutPanel
			// 
			this.MainflowLayoutPanel.AutoScroll = true;
			this.MainflowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainflowLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.MainflowLayoutPanel.Name = "MainflowLayoutPanel";
			this.MainflowLayoutPanel.Size = new System.Drawing.Size(1032, 406);
			this.MainflowLayoutPanel.TabIndex = 1;
			// 
			// BottomPanel
			// 
			this.BottomPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.BottomPanel.Controls.Add(this.OKButton);
			this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.BottomPanel.Location = new System.Drawing.Point(0, 406);
			this.BottomPanel.Name = "BottomPanel";
			this.BottomPanel.Size = new System.Drawing.Size(1032, 50);
			this.BottomPanel.TabIndex = 0;
			// 
			// OKButton
			// 
			this.OKButton.Location = new System.Drawing.Point(873, 3);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(139, 44);
			this.OKButton.TabIndex = 0;
			this.OKButton.Text = "Создать";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// ChoiceDocumentsSubwindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.Controls.Add(this.MainPanel);
			this.Name = "ChoiceDocumentsSubwindow";
			this.Size = new System.Drawing.Size(1032, 456);
			this.MainPanel.ResumeLayout(false);
			this.BottomPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Panel BottomPanel;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.FlowLayoutPanel MainflowLayoutPanel;
	}
}
