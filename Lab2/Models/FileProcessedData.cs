using System.Collections.Generic;

namespace Lab2
{
	public class FileProcessedData
	{
		public string FileName { get; set; }

		public List<string> NewLines { get; set; }

		public List<LogEntry> NewEntries { get; set; }
	}
}
