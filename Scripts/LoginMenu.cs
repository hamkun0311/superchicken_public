using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.ServerModels;
using System;



public class LoginMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static string User_ID = null;
    public string getItemIDList = null;
    public string getItemNameList = null;

    public static string adtype = null;

    public string version;

    public SoundManager SM;

    public GameObject Panel_LoginConfirm;
    public GameObject Panel_Loading;
    public Text txt_LoginConfrim;
    public Text txt_Loading;
    public int error_flag = 0;

    void Start()
    {

        Time.timeScale = 1;

        Panel_LoginConfirm.SetActive(false);
        Panel_Loading.SetActive(false);

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .AddOauthScope("profile")
            .RequestServerAuthCode(false)
            .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        if(!PlayerPrefs.HasKey("BGM"))
        {
            PlayerPrefs.SetFloat("BGM",1);
        }

        if(!PlayerPrefs.HasKey("Effect"))
        {
            PlayerPrefs.SetFloat("Effect",1);
        }

        SM.background.volume = PlayerPrefs.GetFloat("BGM");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickLogin()
    {

        Panel_Loading.SetActive(true);
        txt_Loading.text = "Login..";

        Social.localUser.Authenticate((bool success) => {

            if (success)
            {
                var serverAuthCode = PlayGamesPlatform.Instance.GetServerAuthCode();
                Debug.Log("Server Auth Code: " + serverAuthCode);

                PlayFabClientAPI.LoginWithGoogleAccount(new LoginWithGoogleAccountRequest()
                {
                    TitleId = PlayFabSettings.TitleId,
                    ServerAuthCode = serverAuthCode,
                    CreateAccount = true
                }, (result) =>
                {
                    User_ID = result.PlayFabId;

                    GetVersion();
                    
                }, (error) => 
                {
                    Debug.Log(error);
                    error_flag = 1;
                    txt_LoginConfrim.text = "Your account have Login Issue. Please contact developer T_T..";
                    Panel_LoginConfirm.SetActive(true);
                    return;
                }
                );
            }
            else
            {
                Panel_Loading.SetActive(false);
                Debug.Log("Login Failed!");
            }

        });

    }

    public void GetVersion()
    {

        txt_Loading.text = "Check Version..";

        PlayFabClientAPI.GetCatalogItems(new PlayFab.ClientModels.GetCatalogItemsRequest() { CatalogVersion = "Version" }
        , (result) =>
        {
            string[] version = new string[2];
            for (int i = 0; i < result.Catalog.Count; i++)
            {
                var version_db = result.Catalog[i];
                version[i] = version_db.DisplayName;
            }

            if (version[0] != "1.41") // 0, 1을 번갈아 가면서 다음 버전 입력해주면 됨.
            {
                Panel_Loading.SetActive(false);
                error_flag = 2;
                txt_LoginConfrim.text = "New update\nhas been released\nPlease download\nnew version.";
                Panel_LoginConfirm.SetActive(true);
                return;
            }
            

            GetAdsType();
            

        },
        (error) => { Debug.Log("Version Error!"); });
    }

    public void GetAdsType()
    {
        PlayFabClientAPI.GetCatalogItems(new PlayFab.ClientModels.GetCatalogItemsRequest() { CatalogVersion = "ADS" }
        , (result) =>
        {
            
            for (int i = 0; i < result.Catalog.Count; i++)
            {
                var ads_db = result.Catalog[i];
                adtype = ads_db.DisplayName;
            }

            getPlayerNickNM();
        },
        (error) => { Debug.Log("ads error!"); });

    }

    public void getPlayerNickNM()
    {
        PlayFabClientAPI.GetPlayerProfile( new PlayFab.ClientModels.GetPlayerProfileRequest() {
            PlayFabId = User_ID,
            ProfileConstraints = new PlayFab.ClientModels.PlayerProfileViewConstraints() {ShowDisplayName = true}
        }, result => {

            try{
                if(result.PlayerProfile.DisplayName.Length < 1)
                {
                    grantBasicItems();
                } else
                {
                    SceneManager.LoadScene("LobbyScene");
                }
            }
            catch(NullReferenceException ex){
                grantBasicItems();
            }


        },
        error => {
            Debug.LogError(error.GenerateErrorReport());
        });
    }

    public void grantBasicItems()
    {
        List<string> grantItemId = new List<string>();
        List<string> grantItemName = new List<string>();

        grantItemId.Add("fswordI");
        grantItemName.Add("파이어소드맨_FireSwordMan");
        grantItemId.Add("fbowI");
        grantItemName.Add("파이어보우맨_FireBowMan");

        PlayFabServerAPI.GrantItemsToUser(new GrantItemsToUserRequest {
                CatalogVersion = "ARMY1",PlayFabId = User_ID, ItemIds = grantItemId}
                                    , (result) => {
                                        grantItemData(grantItemId, grantItemName);

                                    }
                                    , (error) => print("fail"));

    }

    public void grantItemData(List<string> grantItemId, List<string> grantItemName)
    {
        PlayFabClientAPI.UpdateUserData(new PlayFab.ClientModels.UpdateUserDataRequest() 
        {Data = new Dictionary<string, string>(){
                {"POWER", "10"}
                ,{"HEALTH", "20"}
                ,{"ARMYID", "fswordI:fbowI"}
                ,{"ARMYNAME", "파이어소드맨_FireSwordMan:파이어보우맨_FireBowMan"}
                ,{"Language", "Eng"}
                
                }}
                            , (result) => 
                            {
                                InitializeNickName();
                            }
                            , (error) => print("failed"));

    }

    public void InitializeNickName()
    {
        var request = new UpdateUserTitleDisplayNameRequest { DisplayName = "player#" };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, 
        (result) => {
            SceneManager.LoadScene("TutorialScene");
        }, (error) => {
            print("failed nickname update");
        });
    }

    public void OnClickTestLogin()
    {
        var request = new LoginWithEmailAddressRequest { Email = "ohs99999999@naver.com", Password = "dhgPtjd12#"};
        //var request = new LoginWithEmailAddressRequest { Email = "ohs77777@naver.com", Password = "dhgPtjd12#"};
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, (error) => 
        {
                error_flag = 1;
                txt_LoginConfrim.text = "Your account has been blocked for abusing.";
                Panel_LoginConfirm.SetActive(true);
                return;
        });
    }

    public void OnClickTestCreateAccount()
    {
        var request = new RegisterPlayFabUserRequest { Email = "ohs77777@naver.com", Password = "dhgPtjd12#", Username = "ascaweq"};
        PlayFabClientAPI.RegisterPlayFabUser(request, 
        (result) => {
                User_ID = result.PlayFabId;
                grantBasicItems();}, 
        (error) => {print("계정생성실패" + error.Error);
            });
    }

    public void OnLoginSuccess(LoginResult result)
    {
        
        User_ID = result.PlayFabId;
        SceneManager.LoadScene("TutorialScene");

    }


    public void OnClickQuit()
    {

        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

    }

    public void onClickPanelLoginConfirmBtn()
    {
        if(error_flag == 1)
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        if(error_flag == 2)
        {
            Application.OpenURL("market://details?id=com.oestewdio.superchicken");
        }

    }
    


}
