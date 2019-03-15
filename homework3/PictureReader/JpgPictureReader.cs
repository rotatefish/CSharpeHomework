using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureReader {
	public class JpgPictureReader : PictureReader {
		public override Picture readPicture() {
			Console.WriteLine("jpg图片读取器");
			return new JpgPicture();
		}
	}
}
