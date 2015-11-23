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
                }
                else {
                    gamePanel = UIManager.Instance.GetPanel<GamePanel>() as GamePanel;
                }
                gamePanel.AddDialog();
                break;
            case 1://choice
                if (choicePanel) {
                    choicePanel.InstatiateChoiceButton(dialogConfig.choiceGoTo.Length); 
                }
                else
                {
                    choicePanel = UIManager.Instance.GetPanel<ChoicePanel>() as ChoicePanel;
                }
                break;
            default:
                Debug.LogError("Fuck you!");
                break;
        }
        GameDataManager.Instance.ArchiveData.progress += 1;
	}
}
