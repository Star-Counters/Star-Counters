using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Config;
using System;
public class GameConfigManager
{
    public static GameConfigManager Instance {
        get;
        set;
    }
    private Dictionary<Type, Dictionary<int,BaseConfig>> configsDictionary;
    private Dictionary<int, string> wordDictionary;
	private Dictionary<string, int> chapterDictionary;
    public GameConfigManager(){
        configsDictionary = new Dictionary<Type, Dictionary<int, BaseConfig>>();
        wordDictionary = new Dictionary<int, string>();
		chapterDictionary = new Dictionary<string, int> ();
        LoadAllConfigs();
    }
    public void LoadAllConfigs() {
        configsDictionary.Add(typeof(NPCConfig), LoadConfigFromText<NPCConfig>());
		configsDictionary.Add(typeof(DialogConfig), LoadConfigFromText<DialogConfig> ());
        //configsDictionary.Add(typeof(ChineseWordConfig), LoadConfigFromText<ChineseWordConfig>());
        //configsDictionary.Add(typeof(EnglishWordConfig), LoadConfigFromText<EnglishWordConfig>());
		SetChapterDictionary ();
    }
    /// <summary>
    /// 加载.txt文件，生成类T的实例字典Dictionary<int, BaseConfig>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
	public Dictionary<int, BaseConfig> LoadConfigFromText<T>() where T : BaseConfig
	{
		string typeName = typeof(T).ToString().Substring(7);
		TextAsset configTextAsset = Resources.Load("Configs/"+typeName) as TextAsset;
		byte[] bytes = configTextAsset.bytes;
		MemoryStream memoryStream = new MemoryStream (bytes);
		StreamReader streamReader = new StreamReader (memoryStream);
		Dictionary<int,BaseConfig> configDictionary = new Dictionary<int, BaseConfig>();
		int i = 0;
		while (streamReader.Peek ()>0) {
			string temp=streamReader.ReadLine();
			if(i>0){
				BaseConfig cc=new BaseConfig(temp);
				//T t=new BaseConfig(temp) as T;
				T t =Activator.CreateInstance(typeof(T),temp) as T;
                configDictionary.Add(i, t);
            }
			i++;
		}
		return configDictionary;
	}
	public Dictionary<int, BaseConfig> GetConfigDictionary<T>() where T:BaseConfig{
		return configsDictionary[typeof(T)];
	}
    public T GetConfigByID<T>(int id) where T : BaseConfig
    {
        Dictionary<int, BaseConfig> configDictionary;
        if (!configsDictionary.TryGetValue(typeof(T), out configDictionary))
        {
            configDictionary = LoadConfigFromText<T>();
        }
        BaseConfig baseConfig;
        if (configDictionary.TryGetValue(id, out baseConfig))
            return baseConfig as T;
        else
            return null;
    }
    public void ChangeWordByLanguage(bool isCN) {
        wordDictionary.Clear();
        if (isCN)
        {
            Dictionary<int, BaseConfig> wordConfigDictionary = LoadConfigFromText<ChineseWordConfig>();
            foreach (ChineseWordConfig config in wordConfigDictionary.Values)
            {
                wordDictionary.Add(config.id, config.CN);
            }
        }
        else
        {
            Dictionary<int, BaseConfig> wordConfigDictionary = LoadConfigFromText<EnglishWordConfig>();
            foreach (EnglishWordConfig config in wordConfigDictionary.Values)
            {
                wordDictionary.Add(config.id, config.EN);
            }
        }
    }
    public string GetWordByID(int wordId) {
        string word;
        if (wordDictionary.TryGetValue(wordId, out word))
        {
            return word;
        }
        else {
            return string.Empty;
        }
    }
	private void SetChapterDictionary(){
		Dictionary<int,BaseConfig> dialogConfigDictionary = GetConfigDictionary<DialogConfig> ();
		DialogConfig dialogConfig;
		foreach (KeyValuePair<int,BaseConfig> pair in dialogConfigDictionary) {
			dialogConfig=pair.Value as DialogConfig;
			if(dialogConfig.chapter!=""){
				chapterDictionary.Add(dialogConfig.chapter,dialogConfig.id);
			}
		}
	}
	public int GetChapterIDByName(string name){
		int id;
		if (chapterDictionary.TryGetValue (name, out id)) {
			return id;
		}
		else {
			Debug.LogError(string.Format("ChapterName {0} doesn't exist!",name));
			return 0;
		}
	}
}
