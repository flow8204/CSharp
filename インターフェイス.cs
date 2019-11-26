using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp学習
{
	public class インターフェイス : CategoryBase
	{
		public override void Execute()
		{
			//TestClassC testClass = new TestClassC();
			TestClassA testClass = new TestClassC();
			//this.OnIsTrue(testClass);
			this.OnIsTrue(testClass as ITest_InterFace);
			((ITest_InterFace)testClass).IsFalse();
		}

		//private bool OnIsTrue(TestClassA testClass)
		//{
		//	return testClass.IsTrue();

			//switch (testClass)
			//{
			//	case TestClassC classC:
			//		return classC.IsTrue();

			//	case TestClassA classA:
			//		return classA.IsTrue();				
			//	default:
			//		return false;
			//}
		//}

		private bool OnIsTrue(ITest_InterFace testClass)
		{
			return testClass.IsTrue();

			//switch (testClass)
			//{
			//	case TestClassC classC:
			//		return classC.IsTrue();

			//	case TestClassA classA:
			//		return classA.IsTrue();
			//	default:
			//		return false;
			//}
		}
	}

	public interface ITest_InterFace
	{
		bool IsTrue();
		bool IsFalse();
		Action GetExecution();
	}

	public class TestClassA : ITest_InterFace
	{
		public Action GetExecution()
		{
			throw new NotImplementedException();
		}

		public bool IsFalse()
		{
			Console.WriteLine(nameof(TestClassA));
			return false;
		}

		//public bool IsTrue()
		//{
		//	Console.WriteLine(nameof(TestClassA));
		//	return true;
		//}

		bool ITest_InterFace.IsTrue()
		{
			Console.WriteLine($"{nameof(TestClassA)}.{nameof(ITest_InterFace)}.{nameof(ITest_InterFace.IsTrue)}");
			return true;
		}
	}

	public class TestClassB : TestClassA
	{
	}

	public class TestClassC : TestClassB, ITest_InterFace
	{
		//public bool IsTrue()
		//{
		//	Console.WriteLine($"{nameof(TestClassC)}.{nameof(IsTrue)}");
		//	return true;
		//}

		bool ITest_InterFace.IsTrue()
		{
			Console.WriteLine($"{nameof(TestClassC)}.{nameof(ITest_InterFace)}.{nameof(ITest_InterFace.IsTrue)}");
			return true;
		}
	}
}