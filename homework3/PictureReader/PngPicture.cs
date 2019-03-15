using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureReader {
	public class PngPicture : Picture {
		public override void display() {
			//diplay a png picture
			Console.WriteLine("This is a png picture!");
		}
	}
}
