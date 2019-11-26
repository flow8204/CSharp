using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp学習
{
	public class 属性 : CategoryBase
	{
		public override void Execute()
		{			
		}

		[System.Diagnostics.Conditional("DEBUG")]
		private void DebugAttribute()
		{
		}
	}
}
