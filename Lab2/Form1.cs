using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab2
{
	public partial class Form1 : Form
	{
		private const string DefaultFilePath = @"C:\Users\kacperkowalski\Downloads\db_small";

		private readonly ILogProcessor _logProcessor;
		private readonly IDialogService _dialogService;
		private readonly ListBox[] _listBoxes;

		public Form1(ILogProcessor logProcessor, IDialogService dialogService)
		{
			InitializeComponent();

			_logProcessor = logProcessor ??
							throw new ArgumentNullException(nameof(logProcessor));
			_dialogService = dialogService ??
							 throw new ArgumentNullException(nameof(dialogService));

			_listBoxes = new[]
			{
				ListBox1,
				ListBox2,
				ListBox3,
				ListBox4,
				ListBox5,
				ListBox6,
				ListBox7
			};

			TextFilePath.Text = DefaultFilePath;
		}

		private void BtnImport_Click(object sender, EventArgs e)
		{
			ClearListBoxes();
			LblLoadedLines.Text = @"The number of loaded file lines of data: 0";

			string filePath = TextFilePath.Text;

			if (File.Exists(filePath))
			{
				ParsedLogData result = _logProcessor.ProcessFile(filePath);
				PopulateListBoxes(result);
				LblLoadedLines.Text = $@"The number of loaded file lines of data: {result.ValidEntries.Count}";
			}
			else
			{
				_dialogService.ShowError(@"Choose a correct text file.",
					@"File not found");
			}
		}

		private void BtnImportFolder_Click(object sender, EventArgs e)
		{
			var folderPath = TextFilePath.Text;

			if (!Directory.Exists(folderPath))
			{
				_dialogService.ShowError(@"Choose a correct folder.", @"Error");
				return;
			}

			ClearListBoxes();
			LblLoadedLines.Text = @"The number of loaded file lines of data: 0";
			BtnImportFolder.Enabled = false;

			var progressForm = new ProgressForm(folderPath, _logProcessor);
			progressForm.FileProcessed += ProgressForm_FileProcessed;
			progressForm.FormClosed += ProgressForm_FormClosed;
			progressForm.Show(this);
		}

		private void ProgressForm_FileProcessed(FileProcessedData fileData)
		{
			SuspendListBoxesUpdate();

			ListBox1.Items.AddRange(fileData.NewLines.ToArray());
			ListBox2.Items.AddRange(fileData.NewEntries.Select(entry => entry.Type).ToArray());
			ListBox3.Items.AddRange(fileData.NewEntries.Select(entry => entry.Date).ToArray());
			ListBox4.Items.AddRange(fileData.NewEntries.Select(entry => entry.Time).ToArray());
			ListBox5.Items.AddRange(fileData.NewEntries.Select(entry => entry.AddressIn).ToArray());
			ListBox6.Items.AddRange(fileData.NewEntries.Select(entry => entry.AddressOut).ToArray());
			ListBox7.Items.AddRange(fileData.NewEntries.Select(entry => entry.Protocol).ToArray());

			ResumeListBoxesUpdate();

			LblLoadedLines.Text =
				$@"The number of loaded file lines of data: {ListBox1.Items.Count}";
		}

		private void ProgressForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			var progressForm = (ProgressForm)sender;
			progressForm.Dispose();
			BtnImportFolder.Enabled = true;
		}

		private void PopulateListBoxes(ParsedLogData data)
		{
			SuspendListBoxesUpdate();

			ListBox1.Items.AddRange(data.AllLines.ToArray());
			ListBox2.Items.AddRange(data.ValidEntries.Select(entry => entry.Type).ToArray());
			ListBox3.Items.AddRange(data.ValidEntries.Select(entry => entry.Date).ToArray());
			ListBox4.Items.AddRange(data.ValidEntries.Select(entry => entry.Time).ToArray());
			ListBox5.Items.AddRange(data.ValidEntries.Select(entry => entry.AddressIn).ToArray());
			ListBox6.Items.AddRange(data.ValidEntries.Select(entry => entry.AddressOut).ToArray());
			ListBox7.Items.AddRange(data.ValidEntries.Select(entry => entry.Protocol).ToArray());

			ResumeListBoxesUpdate();
		}

		private void ClearListBoxes()
		{
			foreach (var listBox in _listBoxes)
			{
				listBox.Items.Clear();
			}
		}

		private void SuspendListBoxesUpdate()
		{
			foreach (var listBox in _listBoxes)
			{
				listBox.BeginUpdate();
			}
		}

		private void ResumeListBoxesUpdate()
		{
			foreach (var listBox in _listBoxes)
			{
				listBox.EndUpdate();
			}
		}

		private void BtnBrowse_Click(object sender, EventArgs e)
		{
			var selectedPath = _dialogService.ShowFileDialog(@"Choose a file to read",
				@"Text files (*.txt)|*.txt|All files (*.*)|*.*");

			if (selectedPath != null)
			{
				TextFilePath.Text = selectedPath;
			}
		}

		private void BtnBrowseFolder_Click(object sender, EventArgs e)
		{
			var selectedPath = _dialogService.ShowFolderDialog();
			if (selectedPath != null)
			{
				TextFilePath.Text = selectedPath;
			}
		}

		private void BtnAbout_Click(object sender, EventArgs e)
		{
			_dialogService.ShowInfo(
				@"Authors: Jakub Bromber and Kacper Kowalski" + Environment.NewLine + Environment.NewLine +
				@"Program: Lab2 (Log analysis)",
				@"About");
		}
	}
}
