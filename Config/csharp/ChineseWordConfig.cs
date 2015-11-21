//Made by Star-Counter.
using System.Collections;
using System.Collections.Generic;
namespace Config{
	public sealed class ChineseWordConfig:BaseConfig{
	    /// <summary>
	    /// id
	    /// </summary>
	    public int id;
	    /// <summary>
	    /// 中文
	    /// </summary>
	    public string CN;
		public ChineseWordConfig(string str):base(str){
			string[] temps=str.Split('\t');
			if(temps.Length>1){
                id = System.Convert.ToInt32(temps[0]);
                CN = (temps[1]);
			}
		}
	}
}
