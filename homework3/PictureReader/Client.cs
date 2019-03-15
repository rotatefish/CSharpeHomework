using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureReader {
	class Client {
		static void Main(string[] args) {
			try {
				Picture pic;
				PictureReader reader;
				reader = new JpgPictureReader();
				pic = reader.readPicture();
				pic.display();
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}
	}
}
