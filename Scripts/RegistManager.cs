using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class RegistManager : MonoBehaviour
{
    public SoundManager SM;

    public InputField input_NickNM;

    public GameObject Panel_Loading;
    public Slider Loading_Bar;
    public Text txt_Loading;
    public Text txt_info;

    public string User_ID;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        User_ID = LoginMenu.User_ID;

        SM.background.volume = PlayerPrefs.GetFloat("BGM");

        for(int i = 0; i < SM.sfxPlayer.Length; i++)
        {
            SM.sfxPlayer[i].volume = PlayerPrefs.GetFloat("Effect");
        }

        Panel_Loading.SetActive(true);
        
        txt_Loading.text = "0%";
        Loading_Bar.value = 0f;

        Invoke("Loading70",1f);
        Invoke("Loading100",2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Loading70()
    {
        txt_Loading.text = "70%";
        Loading_Bar.value = 0.7f;
    }
    public void Loading100()
    {
        txt_Loading.text = "100%";
        Loading_Bar.value = 1f;
        Invoke("LoadingClose",1f);
    }

    public void LoadingClose()
    {
        Panel_Loading.SetActive(false);
    }

    public void selectLanguage(string lang)
    {
        PlayFabClientAPI.UpdateUserData(new PlayFab.ClientModels.UpdateUserDataRequest() 
        {Data = new Dictionary<string, string>(){
                {"Language", lang}
                }}
                            , (result) => 
                            {
                                SceneManager.LoadScene("LobbyScene");
                            }
                            , (error) => print("failed"));
    }

    public void onClickNickNM_ConfirmBtn()
    {
        SM.PlaySE("button");

        if(input_NickNM.text.Length < 2 || input_NickNM.text.Length > 8)
        {
            txt_info.text = "Check your nickname !";
            return;
        }

        var request = new UpdateUserTitleDisplayNameRequest { DisplayName = input_NickNM.text + "#" };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, 
        (result) => {
                        selectLanguage("KOR");
        }, (error) => {
            print("failed nickname update");
        });
    }

    public void onClickNickNM_ConfirmBtn2()
    {
        SM.PlaySE("button");

        if(input_NickNM.text.Length < 2 || input_NickNM.text.Length > 8)
        {
            txt_info.text = "Check your nickname !";
            return;
        }

        var request = new UpdateUserTitleDisplayNameRequest { DisplayName = input_NickNM.text + "#" };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, 
        (result) => {
                        selectLanguage("Eng");
        }, (error) => {
            print("failed nickname update");
        });
    }
    public void onClickNickNM_ConfirmBtn3()
    {
        SM.PlaySE("button");

        if(input_NickNM.text.Length < 2 || input_NickNM.text.Length > 8)
        {
            txt_info.text = "Check your nickname !";
            return;
        }

        var request = new UpdateUserTitleDisplayNameRequest { DisplayName = input_NickNM.text + "#" };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, 
        (result) => {
                        selectLanguage("Jap");
        }, (error) => {
            print("failed nickname update");
        });
    }
}
