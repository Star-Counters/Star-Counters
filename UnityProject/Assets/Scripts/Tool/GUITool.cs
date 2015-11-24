using UnityEngine;
using System.Collections;
using Config;
public class GUITool : MonoBehaviour {
	void Start(){
	}
	void OnGUI(){
		GUI.Label (new Rect (Screen.width - 200, Screen.height - 50, 200, 50), string.Format ("Game Process:{0}", GameDataManager.Instance.ArchiveData.progress));
	}
}
