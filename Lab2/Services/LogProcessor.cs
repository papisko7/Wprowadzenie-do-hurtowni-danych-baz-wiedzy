using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace Lab2
{
	public class LogProcessor : ILogProcessor
	{
		public ParsedLogData ProcessFile(string filePath)
		{
			var data = new ParsedLogData();
			ProcessSingleFile(filePath, data);

			return data;
		}

		public ParsedLogData ProcessDirectory(string directoryPath)
		{
			var data = new ParsedLogData();
			string[] files = Directory.GetFiles(directoryPath, "*.txt");

			foreach (string file in files)
			{
				try
				{
					ProcessSingleFile(file, data);
					data.ProcessedFiles.Add(Path.GetFileName(file));
				}
				catch (Exception)
				{
					// Ignore individual file read errors (fault tolerance)
				}
			}

			return data;
		}

		public ParsedLogData ProcessDirectory(string directoryPath,
			BackgroundWorker worker, ManualResetEvent pauseHandle)
		{
			var data = new ParsedLogData();
			string[] files = Directory.GetFiles(directoryPath, "*.txt");

			for (int i = 0; i < files.Length; i++)
			{
				pauseHandle.WaitOne();

				if (worker.CancellationPending)
					break;

				int linesBefore = data.AllLines.Count;
				int entriesBefore = data.ValidEntries.Count;
				string fileName = Path.GetFileName(files[i]);

				try
				{
					ProcessSingleFile(files[i], data);
					data.ProcessedFiles.Add(fileName);
				}
				catch (Exception)
				{
					// Ignore individual file read errors (fault tolerance)
				}

				var fileData = new FileProcessedData
				{
					FileName = fileName,
					NewLines = data.AllLines.GetRange(linesBefore,
						data.AllLines.Count - linesBefore),
					NewEntries = data.ValidEntries.GetRange(entriesBefore,
						data.ValidEntries.Count - entriesBefore)
				};

				int progress = (int)((i + 1) / (double)files.Length * 100);
				worker.ReportProgress(progress, fileData);

				Thread.Sleep(10);
			}

			return data;
		}

		private void ProcessSingleFile(string filePath, ParsedLogData data)
		{
			using (var sr = new StreamReader(filePath))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					data.AllLines.Add(line);

					var entry = TryParseLine(line);
					if (entry != null)
					{
						data.ValidEntries.Add(entry);
					}
				}
			}
		}

		private LogEntry TryParseLine(string line)
		{
			if (string.IsNullOrWhiteSpace(line) || line.StartsWith("type"))
			{
				return null;
			}

			var parts = line.Split(',');

			if (parts.Length != 6)
			{
				return null;
			}

			return new LogEntry(parts);
		}
	}
}
