using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Config;
using System;
public class GameConfigManager {
	public GameConfigManager(){
		configDictionary = new Dictionary<Type, List<BaseConfig>> ();
	}
	Dictionary<Type,List<BaseConfig>> configDictionary;
	public List<T> ReadText<T>() where T : BaseConfig
	{
		string typeName = typeof(T).ToString().Substring(7);
		TextAsset configTextAsset = Resources.Load("Configs/"+typeName) as TextAsset;
		byte[] bytes = configTextAsset.bytes;
		MemoryStream memoryStream = new MemoryStream (bytes);
		StreamReader streamReader = new StreamReader (memoryStream);
		List<T> configList = new List<T> ();
		int i = 0;
		while (streamReader.Peek ()>0) {
			string temp=streamReader.ReadLine();
			if(i>0){
				T t =Activator.CreateInstance(typeof(T),temp) as T;
			}
			i++;
		}
		return configList; 
	
	}
	public List<T> GetConfig<T>() where T:BaseConfig{
		return null;
	}
}
