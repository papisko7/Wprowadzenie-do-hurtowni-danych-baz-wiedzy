using System;
using System.IO;
using System.Windows.Forms;

namespace Lab2
{
	public partial class Form1 : Form
	{
		private const string FILE_PATH = @"D:\ddata\ZALog2007.06.16.txt";

		public Form1()
		{
			InitializeComponent();
			TextFilePath.Text = FILE_PATH;
		}

		private void BtnImport_Click(object sender, EventArgs e)
		{
			if (File.Exists(TextFilePath.Text))
			{
				ReadFile(TextFilePath.Text);
			}
			else
			{
				MessageBox.Show(@"Choose a correct text file.",
					@"File not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void ReadFile(string filePath)
		{
			SuspendListBoxesUpdate();

			using (var sr = new StreamReader(filePath))
			{
				string fileLine;

				while ((fileLine = sr.ReadLine()) != null)
				{
					ListBox1.Items.Add(fileLine);
					ProcessLine(fileLine);
				}
			}
			ResumeListBoxesUpdate();
		}

		private void ProcessLine(string fileLine)
		{
			if (fileLine.StartsWith("type"))
			{
				return;
			}

			string[] elements = fileLine.Split(',');

			if (elements.Length != 6)
			{
				return;
			}

			ListBox2.Items.Add(elements[0]);
			ListBox3.Items.Add(elements[1]);
			ListBox4.Items.Add(elements[2]);
			ListBox5.Items.Add(elements[3]);
			ListBox6.Items.Add(elements[4]);
			ListBox7.Items.Add(elements[5]);
		}

		private void SuspendListBoxesUpdate()
		{
			ListBox1.BeginUpdate();
			ListBox2.BeginUpdate();
			ListBox3.BeginUpdate();
			ListBox4.BeginUpdate();
			ListBox5.BeginUpdate();
			ListBox6.BeginUpdate();
			ListBox7.BeginUpdate();
		}

		private void ResumeListBoxesUpdate()
		{
			ListBox1.EndUpdate();
			ListBox2.EndUpdate();
			ListBox3.EndUpdate();
			ListBox4.EndUpdate();
			ListBox5.EndUpdate();
			ListBox6.EndUpdate();
			ListBox7.EndUpdate();
		}

		private void BtnBrowse_Click(object sender, EventArgs e)
		{
		}
	}
}
