using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels; 
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System.Text;

public class RankManager : MonoBehaviour
{
    [Serializable]
    public class RankMaster
    {
        public string round_no;
        public string UserName;
        public string UserPoint;
        public string RankItem;
        public string RankGrade;
    }

    [Serializable]
    public class RankMasterList
    {
        public RankMaster[] master;
    }

    public RankMaster master_solo;
    public RankMaster master_multi;


    // Start is called before the first frame update
    public LobbyManager LM;

    public GameObject Panel_Rank;
    public GameObject Panel_RankMenu;
    public GameObject Panel_RankSingle;
    public GameObject Panel_RankMulti;
    public GameObject Panel_RankSingleMaster;
    public GameObject Panel_RankSingleInfo;
    public GameObject Panel_RankMultiMaster;
    public GameObject Panel_RankMultieInfo;
    public GameObject Panel_RankReward;
    public GameObject Panel_Loading;
    
    public Text txt_RoundName;
    public Text txt_UserName;
    public Text txt_UserPoint;
    public Text txt_RoundName2;
    public Text txt_UserName2;
    public Text txt_UserPoint2;

    public List<string> round_no = new List<string>();
    public List<string> UserName = new List<string>();
    public List<string> UserPoint = new List<string>();
    public List<string> RankItem = new List<string>();
    public List<string> RankGrade = new List<string>();
    public Slot[] rank_slot = new Slot[10];
    public int page_no = 0;


    public List<string> round_no2 = new List<string>();
    public List<string> UserName2 = new List<string>();
    public List<string> UserPoint2 = new List<string>();
    public List<string> RankItem2 = new List<string>();
    public List<string> RankGrade2 = new List<string>();
    public Slot[] rank_slot2 = new Slot[10];
    public int page_no2 = 0;



    public Transform txtHolder1;
    public Transform txtHolder2;
    public Text[] txt_TotalRank;
    public Text[] txt_MyRank;
    public Image[] img_TotalRank;
    public Image[] img_MyRank;
    public Transform txtHolder12;
    public Transform txtHolder22;
    public Text[] txt_TotalRank2;
    public Text[] txt_MyRank2;
    public Image[] img_TotalRank2;
    public Image[] img_MyRank2;
    public Text txt_Loading;
    public Text txt_RankMenuConfirmBtn;
    public Text txt_RankSingleConfirmBtn;
    public Text txt_RankMultiConfirmBtn;
    public Text txt_RankSingleMasterConfirmBtn;
    public Text txt_RankSingleInfoConfirmBtn;
    public Text txt_RankMultiMasterConfirmBtn;
    public Text txt_RankMultiInfoConfirmBtn;
    public Text txt_RankRewardConfirmBtn;
    public string User_ID;

