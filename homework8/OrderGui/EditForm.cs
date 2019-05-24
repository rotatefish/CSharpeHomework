using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManage;

namespace OrderGui {
	public partial class EditForm : Form {
		public Order Result { get => (Order)orderBindingSource.Current; }

		public EditForm() {
			InitializeComponent();
			customerBindingSource.Add(new Customer(1, "张三"));
			customerBindingSource.Add(new Customer(2, "李四"));
			goodsBindingSource.Add(new Goods(3, "apple", 5.59));
			goodsBindingSource.Add(new Goods(2, "egg", 4.99));
			goodsBindingSource.Add(new Goods(1, "milk", 69.9));
		}

		public EditForm(Order order): this() {
			order.Date = DateTime.Now;
			orderBindingSource.DataSource = order;
		}

		private void EditForm_Load(object sender, EventArgs e) {
			comboBox1.SelectedItem = ((Order)orderBindingSource.Current).Buyer;
			if (detailBindingSource.Current != null) {
				comboBox2.SelectedItem = ((OrderDetails)detailBindingSource.Current).Product;
			}
			else {
				groupBox3.Enabled = false;
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
			((OrderDetails)detailBindingSource.Current).Product = (Goods)comboBox2.SelectedItem;
			detailBindingSource.ResetBindings(false);
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			((Order)orderBindingSource.Current).Buyer = (Customer)comboBox1.SelectedItem;
			detailBindingSource.ResetBindings(false);
		}

		private void detailBindingSource_CurrentChanged(object sender, EventArgs e) {
			if (detailBindingSource.Current != null) {
				comboBox2.SelectedItem = ((OrderDetails)detailBindingSource.Current).Product;
			} else {
				groupBox3.Enabled = false;
			}
		}

		private void detailBindingSource_AddingNew(object sender, AddingNewEventArgs e) {
			groupBox3.Enabled = true;
		}

		private void button1_Click(object sender, EventArgs e) {
			OrderDetails detail = new OrderDetails();
			((Order)orderBindingSource.Current).AddDetails(detail);
			detailBindingSource.MoveLast();
			comboBox2.SelectedItem = null;
			orderBindingSource.ResetBindings(false);
		}

		private void textBox2_TextChanged(object sender, EventArgs e) {
			orderBindingSource.ResetBindings(false);
		}

		private void button2_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void button3_Click(object sender, EventArgs e) {
			OrderDetails detail = (OrderDetails)detailBindingSource.Current;
			if (detail != null) {
				
			}
		}
	}
}
