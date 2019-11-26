using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp学習
{
	public class ジェネリック : CategoryBase
	{
		public override void Execute()
		{
			this.CheckGenericType();
		}

		private void CheckGenericType()
		{
			GenericsBase generics = null;

			//generics = new Generics<Employee, Employee>();
			generics = new InheritedGenerics();

			var type = generics.GetType();
			Console.WriteLine(type);
			//Console.WriteLine(type.GetGenericTypeDefinition());

			var geneTypes = new List<Type>()
			{
				typeof(Generics<>),
				typeof(Generics<,>),
				typeof(Generics<,,>),
			};
			//var genetype1 = typeof(Generics<>);
			//var genetype2 = typeof(Generics<,>);
			//var genetype3 = typeof(Generics<, ,>);


			Type genetype = null;

			while (type.IsGenericType == false)
			{
				if (type == null)
				{
					return;
				}

				type = type.BaseType;
			}

			Console.WriteLine("\r\nテスト開始");
			Console.WriteLine(type);
			foreach (var item in geneTypes)
			{
				Console.WriteLine(item);
				//Console.WriteLine(type.IsAssignableFrom(item));
				//Console.WriteLine(item.IsAssignableFrom(type));

				//if (item == type)
				//if (item == type.GetGenericTypeDefinition())
				//if (item.IsAssignableFrom(type))
				if (type.IsAssignableFrom(item))
				{
					Console.WriteLine("一致");
				}
			}
		}
	}

	internal class GenericsBase		
	{
		internal virtual string Member => nameof(GenericsBase);
	}

	internal class Generics<T> : GenericsBase
		where T : new()
	{
		internal override string Member => typeof(Generics<T>).ToString();
	}

	internal class Generics<T1, T2> : Generics<T1>
		where T1 : new()
		where T2 : new()
	{
		internal override string Member => typeof(Generics<T1, T2>).ToString();
	}

	internal class Generics<T1, T2, T3> : Generics<T1, T2>
		where T1 : new()
		where T2 : new()
		where T3 : new()
	{
		internal override string Member => typeof(Generics<T1, T2, T3>).ToString();
	}

	internal class InheritedGenerics : Generics<Employee, Employee, Employee>
	{
		internal override string Member => typeof(InheritedGenerics).ToString();
	}
}
