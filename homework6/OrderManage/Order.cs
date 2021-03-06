﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderManage {
	// 订单类
	[Serializable]
	public class Order : IComparable {

		public List<OrderDetails> details;
		public int ID { get; set; }
		public Customer Buyer { get; set; }
		public DateTime Date { get; set; }

		public Order() {
			details = new List<OrderDetails>();
		}

		public Order(int id, Customer customer, DateTime date) {
			ID = id;
			Buyer = customer;
			Date = date;
			details = new List<OrderDetails>();
		}

		public void SortDetails() {
			details.Sort();
		}

		public double TotalAmount() {
			double result = 0;
			details.ForEach(detail => result += detail.TotalAmount());
			return result;
		}
		public void AddDetails(OrderDetails orderDetail) {
			if (details.Contains(orderDetail)) {
				throw new Exception($"The orderDetail is already existed!");
			}
			details.Add(orderDetail);
		}

		public override string ToString() {
			string result = $"orderID:{ID}, customer:({Buyer}), DateTime:{Date}";
			foreach (OrderDetails detail in details) {
				result += "\n\t" + detail;
			}
			return result;
		}

		public override bool Equals(object obj) {
			var order = obj as Order;
			return order != null &&
				   ID == order.ID;
		}

		public override int GetHashCode() {
			return 1213502048 + ID.GetHashCode();
		}

		public int CompareTo(object obj) {
			var order = obj as Order;
			if (order == null) return 0;
			return ID - order.ID;
		}
	}
}
