using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System;


using UnityEngine.SceneManagement;
using System;

public class LobbyManager : MonoBehaviour
{
    public string User_ID;
    public string User_NickNM;

    public static int myRank = 0; 
    public int tempRank = 0;
    
    public List<string> all_army_id = new List<string>();
    public List<string> all_army_name = new List<string>();
    public List<string> all_army_info = new List<string>();
    public List<string> all_army_grade = new List<string>();
    public List<uint> all_army_value = new List<uint>();

    public List<string> all_coupon_id = new List<string>();
    public List<string> all_coupon_name = new List<string>();
    public List<string> all_coupon_info = new List<string>();
    public List<uint> all_coupon_value = new List<uint>();
    public List<string> all_skin_id = new List<string>();
    public List<string> all_skin_name = new List<string>();
    public List<string> all_skin_info = new List<string>();
    public List<uint> all_skin_value = new List<uint>();

    public List<string> player_army_id = new List<string>();
    public List<string> player_army_name = new List<string>();
    public List<string> player_army_info = new List<string>();
    public List<string> player_army_grade = new List<string>();
    public List<uint> player_army_value = new List<uint>();
    public List<int> player_army_count = new List<int>();
    public List<string> player_army_instance_id = new List<string>();

    public List<string> player_coupon_id = new List<string>();
    public List<string> player_coupon_name = new List<string>();
    public List<string> player_coupon_info = new List<string>();
    public List<uint> player_coupon_value = new List<uint>();
    public List<int> player_coupon_count = new List<int>();
    public List<string> player_coupon_instance_id = new List<string>();
    public List<string> player_skin_id = new List<string>();
    public List<string> player_skin_name = new List<string>();
    public List<string> player_skin_info = new List<string>();
    public List<uint> player_skin_value = new List<uint>();
    public List<string> player_skin_instance_id = new List<string>();

    public string getarmyIDList;
    public string getarmyNameList;

    public List<string> setarmyIDList = new List<string>();
    public List<string> setarmyNameList = new List<string>();
    public List<string> string_tip = new List<string>();

    public static List<string> networksetarmyIDList = new List<string>();
    public static List<string> networksetarmyNameList = new List<string>();
    public static List<string> network_all_army_id = new List<string>();
    public static List<string> network_all_army_name = new List<string>();
    public static List<string> network_all_army_info = new List<string>();
    public static List<string> network_all_army_grade = new List<string>();
    public static List<uint> network_all_army_value = new List<uint>();


    public GameObject Panel_Loading;
    public GameObject Panel_GameInfoAlert;
    public GameObject Panel_GameStart;
    public GameObject Panel_GameStartMenu;
    public GameObject Panel_GameRankMenu;
    public GameObject Panel_MatchMake;
    public GameObject Panel_Review;

    public Slider Loading_Bar;
    public Text txt_Loading;
    public Text txt_Loadingtip;
    public Text txt_gameInfoalert;
    public Text txt_gameInfoalertbtn;
    public Text txt_gameStartCancelBtn;
    public Text txt_gameSingleCancelBtn;
    public Text txt_gameMultiCancelBtn;
    public Text txt_matchmember;


    public Text txt_reviewInfo;
    public Text txt_reviewYesBtn;
    public Text txt_reviewNoBtn;

    public bool allarmyChk = false;
    public bool allcouponChk = false;
    public bool setarmyChk = false;
    public bool moneyChk = false;
    public bool playerarmyChk = false;
    public bool playercouponChk = false;
    public bool playernicknameChk = false;

    public Button btn_ready;

    public int user_money;
    public int user_ruby;
    public Text txt_money;
    public Text txt_ruby;    

    public SoundManager SM;
    public NetworkManager NM;
    public StatusManager STM;
    public string Language;

    public bool langChk = false;
    public bool currenyChk = false;
    public bool reviewChk = false;
    public bool skinChk = false;
    public int gamePlayCnt = 0;

    public static string gameLvl = null;
    public static string skin_name;

    public bool bPaused;
    public bool networkChk;
    public bool allskinChk;
    public bool userskinChk;
    public float pauseTime;
    public float resumeTime;



    void Awake()
    {
        User_ID = LoginMenu.User_ID;
        getPlayerLanguage();
        getReviewInfo();
    }

