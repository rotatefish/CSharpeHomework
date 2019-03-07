using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPrime
{
	class GetPrime
	{
		static void Main(string[] args)
		{
			int[] isPrime = new int[110];
			for (int i = 2; i <= 100; i++) isPrime[i] = 1;
			for (int i = 2; i <= 100; i++)
			{
				if (isPrime[i] == 0) continue;
				for (int j = 2; i * j <= 100; j++)
				{
					isPrime[i * j] = 0;
				}
			}
			Console.WriteLine("100以内的所有素数:");
			for (int i = 2; i <= 100; i++)
			{
				if (isPrime[i] == 1)
				{
					Console.Write(i + " ");
				}
			}
			Console.Read();
		}
	}
}
