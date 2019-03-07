using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber
{
	class PrimeNumber
	{
		static void Main(string[] args)
		{
			Console.WriteLine("输入一个数字:");
			int num = int.Parse(Console.ReadLine());
			int tmp = num;
			int k = 2;
			Console.WriteLine("素数因子: ");
			while (tmp > 0)
			{
				if (tmp < k) break;
				if (tmp % k == 0)
				{
					Console.Write(k + " ");
					while (tmp > 0 && tmp % k == 0) tmp /= k;
				}
				else
				{
					++k;
				}
			}
			Console.ReadLine();
		}
	}
}
