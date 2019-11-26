using System;
using System.Collections.Generic;
using System.Reflection;

namespace CSharp学習
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//Program.SelectAndExecuteCategory();
			Program.CallExecute(Category.パターンマッチング);
		}

		private static void SelectAndExecuteCategory()
		{
			Console.WriteLine("▼実行するカテゴリの値を入力してください。");
			string name = string.Empty;
			int num = 0;
			bool isSelected = false;

			foreach (var value in Enum.GetValues(typeof(Category)))
			{
				num = ((Category)value).GetHashCode();
				name = Enum.GetName(typeof(Category), value);
				Console.WriteLine($" ・{name}:{num}");
			}

			while (isSelected == false)
			{
				var input = Console.ReadLine();

				if (int.TryParse(input, out int input_num) == true)
				{
					if (Enum.TryParse<Category>(((Category)input_num).ToString(), out Category result) == true)
					{
						Console.WriteLine($"\r\n「{result.ToString()}」が選択されました。\r\n");
						Program.CallExecute(result);
						isSelected = true;
						break;
					}
				}

				Console.WriteLine("値が正しく入力されませんでした。再度値を入力してください。");
			}
		}

		public static void CallExecute(Category category)
		{
			switch (category)
			{
				case Category.自動プロパティ:
					Program.OnExecute<自動プロパティ>();
					break;
				case Category.式形式のメンバー:
					Program.OnExecute<式形式のメンバー>();
					break;
				case Category.Null条件演算子:
					Program.OnExecute<Null条件演算子>();
					break;
				case Category.文字列補間:
					Program.OnExecute<文字列補間>();
					break;
				case Category.出力変数宣言:
					Program.OnExecute<出力変数宣言>();
					break;
				case Category.匿名メソッド_ラムダ式:
					Program.OnExecute<匿名メソッド_ラムダ式>();
					break;
				case Category.インターフェイス:
					Program.OnExecute<インターフェイス>();
					break;
				case Category.ジェネリック:
					Program.OnExecute<ジェネリック>();
					break;
				case Category.パターンマッチング:
					Program.OnExecute<パターンマッチング>();
					break;
				case Category.LINQ:
					Program.OnExecute<LINQ>();
					break;
				case Category.タプル_分解:
					Program.OnExecute<タプル_分解>();
					break;
				case Category.属性:
					Program.OnExecute<属性>();
					break;
				case Category.aaaa:
					Program.OnExecute<aaaa>();
					break;
				default:
					break;
			}
		}

		public static void OnExecute<T_Category>() where T_Category : CategoryBase , new()
		{
			Console.WriteLine("Start\r\n");

			new T_Category().Execute();

			Console.WriteLine("\r\nEnd");
		}	
	}

	public abstract class CategoryBase
	{
		protected ParformanceCounter Counter { get; set;} = new ParformanceCounter(ByteExpression.B);

		public abstract void Execute();

		public List<Employee> CreateEmployee_List(int createCount, bool isLog = false)
		{
			if (isLog)
			{
				Console.WriteLine($"{nameof(CreateEmployee)}メソッドが実行が開始されました");
			}

			var list = new List<Employee>();

			for (int count = 1; count <= createCount; count++)
			{
				if (isLog)
				{
					Console.WriteLine($"{nameof(CreateEmployee)}：{count}回目");
				}

				list.Add(new Employee()
				{
					No = count,
					Code = $"{count.ToString("0000")}",
					Name = $"社員{count.ToString()}",
					Department = count % 2 == 0 ? "開発" : "営業",
				});
			}

			if (isLog)
			{
				Console.WriteLine($"{nameof(CreateEmployee)}メソッドが実行が終了しました");
			}

			return list;
		}

		public IEnumerable<Employee> CreateEmployee(int createCount, bool isLog = false)
		{
			if (isLog)
			{
				Console.WriteLine($"{nameof(CreateEmployee)}メソッドが実行が開始されました");
			}

			for (int count = 1; count <= createCount; count++)
			{
				if (isLog)
				{
					Console.WriteLine($"{nameof(CreateEmployee)}：{count}回目");
				}

				var emp = new Employee()
				{
					No = count,
					Code = $"{count.ToString("0000")}",
					Name = $"社員{count.ToString()}",
					Department = count % 2 == 0 ? "開発" : "営業",
				};

				yield return emp;
			}

			if (isLog)
			{
				Console.WriteLine($"{nameof(CreateEmployee)}メソッドが実行が終了しました");
			}
		}

		public void WriteAllMember(object obj)
		{
			Type type = obj.GetType();

			IEnumerable<FieldInfo> fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

			Console.WriteLine("■Fieldメンバー");

			foreach (var field in fields)
			{
				Console.WriteLine($"Name：{field.Name} Value：{field.GetValue(obj)}");
			}

			Console.WriteLine("■Propertyメンバー");

			IEnumerable<PropertyInfo> propertys = type.GetProperties();

			foreach (var property in propertys)
			{
				Console.WriteLine($"Name：{property.Name} Value：{property.GetValue(obj)}");
			}
		}

		public void WriteEmployee(Employee employee)
		{
			Console.WriteLine($"No：{employee.No}  名前：{employee.Name}");
		}
	}

	public class ExecusionArgsBase
	{
	}

	public enum Category : byte
	{
		インターフェイス = 100,
		ジェネリック = 101,
		属性 = 102,

		自動プロパティ = 0,
		式形式のメンバー = 1,
		Null条件演算子 = 2,
		文字列補間 = 3,
		出力変数宣言 = 4,
		匿名メソッド_ラムダ式 = 5,
		パターンマッチング = 6,
		LINQ = 7,
		タプル_分解 = 8,
		


		aaaa = 255,
	}

	public class Employee : EmployeeBase
	{
		public int No { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Department { get; set; }

		public string Test { get; set; } = string.Empty;
	}

	public class EmployeeBase
	{
		public string BaseValue => "Base";
	}

	public class InheritedEmployee : Employee
	{
		public string InheritedValue => "Inherited";
	}
}