    // Start is called before the first frame update
    void Start()
    {
        txt_Loading.text = "0%";
        Loading_Bar.value = 0.0f;
        Panel_Loading.SetActive(true);
        Panel_GameInfoAlert.SetActive(false);
        Panel_GameStart.SetActive(false);
        Panel_Review.SetActive(false);
        Panel_GameStartMenu.SetActive(false);
        Panel_GameRankMenu.SetActive(false);
        Panel_MatchMake.SetActive(false);
        getAllArmy();
        getAllCoupon();
        getUserMoney();
        getEquipedArmyList();
        getPlayerArmy();
        getPlayerCoupon();
        getUserRank();
        getSkinName();
        getUserSkinList();
        getAllSkinList();
        Invoke("Loading_70",1);
        SM.background.volume = PlayerPrefs.GetFloat("BGM");

        for(int i = 0; i < SM.sfxPlayer.Length; i++)
        {
            SM.sfxPlayer[i].volume = PlayerPrefs.GetFloat("Effect");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Home))
        {
            Application.Quit();
        }
        
        if(allarmyChk == true && allcouponChk == true && setarmyChk == true && moneyChk == true && playerarmyChk == true && playercouponChk == true && langChk == true && skinChk == true && userskinChk == true && allskinChk == true)
        {
            Time.timeScale = 1 ;   
            Invoke("End_Loading",2);
        }
        txt_money.text = user_money.ToString();
        txt_ruby.text = user_ruby.ToString();

        if(user_money < 0 && currenyChk == false)
        {
            currenyChk = true;
            setCurrecyZero(-user_money);
            Application.Quit();
        }

        alertReview();

        if(reviewChk == true)
        {
            Panel_Review.SetActive(false);
        }

