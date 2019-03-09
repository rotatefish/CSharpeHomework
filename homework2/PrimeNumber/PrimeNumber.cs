using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber
{
	class PrimeNumber {
		private static List<int> primeFactor(int num) {
			List<int> ans = new List<int>();
			int k = 2;
			while (num > 0) {
				if (num < k) break;
				if (num % k == 0) {
					ans.Add(k);
					num /= k;
				}
				else {
					++k;
				}
			}
			return ans;
		}
		static void Main(string[] args) {
			Console.WriteLine("输入一个数字:");
			int num;
			try {
				num = int.Parse(Console.ReadLine());
			}
			catch (Exception e) {
	
				Console.WriteLine(e.Message);
				return;
			}
			List<int> ans = primeFactor(num);
			Console.WriteLine("素数因子:");
			foreach(int fac in ans) {
				Console.Write(fac + " ");
			}
		}
	}
}
