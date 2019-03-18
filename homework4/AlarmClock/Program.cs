using System;

namespace AlarmClock {
	//事件参数
	public class AlarmEventArgs : EventArgs {
		public int H { get; set; }
		public int M { get; set; }
		public int S { get; set; }
	}

	//定义一个委托，声明事件处理函数的格式
	public delegate void AlarmHander(object sender, AlarmEventArgs args);

	//定义闹钟类
	public class MyAlarmClock {
		//定义事件
		public event AlarmHander OnAlarm;
		//触发事件
		public void setAlarm(int h, int m, int s) {
			AlarmEventArgs args = new AlarmEventArgs() {
				H = h,
				M = m,
				S = s
			};
			OnAlarm(this, args);
		}
	}
	class Program {
		static void Main(string[] args) {
			MyAlarmClock clk = new MyAlarmClock();
			clk.OnAlarm += new AlarmHander(clk_OnAlarm1);
			clk.OnAlarm += new AlarmHander(clk_OnAlarm2);
			clk.setAlarm(13, 20, 30);
		}

		static void clk_OnAlarm1(object sender, AlarmEventArgs args) {
			Console.WriteLine($"北京时间：{args.H}时{args.M}分{args.S}秒");
		}
		static void clk_OnAlarm2(object sender, AlarmEventArgs args) {
			Console.WriteLine($"现在是下课时间!");
		}
	}

}
