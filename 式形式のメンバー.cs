using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp学習
{
	public class 式形式のメンバー : CategoryBase
	{
		private bool field1 = false;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="isBodiedFunction"></param>
		public 式形式のメンバー() => this.Property1 = true;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="isBodiedFunction"></param>
		private 式形式のメンバー(bool isBodiedFunction) => this.Property1 = isBodiedFunction;

		public bool Property1
		{
			get => this.field1;
			set => this.field1 = value;
		}

		public bool Property2 => default(bool);		

		public override void Execute()
		{
			this.OnWriteAllMember();
		}

		public void OnWriteAllMember() => this.WriteAllMember(this);
	}
}
