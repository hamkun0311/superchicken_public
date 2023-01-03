
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public string User_ID;
    public string gameLvl;
    public SoundManager SM;

    public int p_HP;
    public int p_UnitCnt;
    public int g_UnitCnt;
    public int m_killCnt;
    public int monster_cnt;
    public int gameTime = 0;
    public int startTime = 0;
    public int eggCnt = 0;
    public int goldCnt = 0;
    public int totalScore = 0;
    public string PlayerUnitIDList;
    public string PlayerUnitNameList;
    public List<string> p_unit_id = new List<string>();
    public List<string> p_unit_name = new List<string>();
    public List<string> p_unit_grade = new List<string>();
    public List<uint> p_unit_value = new List<uint>();

    public List<string> all_unit_id = new List<string>();
    public List<string> all_unit_grade = new List<string>();
    public List<string> all_unit_name = new List<string>();
    public List<uint> all_unit_value = new List<uint>();

    public int[] s_unit_cnt = new int[10];

    public string select_unit_id;
    public string select_unit_name;
    public uint select_unit_value = 0;
    public string select_unit_grade;

    public bool getPlayerStats_chk = false;
    public bool allUnitChk = false;
    public bool playerUnitChk = false;
    public bool startChk = false;
    public bool langChk = false;

    public string Language;


    public Slot[] setslot = new Slot[10];
    public Slot AddUnitSlot;

    public bool Ads;
    public bool AdsUnit = false;



    
    //GameUI
    public Text txt_EggTop;
    public Text txt_MoneyTop;
    public Text txt_HPTop;
    public Text txt_UnitTop;
    public Text txt_killTop;
    public Text txt_TimeTop;
    public Text txt_UnitValue;
    public GameObject Panel_Shop;
    public GameObject Panel_Start;
    public Text txt_AddUnitBtn;
    public Text txt_ShopExitBtn;
    public Transform slotHolder;
    public Button btn_AddUnit;
    public Button btn_ResultConfirm;

    public Text[] txt_s_unit_slot = new Text[10];


    //OptionUI
    public GameObject Panel_OptionMenu;
    public GameObject Panel_Option;
    public GameObject Panel_SoundSetting;
    public GameObject Panel_Result;
    public Slider slider_BGM;
    public Slider slider_Effect;
    public float bgm_value;
    public float effect_value;
    public Text txt_kill_Result;
    public Text txt_time_Result;
    public Text txt_total_Result;
    public Text txt_unit_Result;
    public Text txt_OptionMenuExit;
    public Text txt_SoundSettingExit;
    public Text txt_GameResultExit;
    public Text txt_GameResultAds;
    public Text txt_GameResultAds3;

    //Loading UI
    public GameObject Panel_Loading;
    public Slider Loading_Bar;
    public Text txt_Loading;
    public Text txt_LoadingTip;
    public List<string> string_tip = new List<string>();

    //GameInfo
    public Transform CenterPos;
    public Transform TraderPos1;
    public Transform TraderPos2;
    public GameObject TouchPos;
    public GameObject[] obj = new GameObject[30]; 
    public GameObject swordman;
    public GameObject bowman;
    public GameObject preist;
    public GameObject wizard;
    public GameObject socerer;
    public GameObject defender;
    public GameObject fairy;
    public GameObject blacksmith;
    public GameObject Egg;
    public GameObject Store;
    public int touchdmg = 0;
    public int start_touchdmg = 50;
    public int gameLevel = 0;
    public float egg_cool = 30f;
    public float egg_fire = 0;
    public float store_cool = 60;
    public float store_fire = 0;
    public int fairyDCnt = 0;
    public int fairyCCnt = 0;
    public int fairyBCnt = 0;
    public int fairyACnt = 0;
    public int fairySCnt = 0;


    //Enemy
    public GameObject Slime;
    public GameObject Bat;
    public GameObject SlimeBoss;
    public GameObject Hyena;
    public GameObject Wolf;
    public GameObject Manticore;
    public GameObject Redbird;
    public GameObject Yellowbird;
    public GameObject Wildbore;
    public GameObject Hellhound;

    

    public float slime_cool = 3.0f;
    public float slime_fire = 0;
    public float bat_cool = 3.0f;
    public float bat_fire = 0;
    public float hyena_cool = 4.0f;
    public float hyena_fire = 0;
    public float redbird_cool = 4.0f;
    public float redbird_fire = 0;
    public float wolf_cool = 5.0f;
    public float wolf_fire = 0;
    public float yellowbird_cool = 5.0f;
    public float yellowbird_fire = 0;
    public bool slimeBossChk = false;
    public bool manticoreChk = false;
    public bool wildboreChk = false;
    public bool hellhoundChk = false;

    public bool shopmenuChk = false;
    public bool optionmenuChk = false;

    public int gamePlayCnt = 0;

    //Unit
    //public GameObject FireSwordMan;

    public AdsInitializer AI;


    void Awake()
    {
        User_ID = LoginMenu.User_ID;
        gameLvl = LobbyManager.gameLvl;
        getLanguage();
        Panel_Loading.SetActive(true);
        txt_Loading.text = "0%";
        Loading_Bar.value = 0.0f;
        getVolumn();
        getGameCnt();
        PlayerInitialize();
        AI.InitializeAds();
    }

    // Start is called before the first frame update
    void Start()
    {
        Panel_Shop.SetActive(false);
        Panel_Result.SetActive(false);
        Panel_SoundSetting.SetActive(false);
        Panel_Option.SetActive(false);
        Panel_OptionMenu.SetActive(false);
        Panel_Start.SetActive(false);

        for(int i = 0; i < 10; i++)
        {
            s_unit_cnt[i] = 0;
        }

        setslot = slotHolder.GetComponentsInChildren<Slot>();

        if(Language == "KOR")
        {
            txt_AddUnitBtn.text = "용병추가";
            txt_ShopExitBtn.text = "나 가 기";
            txt_OptionMenuExit.text = "나 가 기";
            txt_SoundSettingExit.text = "나 가 기";
            txt_GameResultExit.text = "나 가 기";
            txt_GameResultAds.text = "광고(x2 Eggs)";
            txt_GameResultAds3.text = "광고(x2 Eggs)";
        } else if(Language == "Eng")
        {
            txt_AddUnitBtn.text = "Add Unit";
            txt_ShopExitBtn.text = "E X I T";
            txt_OptionMenuExit.text = "E X I T";
            txt_SoundSettingExit.text = "E X I T";
            txt_GameResultExit.text = "E X I T";
            txt_GameResultAds.text = "Ads(x2 Eggs)";
            txt_GameResultAds3.text = "Ads(x2 Eggs)";
        } else
        {
            txt_AddUnitBtn.text = "傭 兵 追 加";
            txt_ShopExitBtn.text = "出  る";
            txt_OptionMenuExit.text = "出  る";
            txt_SoundSettingExit.text = "出  る";
            txt_GameResultExit.text = "出  る";
            txt_GameResultAds.text = "広告(x2 Eggs)";
            txt_GameResultAds3.text = "広告(x2 Eggs)";
        }

        txt_Loading.text = "70%";
        Loading_Bar.value = 0.7f;
        touchdmg = start_touchdmg;

    }


    // Update is called once per frame
    void Update()
    {
        StartPanelOpen();
        EndPanelOpen();
        setGameLevel();
        getAdsUnit();
        
        gameTime = Mathf.RoundToInt(Time.time) - startTime;

        txt_HPTop.text = p_HP.ToString();
        txt_UnitTop.text = g_UnitCnt.ToString() + "/"+ p_UnitCnt.ToString();

        txt_killTop.text = m_killCnt.ToString();
        txt_TimeTop.text = gameTime.ToString();
        txt_EggTop.text = eggCnt.ToString();
        txt_MoneyTop.text = goldCnt.ToString();

        txt_kill_Result.text = m_killCnt.ToString();
        txt_time_Result.text = gameTime.ToString();
        
        
        txt_total_Result.text = (totalScore).ToString();

        txt_UnitValue.text = select_unit_value.ToString();

        for(int i = 0; i < 10; i++)
        {
            txt_s_unit_slot[i].text = s_unit_cnt[i].ToString();
        }
        
        if(select_unit_value > goldCnt)
        {
            txt_UnitValue.color = UnityEngine.Color.red;
        } else 
        {
            txt_UnitValue.color = UnityEngine.Color.black;
        }
        
        if(Input.GetMouseButtonDown(0))
        {
        }

        if(Input.GetMouseButtonUp(0))
        {
            Vector3 Pos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Pos);
            Instantiate(TouchPos, worldPos, Quaternion.identity);   
        }

        SpawnSlime();
        SpawnBat();
        SpawnSlimeBoss();
        SpawnHyena();
        SpawnRedbird();
        SpawnManticore();
        SpawnWolf();
        SpawnYellowbird();
        SpawnWildbore();
        SpawnHellhound();

        SpawnEggs();
        SpawnStore();

        touchdmg = start_touchdmg + (( start_touchdmg * 10 / 100 * fairyDCnt) + (start_touchdmg * 20 / 100 * fairyCCnt) + (start_touchdmg * 30 / 100 * fairyBCnt) + (start_touchdmg * 40 / 100 * fairyACnt) + (start_touchdmg * 50 / 100 * fairySCnt) );

        if(optionmenuChk == false && shopmenuChk == false)
        {
            Time.timeScale = 1;
        }
        

    }

   public void PlayerInitialize()
   {
       PlayFabClientAPI.GetCatalogItems(new GetCatalogItemsRequest(){CatalogVersion = "ARMY1"}
       , (result) =>
       {
           for(int i = 0; i < result.Catalog.Count; i++)
           {
               var unit_db = result.Catalog[i];
               all_unit_id.Add(unit_db.ItemId);
               all_unit_name.Add(unit_db.DisplayName);
               all_unit_grade.Add(unit_db.ItemClass);
               all_unit_value.Add(unit_db.VirtualCurrencyPrices["GD"]);
               allUnitChk = true;
           }
           print("AllUnitInfo Success");
           getPlayerUnitList();
       },
       (error) => print("fail"));

  }

    public void getPlayerUnitList()
    {
        PlayFabClientAPI.GetUserData( new GetUserDataRequest() {PlayFabId = User_ID}
                        , (result) => {
                            PlayerUnitIDList = result.Data["ARMYID"].Value;
                            PlayerUnitNameList = result.Data["ARMYNAME"].Value;
                            getPlayerUnit();
                        }
                        , (error) => {});
    }
    public void getPlayerUnit()
    {
        p_unit_id.Clear();
        p_unit_name.Clear();
        p_unit_grade.Clear();
        p_unit_value.Clear();

        string[] arrUnitID = PlayerUnitIDList.Split(':');
        string[] arrUnitName = PlayerUnitNameList.Split(':');

        for(int i = 0; i < arrUnitID.Length; i++)
        {
            p_unit_id.Add(arrUnitID[i]);
            p_unit_name.Add(arrUnitName[i]);
            p_unit_grade.Add("");
            p_unit_value.Add(0);
        }

        for(int i = 0; i < p_unit_id.Count; i++)
        {
            for(int j = 0; j < all_unit_id.Count; j++)
            {
                if(p_unit_id[i] == all_unit_id[j])
                {
                    p_unit_grade[i] = all_unit_grade[j];
                    p_unit_value[i] = all_unit_value[j];
                }
                
            }
        }

        deleteSlot();
        renewSlot();

        playerUnitChk = true;
        print("PlayerUnit Success");

        Invoke("getPlayerStats", 3f);
        
    }

    public void getPlayerStats()
    {
        PlayFabClientAPI.GetUserData( new GetUserDataRequest() {PlayFabId = User_ID}
                        , (result) => {
                            p_HP = int.Parse(result.Data["HEALTH"].Value);
                            goldCnt = int.Parse(result.Data["POWER"].Value);
                            p_UnitCnt = 30;
                            g_UnitCnt = 0;
                            getPlayerStats_chk = true;
                            print("getPlayerStats Success");

                            

                        }
                        , (error) => {});
    }

    public void getLanguage()
    {
        PlayFabClientAPI.GetUserData( new GetUserDataRequest() {PlayFabId = User_ID}
                        , (result) => {
                            Language = result.Data["Language"].Value;
                           
                            if(Language == "KOR")
                            {
                                txt_AddUnitBtn.text = "용병추가";
                                txt_ShopExitBtn.text = "나 가 기";
                                txt_OptionMenuExit.text = "나 가 기";
                                txt_SoundSettingExit.text = "나 가 기";
                                txt_GameResultExit.text = "나 가 기";
                                txt_GameResultAds.text = "광고(x2 Eggs)";
                                txt_GameResultAds3.text = "광고(x2 Eggs)";
                            } else if(Language == "Eng")
                            {
                                txt_AddUnitBtn.text = "Add Unit";
                                txt_ShopExitBtn.text = "E X I T";
                                txt_OptionMenuExit.text = "E X I T";
                                txt_SoundSettingExit.text = "E X I T";
                                txt_GameResultExit.text = "E X I T";
                                txt_GameResultAds.text = "Ads(x2 Eggs)";
                                txt_GameResultAds3.text = "Ads(x2 Eggs)";
                            } else
                            {
                                txt_AddUnitBtn.text = "傭 兵 追 加";
                                txt_ShopExitBtn.text = "出  る";
                                txt_OptionMenuExit.text = "出  る";
                                txt_SoundSettingExit.text = "出  る";
                                txt_GameResultExit.text = "出  る";
                                txt_GameResultAds.text = "広告(x2 Eggs)";
                                txt_GameResultAds3.text = "広告(x2 Eggs)";
                            }
                            
                            if(Language == "KOR")
                            {
                                string_tip.Add("골드가 부족할땐 몬스터를 터치하세요.");
                                string_tip.Add("닭은 보통 새벽 4~5시에 웁니다.");
                                string_tip.Add("계란 반숙 시간은 8~9분 입니다.");
                                string_tip.Add("계란 완숙 시간은 13~15분 입니다.");
                            } else if(Language == "Eng")
                            {
                                string_tip.Add("Chickens cry at 4 or 5\nin the morning.");
                                string_tip.Add("Need Gold, Touch animal.");
                                string_tip.Add("Egg half-boiled time is\n8-9 minutes.");
                                string_tip.Add("Egg hard-boiled time is\n13-15 minutes.");
                            } else 
                            {
                                string_tip.Add("鶏は通常夜明け4〜5時に泣きます。");
                                string_tip.Add("金が足りない場合は、\n動物に触れてください。");
                                string_tip.Add("卵半熟時間は8-9分です。");
                                string_tip.Add("卵完熟時間は13-15分です。");
                            }
                            int rand_no = UnityEngine.Random.Range(0,string_tip.Count - 1);
                            print(rand_no);
                            txt_LoadingTip.text = string_tip[rand_no];


                            langChk = true;

                            
                        }
                        , (error) => langChk = false);
    }

    public void StartPanelOpen()
    {
        if(startChk == false)
        {
            txt_Loading.text = "70%";
            Loading_Bar.value = 0.7f;  
        } else
        {
            txt_Loading.text = "0%";
            Loading_Bar.value = 0.0f;  
        }

        if(startChk == false && allUnitChk == true && playerUnitChk == true && getPlayerStats_chk == true && langChk == true)
        {
            txt_Loading.text = "100%";
            Loading_Bar.value = 1f;  
            startTime = Mathf.RoundToInt(Time.time);
            Panel_Loading.SetActive(false);
            Panel_Start.SetActive(true);

        }

        return;
    }

    public void EndPanelOpen()
    {
        
        if(p_HP < 1 && startChk == true)
        {
            Panel_Option.SetActive(true);
            Panel_Result.SetActive(true);
            Loading_Bar.value = 0.0f;
            txt_Loading.text = "0";
            optionmenuChk = true;
            Time.timeScale = 0;
            return;
        }
    }

    public void onClickStartBtn()
    {
        Panel_Start.SetActive(false);
        startChk = true;
        txt_TimeTop.text = "0";
        txt_time_Result.text = "0";
        Time.timeScale = 1;
    }

    public void deleteSlot()
    {
        for(int i = 0; i < setslot.Length; i++)
        {
            setslot[i].item_id = null;
            setslot[i].item_info = null;
            setslot[i].item_name = null;
            setslot[i].item_value = 0;
            setslot[i].itemImage.sprite = null;
            setslot[i].BackImg.color = UnityEngine.Color.white;
            setslot[i].SelectedImg.color = UnityEngine.Color.white;
        }
    }
    
    public void renewSlot()
    {
        for(int i = 0; i < p_unit_id.Count; i++)
        {
            setslot[i].item_id = p_unit_id[i];
            setslot[i].item_name = p_unit_name[i];
            setslot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + p_unit_name[i]);
            setslot[i].item_grade = p_unit_grade[i];
            setslot[i].item_value = p_unit_value[i];
          
            if(setslot[i].item_grade == "D")
            {
                setslot[i].BackImg.color = UnityEngine.Color.white;
            } else if (setslot[i].item_grade == "C")
            {
                setslot[i].BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            } else if (setslot[i].item_grade == "B")
            {
                setslot[i].BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            } else if (setslot[i].item_grade == "A")
            {
                setslot[i].BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            } else if (setslot[i].item_grade == "S")
            {
                setslot[i].BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
            }

        }
    }

    public void onClicksetSlot(Slot input_slot)
    {
        SM.PlaySE("button");

        if(input_slot.item_id == null || input_slot.item_id == "")
        {
            return;
        }

        for(int i = 0; i < setslot.Length; i++) 
        {
            setslot[i].SelectedImg.color = UnityEngine.Color.white;
        }
        
        input_slot.SelectedImg.color = UnityEngine.Color.black;

        select_unit_id = input_slot.item_id;
        select_unit_name = input_slot.item_name;
        select_unit_grade = input_slot.item_grade;
        select_unit_value = input_slot.item_value;
    }

    public void onClickCallUnitBtn()
    {
        SM.PlaySE("button");
        if(select_unit_value > goldCnt || g_UnitCnt >= p_UnitCnt)
        {
            return;
        }

        goldCnt = goldCnt - (int)select_unit_value;
        g_UnitCnt++;

        for(int i = 0; i < 10; i++)
        {
            if(select_unit_id == setslot[i].item_id)
            {
                s_unit_cnt[i]++;
            }
        }

        if(select_unit_name == "파이어소드맨_FireSwordMan" ||
           select_unit_name == "아이스소드맨_IceSwordMan" ||
           select_unit_name == "스톤소드맨_StoneSwordMan" ||
           select_unit_name == "썬더소드맨_ThunderSwordMan")
        {
            Instantiate(swordman, CenterPos.position, Quaternion.identity);
        } else if (select_unit_name == "파이어보우맨_FireBowMan" ||
                   select_unit_name == "아이스보우맨_IceBowMan" ||
                   select_unit_name == "스톤보우맨_StoneBowMan" ||
                   select_unit_name == "썬더보우맨_ThunderBowMan")
        {
            Instantiate(bowman, CenterPos.position, Quaternion.identity);
        } else if (select_unit_name == "프리스트_Preist")
        {
            Instantiate(preist, CenterPos.position, Quaternion.identity);
        } else if (select_unit_name == "파이어위자드_FireWizard" ||
                   select_unit_name == "아이스위자드_IceWizard" ||
                   select_unit_name == "스톤위자드_StoneWizard" ||
                   select_unit_name == "썬더위자드_ThunderWizard")
        {
            Instantiate(wizard, CenterPos.position, Quaternion.identity);
        } else if (select_unit_name == "파이어소서러_FireSocerer" ||
                   select_unit_name == "아이스소서러_IceSocerer" ||
                   select_unit_name == "스톤소서러_StoneSocerer" ||
                   select_unit_name == "썬더소서러_ThunderSocerer")
        {
            Instantiate(socerer, CenterPos.position, Quaternion.identity);
        } else if (select_unit_name == "디펜더_Defender")
        {
            Instantiate(defender, CenterPos.position, Quaternion.identity);
        } else if (select_unit_name == "요정_Fairy")
        {
            Instantiate(fairy, CenterPos.position, Quaternion.identity);
        } else if (select_unit_name == "대장장이_BlackSmith")
        {
            Instantiate(blacksmith, CenterPos.position, Quaternion.identity);
        }
    }

    public void onClickKillUnitBtn()
    {
        SM.PlaySE("button");

        obj = null;

        obj = GameObject.FindGameObjectsWithTag("Unit");

        int obj_no = 99;

        for(int i = 0; i < obj.Length; i++)
        {
            if(obj[i].GetComponentInChildren<Slot>().item_id == select_unit_id)
            {
                obj_no = i;
            }
        }

        if(obj_no == 99)
        {
            return;
        }

        for(int i = 0; i < 10; i++)
        {
            if(select_unit_id == setslot[i].item_id)
            {
                s_unit_cnt[i]--;
                if(select_unit_id == "fairyI")
                {
                    fairyDCnt--;
                } else if(select_unit_id == "fairyII")
                {
                    fairyCCnt--;
                } else if(select_unit_id == "fairyIII")
                {
                    fairyBCnt--;
                } else if(select_unit_id == "fairyIIII")
                {
                    fairyACnt--;
                } else if(select_unit_id == "fairyIIIII")
                {
                    fairySCnt--;
                }
            }
        }

        g_UnitCnt--;

        Destroy(obj[obj_no]);
        
    }

    public void getVolumn()
    {
        InitializeVolumn();
        SM.background.volume = PlayerPrefs.GetFloat("BGM");
        for(int i = 0; i<SM.sfxPlayer.Length; i++)
        {
            SM.sfxPlayer[i].volume = PlayerPrefs.GetFloat("Effect");
        }
    }

    public void getGameCnt()
    {
        if(!PlayerPrefs.HasKey("GameCnt"))
        {
            gamePlayCnt = 0;
        } else
        {
            gamePlayCnt = PlayerPrefs.GetInt("GameCnt");
        }

        gamePlayCnt++;
        
    }

    public void setGameCnt()
    {
        PlayerPrefs.SetInt("GameCnt",gamePlayCnt);
    }

    public void InitializeVolumn()
    {
        slider_BGM.value = PlayerPrefs.GetFloat("BGM"); 
        slider_Effect.value = PlayerPrefs.GetFloat("Effect");
    }
    public void setVolumn()
    {
        bgm_value = slider_BGM.value;
        effect_value = slider_Effect.value;
        PlayerPrefs.SetFloat("BGM", slider_BGM.value); 
        PlayerPrefs.SetFloat("Effect", slider_Effect.value);
        getVolumn();
    }

    public void setGameLevel()
    {
        if(gameLvl == "easy")
        {
            gameLevel = gameTime / 30;
            txt_unit_Result.text = "0";
            totalScore = m_killCnt + gameTime;

        } else if(gameLvl == "normal")
        {
            gameLevel = gameTime / 20;
            txt_unit_Result.text = "500";
            totalScore = m_killCnt + gameTime + 500;
        } else if(gameLvl == "hard")
        {
            gameLevel = gameTime / 10;
            txt_unit_Result.text = "1000";
            totalScore = m_killCnt + gameTime + 1000;
        }
    }

    public void getAdsUnit()
    {
        if(AdsUnit == true)
        {
            AdsUnit = false;
            deleteSlot();
            renewSlot();
        }
    }

    public void onClickOptionMenuBtn()
    {
        SM.PlaySE("button");
        Panel_Option.SetActive(true);
        Panel_OptionMenu.SetActive(true);
        Panel_Result.SetActive(false);
        Panel_SoundSetting.SetActive(false);
        Time.timeScale = 0;
        optionmenuChk = true;
        return;
    }

    public void onClickOptionMenuCloseBtn()
    {
        SM.PlaySE("button");
        Panel_Option.SetActive(false);
        Panel_OptionMenu.SetActive(false);
        Panel_Result.SetActive(false);
        Panel_SoundSetting.SetActive(false);
        optionmenuChk = false;
        return;
    }

    public void onClickSoundSettingBtn()
    {
        SM.PlaySE("button");
        Panel_OptionMenu.SetActive(false);
        Panel_SoundSetting.SetActive(true);
        Panel_Result.SetActive(false);
        getVolumn();
        return;
    }
    public void onClickSoundSettingCloseBtn()
    {
        SM.PlaySE("button");
        Panel_OptionMenu.SetActive(true);
        Panel_SoundSetting.SetActive(false);
        Panel_Result.SetActive(false);
        setVolumn();
        return;
    }
    public void onClickRestartBtn()
    {
        SM.PlaySE("button");
        SceneManager.LoadScene("PlayScene");
        Time.timeScale = 1;
        return;
    }
    public void onclickLobbyBtn()
    {
        SM.PlaySE("button");
        Panel_OptionMenu.SetActive(false);
        Panel_Result.SetActive(true);
        Panel_SoundSetting.SetActive(false);
        return;
    }

    public void onClickResultCloseBtn()
    {
        SM.PlaySE("button");
        btn_ResultConfirm.interactable = false;
        setGameCnt();
        Panel_Loading.SetActive(true);
        PlayFabClientAPI.AddUserVirtualCurrency(new PlayFab.ClientModels.AddUserVirtualCurrencyRequest() {
                VirtualCurrency = "EG", Amount = (int)eggCnt}
                            , (result) => {
                                
                                setUserRank();
                            }
                            
                            , (error) => print("fail"));
        return;
    }

    public void setUserRank()
    {

        var request = new UpdatePlayerStatisticsRequest {Statistics = new List<StatisticUpdate> {new StatisticUpdate {StatisticName = "HighScore", Value = totalScore}}};

        PlayFabClientAPI.UpdatePlayerStatistics(request
                                , (result) => {
                                    getUserRank();

                                }
                                , (error) => print("fail"));

    }

    public void getUserRank()
    {
        var request = new GetLeaderboardRequest{ StartPosition = 0, StatisticName = "HighScore", MaxResultsCount = 1
                                                , ProfileConstraints = new PlayerProfileViewConstraints(){ShowLocations = true, ShowDisplayName = true}};
        PlayFabClientAPI.GetLeaderboard(request,
            (result) => {

                    if(result.Leaderboard.Count < 1)
                    {
                        setRankItem();
                        return;
                    }

                    int top_point;
                    top_point = result.Leaderboard[0].StatValue;

                    if(top_point < totalScore)
                    {
                        setRankItem();
                    } else
                    {
                        Time.timeScale = 1;
                        Panel_Loading.SetActive(true);
                        SceneManager.LoadScene("LobbyScene");
                    }

            },
            (error) => 
            {
            });
    }

    public void setRankItem()
    {
        string RankItemName = "";
        string RankItemGrade = "";
        string RankItemInfo = "";

        for(int i = 0; i < p_unit_id.Count; i++)
        {
            if(i == p_unit_id.Count - 1)
            {
                RankItemName = RankItemName + p_unit_name[i];
                RankItemGrade = RankItemGrade + p_unit_grade[i];
            } else 
            {
                RankItemName = RankItemName + p_unit_name[i] + ":";
                RankItemGrade = RankItemGrade + p_unit_grade[i] + ":";
            }

        }

        RankItemInfo = RankItemName + "-" + RankItemGrade;

        print(RankItemInfo);
        PlayFabClientAPI.UpdateUserData(new PlayFab.ClientModels.UpdateUserDataRequest() 
        {Data = new Dictionary<string, string>(){
            {"RANKITEM", RankItemInfo}
        }}
        , (result) => 
        {
            Time.timeScale = 1;
            Panel_Loading.SetActive(true);
            SceneManager.LoadScene("LobbyScene");
        }
        , (error) => print("failed"));
        
    }



    //Shop Menu
    public void onClickShopBtn()
    {
        SM.PlaySE("button");
        Panel_Shop.SetActive(true);
        setAddUnit();
        Time.timeScale = 0;
        
    }

    public void onClickSellEggsBtn()
    {
        SM.PlaySE("button");
        if(eggCnt < 1)
        {
            return;
        } else
        {
            goldCnt = goldCnt + 100;
            eggCnt = eggCnt - 1;
        }
    }

    public void onClickBuyEggsBtn()
    {
        SM.PlaySE("button");
        if(goldCnt < 100)
        {
            return;
        } else
        {
            goldCnt = goldCnt - 100;
            eggCnt = eggCnt + 1;
        }
    }
    public void onClickUnitAddBtn()
    {

        int AddValue = 0;

        if(AddUnitSlot.item_grade == "D")
        {
            AddValue = 100;
        } else if (AddUnitSlot.item_grade == "C")
        {
            AddValue = 200;
        } else if (AddUnitSlot.item_grade == "B")
        {
            AddValue = 300;
        } else if (AddUnitSlot.item_grade == "A")
        {
            AddValue = 400;
        } else if (AddUnitSlot.item_grade == "S")
        {
            AddValue = 500;
        }

        if(goldCnt < AddValue)
        {
            return;
        }

        if(p_unit_id.Count > 9)
        {
            return;
        }

        goldCnt = goldCnt - AddValue;

        p_unit_id.Add(AddUnitSlot.item_id);
        p_unit_name.Add(AddUnitSlot.item_name);
        p_unit_grade.Add(AddUnitSlot.item_grade);
        p_unit_value.Add(AddUnitSlot.item_value);


        deleteSlot();
        renewSlot();

        btn_AddUnit.interactable = false;

    }
    public void onClickShopCloseBtn()
    {
        SM.PlaySE("button");
        shopmenuChk = false;
        Panel_Shop.SetActive(false);
    }


    //ShopMenuEnd

    //PLAY
    public void SpawnEggs()
    {
        if(Time.time > egg_fire && startChk == true)
        {
            Instantiate(Egg, CenterPos.position, Quaternion.identity);
            egg_fire = Time.time + egg_cool;
        }
    }
    public void SpawnStore()
    {
        if(gameLevel > 1 && Time.time > store_fire && startChk == true)
        {
            Instantiate(Store, TraderPos1.position , Quaternion.identity);
            store_fire = Time.time + store_cool;
        }
    }
    public void SpawnSlime()
    {
        if(Time.time > slime_fire && startChk == true)
        {
            for(int i = 0; i < 5; i++)
            {
                Instantiate(Slime, getCirclePosition(), Quaternion.identity);
            }
            slime_fire = Time.time + slime_cool;
        }
    }
    public void SpawnBat()
    {
        if(Time.time > bat_fire && startChk == true && gameLevel >= 1)
        {
            for(int i = 0; i < 5; i++)
            {
                Instantiate(Bat, getCirclePosition(), Quaternion.identity);
            }
            bat_fire = Time.time + bat_cool;
        }
    } 
    public void SpawnHyena()
    {
        if(Time.time > hyena_fire && startChk == true && gameLevel >= 5)
        {
            for(int i = 0; i < 5; i++)
            {
                Instantiate(Hyena, getCirclePosition(), Quaternion.identity);
            }
            hyena_fire = Time.time + hyena_cool;
        }
    } 
    public void SpawnRedbird()
    {
        if(Time.time > redbird_fire && startChk == true && gameLevel >= 6)
        {

            for(int i = 0; i < 5; i++)
            {
                Instantiate(Redbird, getCirclePosition(), Quaternion.identity);
            }
            redbird_fire = Time.time + redbird_cool;
        }
    } 
    public void SpawnWolf()
    {
        if(Time.time > wolf_fire && startChk == true && gameLevel >= 8)
        {
            for(int i = 0; i < 5; i++)
            {
                Instantiate(Wolf, getCirclePosition(), Quaternion.identity);
            }
            wolf_fire = Time.time + wolf_cool;
        }
    } 
    public void SpawnYellowbird()
    {
        if(Time.time > yellowbird_fire && startChk == true && gameLevel >= 6)
        {
            for(int i = 0; i < 5; i++)
            {
                Instantiate(Yellowbird, getCirclePosition(), Quaternion.identity);
            }
            yellowbird_fire = Time.time + yellowbird_cool;
        }
    } 
    public void SpawnSlimeBoss()
    {
        if(startChk == true && slimeBossChk == false && gameLevel >= 3 )
        {
            slimeBossChk = true;
            Instantiate(SlimeBoss, getCirclePosition(), Quaternion.identity);
        }
    }
    public void SpawnManticore()
    {
        if(startChk == true && manticoreChk == false && gameLevel >= 7 )
        {
            manticoreChk = true;
            Instantiate(Manticore, getCirclePosition(), Quaternion.identity);
        }
    }
    public void SpawnWildbore()
    {
        if(startChk == true && wildboreChk == false && gameLevel >= 9 )
        {
            wildboreChk = true;
            Instantiate(Wildbore, getCirclePosition(), Quaternion.identity);
        }
    }
    public void SpawnHellhound()
    {
        if(startChk == true && hellhoundChk == false && gameLevel >= 11 )
        {
            hellhoundChk = true;
            Instantiate(Hellhound, getCirclePosition(), Quaternion.identity);
        }
    }
    public Vector3 getCirclePosition()
    {
        float radius = 0;

        radius = 3f;

        Vector3 spwanpos = CenterPos.position;

        float a = spwanpos.x;
        float b = spwanpos.y;

        float x = UnityEngine.Random.Range(-radius + a, radius + a);
        float y_b = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x - a, 2));
        y_b *= UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        float y = y_b + b;

        Vector3 randomPosition = new Vector3(x, y, 0);
 
        return randomPosition;

    }
    public void setAddUnit()
    {

        AddUnitSlot.item_id = null;
        AddUnitSlot.item_name = null;
        AddUnitSlot.item_grade = null;
        AddUnitSlot.item_value = 0;
        AddUnitSlot.itemImage.sprite = null;
        AddUnitSlot.BackImg.color = UnityEngine.Color.white;

        System.Random randomObj = new System.Random(); // 난수발생 obj

        int rand_unit = randomObj.Next(0,all_unit_id.Count); // 1~8까지 난수발생

        AddUnitSlot.item_id = all_unit_id[rand_unit];
        AddUnitSlot.item_name = all_unit_name[rand_unit];
        AddUnitSlot.item_grade = all_unit_grade[rand_unit];
        AddUnitSlot.item_value = all_unit_value[rand_unit];
        AddUnitSlot.itemImage.sprite = Resources.Load<Sprite>("item/" + all_unit_name[rand_unit]);
          
        if(all_unit_grade[rand_unit] == "D")
        {
            AddUnitSlot.BackImg.color = UnityEngine.Color.white;
            txt_AddUnitBtn.text = "100 GOLD";
        } else if (all_unit_grade[rand_unit] == "C")
        {
            AddUnitSlot.BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            txt_AddUnitBtn.text = "200 GOLD";
        } else if (all_unit_grade[rand_unit] == "B")
        {
            AddUnitSlot.BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            txt_AddUnitBtn.text = "300 GOLD";
        } else if (all_unit_grade[rand_unit] == "A")
        {
            AddUnitSlot.BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            txt_AddUnitBtn.text = "400 GOLD";
        } else if (all_unit_grade[rand_unit] == "S")
        {
            AddUnitSlot.BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
            txt_AddUnitBtn.text = "500 GOLD";
        }

        btn_AddUnit.interactable = true;

        for(int i = 0; i < p_unit_id.Count; i++)
        {
            if(p_unit_id[i] == AddUnitSlot.item_id)
            {
                btn_AddUnit.interactable = false;
            }
        }

        shopmenuChk = true;

    }


}
