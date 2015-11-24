using UnityEngine;
using System.Collections;
using Config;
public class StoryBoard {
    public static StoryBoard Instance{get;set;}
    public StoryBoard() {

    }
	public void MoveNext()//float delay
    {
        DialogConfig dialogConfig = GameConfigManager.Instance.GetConfigByID<DialogConfig>(GameDataManager.Instance.ArchiveData.progress) as DialogConfig;
        GamePanel gamePanel = UIManager.Instance.GetPanel<GamePanel>() as GamePanel;
        ChoicePanel choicePanel = UIManager.Instance.GetPanel<ChoicePanel>() as ChoicePanel;
        switch (dialogConfig.type) {
            case 0://dialog
                if (gamePanel)
				{
					gamePanel.AddDialog();
				}
                else {
                    gamePanel = UIManager.Instance.ShowPanel<GamePanel>() as GamePanel;
				}
				GameDataManager.Instance.ArchiveData.progress += 1;
                break;
            case 1://choice
				if(dialogConfig.choiceGoTo.Length<2){
					MakeChoice(0);//go to chapter by the default index 0.
				}
                if (choicePanel) {
                }
                else
                {
					choicePanel = UIManager.Instance.ShowPanel<ChoicePanel>() as ChoicePanel;
                }
                break;
            default:
                Debug.LogError("Fuck you!");
                break;
        }
	}
	/// <summary>
	/// Makes the choice and go to the chapter.
	/// </summary>
	/// <param name="choiceIndex">Choice index.</param>
	public void MakeChoice(int choiceIndex){
		DialogConfig dialogConfig = GameConfigManager.Instance.GetConfigByID<DialogConfig>(GameDataManager.Instance.ArchiveData.progress) as DialogConfig;
		Debug.Log (string.Format("StoryBoard MakeChoice. chapterName:{0},choiceIndex:{1}",dialogConfig.id,choiceIndex));
		string[] choiceGoTos = dialogConfig.choiceGoTo;
		string chapterName = choiceGoTos [choiceIndex];
		int id = GameConfigManager.Instance.GetChapterIDByName (chapterName);
		UIManager.Instance.HidePanel (typeof(ChoicePanel));
		//GamePanel gamePanel = UIManager.Instance.GetPanel<GamePanel>() as GamePanel;
		//gamePanel.AddDialog ();
		GameDataManager.Instance.ArchiveData.progress = id;
		Debug.Log (string.Format("StoryBoard MakeChoice. chapterName:{0},chapterId:{1}",chapterName,id));
		//MoveNext ();
	}
}
