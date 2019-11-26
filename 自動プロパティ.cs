using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp学習
{
	public class 自動プロパティ : CategoryBase
	{
		private string a = "AAAA";

		public 自動プロパティ()
		{
			this.C = "CCCC";
		}

		public string A {
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		public string B { get; } = "BBBB";

		public string C { get; }

		public override void Execute()
		{
			Console.WriteLine(this.A);
			Console.WriteLine(this.B);
			Console.WriteLine(this.C);
		}
	}
}