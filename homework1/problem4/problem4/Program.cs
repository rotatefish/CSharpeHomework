using System;

namespace problem4
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Input two numbers:");
			double a = double.Parse(Console.ReadLine());
			double b = double.Parse(Console.ReadLine());
			double ans = a * b;
			Console.WriteLine("The product of two numbers is : " + ans);
			Console.ReadLine();
		}
	}
}
