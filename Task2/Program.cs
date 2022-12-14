namespace Task2
{
	public delegate void DelegateSort(int num);
	public class SortName
	{
		public event DelegateSort Sort;
		public void StartSort(int num)
		{
			Sorting(num);
		}
		protected virtual void Sorting(int num)
		{
			Sort?.Invoke(num);
		}
	}
	public class MyException : Exception
	{
		public MyException(string message) : base(message) { }
	}

	internal class Program
	{
		public static List<string> list = new List<string>();
		static void Sort(int num)
		{
			switch (num)
			{
				case 1: list.Sort(); break;
				case 2:
					list.Sort();
					list.Reverse();
					break;
			}
		}
		static void Main(string[] args)
		{
			SortName sn = new SortName();
			sn.Sort += Sort;

			while (list.Count != 5)
			{
				Console.WriteLine("Введите пять фамилий, которые требуется отсортировать:");
				try
				{
					for (int i = 0; i < 5; i++)
					{
						string name = Console.ReadLine();
						for (int j = 0; j < name.Length; j++)
						{
							if (!char.IsLetter(name[j]) || int.TryParse(name, out int a))
							{
								list.Clear();
								throw new MyException("Введены некорректные данные! Используйте буквенные символы.");
							}
						}
						if (string.IsNullOrEmpty(name))
						{
							list.Clear();
							throw new MyException("Введены некорректные данные! Пустая строка недопустима.");
						}
						list.Add(name);
					}
				}
				catch (MyException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}

			int num = 0;
			while (num != 1 && num != 2)
			{
				try
				{
					Console.WriteLine("Выберите способ сортировки: 1 (сортировка А-Я) или 2 (сортировка Я-А)");
					num = int.Parse(Console.ReadLine());
					if (num != 1 && num != 2)
						throw new MyException("Введены некорректные данные! Выберите числа 1 или 2.");
					sn.StartSort(num);

					foreach (var name in list)
						Console.WriteLine(name);
				}
				catch (MyException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
	}
}