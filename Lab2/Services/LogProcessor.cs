using System;
using System.IO;

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
				}
				catch (Exception)
				{
					// Ignore individual file read errors (fault tolerance)
				}
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
