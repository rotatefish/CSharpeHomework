using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage {
	//订单明细
	[Serializable]

	public class OrderDetails : IComparable {
		//商品
		public Goods Product { get; set; }
		//数量
		public int Quantity { get; set; }
		
		public OrderDetails() {

		}
		public OrderDetails(Goods product, int quantity) {
			Product = product;
			Quantity = quantity;
		}

		public double TotalAmount() {
			return Product.Price * Quantity;
		}

		public override string ToString() {
			return Product + $", Quantity:{Quantity}";
		}

		public override bool Equals(object obj) {
			var details = obj as OrderDetails;
			return details != null &&
				   Product.Equals(details.Product) &&
				   Quantity == details.Quantity;
		}

		public override int GetHashCode() {
			var hashCode = -220041308;
			hashCode = hashCode * - 1521134295 + Product.GetHashCode();
			hashCode = hashCode * - 1521134295 + Quantity.GetHashCode();
			return hashCode;
		}

		public int CompareTo(object obj) {
			var detail = obj as OrderDetails;
			if (detail == null) return 0;
			return Quantity - detail.Quantity;
		}
	}
}
