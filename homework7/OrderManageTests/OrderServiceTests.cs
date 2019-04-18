using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage.Tests {
	[TestClass()]
	public class OrderServiceTests {
		[TestMethod()]
		public void AddOrderTest() {
			OrderService os = new OrderService();
			Customer ikun = new Customer(1, "ikun");
			DateTime data = DateTime.Now;
			Order order1 = new Order(1, ikun, data);
			Order order2 = new Order(2, ikun, data);
			Order order3 = new Order(3, ikun, data);
			os.AddOrder(order1);
			os.AddOrder(order2);
			os.AddOrder(order3);

			Assert.AreEqual(os.orderList.Count, 3);
		}

		[TestMethod()]
		public void DeleteOrderTest() {
			OrderService os = new OrderService();
			Customer ikun = new Customer(1, "ikun");
			DateTime data = DateTime.Now;
			Order order1 = new Order(1, ikun, data);
			Order order2 = new Order(2, ikun, data);
			Order order3 = new Order(3, ikun, data);
			os.AddOrder(order1);
			os.AddOrder(order2);
			os.AddOrder(order3);

			os.DeleteOrder(order1);
			Assert.AreEqual(os.orderList.Count, 2);
		}

		[TestMethod()]
		public void SortOrdersTest() {
			OrderService os = new OrderService();
			Customer ikun = new Customer(1, "ikun");
			DateTime data = DateTime.Now;
			Order order1 = new Order(1, ikun, data);
			Order order2 = new Order(2, ikun, data);
			Order order3 = new Order(3, ikun, data);
			os.AddOrder(order3);
			os.AddOrder(order1);
			os.AddOrder(order2);

			os.SortOrders();
			int[] list = { 1, 2, 3 };
			int[] result = { os.orderList[0].ID, os.orderList[1].ID, os.orderList[2].ID };
			foreach (int a in list)
				Console.WriteLine(a);
			foreach (int a in result)
				Console.WriteLine(a);
			CollectionAssert.AreEqual(list, result);
		}

		[TestMethod()]
		public void GetByIDTest() {
			OrderService os = new OrderService();
			Customer ikun = new Customer(1, "ikun");
			DateTime data = DateTime.Now;
			Order order1 = new Order(1, ikun, data);
			Order order2 = new Order(2, ikun, data);
			os.AddOrder(order1);
			os.AddOrder(order2);

			Order result = os.GetByID(2);
			Assert.AreEqual(order2, result);
		}


		[TestMethod()]
		public void QueryByGoodsNameTest() {
			OrderService os = new OrderService();
			Customer ikun = new Customer(1, "ikun");
			DateTime data = DateTime.Now;
			Goods apple = new Goods(1, "apple", 12.8);
			Goods banana = new Goods(2, "banana", 7.8);
			Order order1 = new Order(1, ikun, data);
			Order order2 = new Order(2, ikun, data);
			order1.AddDetails(new OrderDetails(apple, 10));
			order2.AddDetails(new OrderDetails(banana, 10));
			os.AddOrder(order1);
			os.AddOrder(order2);

			List<Order> result = os.QueryByGoodsName("apple");
			List<Order> answer = new List<Order>();
			answer.Add(order1);
			CollectionAssert.AreEqual(answer, result);
		}

		[TestMethod()]
		public void QueryByCustomerTest() {
			OrderService os = new OrderService();
			Customer ikun = new Customer(1, "ikun");
			Customer ichuan = new Customer(2, "ichuan");
			DateTime data = DateTime.Now;
			Order order1 = new Order(1, ikun, data);
			Order order2 = new Order(2, ichuan, data);
			os.AddOrder(order1);
			os.AddOrder(order2);

			List<Order> result = os.QueryByCustomer("ikun");
			List<Order> answer = new List<Order>();
			answer.Add(order1);
			CollectionAssert.AreEqual(answer, result);
		}
	}
}