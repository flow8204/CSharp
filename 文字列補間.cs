using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp学習
{
	public class 文字列補間 : CategoryBase
	{
		public override void Execute()
		{
			IEnumerable<Employee> emps = this.CreateEmployee(3);

			foreach (var emp in emps)
			{
				Console.WriteLine($"{emp.Name, 10}さんの社員番号は{emp.Code}です。");
			}
		}
	}
}
