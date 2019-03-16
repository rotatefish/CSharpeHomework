using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat {
	public interface Observer {
		string getName();
		void readArticle(string name);
		void sendMessage(PublicAcc author, string message);
	}
}
