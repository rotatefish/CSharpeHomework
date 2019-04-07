using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage {
	public class Order : IComparable {

		public List<OrderDetails> details;
		
		public int ID { get; set; }
		public Customer Customer { get; set; }
		public DateTime Date { get; set; }

		public Order() {
			details = new List<OrderDetails>();
		}
		public Order(int id, Customer customer, DateTime date) {
			ID = id;
			Customer = customer;
			Date = date;
			details = new List<OrderDetails>();
		}

		public void AddDetails(OrderDetails orderDetail) {
			if (details.Contains(orderDetail)) {
				throw new Exception($"This orderDetail is already existed!");
			}
			details.Add(orderDetail);
		}

		public override string ToString() {
			string result = $"orderID:{ID}, customer:({Customer}), DateTime:{Date}";
			foreach (OrderDetails detail in details) {
				result += "\n\t" + detail;
			}
			return result;
		}

		public int CompareTo(object obj) {
			Order other = (Order)obj;
			return other.ID - ID;
		}

		public override bool Equals(object obj) {
			if (obj is Order) {
				Order o = (Order)obj;
				if (o.ID == ID) return true;
			}
			return false;
		}

		public override int GetHashCode() {
			return ID;
		}
	}
}
