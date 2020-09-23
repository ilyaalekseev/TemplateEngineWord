namespace FrontEnd
{
	partial class DocumentControl
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
			this.label = new System.Windows.Forms.Label();
			this.checkBox = new System.Windows.Forms.CheckBox();
			this.button = new System.Windows.Forms.Button();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainPanel
			// 
			this.MainPanel.Controls.Add(this.button);
			this.MainPanel.Controls.Add(this.checkBox);
			this.MainPanel.Controls.Add(this.label);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(1015, 50);
			this.MainPanel.TabIndex = 0;
			// 
			// label
			// 
			this.label.AutoSize = true;
			this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label.Location = new System.Drawing.Point(70, 19);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(187, 20);
			this.label.TabIndex = 0;
			this.label.Text = "Название документа";
			// 
			// checkBox
			// 
			this.checkBox.AutoSize = true;
			this.checkBox.Location = new System.Drawing.Point(30, 20);
			this.checkBox.Name = "checkBox";
			this.checkBox.Size = new System.Drawing.Size(18, 17);
			this.checkBox.TabIndex = 1;
			this.checkBox.UseVisualStyleBackColor = true;
			// 
			// button
			// 
			this.button.Location = new System.Drawing.Point(838, 3);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(156, 44);
			this.button.TabIndex = 2;
			this.button.Text = "Редактировать шаблон";
			this.button.UseVisualStyleBackColor = true;
			this.button.Click += new System.EventHandler(this.button_Click);
			// 
			// DocumentControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.MainPanel);
			this.Name = "DocumentControl";
			this.Size = new System.Drawing.Size(1015, 50);
			this.MainPanel.ResumeLayout(false);
			this.MainPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Button button;
		private System.Windows.Forms.CheckBox checkBox;
		private System.Windows.Forms.Label label;
	}
}
