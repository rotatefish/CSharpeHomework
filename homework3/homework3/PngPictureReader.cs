using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3 {
	public class PngPictureReader : PictureReader {
		public override Picture readPicture() {
			Console.WriteLine("png图片读取器");
			return new PngPicture();
		}
	}
}
