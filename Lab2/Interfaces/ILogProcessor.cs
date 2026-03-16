namespace Lab2
{
	public interface ILogProcessor
	{
		ParsedLogData ProcessFile(string filePath);

		ParsedLogData ProcessDirectory(string directoryPath);
	}
}
