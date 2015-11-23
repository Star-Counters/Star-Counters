using UnityEngine;
using System.Collections;
using Config;
public class ChoicePanel : BasePanel {
	public GameObject choiceButtonPrefab;
	DialogConfig dialogConfig;
	public override void OnShow ()
	{
		int id = 9;//TODO:set the real value.
		Debug.Log (GameDataManager.Instance.ArchiveData.progress);
		dialogConfig = GameConfigManager.Instance.GetConfigByID<DialogConfig> (id);
		if (dialogConfig.type != 1) {
			Debug.LogError(string.Format("dialogConfig.type is not 1,the real value is:{0}",dialogConfig.type));
			Hide();
			return;
		}
	}
	public override void OnHide ()
	{

	}
	public void InstatiateChoiceButton(int number){
		for(int i=0;i<number;i++){
			GameObject choiceButtonClone=Instantiate(choiceButtonPrefab) as GameObject;
			choiceButtonClone.transform.FindChild("Choice").GetComponent<UILabel>().text=dialogConfig.dialog;
			EventDelegate.Add (choiceButtonClone.GetComponent<UIEventTrigger> ().onClick, ()=>{OnClickChoiceButton(i);});	
		}
	}
	public void OnClickChoiceButton(int index){
		string goTo = dialogConfig.choiceGoTo [index];
	}
}
