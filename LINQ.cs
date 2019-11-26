using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp学習
{
	public class LINQ : CategoryBase
	{
		public override void Execute()
		{
			
		}

		private IEnumerable<EmployeeBase> GetEmployees()
		{
			return this.CreateEmployee_List(10);
		}

		private List<EmployeeBase> GetEmployeeList()
		{
			// return this.CreateEmployee_List(10);
			return this.CreateEmployee_List(10).Cast<EmployeeBase>().ToList();
		}

		private void Union()
		{
			Console.WriteLine("■同一インスタンスなし");
			var list = this.CreateEmployee_List(10);
			var list2 = this.CreateEmployee_List(10);

			foreach (var emp in list.Union(list2))
			{
				this.WriteEmployee(emp);
			}

			Console.WriteLine("\r\n■同一インスタンスあり");
			list = this.CreateEmployee_List(10);
			list2 = new List<Employee>();

			for (int i = 0; i < 10; i++)
			{
				var emp = i % 2 == 1 ? new Employee() { No = i, Name = "新さん" } : list[i];
				list2.Add(emp);
			}

			foreach (var emp in list.Union(list2))
			{
				this.WriteEmployee(emp);
			}
		}

		private void OrderBy()
		{
			var list = this.CreateEmployee_List(10);

			Console.WriteLine("■OrderBy：昇順");
			foreach (var emp in list.OrderBy(emp => emp.No))
			{
				this.WriteEmployee(emp);
			}

			Console.WriteLine();
			Console.WriteLine("■OrderByDescending：降順");
			foreach (var emp in list.OrderByDescending(emp => emp.No))
			{
				this.WriteEmployee(emp);
			}
		}

		private void LINQの定義確認()
		{
			// List<T>
			List<Employee> List = this.CreateEmployee_List(10);
			List.Any();

			// ICollection<T>
			ICollection<Employee> ICollection_Gene = List as ICollection<Employee>;
			ICollection_Gene.Any();

			// IEnumerable<T>
			IEnumerable<Employee> IEnumerable_Gene = List as IEnumerable<Employee>;
			IEnumerable_Gene.Any();

			// IEnumerable
			IEnumerable IEnumerable = List as IEnumerable;

			// これは書けない
			//IEnumerable.Any();

			// LINQを使う場合は要素の型がわかる形にキャストする必要がある。
			Enumerable.Any(IEnumerable.Cast<Employee>());
			IEnumerable.Cast<Employee>().Any();
		}
	}
}