    void Start()
    {
        User_ID = LoginMenu.User_ID;

        Panel_Rank.SetActive(false);
        Panel_RankMenu.SetActive(false);
        Panel_RankSingle.SetActive(false);
        Panel_RankMulti.SetActive(false);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_RankReward.SetActive(false);

        txt_TotalRank = txtHolder1.GetComponentsInChildren<Text>();
        txt_MyRank = txtHolder2.GetComponentsInChildren<Text>();
        img_TotalRank = txtHolder1.GetComponentsInChildren<Image>();
        img_MyRank = txtHolder2.GetComponentsInChildren<Image>();

        txt_TotalRank2 = txtHolder12.GetComponentsInChildren<Text>();
        txt_MyRank2 = txtHolder22.GetComponentsInChildren<Text>();
        img_TotalRank2 = txtHolder12.GetComponentsInChildren<Image>();
        img_MyRank2 = txtHolder22.GetComponentsInChildren<Image>();

        getMasterRank();
        
        if(LM.Language == "KOR")
        {
            txt_RankMenuConfirmBtn.text = "확    인";
            txt_RankSingleConfirmBtn.text = "확    인";
            txt_RankMultiConfirmBtn.text = "확    인";
            txt_RankSingleMasterConfirmBtn.text = "확    인";
            txt_RankSingleInfoConfirmBtn.text = "확    인";
            txt_RankMultiMasterConfirmBtn.text = "확    인";
            txt_RankMultiInfoConfirmBtn.text = "확    인";
            txt_RankRewardConfirmBtn.text = "확    인";
        } else if(LM.Language == "Eng")
        {
            txt_RankMenuConfirmBtn.text = "Confirm";
            txt_RankSingleConfirmBtn.text = "Confirm";
            txt_RankMultiConfirmBtn.text = "Confirm";
            txt_RankSingleMasterConfirmBtn.text = "Confirm";
            txt_RankSingleInfoConfirmBtn.text = "Confirm";
            txt_RankMultiMasterConfirmBtn.text = "Confirm";
            txt_RankMultiInfoConfirmBtn.text = "Confirm";
            txt_RankRewardConfirmBtn.text = "Confirm";
        } else
        {
            txt_RankMenuConfirmBtn.text = "か く に ん";
            txt_RankSingleConfirmBtn.text = "か く に ん";
            txt_RankMultiConfirmBtn.text = "か く に ん";
            txt_RankSingleMasterConfirmBtn.text = "か く に ん";
            txt_RankSingleInfoConfirmBtn.text = "か く に ん";
            txt_RankMultiMasterConfirmBtn.text = "か く に ん";
            txt_RankMultiInfoConfirmBtn.text = "か く に ん";
            txt_RankRewardConfirmBtn.text = "か く に ん";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getMasterRank()
    {

        PlayFabClientAPI.GetCatalogItems(new GetCatalogItemsRequest() { CatalogVersion = "RANK_SOLO" }
        , (result) =>
        {
            
            for (int i = 0; i < result.Catalog.Count; i++)
            {

                var rank_db = result.Catalog[i];

                master_solo =  JsonUtility.FromJson<RankMaster>(rank_db.CustomData);
                    
                round_no.Add(master_solo.round_no);
                UserName.Add(master_solo.UserName);
                UserPoint.Add(master_solo.UserPoint);
                RankItem.Add(master_solo.RankItem);
                RankGrade.Add(master_solo.RankGrade);

            }

            getMasterRank2();

        },
        (error) => { });

        
    }

    public void getMasterRank2()
    {
        PlayFabClientAPI.GetCatalogItems(new GetCatalogItemsRequest() { CatalogVersion = "RANK_MULTI" }
        , (result) =>
        {
            
            for (int i = 0; i < result.Catalog.Count; i++)
            {

                var rank_db = result.Catalog[i];

                master_multi =  JsonUtility.FromJson<RankMaster>(rank_db.CustomData);
                    
                round_no2.Add(master_multi.round_no);
                UserName2.Add(master_multi.UserName);
                UserPoint2.Add(master_multi.UserPoint);
                RankItem2.Add(master_multi.RankItem);
                RankGrade2.Add(master_multi.RankGrade);

            }
        }, (error) => { });
    }



    public void onClickRankBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(true);
        Panel_RankSingle.SetActive(false);
        Panel_RankMulti.SetActive(false);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(false);

        if(LM.Language == "KOR")
        {
            txt_RankMenuConfirmBtn.text = "확    인";
            txt_RankSingleConfirmBtn.text = "확    인";
            txt_RankMultiConfirmBtn.text = "확    인";
            txt_RankSingleMasterConfirmBtn.text = "확    인";
            txt_RankSingleInfoConfirmBtn.text = "확    인";
            txt_RankMultiMasterConfirmBtn.text = "확    인";
            txt_RankMultiInfoConfirmBtn.text = "확    인";
            txt_RankRewardConfirmBtn.text = "확    인";
        } else if(LM.Language == "Eng")
        {
            txt_RankMenuConfirmBtn.text = "Confirm";
            txt_RankSingleConfirmBtn.text = "Confirm";
            txt_RankMultiConfirmBtn.text = "Confirm";
            txt_RankSingleMasterConfirmBtn.text = "Confirm";
            txt_RankSingleInfoConfirmBtn.text = "Confirm";
            txt_RankMultiMasterConfirmBtn.text = "Confirm";
            txt_RankMultiInfoConfirmBtn.text = "Confirm";
            txt_RankRewardConfirmBtn.text = "Confirm";
        } else
        {
            txt_RankMenuConfirmBtn.text = "か く に ん";
            txt_RankSingleConfirmBtn.text = "か く に ん";
            txt_RankMultiConfirmBtn.text = "か く に ん";
            txt_RankSingleMasterConfirmBtn.text = "か く に ん";
            txt_RankSingleInfoConfirmBtn.text = "か く に ん";
            txt_RankMultiMasterConfirmBtn.text = "か く に ん";
            txt_RankMultiInfoConfirmBtn.text = "か く に ん";
            txt_RankRewardConfirmBtn.text = "か く に ん";
        }

        if(LM.Language == "KOR")
        {
            txt_Loading.text = "불러오는 중..";
        } else
        {
            txt_Loading.text = "Loading..";
        }
        
    }
    public void onClickRankSingleBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(false);
        Panel_RankSingle.SetActive(true);
        Panel_RankMulti.SetActive(false);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(false);
        return;
    }
    public void onClickRankSingleConfirmBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(true);
        Panel_RankSingle.SetActive(false);
        Panel_RankMulti.SetActive(false);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(false);
        return;
    }
    public void onClickSingleRankMasterBtn()
    {
        SoundManager.instance.PlaySE("button");
        page_no = 0;

        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(false);
        Panel_RankSingle.SetActive(false);
        Panel_RankMulti.SetActive(false);
        Panel_RankSingleMaster.SetActive(true);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(false);

        txt_RoundName.text = round_no[page_no] ;
        txt_UserName.text = UserName[page_no];
        txt_UserPoint.text = UserPoint[page_no] + " pts";

        string[] arrItemName = RankItem[page_no].Split(':');
        string[] arrItemGrade = RankGrade[page_no].Split(':');

        for(int i = 0; i < arrItemName.Length; i++)
        {
            rank_slot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + arrItemName[i]); 
            
            if(arrItemGrade[i] == "D")
            {
                rank_slot[i].BackImg.color = UnityEngine.Color.white;
            } else if (arrItemGrade[i] == "C")
            {
                rank_slot[i].BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            } else if (arrItemGrade[i] == "B")
            {
                rank_slot[i].BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            } else if (arrItemGrade[i] == "A")
            {
                rank_slot[i].BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            } else if (arrItemGrade[i] == "S")
            {
                rank_slot[i].BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
            }

        }

    }

    public void onClickSingleMasterRankPlusBtn()
    {
        try
        {
        SoundManager.instance.PlaySE("button");
        if(page_no >= round_no.Count - 1)
        {
            return;
        }

        page_no++;

        txt_RoundName.text = round_no[page_no] ;
        txt_UserName.text = UserName[page_no];
        txt_UserPoint.text = UserPoint[page_no] + " pts";

        string[] arrItemName = RankItem[page_no].Split(':');
        string[] arrItemGrade = RankGrade[page_no].Split(':');

        for(int i = 0; i < arrItemName.Length; i++)
        {
            rank_slot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + arrItemName[i]); 
            
            if(arrItemGrade[i] == "D")
            {
                rank_slot[i].BackImg.color = UnityEngine.Color.white;
            } else if (arrItemGrade[i] == "C")
            {
                rank_slot[i].BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            } else if (arrItemGrade[i] == "B")
            {
                rank_slot[i].BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            } else if (arrItemGrade[i] == "A")
            {
                rank_slot[i].BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            } else if (arrItemGrade[i] == "S")
            {
                rank_slot[i].BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
            }

        }
        }catch(IndexOutOfRangeException ex){ 
        } 

    }

    public void onClickSingleMasterRankMinusBtn()
    {
        try{
        
        SoundManager.instance.PlaySE("button");
        if(page_no < 1)
        {
            return;
        }

        page_no--;

        txt_RoundName.text = round_no[page_no] ;
        txt_UserName.text = UserName[page_no];
        txt_UserPoint.text = UserPoint[page_no] + " pts";

        string[] arrItemName = RankItem[page_no].Split(':');
        string[] arrItemGrade = RankGrade[page_no].Split(':');

        for(int i = 0; i < arrItemName.Length; i++)
        {
            rank_slot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + arrItemName[i]); 
            
            if(arrItemGrade[i] == "D")
            {
                rank_slot[i].BackImg.color = UnityEngine.Color.white;
            } else if (arrItemGrade[i] == "C")
            {
                rank_slot[i].BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            } else if (arrItemGrade[i] == "B")
            {
                rank_slot[i].BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            } else if (arrItemGrade[i] == "A")
            {
                rank_slot[i].BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            } else if (arrItemGrade[i] == "S")
            {
                rank_slot[i].BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
            }

        }
        } catch(IndexOutOfRangeException ex){ 
        } 

    }

    public void onClickSingleRankMasterCloseBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(false);
        Panel_RankSingle.SetActive(true);
        Panel_RankMulti.SetActive(false);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(false);
        return;
    }

    public void onClickSingleMonthRankBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(false);
        Panel_RankSingle.SetActive(false);
        Panel_RankMulti.SetActive(false);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(true);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(true);

        getTopUserRank();
        return;

    }


    public void getTopUserRank()
    {

        var request = new GetLeaderboardRequest{ StartPosition = 0, StatisticName = "HighScore", MaxResultsCount = 3
                                                , ProfileConstraints = new PlayerProfileViewConstraints(){ShowLocations = true, ShowDisplayName = true}};
        PlayFabClientAPI.GetLeaderboard(request,
            (result) => {
                    
                    List<string> rank_PlayFabId = new List<string>();
                    List<int> rank_postition = new List<int>();
                    List<int> rank_StatValue = new List<int>();
                    List<string> rank_DisplayName = new List<string>();
                    List<string> rank_nation = new List<string>();

                    for(int i = 0; i < result.Leaderboard.Count; i++)
                    {
                        rank_postition.Add(result.Leaderboard[i].Position + 1);
                        rank_PlayFabId.Add(result.Leaderboard[i].PlayFabId);
                        rank_DisplayName.Add(result.Leaderboard[i].DisplayName);
                        rank_StatValue.Add(result.Leaderboard[i].StatValue);
                        rank_nation.Add(result.Leaderboard[i].Profile.Locations[0].CountryCode.Value.ToString().ToLower());

                        if(rank_DisplayName[i] == null)
                        {
                            rank_DisplayName[i] = rank_PlayFabId[i];
                        }
                        img_TotalRank[i].gameObject.SetActive(true);
                        img_TotalRank[i].sprite = Resources.Load<Sprite>("Nation/" + rank_nation[i]);
                        txt_TotalRank[i].text = rank_postition[i].ToString() + ". " + rank_DisplayName[i] + "\n" + rank_StatValue[i].ToString() + " pts";
                        if(rank_PlayFabId[i] == User_ID)
                        {
                            txt_TotalRank[i].color = UnityEngine.Color.green;
                        } else
                        {
                            txt_TotalRank[i].color = UnityEngine.Color.white;
                        }

                    }

                    getAroundUserRank();
            },
            (error) => 
            {
                if(LM.Language == "KOR")
                {
                    txt_Loading.text = "불러오기 실패!";
                } else 
                {
                    txt_Loading.text = "Loading Failed!";
                }
                
                Panel_Loading.SetActive(false);
            }

        
        );

    }

    public void getAroundUserRank()
    {
        var request = new GetLeaderboardAroundPlayerRequest(){PlayFabId = User_ID, StatisticName = "HighScore", MaxResultsCount = 10
                                                            , ProfileConstraints = new PlayerProfileViewConstraints(){ShowLocations = true, ShowDisplayName = true}};

        PlayFabClientAPI.GetLeaderboardAroundPlayer(request,
            (result) =>
            {
                    List<string> rank_PlayFabId = new List<string>();
                    List<int> rank_postition = new List<int>();
                    List<int> rank_StatValue = new List<int>();
                    List<string> rank_DisplayName = new List<string>();
                    List<string> rank_nation = new List<string>();

                    for(int i = 0; i < result.Leaderboard.Count; i++)
                    {
                        rank_postition.Add(result.Leaderboard[i].Position + 1);
                        rank_PlayFabId.Add(result.Leaderboard[i].PlayFabId);
                        rank_DisplayName.Add(result.Leaderboard[i].DisplayName);
                        rank_StatValue.Add(result.Leaderboard[i].StatValue);
                        rank_nation.Add(result.Leaderboard[i].Profile.Locations[0].CountryCode.Value.ToString().ToLower());

                        if(rank_DisplayName[i] == null)
                        {
                            rank_DisplayName[i] = rank_PlayFabId[i];
                        }
                        img_MyRank[i].gameObject.SetActive(true);
                        img_MyRank[i].sprite = Resources.Load<Sprite>("Nation/" + rank_nation[i]);
                        txt_MyRank[i].text = rank_postition[i].ToString() + ". " + rank_DisplayName[i] + "\n" + rank_StatValue[i].ToString() + " pts";

                        if(rank_PlayFabId[i] == User_ID)
                        {
                            txt_MyRank[i].color = UnityEngine.Color.green;
                        }
                        else
                        {
                            txt_MyRank[i].color = UnityEngine.Color.white;
                        }

                    }

                    Panel_Loading.SetActive(false);

            } ,
            (error) => {
                if(LM.Language == "KOR")
                {
                    txt_Loading.text = "불러오기 실패!";
                } else 
                {
                    txt_Loading.text = "Loading Failed!";
                }
                Panel_Loading.SetActive(false);
            }
        );   

    }

    public void onClickSingleMonthRankCloseBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(false);
        Panel_RankSingle.SetActive(true);
        Panel_RankMulti.SetActive(false);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(false);
        return;
    }

    public void onClickMultiRankBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(false);
        Panel_RankSingle.SetActive(false);
        Panel_RankMulti.SetActive(true);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(false);
        return;
    }
    public void onClickMultiRankConfirmBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(true);
        Panel_RankSingle.SetActive(false);
        Panel_RankMulti.SetActive(false);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(false);
        return;
    }

    public void onClickMultiMasterRankBtn()
    {
        SoundManager.instance.PlaySE("button");

        page_no2 = 0;

        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(false);
        Panel_RankSingle.SetActive(false);
        Panel_RankMulti.SetActive(false);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(true);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(false);

        txt_RoundName2.text = round_no2[page_no2] ;
        txt_UserName2.text = UserName2[page_no2];
        txt_UserPoint2.text = UserPoint2[page_no2] + " pts";

        string[] arrItemName = RankItem2[page_no2].Split(':');
        string[] arrItemGrade = RankGrade2[page_no2].Split(':');

        for(int i = 0; i < arrItemName.Length; i++)
        {
            rank_slot2[i].itemImage.sprite = Resources.Load<Sprite>("item/" + arrItemName[i]); 
            
            if(arrItemGrade[i] == "D")
            {
                rank_slot2[i].BackImg.color = UnityEngine.Color.white;
            } else if (arrItemGrade[i] == "C")
            {
                rank_slot2[i].BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            } else if (arrItemGrade[i] == "B")
            {
                rank_slot2[i].BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            } else if (arrItemGrade[i] == "A")
            {
                rank_slot2[i].BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            } else if (arrItemGrade[i] == "S")
            {
                rank_slot2[i].BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
            }

        }
    }


    public void onClickMultiMasterRankPlusBtn()
    {
        try{
        SoundManager.instance.PlaySE("button");
        if(page_no2 >= round_no2.Count - 1)
        {
            return;
        }

        page_no2++;

        txt_RoundName2.text = round_no2[page_no2] ;
        txt_UserName2.text = UserName2[page_no2];
        txt_UserPoint2.text = UserPoint2[page_no2] + " pts";

        string[] arrItemName = RankItem2[page_no2].Split(':');
        string[] arrItemGrade = RankGrade2[page_no2].Split(':');

        for(int i = 0; i < arrItemName.Length; i++)
        {
            rank_slot2[i].itemImage.sprite = Resources.Load<Sprite>("item/" + arrItemName[i]); 
            
            if(arrItemGrade[i] == "D")
            {
                rank_slot2[i].BackImg.color = UnityEngine.Color.white;
            } else if (arrItemGrade[i] == "C")
            {
                rank_slot2[i].BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            } else if (arrItemGrade[i] == "B")
            {
                rank_slot2[i].BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            } else if (arrItemGrade[i] == "A")
            {
                rank_slot2[i].BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            } else if (arrItemGrade[i] == "S")
            {
                rank_slot2[i].BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
            }

        }
        }catch(IndexOutOfRangeException ex){ 
        } 

    }

    public void onClickMultiMasterRankMinusBtn()
    {
        try{
        SoundManager.instance.PlaySE("button");
        if(page_no2 < 1)
        {
            return;
        }

        page_no2--;

        txt_RoundName2.text = round_no[page_no2] ;
        txt_UserName2.text = UserName[page_no2];
        txt_UserPoint2.text = UserPoint[page_no2] + " pts";

        string[] arrItemName = RankItem[page_no2].Split(':');
        string[] arrItemGrade = RankGrade[page_no2].Split(':');

        for(int i = 0; i < arrItemName.Length; i++)
        {
            rank_slot2[i].itemImage.sprite = Resources.Load<Sprite>("item/" + arrItemName[i]); 
            
            if(arrItemGrade[i] == "D")
            {
                rank_slot2[i].BackImg.color = UnityEngine.Color.white;
            } else if (arrItemGrade[i] == "C")
            {
                rank_slot2[i].BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            } else if (arrItemGrade[i] == "B")
            {
                rank_slot2[i].BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            } else if (arrItemGrade[i] == "A")
            {
                rank_slot2[i].BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            } else if (arrItemGrade[i] == "S")
            {
                rank_slot2[i].BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
            }

        }
        }catch(IndexOutOfRangeException ex){ 
        } 

    }

    public void onClickMultiMasterConfirmBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(false);
        Panel_RankSingle.SetActive(false);
        Panel_RankMulti.SetActive(true);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(false);
        return;
    }


    public void onClickMultiMonthRankBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(false);
        Panel_RankSingle.SetActive(false);
        Panel_RankMulti.SetActive(false);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(true);
        Panel_Loading.SetActive(true);

        getTopUserRank2();
        return;

    }


    public void getTopUserRank2()
    {

        var request = new GetLeaderboardRequest{ StartPosition = 0, StatisticName = "pvp_Rank", MaxResultsCount = 3
                                                , ProfileConstraints = new PlayerProfileViewConstraints(){ShowLocations = true, ShowDisplayName = true}};
        PlayFabClientAPI.GetLeaderboard(request,
            (result) => {
                    
                    List<string> rank_PlayFabId = new List<string>();
                    List<int> rank_postition = new List<int>();
                    List<int> rank_StatValue = new List<int>();
                    List<string> rank_DisplayName = new List<string>();
                    List<string> rank_nation = new List<string>();

                    for(int i = 0; i < result.Leaderboard.Count; i++)
                    {
                        rank_postition.Add(result.Leaderboard[i].Position + 1);
                        rank_PlayFabId.Add(result.Leaderboard[i].PlayFabId);
                        rank_DisplayName.Add(result.Leaderboard[i].DisplayName);
                        rank_StatValue.Add(result.Leaderboard[i].StatValue);
                        rank_nation.Add(result.Leaderboard[i].Profile.Locations[0].CountryCode.Value.ToString().ToLower());

                        if(rank_DisplayName[i] == null)
                        {
                            rank_DisplayName[i] = rank_PlayFabId[i];
                        }
                        img_TotalRank2[i].gameObject.SetActive(true);
                        img_TotalRank2[i].sprite = Resources.Load<Sprite>("Nation/" + rank_nation[i]);
                        txt_TotalRank2[i].text = rank_postition[i].ToString() + ". " + rank_DisplayName[i] + "\n" + rank_StatValue[i].ToString() + " pts";
                        if(rank_PlayFabId[i] == User_ID)
                        {
                            txt_TotalRank2[i].color = UnityEngine.Color.green;
                        } else
                        {
                            txt_TotalRank2[i].color = UnityEngine.Color.white;
                        }

                    }

                    getAroundUserRank2();
            },
            (error) => 
            {
                if(LM.Language == "KOR")
                {
                    txt_Loading.text = "불러오기 실패!";
                } else 
                {
                    txt_Loading.text = "Loading Failed!";
                }
                
                Panel_Loading.SetActive(false);
            }

        
        );

    }

    public void getAroundUserRank2()
    {
        var request = new GetLeaderboardAroundPlayerRequest(){PlayFabId = User_ID, StatisticName = "pvp_Rank", MaxResultsCount = 10
                                                            , ProfileConstraints = new PlayerProfileViewConstraints(){ShowLocations = true, ShowDisplayName = true}};

        PlayFabClientAPI.GetLeaderboardAroundPlayer(request,
            (result) =>
            {
                    List<string> rank_PlayFabId = new List<string>();
                    List<int> rank_postition = new List<int>();
                    List<int> rank_StatValue = new List<int>();
                    List<string> rank_DisplayName = new List<string>();
                    List<string> rank_nation = new List<string>();

                    for(int i = 0; i < result.Leaderboard.Count; i++)
                    {
                        rank_postition.Add(result.Leaderboard[i].Position + 1);
                        rank_PlayFabId.Add(result.Leaderboard[i].PlayFabId);
                        rank_DisplayName.Add(result.Leaderboard[i].DisplayName);
                        rank_StatValue.Add(result.Leaderboard[i].StatValue);
                        rank_nation.Add(result.Leaderboard[i].Profile.Locations[0].CountryCode.Value.ToString().ToLower());

                        if(rank_DisplayName[i] == null)
                        {
                            rank_DisplayName[i] = rank_PlayFabId[i];
                        }
                        img_MyRank2[i].gameObject.SetActive(true);
                        img_MyRank2[i].sprite = Resources.Load<Sprite>("Nation/" + rank_nation[i]);
                        txt_MyRank2[i].text = rank_postition[i].ToString() + ". " + rank_DisplayName[i] + "\n" + rank_StatValue[i].ToString() + " pts";

                        if(rank_PlayFabId[i] == User_ID)
                        {
                            txt_MyRank2[i].color = UnityEngine.Color.green;
                        }
                        else
                        {
                            txt_MyRank2[i].color = UnityEngine.Color.white;
                        }

                    }

                    Panel_Loading.SetActive(false);

            } ,
            (error) => {
                if(LM.Language == "KOR")
                {
                    txt_Loading.text = "불러오기 실패!";
                } else 
                {
                    txt_Loading.text = "Loading Failed!";
                }
                Panel_Loading.SetActive(false);
            }
        );   

    }

    public void onClickMultiMonthRankConfirmBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(false);
        Panel_RankSingle.SetActive(false);
        Panel_RankMulti.SetActive(true);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(false);
        return;
    }


    public void onClickRankCloseBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Rank.SetActive(false);
        Panel_RankMenu.SetActive(false);
        Panel_RankSingle.SetActive(false);
        Panel_RankMulti.SetActive(false);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(false);
        return;
    }

    public void onClickRankRewardBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(false);
        Panel_RankSingle.SetActive(false);
        Panel_RankMulti.SetActive(false);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(false);
        Panel_RankReward.SetActive(true);
        return;
    }

    public void onClickRankRewardConfirmBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Rank.SetActive(true);
        Panel_RankMenu.SetActive(true);
        Panel_RankSingle.SetActive(false);
        Panel_RankMulti.SetActive(false);
        Panel_RankSingleMaster.SetActive(false);
        Panel_RankSingleInfo.SetActive(false);
        Panel_RankMultiMaster.SetActive(false);
        Panel_RankMultieInfo.SetActive(false);
        Panel_Loading.SetActive(false);
        Panel_RankReward.SetActive(false);
        return;
    }

}
