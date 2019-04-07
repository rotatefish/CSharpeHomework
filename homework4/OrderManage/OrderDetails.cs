using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage {
	//订单明细
	public class OrderDetails {
		//商品
		public Goods Product { get; set; }
		//数量
		public int Quantity { get; set; }
		
		public OrderDetails(Goods product, int quantity) {
			Product = product;
			Quantity = quantity;
		}

		public override string ToString() {
			return Product + $", Quantity:{Quantity}";
		}
	}
}
