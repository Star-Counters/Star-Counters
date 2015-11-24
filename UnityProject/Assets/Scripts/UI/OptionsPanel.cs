using UnityEngine;
using System.Collections;

public class OptionsPanel : BasePanel {
	OptionData data;
	public override void OnShow ()
	{
		data = GameDataManager.Instance.Get<OptionData> ();
		SetMusicSprite ();
		//GameData data=GameDataManager.Instance.gameData;
		Debug.Log ("isMusicOn:" + data.isMusicOn + ",language:" + data.language);
		EventDelegate.Add (transform.FindChild ("Options").GetComponent<UIEventTrigger> ().onClick, Hide);
		EventDelegate.Add (transform.FindChild ("Back").GetComponent<UIEventTrigger> ().onClick, Hide);
		EventDelegate.Add (transform.FindChild ("Music").GetComponent<UIEventTrigger> ().onClick, OnClickMusic);
	}
	public override void OnHide ()
	{
		GameDataManager.Instance.Save<OptionData> (data);
	}
	void OnClickMusic(){
		data.isMusicOn = !data.isMusicOn;
		SetMusicSprite ();
	}
	void SetMusicSprite(){
		transform.FindChild ("Music").GetComponent<UISprite> ().spriteName = data.isMusicOn ? "Buttons_Sound" : "Buttons_Mute";
	}
	public void OnChooseLanguage(string curLanguage){

        //FixMe : Its a hard code,maybe need to refactoring
        switch (curLanguage) {
            case "English":
                data.language = SystemLanguage.English;
                break;
            case "简体中文":
                data.language = SystemLanguage.ChineseSimplified;
                break;
            default:
                break;
        }
        bool isCN = data.language == SystemLanguage.ChineseSimplified;
        GameConfigManager.Instance.ChangeWordByLanguage(isCN);
        UIManager.Instance.RefreshAllPanels();
    }
}
