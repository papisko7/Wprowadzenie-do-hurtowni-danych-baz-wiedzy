using System.ComponentModel;
using System.Threading;

namespace Lab2
{
	public interface ILogProcessor
	{
		ParsedLogData ProcessFile(string filePath);

		ParsedLogData ProcessDirectory(string directoryPath);

		ParsedLogData ProcessDirectory(string directoryPath,
			BackgroundWorker worker, ManualResetEvent pauseHandle);
	}
}
