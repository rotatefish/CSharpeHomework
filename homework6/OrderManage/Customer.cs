using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage {
	public class Customer {
		public int ID { get; set; }
		public string Name { get; set; }

		public Customer() {

		}
		public Customer(int id, string name) {
			ID = id;
			Name = name;
		}

		public override string ToString() {
			return "CustomerID:" + ID + ",CustomerName:" + Name;
		}

		public override bool Equals(object obj) {
			var customer = obj as Customer;
			return customer != null &&
				   ID == customer.ID &&
				   Name == customer.Name;
		}

		public override int GetHashCode() {
			var hashCode = 1479869798;
			hashCode = hashCode * - 1521134295 + ID.GetHashCode();
			hashCode = hashCode * - 1521134295 + Name.GetHashCode();
			return hashCode;
		}
	}
}
