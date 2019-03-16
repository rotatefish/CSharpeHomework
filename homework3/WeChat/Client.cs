using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat {
	class Client {
		static void Main(string[] args) {
			PublicAcc publicAcc = new PublicAcc("李叶");

			User user1 = new User("小孟");
			publicAcc.register(user1);

			User user2 = new User("小寇");
			publicAcc.register(user2);

			User user3 = new User("小磊");
			publicAcc.register(user3);

			User user4 = new User("小淇");
			publicAcc.register(user4);

			publicAcc.postArticle("深海鱼biss");

			user1.sendMessage(publicAcc, "Hi!");
		}
	}
}
