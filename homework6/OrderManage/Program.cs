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
				/*
				DateTime date = DateTime.Now;
				Console.WriteLine();

				Customer customer1 = new Customer(1, "kyh");
				Customer customer2 = new Customer(2, "qdl");
				Customer customer3 = new Customer(3, "cq");

				Goods milk = new Goods(1, "Milk", 4.49);
				Goods eggs = new Goods(2, "eggs", 3.99);
				Goods banana = new Goods(3, "banana", 5.59);

				OrderDetails orderDetails1 = new OrderDetails(banana, 2);
				OrderDetails orderDetails2 = new OrderDetails(eggs, 3);
				OrderDetails orderDetails3 = new OrderDetails(milk, 4);

				Order order1 = new Order(1, customer1, date);
				Order order2 = new Order(2, customer2, date);
				Order order3 = new Order(3, customer3, date);

				order1.AddDetails(new OrderDetails(milk, 20));
				order1.AddDetails(orderDetails1);
				order1.AddDetails(orderDetails2);

				order2.AddDetails(new OrderDetails(eggs, 30));
				order2.AddDetails(orderDetails1);
				order2.AddDetails(orderDetails3);

				order3.AddDetails(new OrderDetails(banana, 25));
				order3.AddDetails(orderDetails2);
				order3.AddDetails(orderDetails3);

				order1.SortDetails();
				order2.SortDetails();
				order3.SortDetails();
				

				os.AddOrder(order2);
				os.AddOrder(order1);
				os.AddOrder(order3);
				*/

				//os.Export("data.txt");
				os.SortOrders();
				Console.WriteLine(os.orderList.Count());
				
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
