using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage {
	public class Customer {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Sex { get; set; }

		public Customer(int id, string name, string sex) {
			ID = id;
			Name = name;
			Sex = sex;
		}
		public override bool Equals(object obj) {
			if (obj is Customer) {
				Customer other = (Customer)obj;
				if (other.Name == Name) return true;
			}
			return false;
		}
		public override int GetHashCode() {
			return ID;
		}
		public override string ToString() {
			return "CustomerID:" + ID + ",CustomerName:" + Name + ",CustomerSex:" + Sex;
		}
	}
}
