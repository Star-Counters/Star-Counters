//Made by Star-Counter.
using System.Collections;
using System.Collections.Generic;
namespace Config{
	public sealed class DialogConfig:BaseConfig{
	    /// <summary>
	    /// 剧情id
	    /// </summary>
	    public int id;
	    /// <summary>
	    /// 章节名字
	    /// </summary>
	    public string chapter;
	    /// <summary>
	    /// 剧情类型
	    /// </summary>
	    public int type;
	    /// <summary>
	    /// 对话
	    /// </summary>
	    public string dialog;
	    /// <summary>
	    /// 选择转到
	    /// </summary>
	    public string[] choiceGoTo;
		public DialogConfig(string str):base(str){
			string[] temps=str.Split('\t');
			if(temps.Length>4){
                id = System.Convert.ToInt32(temps[0]);
                chapter = (temps[1]);
                type = System.Convert.ToInt32(temps[2]);
                dialog = (temps[3]);
                choiceGoTo = ConvertStringToArray(temps[4]);
			}
		}
	}
}
