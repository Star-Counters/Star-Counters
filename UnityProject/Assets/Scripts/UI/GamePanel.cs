using UnityEngine;
using System.Collections;
using Config;
public class GamePanel : BasePanel {
	UILabel progress;
    Object dialog;
    UITable uiTable;
	public override void OnShow ()
	{
		progress = transform.FindChild ("Progress").GetComponent<UILabel> ();
		progress.text = GameDataManager.Instance.ArchiveData.progress.ToString();
        dialog = Resources.Load("UI/Items/DialogItem");
		uiTable = transform.FindChild("Scroll View/Table").GetComponent<UITable>();
		uiTable.onCustomSort = CompareTransformByName; 
		EventDelegate.Add (transform.FindChild ("BackBtn").GetComponent<UIEventTrigger> ().onClick, OnClickBack);
        //StoryBoard.Instance.MoveNext();
		GameMainLoop.Instance.StartLoop (StoryBoard.Instance.MoveNext, 2);
    }
	public override void OnHide ()
	{
		GameMainLoop.Instance.StopLoop ();
	}
	void OnClickBack(){
		Hide ();
		UIManager.Instance.ShowPanel<LoginPanel> ();
	}
	public void OnGUI(){
        if (GUILayout.Button("StoryBoard->MoveNext!"))
        {
            StoryBoard.Instance.MoveNext();
        }
    }
    public void AddDialog()
    {
        DialogConfig dialogConfig = GameConfigManager.Instance.GetConfigByID<DialogConfig>(GameDataManager.Instance.ArchiveData.progress) as DialogConfig;
        if (dialogConfig.type != 0)
        {
            Debug.LogError(string.Format("dialogConfig.type is not 0,the real value is:{0}", dialogConfig.type));
            Hide();
            return;
        }
        GameObject dialogClone=Instantiate(dialog) as GameObject;
        dialogClone.GetComponent<UILabel>().text = dialogConfig.dialog;
		dialogClone.name = dialogConfig.id.ToString();
        AddChildToUITable(dialogClone.transform);
    }
	public void AddChoice(int choiceIndex){
		DialogConfig dialogConfig = GameConfigManager.Instance.GetConfigByID<DialogConfig>(GameDataManager.Instance.ArchiveData.progress) as DialogConfig;
		if (dialogConfig.type != 0)
		{
			Debug.LogError(string.Format("dialogConfig.type is not 0,the real value is:{0}", dialogConfig.type));
			Hide();
			return;
		}
		GameObject dialogClone=Instantiate(dialog) as GameObject;
		dialogClone.GetComponent<UILabel>().text = dialogConfig.dialog;
		dialogClone.name = dialogConfig.id.ToString();
		AddChildToUITable(dialogClone.transform);
	
	}
    void AddChildToUITable(Transform child)
    {
        child.parent = uiTable.transform;
        child.localScale = Vector3.one;  
        uiTable.Reposition();
    }
	int CompareTransformByName<T>(T a,T b) where T:Transform{
		return int.Parse (b.name).CompareTo (int.Parse (a.name));
	}
}
