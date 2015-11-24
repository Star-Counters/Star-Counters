//Made by Star-Counter.
using System.Collections;
using System.Collections.Generic;
namespace Config{
	public sealed class EnglishWordConfig:BaseConfig{
	    /// <summary>
	    /// id
	    /// </summary>
	    public int id;
	    /// <summary>
	    /// 英文
	    /// </summary>
	    public string EN;
		public EnglishWordConfig(string str):base(str){
			string[] temps=str.Split('\t');
			if(temps.Length>1){
                id = string.IsNullOrEmpty(temps[0])?0:System.Convert.ToInt32(temps[0]);
                EN = string.IsNullOrEmpty(temps[1])?string.Empty:(temps[1]);
			}
		}
	}
}
