using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{

    public GameObject Panel_Option;
    public GameObject Panel_OptionMenu;
    public GameObject Panel_SoundSetting;
    public GameObject Panel_Creator;

    public Text txt_SoundSettingBtn;
    public Text txt_CreatorBtn;
    public Text txt_GameQuitBtn;
    public Text txt_PanelOptionQuitBtn;
    public Text txt_PanelSoundQuitBtn;
    public Text txt_PanelCreatorQuitBtn;

    public LobbyManager LM;
    public SoundManager SM;
    
    public float bgm_value;
    public float effect_value;
    public Slider slider_bgm;
    public Slider slider_effect;


    // Start is called before the first frame update
    void Start()
    {
        Panel_Option.SetActive(false);
        Panel_OptionMenu.SetActive(false);
        Panel_SoundSetting.SetActive(false);
        Panel_Creator.SetActive(false);

        if(LM.Language == "KOR")
        {
            txt_SoundSettingBtn.text = "사 운 드";
            txt_CreatorBtn.text = "만 든 이";
            txt_GameQuitBtn.text = "게임종료";
            txt_PanelOptionQuitBtn.text = "확 인";
            txt_PanelSoundQuitBtn.text = "확 인";
            txt_PanelCreatorQuitBtn.text = "확 인";
        } else
        {
            txt_SoundSettingBtn.text = "Sound";
            txt_CreatorBtn.text = "Creator";
            txt_GameQuitBtn.text = "Game Quit";
            txt_PanelOptionQuitBtn.text = "Confirm";
            txt_PanelSoundQuitBtn.text = "Confirm";
            txt_PanelCreatorQuitBtn.text = "Confirm";
        }

        getVolumn();
        inistializeVolumn();

    }

    // Update is called once per frame
    void Update()
    {

    }   

    public void getVolumn()
    {
        bgm_value = PlayerPrefs.GetFloat("BGM");
        effect_value = PlayerPrefs.GetFloat("Effect");
    }
    public void inistializeVolumn()
    {
        slider_bgm.value = bgm_value;
        slider_effect.value = effect_value;
    }
    public void setVolumn()
    {
        bgm_value = slider_bgm.value;
        effect_value = slider_effect.value;
        PlayerPrefs.SetFloat("BGM", bgm_value); 
        PlayerPrefs.SetFloat("Effect", effect_value);
        getVolumn();
        inistializeVolumn();
    }

    //옵션 메뉴
    public void onClickOptionMenuBtn()
    {
        SM.PlaySE("button");
    
        print(LM.Language);

        if(LM.Language == "KOR")
        {
            txt_SoundSettingBtn.text = "사 운 드";
            txt_CreatorBtn.text = "만 든 이";
            txt_GameQuitBtn.text = "게임종료";
            txt_PanelOptionQuitBtn.text = "확 인";
            txt_PanelSoundQuitBtn.text = "확 인";
            txt_PanelCreatorQuitBtn.text = "확 인";
        } else
        {
            txt_SoundSettingBtn.text = "Sound";
            txt_CreatorBtn.text = "Creator";
            txt_GameQuitBtn.text = "Game Quit";
            txt_PanelOptionQuitBtn.text = "Confirm";
            txt_PanelSoundQuitBtn.text = "Confirm";
            txt_PanelCreatorQuitBtn.text = "Confirm";
        }

        Panel_Option.SetActive(true);
        Panel_OptionMenu.SetActive(true);
    }
    public void onClickOptionMenuQuitBtn()
    {
        SM.PlaySE("button");
        Panel_Option.SetActive(false);
        Panel_OptionMenu.SetActive(false);
    }
    //옵션메뉴 종료

    //볼륨조절 
    public void onClickSoundSettingBtn()
    {
        SM.PlaySE("button");
        Panel_OptionMenu.SetActive(false);
        Panel_SoundSetting.SetActive(true);
    }
    public void onClickSoundSettingQuitBtn()
    {
        SM.PlaySE("button");
        setVolumn();
        Panel_OptionMenu.SetActive(true);
        Panel_SoundSetting.SetActive(false);

        SM.background.volume = bgm_value;

        for(int i = 0; i < SM.sfxPlayer.Length; i++)
        {
            SM.sfxPlayer[i].volume = effect_value;
        }

    }
    //볼륨조절 종료
    //제작자
    public void onClickCreatorBtn()
    {
        SM.PlaySE("button");
        Panel_OptionMenu.SetActive(false);
        Panel_Creator.SetActive(true);
    }
    public void onClickCreatorQuitBtn()
    {
        SM.PlaySE("button");
        Panel_OptionMenu.SetActive(true);
        Panel_Creator.SetActive(false);
    }
    //제작자 종료
    //게임종료
    public void onClickGameQuitBtn()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}
