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
			this.button_OK = new System.Windows.Forms.Button();
			this.button_Calen = new System.Windows.Forms.Button();
			this.button_All = new System.Windows.Forms.Button();
			this.comboBox_All = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// main_flowLayoutPanel
			// 
			this.main_flowLayoutPanel.AutoScroll = true;
			this.main_flowLayoutPanel.Location = new System.Drawing.Point(0, 48);
			this.main_flowLayoutPanel.Name = "main_flowLayoutPanel";
			this.main_flowLayoutPanel.Size = new System.Drawing.Size(800, 455);
			this.main_flowLayoutPanel.TabIndex = 0;
			// 
			// button_OK
			// 
			this.button_OK.Location = new System.Drawing.Point(681, 512);
			this.button_OK.Name = "button_OK";
			this.button_OK.Size = new System.Drawing.Size(107, 41);
			this.button_OK.TabIndex = 1;
			this.button_OK.Text = "OK";
			this.button_OK.UseVisualStyleBackColor = true;
			this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
			// 
			// button_Calen
			// 
			this.button_Calen.Location = new System.Drawing.Point(568, 512);
			this.button_Calen.Name = "button_Calen";
			this.button_Calen.Size = new System.Drawing.Size(107, 41);
			this.button_Calen.TabIndex = 2;
			this.button_Calen.Text = "Отмена";
			this.button_Calen.UseVisualStyleBackColor = true;
			this.button_Calen.Click += new System.EventHandler(this.button_Calen_Click);
			// 
			// button_All
			// 
			this.button_All.Location = new System.Drawing.Point(650, 7);
			this.button_All.Name = "button_All";
			this.button_All.Size = new System.Drawing.Size(138, 35);
			this.button_All.TabIndex = 3;
			this.button_All.Text = "Применить всем";
			this.button_All.UseVisualStyleBackColor = true;
			this.button_All.Click += new System.EventHandler(this.button_All_Click);
			// 
			// comboBox_All
			// 
			this.comboBox_All.FormattingEnabled = true;
			this.comboBox_All.Items.AddRange(new object[] {
            "5",
            "4",
            "3",
            "2"});
			this.comboBox_All.Location = new System.Drawing.Point(523, 12);
			this.comboBox_All.Name = "comboBox_All";
			this.comboBox_All.Size = new System.Drawing.Size(121, 24);
			this.comboBox_All.TabIndex = 4;
			this.comboBox_All.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_All_KeyPress);
			// 
			// SetRatings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 565);
			this.Controls.Add(this.comboBox_All);
			this.Controls.Add(this.button_All);
			this.Controls.Add(this.button_Calen);
			this.Controls.Add(this.button_OK);
			this.Controls.Add(this.main_flowLayoutPanel);
			this.Name = "SetRatings";
			this.Text = "SetRatings";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel main_flowLayoutPanel;
		private System.Windows.Forms.Button button_OK;
		private System.Windows.Forms.Button button_Calen;
		private System.Windows.Forms.Button button_All;
		private System.Windows.Forms.ComboBox comboBox_All;
	}
}