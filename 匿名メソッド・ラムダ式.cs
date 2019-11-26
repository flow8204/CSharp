using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp学習
{
	public class 匿名メソッド_ラムダ式 : CategoryBase
	{
		public override void Execute()
		{			
			this.Counter.StartMeasure();

			//this.Execute_Delegate();
			//this.Execute_LazyEvaluation_OnlyLINQ();
			this.Execute_LazyEvaluation_WithIterator(10000, false);

			ParformanceResult result = Counter.EndMeasure();
			Console.WriteLine(result.UsedMemory);
		}

		private void Execute_Delegate()
		{
			Console.WriteLine($"■{nameof(Execute_Delegate)}を実行開始\r\n");

			IEnumerable<Employee> employees = this.CreateEmployee(10);

			Action action = () => Console.WriteLine(nameof(action));

			Func<bool> func = () =>
			{
				Console.WriteLine(nameof(func));
				return true;
			};

			Predicate<IEnumerable<Employee>> predicate = (emps) =>
			{
				Console.WriteLine(nameof(predicate));
				return emps.Any((emp) => emp.Department.Contains("開発"));
			};

			action();

			if (func() == true)
			{
				Console.WriteLine($"{nameof(func)}の結果がtrueでした");
			}

			if (predicate(employees) == true)
			{
				Console.WriteLine($"{nameof(predicate)}の結果がtrueでした");
			}
		}

		private void Execute_LazyEvaluation_WithIterator(int createCount = 10, bool isUseIterator = true)
		{
			Console.WriteLine($"■{nameof(Execute_LazyEvaluation_WithIterator)}を実行開始\r\n");

			IEnumerable<Employee> employees = isUseIterator ?
												this.CreateEmployee(createCount, isLog: true) :
												this.CreateEmployee_List(createCount, isLog: true);

			Predicate<IEnumerable<Employee>> predicate = (emps) =>
			{
				Console.WriteLine(nameof(predicate));
				this.Counter.WriteCurrentMemory(nameof(predicate));
				//return emps.Any((emp) => emp.Department.Contains(""));

				int count = 1;

				return emps.Any((emp) =>
				{
					Console.WriteLine($"{nameof(Enumerable.Any)}:{count++}要素目");
					this.Counter.WriteCurrentMemory($"{nameof(Enumerable.Any)}:{count++}要素目");

					return emp.No == createCount - 1 ? true : false;
				});
			};

			if (predicate(employees) == true)
			{
				Console.WriteLine($"{nameof(predicate)}の結果がtrueでした");
			}
		}

		private void Execute_LazyEvaluation_OnlyLINQ()
		{
			Console.WriteLine($"■{nameof(Execute_LazyEvaluation_OnlyLINQ)}を実行開始\r\n");

			IEnumerable<Employee> employees = this.CreateEmployee(10, isLog: false);
			int count1 = 1;
			int count2 = 1;
			int count3 = 1;

			List<Employee> list = employees.ToList();

			IEnumerable<Employee> devemps = list.Where((emp) =>
			{
				Console.WriteLine($"{nameof(Enumerable.Where)}:{count1++}要素目");
				return emp.Department == "開発" ? true : false;
			});

			IEnumerable<string> names = devemps.Select(emp =>
			{
				Console.WriteLine($"{nameof(Enumerable.Select)}:{count2++}要素目");
				return emp.Name;
			});

			foreach (var name in names)
			{
				Console.WriteLine($"foreach:{count3++}要素目 = {name}さん");
			}
		}		
	}
}