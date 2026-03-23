using System.Collections.Generic;

namespace Lab2
{
	public class ParsedLogData
	{
		public List<string> AllLines { get; } = new List<string>();

		public List<LogEntry> ValidEntries { get; } = new List<LogEntry>();

		public List<string> ProcessedFiles { get; } = new List<string>();
	}
}
