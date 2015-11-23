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
        EventDelegate.Add (transform.FindChild ("DoBtn").GetComponent<UIEventTrigger> ().onClick, OnClickDo);
		EventDelegate.Add (transform.FindChild ("BackBtn").GetComponent<UIEventTrigger> ().onClick, OnClickBack);
        StoryBoard.Instance.MoveNext();
    }
	public override void OnHide ()
	{

	}
	void OnClickDo(){
        GameDataManager.Instance.ArchiveData.progress += 1;
		progress.text = GameDataManager.Instance.ArchiveData.progress.ToString();
	}
	void OnClickBack(){
		Hide ();
		UIManager.Instance.ShowPanel<LoginPanel> ();
	}
	public void OnGUI(){
		//if (GUILayout.Button ("ShowChoicePanel")) {
		//	ShowChoicePanel();
  //      }
        if (GUILayout.Button("StoryBoard->MoveNext!"))
        {
            StoryBoard.Instance.MoveNext();
        }
    }
	void ShowChoicePanel(){
        GameDataManager.Instance.ArchiveData.progress += 1;
		UIManager.Instance.ShowPanel<ChoicePanel> ();
		//TODO:mist the screen.
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
        AddChildToUITable(dialogClone.transform);
    }
    void AddChildToUITable(Transform child)
    {
        child.parent = uiTable.transform;
        child.localScale = Vector3.one;
        uiTable.Reposition();
    }
}
