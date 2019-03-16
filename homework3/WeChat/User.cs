using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat {
	public class User : Observer {
		public string Name { get; set; }
		public User() {
		}
		public User(string name) {
			this.Name = name;
		}
		public string getName() {
			return this.Name;
		}
		public void readArticle(string articleName) {
			Console.WriteLine($"{this.Name}阅读了文章<{articleName}>");
		}

		public void sendMessage(PublicAcc author, string message) {
			Console.WriteLine($"{this.Name}向公众号{author.Name}发送消息:{message}");
			author.acceptMessage(this.Name, message);
		}
	}
}
