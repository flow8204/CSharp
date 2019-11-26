using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp学習
{
	public class タプル_分解 : CategoryBase
	{
		public override void Execute()
		{
			Console.WriteLine(nameof(タプル_分解.GetValue_Tuple));
			Tuple<int, int, int> result = this.GetValue_Tuple();
			Console.WriteLine($" result.Item2：{result.Item2}");

			Console.WriteLine(nameof(タプル_分解.GetValue_ValueTuple));
			ValueTuple<int, int, int> result2 = this.GetValue_ValueTuple();
			Console.WriteLine($" result2.Item2：{result2.Item2}");

			Console.WriteLine(nameof(タプル_分解.GetValue_ValueTuple2));
			(int value1, int value2, int value3) result3 = this.GetValue_ValueTuple2();
			Console.WriteLine($" result3.value2：{result3.value2}");
			Console.WriteLine($" result3.Item2：{result3.Item2}");

			(int value1, int value2, int value3) = this.GetValue_ValueTuple2();
			Console.WriteLine($" value2：{value2}");
		}

		private Tuple<int, int, int> GetValue_Tuple()
		{
			int value1 = 1;
			int value2 = 2;
			int value3 = 3;
			
			var result = Tuple.Create(value1, value2, value3);			

			return result;
		}

		private ValueTuple<int, int, int> GetValue_ValueTuple()
		{
			int value1 = 1;
			int value2 = 2;
			int value3 = 3;

			var result = ValueTuple.Create(value1, value2, value3);

			return result;
		}

		private (int value1, int value2, int value3) GetValue_ValueTuple2()
		{
			int value1 = 1;
			int value2 = 2;
			int value3 = 3;

			return (value1, value2, value3);
		}
	}
}
