using UnityEngine;
using System.Collections;
using System;
public class GameMainLoop : MonoBehaviour {
	public static GameMainLoop Instance;
	float durationTime = 0;
	void Awake(){
		Instance = this;
		Debug.Log ("No more counting dollars\tWe'll be counting stars");
		DontDestroyOnLoad (gameObject);
		//creat singleton
		UIManager.Instance = new UIManager ();
		GameDataManager.Instance = new GameDataManager ();
		GameConfigManager.Instance = new GameConfigManager();
		UIManager.Instance.ShowPanel<LoginPanel> ();
		GameConfigManager.Instance.ChangeWordByLanguage(GameDataManager.Instance.IsChinese);
		StoryBoard.Instance = new StoryBoard();
	}
	void Start () {
    }
	void OnApplicationPause(bool pause){
	
	}
	void Update () {
	
	}
	/// <summary>
	/// Loop the specified action periodically by the interval.
	/// </summary>
	/// <param name="action">Action.</param>
	/// <param name="interval">Interval.</param>
	IEnumerator Loop(Action action,float interval){
		WaitForSeconds waitForSeconds = new WaitForSeconds (interval);
		while (true) {
			action ();
			yield return waitForSeconds;//new WaitForSeconds (interval);
		}
	}
	public void StartLoop(Action action,float interval){
		StartCoroutine(Loop(action,interval));
	}
	public void StopLoop(){
		StopAllCoroutines ();
	}
}
