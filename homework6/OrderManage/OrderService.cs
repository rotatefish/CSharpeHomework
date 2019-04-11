using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderManage {
	/// <summary>
	/// 订单服务类
	/// </summary>
	[Serializable]
	public class OrderService {

		public List<Order> orderList;

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

		//将所有订单排序
		public void SortOrders() {
			//Lambda表达式按ID递增排序
			//orderList.Sort((x, y)=>x.ID.CompareTo(y.ID));

			//Lambda表达式按订单总额递增排序
			orderList.Sort((y, x) => x.TotalAmount().CompareTo(y.TotalAmount()));

			//实现IComparable接口排序
			//orderList.Sort();
		}

		//Export方法可以将所有的订单序列化为XML文件
		public void Export(string fileName) {
			XmlSerializer xmlser = new XmlSerializer(orderList.GetType());
			
			using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
				xmlser.Serialize(fs, orderList);
			}
		}
		//Import方法可以从XML文件中载入订单
		public void Import(string fileName) {
			XmlSerializer xmlser = new XmlSerializer(orderList.GetType());
			using (FileStream fs = new FileStream(fileName, FileMode.Open)) {
				orderList = (List<Order>)xmlser.Deserialize(fs);
			}

		}
		//获取指定ID的订单
		public Order GetByID(int id) {
			
			foreach (Order obj in orderList) {
				if (obj.ID == id) return obj;
			}
			return null;
		}
		//移除指定ID的订单
		public void RemoveByID(int id) {
			Order o = GetByID(id);
			if (o != null) orderList.Remove(o);
		}
		//查询所有订单
		public List<Order> QueryAllOrder() {
			return orderList;
		}
		//通过商品名查询订单
		public List<Order> QueryByGoodsName(string goodsName) {
			/*
			List<Order> result = new List<Order>();
			foreach (Order o in orderList) {
				foreach (OrderDetails od in o.details) {
					if (od.Product.Name == goodsName) {
						result.Add(o);
						break;
					}
				}
			}
			*/
			var result = from order in orderList
						 from detail in order.details
						 where detail.Product.Name == goodsName
						 select order;
			return result.ToList();
		}
		//通过客户名查询订单
		public List<Order> QueryByCustomer(string name) {
			var result = orderList.Where(order => order.Buyer.Name == name);
			return result.ToList();
		}

	}
}
