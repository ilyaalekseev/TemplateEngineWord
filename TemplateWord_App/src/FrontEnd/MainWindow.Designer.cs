﻿namespace FrontEnd
{
	partial class MainWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.MainPanel = new System.Windows.Forms.Panel();
			this.CentralPanel = new System.Windows.Forms.Panel();
			this.BottomPanel = new System.Windows.Forms.Panel();
			this.Authorsbutton = new System.Windows.Forms.Button();
			this.TopPanel = new System.Windows.Forms.Panel();
			this.DatabaseManagementButton = new System.Windows.Forms.Button();
			this.FillingOutDocumentsButton = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.MainPanel.SuspendLayout();
			this.BottomPanel.SuspendLayout();
			this.TopPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainPanel
			// 
			this.MainPanel.Controls.Add(this.CentralPanel);
			this.MainPanel.Controls.Add(this.BottomPanel);
			this.MainPanel.Controls.Add(this.TopPanel);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(1032, 603);
			this.MainPanel.TabIndex = 0;
			// 
			// CentralPanel
			// 
			this.CentralPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.CentralPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CentralPanel.Location = new System.Drawing.Point(0, 50);
			this.CentralPanel.Name = "CentralPanel";
			this.CentralPanel.Size = new System.Drawing.Size(1032, 503);
			this.CentralPanel.TabIndex = 2;
			// 
			// BottomPanel
			// 
			this.BottomPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.BottomPanel.Controls.Add(this.Authorsbutton);
			this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.BottomPanel.Location = new System.Drawing.Point(0, 553);
			this.BottomPanel.Name = "BottomPanel";
			this.BottomPanel.Size = new System.Drawing.Size(1032, 50);
			this.BottomPanel.TabIndex = 1;
			// 
			// Authorsbutton
			// 
			this.Authorsbutton.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.Authorsbutton.Location = new System.Drawing.Point(447, 13);
			this.Authorsbutton.Margin = new System.Windows.Forms.Padding(0);
			this.Authorsbutton.Name = "Authorsbutton";
			this.Authorsbutton.Size = new System.Drawing.Size(138, 28);
			this.Authorsbutton.TabIndex = 0;
			this.Authorsbutton.Text = "Авторы";
			this.Authorsbutton.UseVisualStyleBackColor = false;
			this.Authorsbutton.Click += new System.EventHandler(this.Authorsbutton_Click);
			// 
			// TopPanel
			// 
			this.TopPanel.Controls.Add(this.DatabaseManagementButton);
			this.TopPanel.Controls.Add(this.FillingOutDocumentsButton);
			this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPanel.Location = new System.Drawing.Point(0, 0);
			this.TopPanel.Name = "TopPanel";
			this.TopPanel.Size = new System.Drawing.Size(1032, 50);
			this.TopPanel.TabIndex = 0;
			// 
			// DatabaseManagementButton
			// 
			this.DatabaseManagementButton.Location = new System.Drawing.Point(183, 0);
			this.DatabaseManagementButton.Name = "DatabaseManagementButton";
			this.DatabaseManagementButton.Size = new System.Drawing.Size(184, 50);
			this.DatabaseManagementButton.TabIndex = 1;
			this.DatabaseManagementButton.Text = "Управление базой данных";
			this.DatabaseManagementButton.UseVisualStyleBackColor = true;
			this.DatabaseManagementButton.Click += new System.EventHandler(this.DatabaseManagementButton_Click);
			// 
			// FillingOutDocumentsButton
			// 
			this.FillingOutDocumentsButton.Location = new System.Drawing.Point(0, 0);
			this.FillingOutDocumentsButton.Name = "FillingOutDocumentsButton";
			this.FillingOutDocumentsButton.Size = new System.Drawing.Size(184, 50);
			this.FillingOutDocumentsButton.TabIndex = 0;
			this.FillingOutDocumentsButton.Text = "Заполнить документы";
			this.FillingOutDocumentsButton.UseVisualStyleBackColor = true;
			this.FillingOutDocumentsButton.Click += new System.EventHandler(this.FillingOutDocumentsButton_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1032, 603);
			this.Controls.Add(this.MainPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(1050, 650);
			this.MinimumSize = new System.Drawing.Size(1050, 650);
			this.Name = "MainWindow";
			this.Text = "Автоматическое заполнение документов для практики";
			this.MainPanel.ResumeLayout(false);
			this.BottomPanel.ResumeLayout(false);
			this.TopPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Panel BottomPanel;
		private System.Windows.Forms.Panel TopPanel;
		private System.Windows.Forms.Button DatabaseManagementButton;
		private System.Windows.Forms.Button FillingOutDocumentsButton;
		private System.Windows.Forms.Panel CentralPanel;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button Authorsbutton;
	}
}