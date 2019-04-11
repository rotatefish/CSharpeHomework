using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage {
	// 商品类
	[Serializable]
	public class Goods {

		public int ID { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		
		public Goods() {

		}
		public Goods(int id, string name, double price) {
			ID = id;
			Name = name;
			Price = price;
		}

		public override string ToString() {
			return "GoodsID:" + ID + ", GoodsName:" + Name + ", Price:" + Price;
		}

		public override bool Equals(object obj) {
			var goods = obj as Goods;
			return goods != null &&
				   ID == goods.ID &&
				   Name == goods.Name &&
				   Price == goods.Price;
		}

		public override int GetHashCode() {
			var hashCode = 560300832;
			hashCode = hashCode * -1521134295 + ID.GetHashCode();
			hashCode = hashCode * -1521134295 + Name.GetHashCode();
			hashCode = hashCode * -1521134295 + Price.GetHashCode();
			return hashCode;
		}
	}
}
