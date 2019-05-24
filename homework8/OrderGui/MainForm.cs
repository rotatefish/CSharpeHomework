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
	public partial class MainForm : Form {
		OrderService orderService;
		BindingSource fieldsBS = new BindingSource();
		public String Keyword { get; set; }

		public MainForm() {
			InitializeComponent();
			init();
		}
		public void init() {
			Customer customer1 = new Customer(1, "张三");
			Customer customer2 = new Customer(2, "李四");

			Goods apple = new Goods(3, "apple", 5.59f);
			Goods egg = new Goods(2, "egg", 4.99f);
			Goods milk = new Goods(1, "milk", 69.9f);

			OrderDetails orderDetails1 = new OrderDetails(apple, 8);
			OrderDetails orderDetails2 = new OrderDetails(egg, 2);
			OrderDetails orderDetails3 = new OrderDetails(milk, 1);

			Order order1 = new Order(1, customer1, DateTime.Now);
			Order order2 = new Order(2, customer2, DateTime.Now);
			Order order3 = new Order(3, customer2, DateTime.Now);

			order1.AddDetails(orderDetails1);
			order1.AddDetails(orderDetails2);
			order1.AddDetails(orderDetails3);
			order2.AddDetails(orderDetails2);
			order2.AddDetails(orderDetails3);
			order3.AddDetails(orderDetails3);

			orderService = new OrderService();
			orderService.AddOrder(order1);
			orderService.AddOrder(order2);
			orderService.AddOrder(order3);

			orderBindingSource.DataSource = orderService.QueryAllOrder();
			textBox1.DataBindings.Add("Text", this, "Keyword");
			
		}
		private void Form1_Load(object sender, EventArgs e) {

		}

		private void button1_Click(object sender, EventArgs e) {
			EditForm editForm = new EditForm(new Order());
			editForm.ShowDialog();
			if (editForm.Result != null) {
				orderService.AddOrder(editForm.Result);
				QueryAll();
			}
		}

		private void button6_Click(object sender, EventArgs e) {
			switch (comboBox1.SelectedIndex) {
				case 0:
					orderBindingSource.DataSource = orderService.QueryAllOrder();
					break;
				case 1:
					orderBindingSource.DataSource = orderService.QueryByCustomer(Keyword);
					break;
				case 2:
					orderBindingSource.DataSource = orderService.QueryByGoodsName(Keyword);
					break;
				case 3:
					int.TryParse(Keyword, out int id);
					orderBindingSource.DataSource = orderService.GetByID(id);
					break;

				default:
					break;
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			DialogResult dr;
			dr = MessageBox.Show("确认删除", "删除订单", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
			if (dr == DialogResult.OK) {
				Order o = (Order)orderBindingSource.Current;
				if (o != null) {
					orderService.DeleteOrder(o);
					QueryAll();
				}
			}

		}
		private void QueryAll() {
			orderBindingSource.DataSource = orderService.QueryAllOrder();
			orderBindingSource.ResetBindings(false);
		}

		private void button3_Click(object sender, EventArgs e) {
			EditForm editForm = new EditForm((Order)orderBindingSource.Current);
			editForm.ShowDialog();
		}

		private void button5_Click(object sender, EventArgs e) {
			DialogResult result = saveFileDialog1.ShowDialog();
			if (result.Equals(DialogResult.OK)) {
				String fileName = saveFileDialog1.FileName;
				orderService.Export(fileName);
			}
		}

		private void button4_Click(object sender, EventArgs e) {
			DialogResult result = openFileDialog1.ShowDialog();
			if (result.Equals(DialogResult.OK)) {
				String fileName = openFileDialog1.FileName;
				orderService.Import(fileName);
				QueryAll();
			}
		}

		private void button1_Click_1(object sender, EventArgs e) {

			this.Close();
		}
	}
}
