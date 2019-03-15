using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureReader {
	public class JpgPicture : Picture {
		public override void display() {
			//diplay a jpg picture
			Console.WriteLine("This is a jpg picture!");
		}
	}
}