        getPlayerNickNM();

    }

    public void getUserSkinList()
    {
        player_skin_id.Clear();
        player_skin_name.Clear();
        player_skin_info.Clear();
        player_skin_value.Clear();
        player_skin_instance_id.Clear();


        PlayFabClientAPI.GetUserInventory(new PlayFab.ClientModels.GetUserInventoryRequest(),
        (result) => 
        {
            
            foreach(var item in result.Inventory)
            {
                if (item.CatalogVersion == "SKIN")
                {
                    player_skin_id.Add(item.ItemId);
                    player_skin_name.Add(item.DisplayName);
                    player_skin_value.Add(item.UnitPrice);
                    player_skin_instance_id.Add(item.ItemInstanceId);
                }

            }

            userskinChk = true;
        }, 
        (error) => {
            playercouponChk = false;            
        });
    }

    public void getAllSkinList()
    {
        PlayFabClientAPI.GetCatalogItems(new GetCatalogItemsRequest(){CatalogVersion = "SKIN"}
        , (result) =>
        {
            for(int i = 0; i < result.Catalog.Count; i++)
            {
                var skin_db = result.Catalog[i];
                all_skin_id.Add(skin_db.ItemId);
                all_skin_name.Add(skin_db.DisplayName);
                all_skin_info.Add(skin_db.Description);
                all_skin_value.Add(skin_db.VirtualCurrencyPrices["EG"]);
            }

            allskinChk = true;
          
        },
        (error) => allskinChk = false );
    }


    public void getSkinName()
    {
        PlayFabClientAPI.GetUserData( new GetUserDataRequest() {PlayFabId = User_ID}
                        , (result) => {

                            try{
                                skin_name = result.Data["SKIN"].Value;
                                print(skin_name);
                                skinChk = true;
                            }
                            catch(KeyNotFoundException ex){
                                setSkinName();
                            }

                            STM.Panel_SkinLoading.SetActive(false);
                            
                        }
                        , (error) => 
                        {   
                            Debug.Log(error.Error);
                        });
    }

    public void setSkinName()
    {
        PlayFabClientAPI.UpdateUserData(new PlayFab.ClientModels.UpdateUserDataRequest() 
        {Data = new Dictionary<string, string>(){
                 {"SKIN", "default"}  
                }}
                            , (result) => {
                                    getSkinName();
                            }
                            , (error) => {

                            });
    }

    public void getPlayerNickNM()
    {

        if(playernicknameChk == false)
        {
            playernicknameChk = true;
            PlayFabClientAPI.GetPlayerProfile( new PlayFab.ClientModels.GetPlayerProfileRequest() {
                PlayFabId = User_ID,
                ProfileConstraints = new PlayFab.ClientModels.PlayerProfileViewConstraints() {ShowDisplayName = true}
            }, result => {
                User_NickNM = result.PlayerProfile.DisplayName;
                try{
                    if(result.PlayerProfile.DisplayName.Length < 1)
                    {
                        Application.Quit();
                    } 
                }
                catch(NullReferenceException ex){
                    Application.Quit();
                }


            },
            error => {
                Debug.LogError(error.GenerateErrorReport());
            });
        }


    }

    public void getReviewInfo()
    {
        if(!PlayerPrefs.HasKey("GameCnt"))
        {
            gamePlayCnt = 0;
        } else 
        {
            gamePlayCnt = PlayerPrefs.GetInt("GameCnt");
        }

        if(!PlayerPrefs.HasKey("ReviewChk"))
        {
            reviewChk = false;
        } else 
        {
            reviewChk = true;
        }

    }

    public void alertReview()
    {
        if(reviewChk == false && gamePlayCnt > 5)
        {
            Panel_Review.SetActive(true);

            if(Language == "KOR")
            {
                txt_reviewInfo.text = "리뷰를 적어주세요.\n리뷰는 게임 발전에 큰 도움을 줍니다.\n보상 : 용병교환권(B)";
                txt_reviewYesBtn.text = "좋아요";
                txt_reviewNoBtn.text = "싫어요";
            } else 
            {
                txt_reviewInfo.text = "Please write a review.\nReviews are a great\nhelp to the development\nof the game.\nReward : UnitCoupon(B)";
                txt_reviewYesBtn.text = "YES";
                txt_reviewNoBtn.text = "N O";
            }

        }
    }

    public void setCurrecyZero(int amount)
    {
        var request = new AddUserVirtualCurrencyRequest() { VirtualCurrency = "EG", Amount = amount };
                PlayFabClientAPI.AddUserVirtualCurrency(request, 
                                        (result) => {
                                            if(result.Balance != 0)
                                            {
                                                setCurrecyZero2(result.Balance);
                                            }
                                        }
                                    , (error) => {
                                        print(error.GenerateErrorReport());
                                    });
    }

    public void setCurrecyZero2(int amount)
    {
        var request = new SubtractUserVirtualCurrencyRequest() { VirtualCurrency = "EG", Amount = amount };
                PlayFabClientAPI.SubtractUserVirtualCurrency(request, 
                                        (result) => {
                                            if(result.Balance != 0)
                                            {
                                                setCurrecyZero(result.Balance);
                                            }
                                        }
                                    , (error) => {
                                        print(error.GenerateErrorReport());
                                    });
    }

    public void Loading_70()
    {
        txt_Loading.text = "70%";
        Loading_Bar.value = 0.7f;
    }

    public void End_Loading()
    {
        Loading_Bar.value = 1;
        txt_Loading.text = "100%";
        Invoke("Close_Loading", 1); 
    }

    public void Close_Loading()
    {
        Panel_Loading.SetActive(false);
    }

  public void sortAllArmy()
  {
      for(int i = 0; i < all_army_id.Count; i++)
      {
          for(int j = i+1; j<all_army_id.Count; j++)
          {
              if( all_army_value[i] < all_army_value[j])
              {
                  string temp_id;
                  string temp_name;
                  string temp_info;
                  string temp_grade;
                  uint temp_value;

                  temp_id = all_army_id[i];
                  all_army_id[i] = all_army_id[j];
                  all_army_id[j] = temp_id;

                  temp_name = all_army_name[i];
                  all_army_name[i] = all_army_name[j];
                  all_army_name[j] = temp_name;

                  temp_info = all_army_info[i];
                  all_army_info[i] = all_army_info[j];
                  all_army_info[j] = temp_info;

                  temp_grade = all_army_grade[i];
                  all_army_grade[i] = all_army_grade[j];
                  all_army_grade[j] = temp_grade;

                  temp_value = all_army_value[i];
                  all_army_value[i] = all_army_value[j];
                  all_army_value[j] = temp_value;

              }
          }
      }
  }

  public void sortAllCoupon()
  {
      for(int i = 0; i < all_coupon_id.Count; i++)
      {
          for(int j = i+1; j<all_coupon_id.Count; j++)
          {
              if(all_coupon_value[i]<all_coupon_value[j])
              {
                  string temp_id;
                  string temp_name;
                  string temp_info;
                  uint temp_value;

                  temp_id = all_coupon_id[i];
                  all_coupon_id[i] = all_coupon_id[j];
                  all_coupon_id[j] = temp_id;

                  temp_name = all_coupon_name[i];
                  all_coupon_name[i] = all_coupon_name[j];
                  all_coupon_name[j] = temp_name;

                  temp_info = all_coupon_info[i];
                  all_coupon_info[i] = all_coupon_info[j];
                  all_coupon_info[j] = temp_info;

                  temp_value = all_coupon_value[i];
                  all_coupon_value[i] = all_coupon_value[j];
                  all_coupon_value[j] = temp_value;

              }
          }
      }
  }

    public void getAllArmy()
    {
        PlayFabClientAPI.GetCatalogItems(new GetCatalogItemsRequest(){CatalogVersion = "ARMY1"}
        , (result) =>
        {
            for(int i = 0; i < result.Catalog.Count; i++)
            {
                var army_db = result.Catalog[i];
                all_army_id.Add(army_db.ItemId);
                all_army_name.Add(army_db.DisplayName);
                all_army_info.Add(army_db.Description);
                all_army_grade.Add(army_db.ItemClass);
                all_army_value.Add(army_db.VirtualCurrencyPrices["GD"]);
            }

            sortAllArmy();

            allarmyChk = true;
          
        },
        (error) => allarmyChk = false );
    }

    public void getAllCoupon()
    {
       PlayFabClientAPI.GetCatalogItems(new GetCatalogItemsRequest(){CatalogVersion = "COUPON"}
       , (result) =>
       {
           
           for(int i = 0; i < result.Catalog.Count; i++)
           {
               if(result.Catalog[i].ItemId != "3")
               {
                    var coupon_db = result.Catalog[i];
                    all_coupon_id.Add(coupon_db.ItemId);
                    all_coupon_name.Add(coupon_db.DisplayName);
                    all_coupon_info.Add(coupon_db.Description);
                    all_coupon_value.Add(coupon_db.VirtualCurrencyPrices["EG"]);
               }


           }

           sortAllCoupon();

           allcouponChk = true;
         
       },
       (error) => allcouponChk = false );
    }

    public void getEquipedArmyList()
    {
        PlayFabClientAPI.GetUserData( new GetUserDataRequest() {PlayFabId = User_ID}
                        , (result) => {
                            getarmyIDList = result.Data["ARMYID"].Value;
                            getarmyNameList = result.Data["ARMYNAME"].Value;

                            getEquipedArmy();

                        }
                        , (error) => setarmyChk = false);
    }

    public void getEquipedArmy()
    {
        try
        {
            setarmyIDList.Clear();
            setarmyNameList.Clear();

            networksetarmyIDList.Clear();
            networksetarmyNameList.Clear();

            string[] arrItemID = getarmyIDList.Split(':');
            string[] arrItemName = getarmyNameList.Split(':');

            for(int i = 0; i < arrItemID.Length; i++)
            {
                setarmyIDList.Add(arrItemID[i]);
                setarmyNameList.Add(arrItemName[i]);
                networksetarmyIDList.Add(arrItemID[i]);
                networksetarmyNameList.Add(arrItemName[i]);
            }
            setarmyChk = true;

        } catch(NullReferenceException ex){ 

            setarmyChk = true;
        }

    }
    public void getUserMoney()
    {
        PlayFabClientAPI.GetUserInventory(new PlayFab.ClientModels.GetUserInventoryRequest(),
        (result) => 
        {
            user_money = result.VirtualCurrency["EG"];
            user_ruby = result.VirtualCurrency["RB"];
            moneyChk = true;
        }, 
        (error) => {
        });

    }

    public void getPlayerArmy()
    {
        player_army_id.Clear();
        player_army_name.Clear();
        player_army_info.Clear();
        player_army_value.Clear();
        player_army_count.Clear();
        player_army_grade.Clear();
        player_army_instance_id.Clear();


        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(),
        (result) => 
        {

            foreach(var item in result.Inventory)
            {
                if(item.CatalogVersion == "ARMY1")
                {
                    player_army_id.Add(item.ItemId);
                    player_army_name.Add(item.DisplayName);
                    player_army_grade.Add(item.ItemClass);
                    player_army_value.Add(item.UnitPrice);
                    player_army_count.Add(item.RemainingUses.Value);
                    player_army_instance_id.Add(item.ItemInstanceId);
                }

            }

            playerarmyChk = true;
        }, 
        (error) => {
            playerarmyChk = false;
            print(error.ErrorDetails);
        });
    }

    public void getPlayerCoupon()
    {
        player_coupon_id.Clear();
        player_coupon_name.Clear();
        player_coupon_info.Clear();
        player_coupon_value.Clear();
        player_coupon_count.Clear();
        player_coupon_instance_id.Clear();


        PlayFabClientAPI.GetUserInventory(new PlayFab.ClientModels.GetUserInventoryRequest(),
        (result) => 
        {
            
            foreach(var item in result.Inventory)
            {
                if (item.CatalogVersion == "COUPON" || item.CatalogVersion == "MONEY")
                {
                    player_coupon_id.Add(item.ItemId);
                    player_coupon_name.Add(item.DisplayName);
                    player_coupon_value.Add(item.UnitPrice);
                    player_coupon_count.Add(item.RemainingUses.Value);
                    player_coupon_instance_id.Add(item.ItemInstanceId);
                }

            }

            playercouponChk = true;

        }, 
        (error) => {
            playercouponChk = false;            
        });
    }

    public void getPlayerLanguage()
    {
        PlayFabClientAPI.GetUserData( new GetUserDataRequest() {PlayFabId = User_ID}
                        , (result) => {
                            Language = result.Data["Language"].Value;

                            
                            if(Language == "KOR")
                            {
                                txt_gameInfoalert.text = "유닛 셋팅이 필요합니다.";
                                txt_gameInfoalertbtn.text = "확 인";
                                string_tip.Add("골드가 부족할땐 몬스터를 터치하세요.");
                                string_tip.Add("닭은 보통 새벽 4~5시에 웁니다.");
                                string_tip.Add("계란 반숙 시간은 8~9분 입니다.");
                                string_tip.Add("계란 완숙 시간은 13~15분 입니다.");
                            } else if(Language == "Eng")
                            {
                                txt_gameInfoalert.text = "Check Unit Setting!";
                                txt_gameInfoalertbtn.text = "Confirm";
                                string_tip.Add("Chickens cry at 4 or 5\nin the morning.");
                                string_tip.Add("Need Gold, Touch animal.");
                                string_tip.Add("Egg half-boiled time is\n8-9 minutes.");
                                string_tip.Add("Egg hard-boiled time is\n13-15 minutes.");
                            } else 
                            {
                                txt_gameInfoalert.text = "Check Unit Setting!";
                                txt_gameInfoalertbtn.text = "Confirm";
                                string_tip.Add("鶏は通常夜明け4〜5時に泣きます。");
                                string_tip.Add("金が足りない場合は、\n動物に触れてください。");
                                string_tip.Add("卵半熟時間は8-9分です。");
                                string_tip.Add("卵完熟時間は13-15分です。");
                            }
                            int rand_no = UnityEngine.Random.Range(0,string_tip.Count - 1);
                            print(rand_no);
                            txt_Loadingtip.text = string_tip[rand_no];
                            print(string_tip[rand_no]);
                            langChk = true;
                        }
                        , (error) => langChk = false);
    }

    public void onClickGameStart()
    {
        SM.PlaySE("button");

        if(Language == "KOR")
        {
            txt_gameInfoalert.text = "유닛 셋팅이 필요합니다.";
            txt_gameInfoalertbtn.text = "확 인";
            txt_gameStartCancelBtn.text = "취  소";
            txt_gameSingleCancelBtn.text ="취  소";
            txt_gameMultiCancelBtn.text = "취  소";
        } else if(Language == "Eng")
        {
            txt_gameInfoalert.text = "Check Unit Setting!";
            txt_gameInfoalertbtn.text = "Confirm";
            txt_gameStartCancelBtn.text = "Cancel";
            txt_gameSingleCancelBtn.text ="Cancel";
            txt_gameMultiCancelBtn.text = "Cancel";
        } else 
        {
            txt_gameInfoalert.text = "Check Unit Setting!";
            txt_gameInfoalertbtn.text = "Confirm";
            txt_gameStartCancelBtn.text = "Cancel";
            txt_gameSingleCancelBtn.text ="Cancel";
            txt_gameMultiCancelBtn.text = "Cancel";
        }

        if(setarmyIDList.Count < 1)
        {
            Panel_GameInfoAlert.SetActive(true);
            return;
        }

        Panel_GameStart.SetActive(true);
        Panel_GameStartMenu.SetActive(true);

        network_all_army_id.Clear();
        network_all_army_name.Clear();
        network_all_army_grade.Clear();
        network_all_army_value.Clear();
        networksetarmyIDList.Clear();
        networksetarmyNameList.Clear();


        for(int i = 0; i < all_army_id.Count; i++)
        {
            network_all_army_id.Add(all_army_id[i]);
            network_all_army_name.Add(all_army_name[i]);
            network_all_army_grade.Add(all_army_grade[i]);
            network_all_army_value.Add(all_army_value[i]);

        }

        for(int i = 0; i < setarmyIDList.Count; i++)
        {
            networksetarmyIDList.Add(setarmyIDList[i]);
            networksetarmyNameList.Add(setarmyNameList[i]);
        }

    }

    public void onClickGameStartCancelBtn()
    {
        SM.PlaySE("button");
        Panel_GameStart.SetActive(false);
        Panel_GameStartMenu.SetActive(false);
        return;
    }

    public void onClickSingleBtn()
    {
        SM.PlaySE("button");
        Panel_GameStartMenu.SetActive(false);
        Panel_GameRankMenu.SetActive(true);
        return;
    }

    public void onClickSingleCancelBtn()
    {
        SM.PlaySE("button");
        Panel_GameStartMenu.SetActive(true);
        Panel_GameRankMenu.SetActive(false);
        return;
    }

    public void onClickMultiBtn()
    {
        SM.PlaySE("button");
        txt_matchmember.text = "1 / 5";
        Panel_GameStartMenu.SetActive(false);
        Panel_MatchMake.SetActive(true);
        NM.InitializePhoton();
        btn_ready.interactable = false;

        return;
    }
    public void onClickReadyBtn()
    {
        SM.PlaySE("button"); 
        NM.onClickGameStartBtn();
        return;
    }
    public void onClickReadyCancleBtn()
    {
        SM.PlaySE("button");
        NM.Disconnect();
        Panel_GameStartMenu.SetActive(true);
        Panel_MatchMake.SetActive(false);
        return;
    }

    public void onClickEasyLvlBtn()
    {
        SM.PlaySE("button");
        gameLvl = "easy";
        SceneManager.LoadScene("PlayScene");
    }

    public void onClickNormalLvlBtn()
    {
        SM.PlaySE("button");
        gameLvl = "normal";
        SceneManager.LoadScene("PlayScene");
    }

    public void onClickHardLvlBtn()
    {
        SM.PlaySE("button");
        gameLvl = "hard";
        SceneManager.LoadScene("PlayScene");
    }

    public void onClickGameInfoAlertBtn()
    {
        SM.PlaySE("button");
        Panel_GameInfoAlert.SetActive(false);
        return;
    }
    public void onClickReviewConfirmBtn()
    {
        SM.PlaySE("button");
        PlayerPrefs.SetInt("ReviewChk",1);
        List<string> CouponID = new List<string>();
        CouponID.Add("5");
        Application.OpenURL("market://details?id=com.oestewdio.superchicken");
        PlayFabServerAPI.GrantItemsToUser(new PlayFab.ServerModels.GrantItemsToUserRequest {
                    CatalogVersion = "COUPON",PlayFabId = User_ID, ItemIds = CouponID}
                                        , (result) => {
                                        }
                                        , (error) => 
                                        {
                                        });
        reviewChk = true;
        Panel_Review.SetActive(false);
    }
    public void onClickReviewCancelBtn()
    {
        SM.PlaySE("button");
        PlayerPrefs.SetInt("ReviewChk",1);
        reviewChk = true;
        Panel_Review.SetActive(false);
    }

    public void getUserRank()
    {
        var request = new GetLeaderboardAroundPlayerRequest(){PlayFabId = User_ID, StatisticName = "pvp_Rank", MaxResultsCount = 10
                                                            , ProfileConstraints = new PlayerProfileViewConstraints(){ShowLocations = true, ShowDisplayName = true}};

        PlayFabClientAPI.GetLeaderboardAroundPlayer(request,
            (result) =>
            {
                for(int i = 0; i< result.Leaderboard.Count; i++)
                {
                    if(result.Leaderboard[i].PlayFabId == User_ID)
                    {
                        myRank = result.Leaderboard[i].StatValue;
                    }
                }
                print(myRank);
                tempRank = myRank;
            } ,
            (error) => {
                print(error.ErrorMessage);
            }
        );   

    }

    void OnApplicationPause(bool bPaused) {
        
        if(bPaused)
        {
            if(networkChk == true)
            {
                networkChk = false;
                NM.Disconnect();
                Panel_GameStartMenu.SetActive(true);
                Panel_MatchMake.SetActive(false);
            }
            pauseTime = Time.realtimeSinceStartup;
        } else
        {
            resumeTime = Time.realtimeSinceStartup;
            if(resumeTime - pauseTime > 300)
            {
                Application.Quit();
            }
        }

    }

}

