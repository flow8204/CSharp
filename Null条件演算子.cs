using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp学習
{
	public class Null条件演算子 : CategoryBase
	{
		public override void Execute()
		{
			bool? result = null;
			var a = new A();

			result = new A().B?.C?.result ?? null;
			Console.WriteLine(result?.ToString() ?? "null");

			a.B = new B();
			result = a.B.C?.result ?? null;
			Console.WriteLine(result?.ToString() ?? "null");

			a.B.C = new C();
			result = a.B.C.result ?? null;
			Console.WriteLine(result?.ToString() ?? "null");

			a.B.C.result = true;
			result = a.B.C.result.Value;
			Console.WriteLine(result?.ToString() ?? "null");
		}
	}

	public class A
	{
		public B B { get; set; } = null;
	}

	public class B
	{
		public C C { get; set; } = null;
	}

	public class C
	{
		public bool? result = null;
	}
}
