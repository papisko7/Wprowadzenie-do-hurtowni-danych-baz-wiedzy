namespace Lab2
{
	partial class Form1
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
			this.TextFilePath = new System.Windows.Forms.TextBox();
			this.BtnImport = new System.Windows.Forms.Button();
			this.BtnBrowse = new System.Windows.Forms.Button();
			this.ListBox1 = new System.Windows.Forms.ListBox();
			this.ListBox2 = new System.Windows.Forms.ListBox();
			this.ListBox3 = new System.Windows.Forms.ListBox();
			this.ListBox4 = new System.Windows.Forms.ListBox();
			this.ListBox5 = new System.Windows.Forms.ListBox();
			this.ListBox6 = new System.Windows.Forms.ListBox();
			this.ListBox7 = new System.Windows.Forms.ListBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// TextFilePath
			// 
			this.TextFilePath.Location = new System.Drawing.Point(134, 22);
			this.TextFilePath.Name = "TextFilePath";
			this.TextFilePath.Size = new System.Drawing.Size(529, 22);
			this.TextFilePath.TabIndex = 0;
			this.TextFilePath.Text = "provide a file path here";
			// 
			// BtnImport
			// 
			this.BtnImport.Location = new System.Drawing.Point(695, 12);
			this.BtnImport.Name = "BtnImport";
			this.BtnImport.Size = new System.Drawing.Size(93, 43);
			this.BtnImport.TabIndex = 1;
			this.BtnImport.Text = "Read File";
			this.BtnImport.UseVisualStyleBackColor = true;
			this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
			// 
			// BtnBrowse
			// 
			this.BtnBrowse.Location = new System.Drawing.Point(12, 12);
			this.BtnBrowse.Name = "BtnBrowse";
			this.BtnBrowse.Size = new System.Drawing.Size(75, 43);
			this.BtnBrowse.TabIndex = 2;
			this.BtnBrowse.Text = "File";
			this.BtnBrowse.UseVisualStyleBackColor = true;
			this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
			// 
			// ListBox1
			// 
			this.ListBox1.FormattingEnabled = true;
			this.ListBox1.ItemHeight = 16;
			this.ListBox1.Location = new System.Drawing.Point(-2, 75);
			this.ListBox1.Name = "ListBox1";
			this.ListBox1.ScrollAlwaysVisible = true;
			this.ListBox1.Size = new System.Drawing.Size(799, 180);
			this.ListBox1.TabIndex = 6;
			// 
			// ListBox2
			// 
			this.ListBox2.FormattingEnabled = true;
			this.ListBox2.ItemHeight = 16;
			this.ListBox2.Location = new System.Drawing.Point(-2, 271);
			this.ListBox2.Name = "ListBox2";
			this.ListBox2.ScrollAlwaysVisible = true;
			this.ListBox2.Size = new System.Drawing.Size(95, 180);
			this.ListBox2.TabIndex = 7;
			// 
			// ListBox3
			// 
			this.ListBox3.FormattingEnabled = true;
			this.ListBox3.ItemHeight = 16;
			this.ListBox3.Location = new System.Drawing.Point(99, 271);
			this.ListBox3.Name = "ListBox3";
			this.ListBox3.ScrollAlwaysVisible = true;
			this.ListBox3.Size = new System.Drawing.Size(95, 180);
			this.ListBox3.TabIndex = 8;
			// 
			// ListBox4
			// 
			this.ListBox4.FormattingEnabled = true;
			this.ListBox4.ItemHeight = 16;
			this.ListBox4.Location = new System.Drawing.Point(200, 271);
			this.ListBox4.Name = "ListBox4";
			this.ListBox4.ScrollAlwaysVisible = true;
			this.ListBox4.Size = new System.Drawing.Size(95, 180);
			this.ListBox4.TabIndex = 9;
			// 
			// ListBox5
			// 
			this.ListBox5.FormattingEnabled = true;
			this.ListBox5.ItemHeight = 16;
			this.ListBox5.Location = new System.Drawing.Point(301, 271);
			this.ListBox5.Name = "ListBox5";
			this.ListBox5.ScrollAlwaysVisible = true;
			this.ListBox5.Size = new System.Drawing.Size(95, 180);
			this.ListBox5.TabIndex = 10;
			// 
			// ListBox6
			// 
			this.ListBox6.FormattingEnabled = true;
			this.ListBox6.ItemHeight = 16;
			this.ListBox6.Location = new System.Drawing.Point(402, 271);
			this.ListBox6.Name = "ListBox6";
			this.ListBox6.ScrollAlwaysVisible = true;
			this.ListBox6.Size = new System.Drawing.Size(95, 180);
			this.ListBox6.TabIndex = 11;
			// 
			// ListBox7
			// 
			this.ListBox7.FormattingEnabled = true;
			this.ListBox7.ItemHeight = 16;
			this.ListBox7.Location = new System.Drawing.Point(514, 271);
			this.ListBox7.Name = "ListBox7";
			this.ListBox7.ScrollAlwaysVisible = true;
			this.ListBox7.Size = new System.Drawing.Size(95, 180);
			this.ListBox7.TabIndex = 12;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.ListBox7);
			this.Controls.Add(this.ListBox6);
			this.Controls.Add(this.ListBox5);
			this.Controls.Add(this.ListBox4);
			this.Controls.Add(this.ListBox3);
			this.Controls.Add(this.ListBox2);
			this.Controls.Add(this.ListBox1);
			this.Controls.Add(this.BtnBrowse);
			this.Controls.Add(this.BtnImport);
			this.Controls.Add(this.TextFilePath);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TextFilePath;
		private System.Windows.Forms.Button BtnImport;
		private System.Windows.Forms.Button BtnBrowse;
		private System.Windows.Forms.ListBox ListBox1;
		private System.Windows.Forms.ListBox ListBox2;
		private System.Windows.Forms.ListBox ListBox3;
		private System.Windows.Forms.ListBox ListBox4;
		private System.Windows.Forms.ListBox ListBox5;
		private System.Windows.Forms.ListBox ListBox6;
		private System.Windows.Forms.ListBox ListBox7;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}

