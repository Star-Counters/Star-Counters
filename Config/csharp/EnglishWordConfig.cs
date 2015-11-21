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
                id = System.Convert.ToInt32(temps[0]);
                EN = (temps[1]);
			}
		}
	}
}
