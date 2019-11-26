using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp学習
{
	public class パターンマッチング : CategoryBase
	{
		public override void Execute()
		{

		}

		private void OnVarPattern()
		{
		}

		private void VarPattern(object value, bool isHaki)
		{
			if (value is int intvalue)
			{
				Console.WriteLine($"intでした。 Value:{intvalue}");
			}
			else 
			{
				if (isHaki)
				{
					if (value is var _)
					{
						Console.WriteLine($"Varパターン + 破棄パターンです・・・");
					}
				}
				else
				{
					if (value is var a)
					{
						a.GetHashCode();
					}
				}
			}
			
		}

		private void OnHasIntValue()
		{
			int? num = null;
			this.HasIntValue(num);

			num = 3;
			this.HasIntValue(num);

			float floatNum = 3f;
			this.HasIntValue(floatNum);
		}

		private void HasIntValue(object value)
		{
			if (value is int intvalue)
			{
				Console.WriteLine($"HasIntValue:True  Value:{intvalue}");
			}
			else
			{
				if (value == null)
				{
					Console.WriteLine($"HasIntValue:False  Value:Null");
				}
				else
				{
					Console.WriteLine($"HasIntValue:False  ValueType:{value.GetType().Name}  Value:{value.ToString()}");
				}				
			}
		}

		private bool OnIsPlus()
		{
			////int value = 6;
			long value = 6;
			return this.IsPlus(value) ?? false;
		}

		private bool OnIsMatchGeneType()
		{
			var gene = new Generics<Employee>();
			return this.IsMatchGeneType<Employee>(gene);
		}

		private bool? IsPlus(object value)
		{
			switch (value)
			{
				case float num when num > 0:
					return true;
				case float num when num < 0:
					return false;
				case long num when num > 0:
					return true;
				case long num when num < 0:
					return false;
				case int num when num > 0:
					return true;
				case int num when num < 0:
					return false;
				default:
					return null;
			}
		}

		//private bool IsMatchGeneType2<T_Gene, T_Mem>(T_Gene gene)
		//	where T_Gene : GenericsBase
		//	where T_Mem : new()
		//{
		//	bool isMatch = false;

		//	switch (gene)
		//	{
		//		case InheritedGenerics temp:
		//			Console.WriteLine(temp.Member);
		//			isMatch = true;
		//			break;
		//		case Generics<T_Mem, T_Mem, T_Mem> temp:
		//			Console.WriteLine(temp.Member);
		//			isMatch = true;
		//			break;
		//		case Generics<T_Mem, T_Mem> temp:
		//			Console.WriteLine(temp.Member);
		//			isMatch = true;
		//			break;
		//		case Generics<T_Mem> temp:
		//			Console.WriteLine(temp.Member);
		//			isMatch = true;
		//			break;
		//		case GenericsBase temp:
		//			Console.WriteLine(temp.Member);
		//			isMatch = true;
		//			break;
		//		default:
		//			break;

		//	}
		//	return isMatch;
		//}
		
		private bool IsMatchGeneType<T_Mem>(GenericsBase gene)
			where T_Mem : new()
		{
			// C#7.0以下ではコンパイルエラー
			bool isMatch = false;

			switch (gene)
			{
				case InheritedGenerics temp:
					Console.WriteLine(temp.Member);
					isMatch = true;
					break;
				case Generics<T_Mem, T_Mem, T_Mem> temp:
					Console.WriteLine(temp.Member);
					isMatch = true;
					break;
				case Generics<T_Mem, T_Mem> temp:
					Console.WriteLine(temp.Member);
					isMatch = true;
					break;
				case Generics<T_Mem> temp:
					Console.WriteLine(temp.Member);
					isMatch = true;
					break;
				case GenericsBase temp:
					Console.WriteLine(temp.Member);
					isMatch = true;
					break;
				default:
					break;

			}
			return isMatch;
		}
	}

	public class Point
	{
		public int X
		{
			get; set;
		}
		public int Y
		{
			get; set;
		}
		public Point(int x = 0, int y = 0) => (X, Y) = (x, y);
		public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
	}

	class Test
	{
		static int M(object obj)
		=> obj switch
		{
			0 => 1,
			int i => 2,
			Point(1, _) => 4, // new!
			Point { X: 2, Y: var y } => y, // new!
			_ => 0
		};
	}
}
