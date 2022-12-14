namespace Task1
{
	public class MyException : Exception
	{
		public override string Message { get; }
		public MyException()
		{
			Message = "Вызван собственный тип исключения.";
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			Exception[] exceptions = new Exception[]
			{ new ArgumentNullException(), new ArgumentException(), new DirectoryNotFoundException(),
			  new MyException(), new Exception() };

			foreach (var exception in exceptions)
			{
				try
				{
					throw exception;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
	}
}