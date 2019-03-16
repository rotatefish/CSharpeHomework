using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat {
	public class PublicAcc : Subject {
		private List<Observer> userList = new List<Observer>();
		public string Name { get; set; }
		public PublicAcc() {
		}
		public PublicAcc(string name) {
			this.Name = name;
		}
		public void register(Observer user) {
			Console.WriteLine($"{user.getName()}关注了微信公众号{this.Name}");
			userList.Add(user);
		}

		public void remove(Observer user) {
			Console.WriteLine($"{user.getName()}取消关注了微信公众号{this.Name}");
			userList.Remove(user);
		}

		public void notify(string msg) {
			foreach (Observer obs in userList) {
				obs.readArticle(msg);
			}
		}
		public void postArticle(string articleName) {
			Console.WriteLine($"公众号 {this.Name}发布了文章<{articleName}>");
			notify(articleName);
		}
		public void acceptMessage(string userName, string message) {
			Console.WriteLine($"公众号{this.Name}收到用户{userName}的消息:{message}");
		}
	}
}
