using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayCalc
{
	class ArrayCalc
	{
		static void Main(string[] args)
		{
			int[] num = new int[10] {213, 123, 34, 12, 9, 10, 67, 113, 594, 110};
			int maximum = 0;
			int minimum = 0x7fffffff;
			int average = 0;
			int sumNumber = 0;
			for (int i = 0; i < num.Length; i++)
			{
				maximum = Math.Max(maximum, num[i]);
				minimum = Math.Min(minimum, num[i]);
				sumNumber += num[i];
			}
			average = sumNumber / num.Length;
			Console.WriteLine("最大值: " + maximum);
			Console.WriteLine("最小值: " + minimum);
			Console.WriteLine("平均值: " + average);
			Console.WriteLine("元素和: " + sumNumber);
			Console.Read();
		}
	}
}
