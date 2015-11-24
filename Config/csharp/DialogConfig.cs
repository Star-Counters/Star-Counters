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
	    /// <summary>
	    /// 变量名
	    /// </summary>
	    public string variable;
	    /// <summary>
	    /// 表达式
	    /// </summary>
	    public string expression;
	    /// <summary>
	    /// 判断转到
	    /// </summary>
	    public int switchGoTo;
	    /// <summary>
	    /// 备注
	    /// </summary>
	    public string comment;
		public DialogConfig(string str):base(str){
			string[] temps=str.Split('\t');
			if(temps.Length>8){
                id = string.IsNullOrEmpty(temps[0])?0:System.Convert.ToInt32(temps[0]);
                chapter = string.IsNullOrEmpty(temps[1])?string.Empty:(temps[1]);
                type = string.IsNullOrEmpty(temps[2])?0:System.Convert.ToInt32(temps[2]);
                dialog = string.IsNullOrEmpty(temps[3])?string.Empty:(temps[3]);
                choiceGoTo = string.IsNullOrEmpty(temps[4])?null:ConvertStringToArray(temps[4]);
                variable = string.IsNullOrEmpty(temps[5])?string.Empty:(temps[5]);
                expression = string.IsNullOrEmpty(temps[6])?string.Empty:(temps[6]);
                switchGoTo = string.IsNullOrEmpty(temps[7])?0:System.Convert.ToInt32(temps[7]);
                comment = string.IsNullOrEmpty(temps[8])?string.Empty:(temps[8]);
			}
		}
	}
}
