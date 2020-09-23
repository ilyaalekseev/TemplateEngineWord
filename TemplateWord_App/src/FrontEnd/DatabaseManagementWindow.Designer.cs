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
			this.TabtlComboboxLabel = new System.Windows.Forms.Label();
			this.TableComboBox = new System.Windows.Forms.ComboBox();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainPanel
			// 
			this.MainPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.MainPanel.Controls.Add(this.TableComboBox);
			this.MainPanel.Controls.Add(this.TabtlComboboxLabel);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(1032, 503);
			this.MainPanel.TabIndex = 0;
			// 
			// TabtlComboboxLabel
			// 
			this.TabtlComboboxLabel.AutoSize = true;
			this.TabtlComboboxLabel.Location = new System.Drawing.Point(37, 37);
			this.TabtlComboboxLabel.Name = "TabtlComboboxLabel";
			this.TabtlComboboxLabel.Size = new System.Drawing.Size(230, 17);
			this.TabtlComboboxLabel.TabIndex = 0;
			this.TabtlComboboxLabel.Text = "Выберите таблицу в базе данных";
			// 
			// TableComboBox
			// 
			this.TableComboBox.FormattingEnabled = true;
			this.TableComboBox.Items.AddRange(new object[] {
            "Студенты",
            "Преподаватели"});
			this.TableComboBox.Location = new System.Drawing.Point(335, 34);
			this.TableComboBox.Name = "TableComboBox";
			this.TableComboBox.Size = new System.Drawing.Size(165, 24);
			this.TableComboBox.TabIndex = 1;
			this.TableComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TableComboBox_KeyPress);
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
			this.MainPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.ComboBox TableComboBox;
		private System.Windows.Forms.Label TabtlComboboxLabel;
	}
}
