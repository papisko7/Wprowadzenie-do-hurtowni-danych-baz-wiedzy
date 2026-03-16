using System;
using System.ComponentModel;
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
		private readonly BackgroundWorker _bw;
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

			_bw = new BackgroundWorker();
			_bw.DoWork += Bw_DoWork;
			_bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
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

			if (Directory.Exists(folderPath))
			{
				ClearListBoxes();
				BtnImportFolder.Enabled = false;
				LblLoadedLines.Text = @"Files are being loaded from the folder in the background...";

				_bw.RunWorkerAsync(folderPath);
			}
			else
			{
				_dialogService.ShowError(@"Choose a correct folder.", @"Error");
			}
		}

		private void Bw_DoWork(object sender, DoWorkEventArgs e)
		{
			var path = (string)e.Argument;
			e.Result = _logProcessor.ProcessDirectory(path);
		}

		private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Result is ParsedLogData result)
			{
				PopulateListBoxes(result);
				LblLoadedLines.Text = $@"Number of loaded lines of data: {result.ValidEntries.Count}";
				_dialogService.ShowInfo(
					@"The process of reading all files from the selected folder has been completed!",
					@"Success");
			}

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
