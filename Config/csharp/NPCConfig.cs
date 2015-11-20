//Made by Star-Counter.
using System.Collections;
using System.Collections.Generic;
namespace Config{
	public sealed class NPCConfig:BaseConfig{
	    /// <summary>
	    /// id
	    /// </summary>
	    public int id;
	    /// <summary>
	    /// 名字
	    /// </summary>
	    public string name;
	    /// <summary>
	    /// 描述
	    /// </summary>
	    public string describe;
		public NPCConfig(string str):base(str){
			string[] temps=str.Split('\t');
			if(temps.Length>3){
                id = System.Convert.ToInt32(temps[0]);
                name = (temps[1]);
                describe = (temps[2]);
			}
		}
	}
}
