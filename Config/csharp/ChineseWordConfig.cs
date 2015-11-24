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
                id = string.IsNullOrEmpty(temps[0])?0:System.Convert.ToInt32(temps[0]);
                CN = string.IsNullOrEmpty(temps[1])?string.Empty:(temps[1]);
			}
		}
	}
}
