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
			ClearListBoxes();
			LblLoadedLines.Text = "Liczba załadowanych linii danych: 0";

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

		private void ClearListBoxes()
		{
			ListBox1.Items.Clear();
			ListBox2.Items.Clear();
			ListBox3.Items.Clear();
			ListBox4.Items.Clear();
			ListBox5.Items.Clear();
			ListBox6.Items.Clear();
			ListBox7.Items.Clear();
		}

		private void ReadFile(string filePath)
		{
			int loadedLinesCount = 0;

			SuspendListBoxesUpdate();

			using (var sr = new StreamReader(filePath))
			{
				string fileLine;

				while ((fileLine = sr.ReadLine()) != null)
				{
					ListBox1.Items.Add(fileLine);
					if (ProcessLine(fileLine))
					{
						loadedLinesCount++;
					}
				}
			}
			ResumeListBoxesUpdate();
			LblLoadedLines.Text = "Liczba załadowanych linii danych: " + loadedLinesCount;
		}

		private bool ProcessLine(string fileLine)
		{
			if (fileLine.StartsWith("type"))
			{
				return false;
			}

			int commaCount = 0;
			foreach (char c in fileLine)
			{
				if (c == ',')
				{
					commaCount++;
				}
			}

			if (commaCount != 5)
			{
				return false;
			}

			string typ = ReadElement(ref fileLine);
			string data = ReadElement(ref fileLine);
			string czas = ReadElement(ref fileLine);
			string adresWe = ReadElement(ref fileLine);
			string adresWy = ReadElement(ref fileLine);
			string protokol = ReadElement(ref fileLine);

			ListBox2.Items.Add(typ);
			ListBox3.Items.Add(data);
			ListBox4.Items.Add(czas);
			ListBox5.Items.Add(adresWe);
			ListBox6.Items.Add(adresWy);
			ListBox7.Items.Add(protokol);

			return true;
		}

		private string ReadElement(ref string line)
		{
			int commaIndex = line.IndexOf(',');

			if (commaIndex == -1)
			{
				string element = line;
				line = "";
				return element;
			}

			string result = line.Substring(0, commaIndex);
			line = line.Substring(commaIndex + 1);

			return result;
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
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Title = "Wybierz plik do odczytu";
				openFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
				openFileDialog.FileName = "";
				openFileDialog.CheckFileExists = true;
				openFileDialog.CheckPathExists = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					TextFilePath.Text = openFileDialog.FileName;
				}
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void BtnAbout_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Autorzy: Jakub Bromber i Kacper Kowalski\n\nProgram: Lab2 (Analiza logów)", "O programie", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}