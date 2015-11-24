using UnityEngine;
using System.Collections;
using Config;
public class ChoicePanel : BasePanel {
	public GameObject choiceButtonPrefab;
	DialogConfig dialogConfig;
	public override void OnShow ()
	{
		dialogConfig = GameConfigManager.Instance.GetConfigByID<DialogConfig> (GameDataManager.Instance.ArchiveData.progress);
		if (dialogConfig.type != 1) {
			Debug.LogError(string.Format("dialogConfig.type is not 1,the real value is:{0},process is:{1}",dialogConfig.type,GameDataManager.Instance.ArchiveData.progress));
			Hide();
			return;
		}
		InstatiateChoiceButton ();
	}
	public override void OnHide ()
	{

	}
	private void InstatiateChoiceButton(){
		UIGrid uiGrid = transform.FindChild ("Grid").GetComponent<UIGrid>();
		string[] choices = dialogConfig.dialog.Split ('|');
		int length = choices.Length;
		for(int i=0;i<length;i++){
			GameObject choiceButtonClone=Instantiate(choiceButtonPrefab) as GameObject;
			choiceButtonClone.transform.FindChild("Choice").GetComponent<UILabel>().text=choices[i];
			choiceButtonClone.name="ChoiceBtn"+i;
			int n=i;
			EventDelegate.Add (choiceButtonClone.GetComponent<UIEventTrigger> ().onClick, ()=>{
				StoryBoard.Instance.MakeChoice(n);
			});
			uiGrid.AddChild(choiceButtonClone.transform);
			choiceButtonClone.transform.localScale=Vector3.one;
			uiGrid.Reposition();
		}
	}
}
