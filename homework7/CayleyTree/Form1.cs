using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			this.colorSelect.SelectedIndex = 0;
		}
		private void button1_Click(object sender, EventArgs e) {
			if (graphics == null) graphics = this.CreateGraphics();
			drawCayleyTree(10, 250, 350, 100, -Math.PI / 2);
		}
		private Graphics graphics;
		double th1 = 30 * Math.PI / 180;
		double th2 = 20 * Math.PI / 180;
		double per1 = 0.6;
		double per2 = 0.7;

		void drawCayleyTree(int n, double x0, double y0, double leng, double th) {
			if (n == 0) return;
			double x1 = x0 + leng * Math.Cos(th);
			double y1 = y0 + leng * Math.Sin(th);

			drawLine(x0, y0, x1, y1);

			drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
			drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);

		}

		void drawLine(double x0, double y0, double x1, double y1) {
			Pen penColor = Pens.Blue;
			switch (this.colorSelect.SelectedIndex) {
				case 0:
					penColor = Pens.Blue;
					break;
				case 1:
					penColor = Pens.Green;
					break;
				case 2:
					penColor = Pens.Red;
					break;
				case 3:
					penColor = Pens.Yellow;
					break;
				case 4:
					penColor = Pens.Black;
					break;
				default:
					penColor = Pens.Blue;
					break;
			}
			graphics.DrawLine(penColor, (int)x0, (int)y0, (int)x1, (int)y1);
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			

		}

		private void label1_Click(object sender, EventArgs e) {

		}
	}
}
