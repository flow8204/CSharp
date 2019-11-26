using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp学習
{
	public class 出力変数宣言 : CategoryBase
	{
		private IEnumerable<Employee> employees;
		private List<Employee> empList;
		private Employee[] empArray;

		public 出力変数宣言()
		{
			this.employees = this.CreateEmployee(10);
			this.empList = this.CreateEmployee_List(10);
			this.empArray = this.CreateEmployee_List(10).ToArray();
		}

		public override void Execute()
		{
			//bool originalValue = false;

			//Console.WriteLine($"■{nameof(this.Ref_ValueType_Sample)}");
			//this.Ref_ValueType_Sample(ref originalValue);

			//Console.WriteLine($"■{nameof(this.Out_ValueType_Sample)}");
			//this.Out_ValueType_Sample(originalValue, out var value);

			ref Employee a = ref this.SearchEmployee(2);

			Console.WriteLine(a.No);

			a = new Employee() { No = 100 };

			Console.WriteLine(this.empArray[2].No);


			a = this.SearchEmployee(3);

			Console.WriteLine(a.No);

			a = new Employee() { No = 100 };

			Console.WriteLine(this.empArray[3].No);
		}		

		//public void In_ValueType_Sample(in int a)
		//{
		//}

		public void Ref_ValueType_Sample(ref bool value)
		{			
			value = true;
		}

		public void Out_ValueType_Sample(bool value1, out bool value2)
		{
			value2 = true;
		}

		public void Ref_ReferenceType_Sample(ref Employee value)
		{
			value.Name = "ref_testさん";
		}

		public void Out_ReferenceType_Sample(Employee value1, out Employee value2)
		{
			value2 = new Employee() { Name = "out_testさん", };
		}

		private ref Employee SearchEmployee(int index)
		{
			//return ref this.empList[index];
			return ref this.empArray[index];
			//return ref this.empArray.FirstOrDefault(emp => emp.No == index);
		}
	}
}
