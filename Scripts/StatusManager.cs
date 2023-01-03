using System.IO;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public GameObject Panel_Status;
    public GameObject Panel_StatusInfo;
    public GameObject Panel_StatusCnt;
    public GameObject Panel_Loading;
    public GameObject Panel_Result;
    public GameObject Panel_Skin;
    public GameObject Panel_SetSkin;
    public GameObject Panel_SkinLoading;

    //StatusCount
    public Text txt_StatusCntTitle;
    public Text txt_StatusCnt;
    public Text txt_StatusBuyBtn;
    public Text txt_StatusExitBtn;

    //Skin 
    public Text txt_SkinTitle;
    public Text txt_SkinName;
    public Text txt_SkinInfo;
    public Text txt_SkinUse;
    public Text txt_SkinExit;
    public Button btn_SetSkin;
    public string[] player_skin_id = new string[100];
    public string[] player_skin_name = new string[100];
    public string[] player_skin_info = new string[100];
    public uint[] player_skin_value = new uint[100];
    public string select_player_skin_id;
    public string select_player_skin_name;
    public uint select_player_skin_value;
    public string select_player_skin_info;
    public Transform slotHolder_skin;
    public Slot[] skin_slot = new Slot[100];
    public Image img_select_skin;

    public Text txt_status;
    public Text txt_NickNM;
    public Text txt_Result;
    public Text txt_Loading;
    public Text txt_BtnChange;
    public Text txt_BtnPowerUP;
    public Text txt_BtnConfirm;
    public Text txt_ResultBtnConfirm;
    public InputField input_NickName;

    public LobbyManager LM;

    public int getHP;
    public int getPower;
    public int setData;
    public string NickNM;
    public string User_ID;



    public bool nickChangeChk = false;

    
    // Start is called before the first frame update
    void Start()
    {
        Panel_Status.SetActive(false);
        Panel_StatusInfo.SetActive(false);
        Panel_Result.SetActive(false);
        Panel_StatusCnt.SetActive(false);
        Panel_Loading.SetActive(false);
        Panel_Skin.SetActive(false);
        Panel_SetSkin.SetActive(false);
        Panel_SkinLoading.SetActive(false);

        User_ID = LoginMenu.User_ID;

        skin_slot = slotHolder_skin.GetComponentsInChildren<Slot>();

        if(LM.Language == "KOR")
        {
            txt_BtnChange.text = "바 꾸 기";
            txt_BtnPowerUP.text = "강화(100EGG)";
            txt_BtnConfirm.text = "확    인";
            txt_StatusCntTitle.text = "강화 수량";
            txt_StatusBuyBtn.text = "강 화";
            txt_StatusExitBtn.text = "닫 기";
            txt_ResultBtnConfirm.text = "확    인";
            txt_SkinTitle.text = "스    킨";
            txt_SkinUse.text = "사   용";
            txt_SkinExit.text = "닫   기";
        }
        else if(LM.Language == "Eng")
        {
            txt_BtnChange.text = "Change";
            txt_BtnPowerUP.text = "Power UP(100EGG)";
            txt_BtnConfirm.text = "Confirm";
            txt_StatusCntTitle.text = "Count";
            txt_StatusBuyBtn.text = "U P";
            txt_StatusExitBtn.text = "EXIT";
            txt_ResultBtnConfirm.text = "Confirm";
            txt_SkinTitle.text = "Skin";
            txt_SkinUse.text = "USE";
            txt_SkinExit.text = "EXIT";
        } else
        {
            txt_BtnChange.text = "か え る";
            txt_BtnPowerUP.text = "きょうか(100EGG)";
            txt_BtnConfirm.text = "か く に ん";
            txt_StatusCntTitle.text = "数 量";
            txt_StatusBuyBtn.text = "は い";
            txt_StatusExitBtn.text = "出 る";
            txt_ResultBtnConfirm.text = "か く に ん";
            txt_SkinTitle.text = "コスチューム";
            txt_SkinUse.text = "は い";
            txt_SkinExit.text = "出 る";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickStatusBtn()
    {

        print(LM.Language);

        if(LM.Language == "KOR")
        {
            txt_BtnChange.text = "바 꾸 기";
            txt_BtnPowerUP.text = "강화(100EGG)";
            txt_BtnConfirm.text = "확    인";
            txt_StatusCntTitle.text = "강화 수량";
            txt_StatusBuyBtn.text = "강 화";
            txt_StatusExitBtn.text = "닫 기";
            txt_ResultBtnConfirm.text = "확    인";
            txt_SkinTitle.text = "스    킨";
            txt_SkinUse.text = "사   용";
            txt_SkinExit.text = "닫   기";
        }
        else if(LM.Language == "Eng")
        {
            txt_BtnChange.text = "Change";
            txt_BtnPowerUP.text = "Power UP(100EGG)";
            txt_BtnConfirm.text = "Confirm";
            txt_StatusCntTitle.text = "Count";
            txt_StatusBuyBtn.text = "U P";
            txt_StatusExitBtn.text = "EXIT";
            txt_ResultBtnConfirm.text = "Confirm";
            txt_SkinTitle.text = "Skin";
            txt_SkinUse.text = "USE";
            txt_SkinExit.text = "EXIT";
        } else
        {
            txt_BtnChange.text = "か え る";
            txt_BtnPowerUP.text = "きょうか(100EGG)";
            txt_BtnConfirm.text = "か く に ん";
            txt_StatusCntTitle.text = "数 量";
            txt_StatusBuyBtn.text = "は い";
            txt_StatusExitBtn.text = "出 る";
            txt_ResultBtnConfirm.text = "か く に ん";
            txt_SkinTitle.text = "コスチューム";
            txt_SkinUse.text = "は い";
            txt_SkinExit.text = "出 る";
        }

        SoundManager.instance.PlaySE("button");
        getPlayerStats(); 
        Panel_Status.SetActive(true);
        Panel_StatusInfo.SetActive(true);
        
    }

    public void getPlayerStats()
    {
        Panel_Loading.SetActive(true);
        if(LM.Language == "KOR")
        {
            txt_Loading.text = "불러오는 중..";
        }
        else 
        {
            txt_Loading.text = "Loading..";
        }
        

        PlayFabClientAPI.GetUserData( new GetUserDataRequest() {PlayFabId = User_ID}
                        , (result) => {

                            getHP = int.Parse(result.Data["HEALTH"].Value);
                            getPower = int.Parse(result.Data["POWER"].Value);

                            if(LM.Language == "KOR")
                            {
                               txt_status.text = "(싱글)체력 : " + result.Data["HEALTH"].Value 
                                     + "\n" + "\n" + "(싱글)시작 금화 : " + result.Data["POWER"].Value;
                            }
                            else 
                            {
                               txt_status.text = "(Single)HP : " + result.Data["HEALTH"].Value 
                                     + "\n" + "\n" + "(Single)Start Gold : " + result.Data["POWER"].Value;
                            }

                            getPlayerNickNM();

                        }
                        , (error) => print("error"));
    }

    public void getPlayerNickNM()
    {
        PlayFabClientAPI.GetPlayerProfile( new GetPlayerProfileRequest() {
            PlayFabId = User_ID,
            ProfileConstraints = new PlayerProfileViewConstraints() {ShowDisplayName = true}
        }, result => {
            txt_NickNM.text = result.PlayerProfile.DisplayName;
            NickNM = result.PlayerProfile.DisplayName;
            Panel_Loading.SetActive(false);

        },
        error => {
            Debug.LogError(error.GenerateErrorReport());
        });
    }

    public void onClickChangeNickName()
    {

        SoundManager.instance.PlaySE("button");

        if(input_NickName.text.Length < 2 || input_NickName.text.Length > 8)
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "글자수를 확인하세요!";
            }
            else if(LM.Language == "Eng")
            {
                txt_Result.text = "Check Your NickName!";
            } else 
            {
                txt_Result.text = "文字数を確認してください!";
            }
            
            Panel_Result.SetActive(true);
            return;
        }

        Panel_Loading.SetActive(true);
        var request = new UpdateUserTitleDisplayNameRequest { DisplayName = input_NickName.text + "#" };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, 
        (result) => {
                        Panel_Loading.SetActive(false);
                        if(LM.Language == "KOR")
                        {
                            txt_Result.text = "닉네임 변경 완료!";
                        }
                        else if (LM.Language == "Eng"){
                            txt_Result.text = "Success Changed!";
                        } else
                        {
                            txt_Result.text = "変 更 成 功!";
                        }
                        Panel_Result.SetActive(true);
                        nickChangeChk = true;
                
        }, (error) => {
            print("failed nickname update");
        });
    }

    public void onClickPowerUP()
    {
        SoundManager.instance.PlaySE("button");
        Panel_StatusInfo.SetActive(false);
        Panel_StatusCnt.SetActive(true);
    }

    public void onClickPowerUPCloseBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_StatusInfo.SetActive(true);
        Panel_StatusCnt.SetActive(false);
    }

    public void onClickPlusBtn()
    {
        SoundManager.instance.PlaySE("button");
        if(int.Parse(txt_StatusCnt.text) * 100 > LM.user_money)
        {
            return;
        }

        txt_StatusCnt.text = (int.Parse(txt_StatusCnt.text) + 1).ToString();

    }
    public void onClickMinusBtn()
    {
        SoundManager.instance.PlaySE("button");
        if(int.Parse(txt_StatusCnt.text) <= 1)
        {
            return;
        }

        txt_StatusCnt.text = (int.Parse(txt_StatusCnt.text) - 1).ToString();
    }

    public void onClickPowerUpConfirmBtn()
    {
        SoundManager.instance.PlaySE("button");
        nickChangeChk = false;

        int powerupCnt = 0;
        powerupCnt = int.Parse(txt_StatusCnt.text);

        if(LM.user_money < 100 *  powerupCnt)
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "계란이 부족합니다!";
            }
            else if(LM.Language == "Eng"){
                txt_Result.text = "Check Your Eggs!";
            } else
            {
                txt_Result.text = "卵が足りません!";
            }
            Panel_Result.SetActive(true);
            return;
        }

        Panel_Loading.SetActive(true);

        int HPCnt = 0;
        int Power_Cnt = 0;
        int HPData = 0; 
        int PowerData = 0;

        for(int i = 0; i < powerupCnt; i++)
        {

            int rand_no = UnityEngine.Random.Range(1,100);

            print(rand_no);

            if(rand_no % 2 == 1)
            {
                HPCnt++;
                HPData = HPData + 10;

            } else {
                Power_Cnt++;
                PowerData = PowerData + 100;
            }
        }

        PlayFabClientAPI.UpdateUserData(new PlayFab.ClientModels.UpdateUserDataRequest() 
        {Data = new Dictionary<string, string>(){
                 {"HEALTH", (getHP + HPData).ToString()},{"POWER", (getPower + PowerData).ToString()}
                }}
                            , (result) => {
                                    LM.user_money = LM.user_money - (100*powerupCnt);
                                    substractUserMoney(Power_Cnt, HPCnt, 100*powerupCnt);
                                    
                            }
                            , (error) => {
                                print("failed power up");

                            });
    }


    public void substractUserMoney(int Power_Cnt, int HP_Cnt, int MoneyCnt)
    {
        var request = new SubtractUserVirtualCurrencyRequest() { VirtualCurrency = "EG", Amount = MoneyCnt };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, 
                                (result) => {

                                    Panel_Loading.SetActive(false);
                                    
                                    if(LM.Language == "KOR")
                                    {
                                        txt_Result.text = "체력 강화 " + HP_Cnt * 10 + " 증가!\n" 
                                                        + "시작 금화 " + Power_Cnt * 100 + " 증가!";
                                    }
                                    else{
                                        txt_Result.text = "HP " + HP_Cnt * 10 + " UP!\n" 
                                                        + "Start Money " + Power_Cnt * 100 + " UP!";
                                    }
                                    Panel_Result.SetActive(true);
                                    Panel_StatusInfo.SetActive(true);
                                    Panel_StatusCnt.SetActive(false);
                                    getPlayerStats();      
                                }
                              , (error) => {
                                print(error.GenerateErrorReport());
                              });
    }

    public void onClickConfirmBtn()
    {
        SoundManager.instance.PlaySE("button");

        if(nickChangeChk == true)
        {
            Panel_Result.SetActive(false);
            Panel_Status.SetActive(false);
        }else
        {
            Panel_Result.SetActive(false);
        }
    }

    public void onClickStatusCloseBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Status.SetActive(false);
    }

    public void onClickSkinBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Skin.SetActive(true);
        Panel_SkinLoading.SetActive(true);

        if(LM.Language == "KOR")
        {
            txt_BtnChange.text = "바 꾸 기";
            txt_BtnPowerUP.text = "강화(100EGG)";
            txt_BtnConfirm.text = "확    인";
            txt_StatusCntTitle.text = "강화 수량";
            txt_StatusBuyBtn.text = "강 화";
            txt_StatusExitBtn.text = "닫 기";
            txt_ResultBtnConfirm.text = "확    인";
            txt_SkinTitle.text = "스    킨";
            txt_SkinUse.text = "사   용";
            txt_SkinExit.text = "닫   기";
        }
        else if(LM.Language == "Eng")
        {
            txt_BtnChange.text = "Change";
            txt_BtnPowerUP.text = "Power UP(100EGG)";
            txt_BtnConfirm.text = "Confirm";
            txt_StatusCntTitle.text = "Count";
            txt_StatusBuyBtn.text = "U P";
            txt_StatusExitBtn.text = "EXIT";
            txt_ResultBtnConfirm.text = "Confirm";
            txt_SkinTitle.text = "Skin";
            txt_SkinUse.text = "USE";
            txt_SkinExit.text = "EXIT";
        } else
        {
            txt_BtnChange.text = "か え る";
            txt_BtnPowerUP.text = "きょうか(100EGG)";
            txt_BtnConfirm.text = "か く に ん";
            txt_StatusCntTitle.text = "数 量";
            txt_StatusBuyBtn.text = "は い";
            txt_StatusExitBtn.text = "出 る";
            txt_ResultBtnConfirm.text = "か く に ん";
            txt_SkinTitle.text = "コスチューム";
            txt_SkinUse.text = "は い";
            txt_SkinExit.text = "出 る";
        }

        getSkinList();

    }

    public void onClickSkinCloseBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Skin.SetActive(false);
        Panel_SkinLoading.SetActive(false);
    }

    public void onClickSkinUseBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_SkinLoading.SetActive(true);
        setSkinName();


    }

    public void setSkinName()
    {
        PlayFabClientAPI.UpdateUserData(new PlayFab.ClientModels.UpdateUserDataRequest() 
        {Data = new Dictionary<string, string>(){
                 {"SKIN", select_player_skin_id}  
                }}
                            , (result) => {
                                LM.getSkinName();
                                btn_SetSkin.interactable = false;
                            }
                            , (error) => {

                            });
    }

    public void getSkinList()
    {
        for(int i = 0; i < LM.player_skin_id.Count; i++)
        {
            player_skin_id[i] = LM.player_skin_id[i];
            player_skin_name[i] = LM.player_skin_name[i];
        
            skin_slot[i].item_id = player_skin_id[i];
            skin_slot[i].item_name = player_skin_name[i];
            skin_slot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + player_skin_name[i]);
            skin_slot[i].itemImage.preserveAspect = true;
        }

        for(int i = 0; i < player_skin_id.Length; i++)
        {
            for(int j = 0; j < LM.all_skin_id.Count; j++)
            {
                if(player_skin_id[i] == LM.all_skin_id[j])
                {
                    player_skin_info[i] = LM.all_skin_info[j];
                    skin_slot[i].item_info = player_skin_info[i];
                }
            }
        }

        Panel_SetSkin.SetActive(true);
        Panel_SkinLoading.SetActive(false);
    }

    public void onClickSkinSlotItem(Slot input_slot)
    {

        if(input_slot.item_id == "")
        {
            return;
        }

        img_select_skin.gameObject.SetActive(true);

        SoundManager.instance.PlaySE("button");

        for(int i = 0; i < skin_slot.Length; i++)
        {
            skin_slot[i].SelectedImg.color = UnityEngine.Color.white;
        }
        
        input_slot.SelectedImg.color = UnityEngine.Color.yellow;
        select_player_skin_id = input_slot.item_id;
        select_player_skin_name = input_slot.item_name;
        select_player_skin_info = input_slot.item_info;
        img_select_skin.sprite = Resources.Load<Sprite>("item/" + select_player_skin_name);

        string[] languageitem_name = select_player_skin_name.Split('_');
        string[] languageitem_info = select_player_skin_info.Split('_');

        if(LM.Language == "KOR")
        {
            txt_SkinName.text = languageitem_name[0];
            txt_SkinInfo.text = languageitem_info[0];
        } else
        {
            txt_SkinName.text = languageitem_name[1];
            txt_SkinInfo.text = languageitem_info[1];
            
        }

        if(select_player_skin_id == LobbyManager.skin_name)
        {
            btn_SetSkin.interactable = false;
        } else
        {
            btn_SetSkin.interactable = true;
        }

    }
}
