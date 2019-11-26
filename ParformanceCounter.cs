using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp学習
{
	public enum ByteExpression : byte
	{
		B = 0,
		KB = 1,
		MB = 2,
	}

	public static class ByteExpressionExtension
	{
		public static long GetMemorySize(this ByteExpression expression)
		{
			return GC.GetTotalMemory(true) / (long)(Math.Pow(10, 3 * (Math.Max(Convert.ToInt32(expression), 1))));
		}
	}

	public class ParformanceCounter : IDisposable
	{
		public ParformanceCounter(ByteExpression byteExpression, string outputPath = null)
		{
			//string path = outputPath ?? Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
			string path = outputPath ?? @"W:\MeasurementResult.txt";

			this.stopwatch = new Stopwatch();
			this.stream = new FileStream(path, FileMode.Create);
			this.writer = new StreamWriter(stream);
		}

		private Timer timer = null;
		private ByteExpression byteExpression = ByteExpression.B;
		private Stopwatch stopwatch = null;
		private FileStream stream = null;
		private StreamWriter writer = null;
		private long usedMemory = 0L;

		internal void WriteText(string text)
		{
			this.writer.WriteLine(text);
		}

		internal void WriteCurrentMemory(string text, long? memory = null)
		{
			this.writer.WriteLine($"{text},{memory ?? this.byteExpression.GetMemorySize()}");
		}

		private void WriteElapsedSeconds()
		{
			this.writer.WriteLine($"経過時間,{this.stopwatch.Elapsed.TotalSeconds.ToString()}");
		}

		internal void StartMeasure()
		{
			this.stopwatch.Start();

			this.usedMemory = this.byteExpression.GetMemorySize();
			this.WriteCurrentMemory("Start", this.usedMemory);
		}

		internal ParformanceResult EndMeasure()
		{
			this.stopwatch.Stop();

			long memory = this.byteExpression.GetMemorySize();

			this.WriteCurrentMemory("End", memory);
			this.WriteElapsedSeconds();

			this.usedMemory = memory - this.usedMemory;

			this.WriteCurrentMemory("使用メモリ", this.usedMemory);

			this.writer.Flush();

			return new ParformanceResult(this.stopwatch, this.usedMemory);
		}

		public void Dispose()
		{
			this.writer.Dispose();
			this.stream.Dispose();
		}
	}

	internal class ParformanceResult
	{
		internal ParformanceResult(Stopwatch stopwatch, long usedMemory)
		{
			this.stopwatch = stopwatch;
			this.UsedMemory = usedMemory;
		}

		private Stopwatch stopwatch = null;

		internal TimeSpan TimeSpan => this.stopwatch.Elapsed;
		internal long UsedMemory { get; private set; } = 0L;
	}
}
