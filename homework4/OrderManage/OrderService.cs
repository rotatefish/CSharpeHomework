using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage {
	/// <summary>
	/// 订单服务
	/// </summary>
	public class OrderService {

		private List<Order> orderList;

		public OrderService() {
			orderList = new List<Order>();
		}
		/// <summary>
		/// 添加订单
		/// </summary>
		/// <param name="order"></param>
		public void AddOrder(Order order) {
			if (orderList.Contains(order)) {
				throw new Exception("This order already exists!!!");
			} else {
				orderList.Add(order);
				Console.WriteLine($"Successfully add order{order.ID}!");
			}
		}
		/// <summary>
		/// 删除订单
		/// </summary>
		/// <param name="order"></param>
		public void DeleteOrder(Order order) {
			if (!orderList.Contains(order)) {
				throw new Exception("This order does not exist!!!");
			} else {
				orderList.Remove(order);
				Console.WriteLine("Successfully remove this order!");
			}
		}
		/// <summary>
		/// 修改订单
		/// </summary>
		/// <param name="order"></param>
		public void ModifyOrder(Order order) {
			if (!orderList.Contains(order)) {
				throw new Exception("This order does not exist!!!");
			}
			else {
				
			}
		}

		public Order GetByID(int id) {
			
			foreach (Order obj in orderList) {
				if (obj.ID == id) return obj;
			}
			return null;
		}

		public void RemoveByID(int id) {
			Order o = GetByID(id);
			if (o != null) orderList.Remove(o);
		}

		public List<Order> QueryAllOrder() {
			return orderList;
		}

		public List<Order> QueryByGoodsName(string goodsName) {
			List<Order> result = new List<Order>();
			foreach (Order o in orderList) {
				foreach (OrderDetails od in o.details) {
					if (od.Product.Name == goodsName) {
						result.Add(o);
						break;
					}
				}
			}
			return result;
		}
		public List<Order> QueryByCustomer(string name) {
			List<Order> result = new List<Order>();
			foreach (Order obj in orderList) {
				if (obj.Customer.Name == name) result.Add(obj);
			}
			return result;
		}

	}
}
