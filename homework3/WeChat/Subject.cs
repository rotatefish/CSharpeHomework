using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat {
	public interface Subject {
		void register(Observer observer);
		void remove(Observer observer);
		void notify(string name);
	}
}
