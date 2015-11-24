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
			if(temps.Length>2){
                id = string.IsNullOrEmpty(temps[0])?0:System.Convert.ToInt32(temps[0]);
                name = string.IsNullOrEmpty(temps[1])?string.Empty:(temps[1]);
                describe = string.IsNullOrEmpty(temps[2])?string.Empty:(temps[2]);
			}
		}
	}
}
