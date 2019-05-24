using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage {

	class Program {
		static void Main(string[] args) {
			
			try {
				OrderService os = new OrderService();
				os.Import("data.txt");
				os.SortOrders();
				Console.WriteLine(os.QueryAllOrder().Count());
				
				Console.WriteLine("\n");

				Console.WriteLine("查询所有订单");
				List<Order> orders = os.QueryAllOrder();
				foreach (Order order in orders) {
					Console.WriteLine(order);
				}
				Console.WriteLine("\n");

				Console.WriteLine("查询客户qdl的所有订单");
				orders = os.QueryByCustomer("qdl");
				foreach (Order order in orders) {
					Console.WriteLine(order);
				}
				Console.WriteLine("\n");

				Console.WriteLine("查询包含商品banana的所有订单");
				orders = os.QueryByGoodsName("banana");
				foreach (Order order in orders) {
					Console.WriteLine(order);
				}
				Console.WriteLine("\n");

				Console.WriteLine("删除订单编号为2和4的订单");
				os.RemoveByID(2);
				os.RemoveByID(4);
				
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
			}
			
		}
	}
}
