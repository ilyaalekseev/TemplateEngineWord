namespace FrontEnd
{
	partial class DatabaseManagementWindow
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
			this.RightPpanel = new System.Windows.Forms.Panel();
			this.ClearCheckPanel = new System.Windows.Forms.Panel();
			this.ClearLabel = new System.Windows.Forms.Label();
			this.ClearDatabaseCheckBox = new System.Windows.Forms.CheckBox();
			this.ActionTextLabel = new System.Windows.Forms.Label();
			this.FolderButton = new System.Windows.Forms.Button();
			this.FolderTextBox = new System.Windows.Forms.TextBox();
			this.RightBottomPanel = new System.Windows.Forms.Panel();
			this.StartButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.LeftPanel = new System.Windows.Forms.Panel();
			this.OKButton = new System.Windows.Forms.Button();
			this.ActionComboBox = new System.Windows.Forms.ComboBox();
			this.ActionLabel = new System.Windows.Forms.Label();
			this.TableComboBox = new System.Windows.Forms.ComboBox();
			this.TabtlComboboxLabel = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.InfoPanel = new System.Windows.Forms.Panel();
			this.InfoLabel = new System.Windows.Forms.Label();
			this.MainPanel.SuspendLayout();
			this.RightPpanel.SuspendLayout();
			this.ClearCheckPanel.SuspendLayout();
			this.RightBottomPanel.SuspendLayout();
			this.LeftPanel.SuspendLayout();
			this.InfoPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainPanel
			// 
			this.MainPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.MainPanel.Controls.Add(this.RightPpanel);
			this.MainPanel.Controls.Add(this.LeftPanel);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(1032, 503);
			this.MainPanel.TabIndex = 0;
			// 
			// RightPpanel
			// 
			this.RightPpanel.Controls.Add(this.ClearCheckPanel);
			this.RightPpanel.Controls.Add(this.ActionTextLabel);
			this.RightPpanel.Controls.Add(this.FolderButton);
			this.RightPpanel.Controls.Add(this.FolderTextBox);
			this.RightPpanel.Controls.Add(this.RightBottomPanel);
			this.RightPpanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.RightPpanel.Location = new System.Drawing.Point(488, 0);
			this.RightPpanel.Name = "RightPpanel";
			this.RightPpanel.Size = new System.Drawing.Size(544, 503);
			this.RightPpanel.TabIndex = 6;
			// 
			// ClearCheckPanel
			// 
			this.ClearCheckPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ClearCheckPanel.Controls.Add(this.ClearLabel);
			this.ClearCheckPanel.Controls.Add(this.ClearDatabaseCheckBox);
			this.ClearCheckPanel.Location = new System.Drawing.Point(28, 145);
			this.ClearCheckPanel.Name = "ClearCheckPanel";
			this.ClearCheckPanel.Size = new System.Drawing.Size(485, 112);
			this.ClearCheckPanel.TabIndex = 6;
			// 
			// ClearLabel
			// 
			this.ClearLabel.Location = new System.Drawing.Point(12, 9);
			this.ClearLabel.Name = "ClearLabel";
			this.ClearLabel.Size = new System.Drawing.Size(456, 54);
			this.ClearLabel.TabIndex = 7;
			this.ClearLabel.Text = "Рекомендуется выбрать, если неоходимо точное совпадение (за исключением ID) данны" +
    "х в базе данных и загружаемых данных!";
			// 
			// ClearDatabaseCheckBox
			// 
			this.ClearDatabaseCheckBox.AutoSize = true;
			this.ClearDatabaseCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ClearDatabaseCheckBox.Location = new System.Drawing.Point(15, 66);
			this.ClearDatabaseCheckBox.Name = "ClearDatabaseCheckBox";
			this.ClearDatabaseCheckBox.Size = new System.Drawing.Size(359, 21);
			this.ClearDatabaseCheckBox.TabIndex = 6;
			this.ClearDatabaseCheckBox.Text = "Отчистить таблицу в базе данных перед записью";
			this.ClearDatabaseCheckBox.UseVisualStyleBackColor = true;
			this.ClearDatabaseCheckBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClearDatabaseCheckBox_MouseClick);
			// 
			// ActionTextLabel
			// 
			this.ActionTextLabel.AutoSize = true;
			this.ActionTextLabel.Location = new System.Drawing.Point(40, 35);
			this.ActionTextLabel.Name = "ActionTextLabel";
			this.ActionTextLabel.Size = new System.Drawing.Size(46, 17);
			this.ActionTextLabel.TabIndex = 3;
			this.ActionTextLabel.Text = "label1";
			// 
			// FolderButton
			// 
			this.FolderButton.Location = new System.Drawing.Point(389, 74);
			this.FolderButton.Name = "FolderButton";
			this.FolderButton.Size = new System.Drawing.Size(124, 33);
			this.FolderButton.TabIndex = 2;
			this.FolderButton.Text = "Открыть";
			this.FolderButton.UseVisualStyleBackColor = true;
			this.FolderButton.Click += new System.EventHandler(this.FolderButton_Click);
			// 
			// FolderTextBox
			// 
			this.FolderTextBox.Location = new System.Drawing.Point(33, 79);
			this.FolderTextBox.Name = "FolderTextBox";
			this.FolderTextBox.Size = new System.Drawing.Size(329, 22);
			this.FolderTextBox.TabIndex = 1;
			this.FolderTextBox.MouseEnter += new System.EventHandler(this.FolderTextBox_MouseEnter);
			// 
			// RightBottomPanel
			// 
			this.RightBottomPanel.Controls.Add(this.StartButton);
			this.RightBottomPanel.Controls.Add(this.CancelButton);
			this.RightBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.RightBottomPanel.Location = new System.Drawing.Point(0, 416);
			this.RightBottomPanel.Name = "RightBottomPanel";
			this.RightBottomPanel.Size = new System.Drawing.Size(544, 87);
			this.RightBottomPanel.TabIndex = 0;
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(368, 13);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(165, 45);
			this.StartButton.TabIndex = 1;
			this.StartButton.Text = "Готово";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(184, 13);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(165, 45);
			this.CancelButton.TabIndex = 0;
			this.CancelButton.Text = "Отмена";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// LeftPanel
			// 
			this.LeftPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.LeftPanel.Controls.Add(this.InfoPanel);
			this.LeftPanel.Controls.Add(this.OKButton);
			this.LeftPanel.Controls.Add(this.ActionComboBox);
			this.LeftPanel.Controls.Add(this.ActionLabel);
			this.LeftPanel.Controls.Add(this.TableComboBox);
			this.LeftPanel.Controls.Add(this.TabtlComboboxLabel);
			this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.LeftPanel.Location = new System.Drawing.Point(0, 0);
			this.LeftPanel.Name = "LeftPanel";
			this.LeftPanel.Size = new System.Drawing.Size(482, 503);
			this.LeftPanel.TabIndex = 5;
			// 
			// OKButton
			// 
			this.OKButton.Location = new System.Drawing.Point(280, 429);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(165, 45);
			this.OKButton.TabIndex = 9;
			this.OKButton.Text = "Далее";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// ActionComboBox
			// 
			this.ActionComboBox.FormattingEnabled = true;
			this.ActionComboBox.Items.AddRange(new object[] {
            "Выгрузить",
            "Загрузить"});
			this.ActionComboBox.Location = new System.Drawing.Point(280, 79);
			this.ActionComboBox.Name = "ActionComboBox";
			this.ActionComboBox.Size = new System.Drawing.Size(165, 24);
			this.ActionComboBox.TabIndex = 8;
			this.ActionComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ActionComboBox_KeyPress);
			this.ActionComboBox.MouseEnter += new System.EventHandler(this.ActionComboBox_MouseEnter);
			// 
			// ActionLabel
			// 
			this.ActionLabel.AutoSize = true;
			this.ActionLabel.Location = new System.Drawing.Point(35, 79);
			this.ActionLabel.Name = "ActionLabel";
			this.ActionLabel.Size = new System.Drawing.Size(137, 17);
			this.ActionLabel.TabIndex = 7;
			this.ActionLabel.Text = "Веберите действие";
			// 
			// TableComboBox
			// 
			this.TableComboBox.FormattingEnabled = true;
			this.TableComboBox.Items.AddRange(new object[] {
            "Студенты",
            "Преподаватели"});
			this.TableComboBox.Location = new System.Drawing.Point(280, 28);
			this.TableComboBox.Name = "TableComboBox";
			this.TableComboBox.Size = new System.Drawing.Size(165, 24);
			this.TableComboBox.TabIndex = 6;
			this.TableComboBox.MouseEnter += new System.EventHandler(this.TableComboBox_MouseEnter);
			// 
			// TabtlComboboxLabel
			// 
			this.TabtlComboboxLabel.AutoSize = true;
			this.TabtlComboboxLabel.Location = new System.Drawing.Point(35, 31);
			this.TabtlComboboxLabel.Name = "TabtlComboboxLabel";
			this.TabtlComboboxLabel.Size = new System.Drawing.Size(230, 17);
			this.TabtlComboboxLabel.TabIndex = 5;
			this.TabtlComboboxLabel.Text = "Выберите таблицу в базе данных";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// InfoPanel
			// 
			this.InfoPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.InfoPanel.Controls.Add(this.InfoLabel);
			this.InfoPanel.Location = new System.Drawing.Point(3, 124);
			this.InfoPanel.Name = "InfoPanel";
			this.InfoPanel.Size = new System.Drawing.Size(476, 291);
			this.InfoPanel.TabIndex = 10;
			// 
			// InfoLabel
			// 
			this.InfoLabel.Location = new System.Drawing.Point(14, 21);
			this.InfoLabel.Name = "InfoLabel";
			this.InfoLabel.Size = new System.Drawing.Size(446, 258);
			this.InfoLabel.TabIndex = 0;
			this.InfoLabel.Text = "123";
			// 
			// DatabaseManagementWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.MainPanel);
			this.MaximumSize = new System.Drawing.Size(1032, 503);
			this.MinimumSize = new System.Drawing.Size(1032, 503);
			this.Name = "DatabaseManagementWindow";
			this.Size = new System.Drawing.Size(1032, 503);
			this.MainPanel.ResumeLayout(false);
			this.RightPpanel.ResumeLayout(false);
			this.RightPpanel.PerformLayout();
			this.ClearCheckPanel.ResumeLayout(false);
			this.ClearCheckPanel.PerformLayout();
			this.RightBottomPanel.ResumeLayout(false);
			this.LeftPanel.ResumeLayout(false);
			this.LeftPanel.PerformLayout();
			this.InfoPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Panel RightPpanel;
		private System.Windows.Forms.Panel RightBottomPanel;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Panel LeftPanel;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.ComboBox ActionComboBox;
		private System.Windows.Forms.Label ActionLabel;
		private System.Windows.Forms.ComboBox TableComboBox;
		private System.Windows.Forms.Label TabtlComboboxLabel;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button FolderButton;
		private System.Windows.Forms.TextBox FolderTextBox;
		private System.Windows.Forms.Label ActionTextLabel;
		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.Panel ClearCheckPanel;
		private System.Windows.Forms.Label ClearLabel;
		private System.Windows.Forms.CheckBox ClearDatabaseCheckBox;
		private System.Windows.Forms.Panel InfoPanel;
		private System.Windows.Forms.Label InfoLabel;
	}
}
