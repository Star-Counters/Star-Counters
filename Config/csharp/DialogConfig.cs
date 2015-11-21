//Made by Star-Counter.
using System.Collections;
using System.Collections.Generic;
namespace Config{
	public sealed class DialogConfig:BaseConfig{
	    /// <summary>
	    /// id
	    /// </summary>
	    public int id;
	    /// <summary>
	    /// 文字id
	    /// </summary>
	    public int wordid;
	    /// <summary>
	    /// npcid
	    /// </summary>
	    public int npcid;
		public DialogConfig(string str):base(str){
			string[] temps=str.Split('\t');
			if(temps.Length>2){
                id = System.Convert.ToInt32(temps[0]);
                wordid = System.Convert.ToInt32(temps[1]);
                npcid = System.Convert.ToInt32(temps[2]);
			}
		}
	}
}
