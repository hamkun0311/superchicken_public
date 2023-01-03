using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviourPunCallbacks
{
    public string User_ID;
    public SoundManager SM;
    public PhotonView PV;
    public GameManagerNetwork GMN;
    public Transform Chicken;
    public GameObject TouchPos;
    public AdsInitializer AI;

    public string select_unit_id;
    public string select_unit_name;
    public uint select_unit_value = 0;
    public string select_unit_grade;


    public Text txt_EggTop;
    public Text txt_MoneyTop;
    public Text txt_HPTop;
    public Text txt_UnitTop;
    public Text txt_killTop;
    public Text txt_TimeTop;
    public Text txt_UnitValue;
    public Text[] txt_s_unit_slot = new Text[10];

    public GameObject Panel_StartTime;
    public Text txt_startTime;

    //Loading UI
    public GameObject Panel_Loading;
    public Slider Loading_Bar;
    public Text txt_Loading;
    public Text txt_LoadingTip;
    public List<string> string_tip = new List<string>();
    public string Language;

    //OptionUI
    public GameObject Panel_OptionMenu;
    public GameObject Panel_Option;
    public GameObject Panel_SoundSetting;
    public GameObject Panel_Result;
    public Slider slider_BGM;
    public Slider slider_Effect;
    public float bgm_value;
    public float effect_value;
    public Text txt_total_Result;
    public Text txt_rank_Result;
    public Text txt_ruby_Result;
    public Text txt_Egg_Result;
    public Text txt_OptionMenuExit;
    public Text txt_SoundSettingExit;
    public Text txt_GameResultExit;
    public Text txt_GameResultAds;
    public Text txt_GameResultAds3;

    public Button btn_ResultConfirm;

    public bool optionmenuChk = false;
    public int myRank = 0;
    public int gameRank = 0;
    public int totalPoint = 0;

    public int eggCnt = 0;
    public int goldCnt = 1000;
    public int g_unit_cnt = 0;
    public int p_unit_cnt = 30;
    public int rubyCnt = 0;
    public int[] s_unit_cnt = new int[10];
    public int gameTime = 0;
    public int gameLevel = 0;
    public int startTime = 0;
    public int m_killCnt;
    public int p_HP = 50;
    public int touchdmg = 0;
    public int start_touchdmg = 50;

    public List<string> networksetarmyIDList = new List<string>();
    public List<string> networksetarmyNameList = new List<string>();
    public List<string> networksetarmyGradeList = new List<string>();
    public List<uint> networksetarmyValueList = new List<uint>();
    public List<string> network_all_army_id = new List<string>();
    public List<string> network_all_army_name = new List<string>();
    public List<string> network_all_army_info = new List<string>();
    public List<string> network_all_army_grade = new List<string>();
    public List<uint> network_all_army_value = new List<uint>();

    public Transform slotholder;
    public Slot[] setslot = new Slot[10];

    public GameObject swordman;
    public GameObject bowman;
    public GameObject preist;
    public GameObject wizard;
    public GameObject socerer;
    public GameObject defender;
    public GameObject fairy;
    public GameObject blacksmith;

    public GameObject[] obj = new GameObject[30]; 

    public GameObject[] PIL;
    public PlayerInfo PI;
    public List<string> p_info_list;
    public int startplayerCnt;

    public int fairyDCnt = 0;
    public int fairyCCnt = 0;
    public int fairyBCnt = 0;
    public int fairyACnt = 0;
    public int fairySCnt = 0;

    //Enemy

    public float slime_cool = 3.0f;
    public float slime_fire = 0;
    public float bat_cool = 3.0f;
    public float bat_fire = 0;
    public float hyena_cool = 5.0f;
    public float hyena_fire = 0;
    public float redbird_cool = 5.0f;
    public float redbird_fire = 0;
    public float wolf_cool = 7.0f;
    public float wolf_fire = 0;
    public float yellowbird_cool = 7.0f;
    public float yellowbird_fire = 0;
    public float slimeBoss_cool = 5.0f;
    public float slimeBoss_fire = 0;
    public float manticore_cool = 5.0f;
    public float manticore_fire = 0;
    public float wildbore_cool = 6.0f;
    public float wildbore_fire = 0;
    public float hellhound_cool = 6.0f;
    public float hellhound_fire = 0;

    public bool slimeBossChk = false;
    public bool manticoreChk = false;
    public bool wildboreChk = false;
    public bool hellhoundChk = false;

    public int monster_cnt;
    public bool playerChk = false;

    public bool startChk = false;
    public bool langChk = false;
    public bool gameEndChk = false;
    public int gamePlayCnt = 0;

    public GameObject[] monsterList;

    public Text[] txt_player = new Text[4];

    bool bPaused;
    public bool Ads;

    void Awake()
    {
        User_ID = LoginMenu.User_ID;
        myRank = LobbyManager.myRank;
        getLanguage();
        Panel_Loading.SetActive(true);
        txt_Loading.text = "0%";
        Loading_Bar.value = 0.0f;
        getVolumn();
        AI.InitializeAds();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        setslot = slotholder.GetComponentsInChildren<Slot>();
        getslotinfo();
        touchdmg = start_touchdmg;
        Panel_Option.SetActive(false);
        Panel_OptionMenu.SetActive(false);
        Panel_SoundSetting.SetActive(false);
        Panel_StartTime.SetActive(false);
        Panel_Result.SetActive(false);

        for(int i = 0; i < 10; i++)
        {
            s_unit_cnt[i] = 0;
        }

        if(Language == "KOR")
        {
            txt_OptionMenuExit.text = "나 가 기";
            txt_SoundSettingExit.text = "나 가 기";
            txt_GameResultExit.text = "나 가 기";
            txt_GameResultAds.text = "광고(x2 Eggs)";
            txt_GameResultAds3.text = "광고(x2 Eggs)";
        } else if(Language == "Eng")
        {
            txt_OptionMenuExit.text = "E X I T";
            txt_SoundSettingExit.text = "E X I T";
            txt_GameResultExit.text = "E X I T";
            txt_GameResultAds.text = "Ads(x2 Eggs)";
            txt_GameResultAds3.text = "Ads(x2 Eggs)";
        } else
        {
            txt_OptionMenuExit.text = "出  る";
            txt_SoundSettingExit.text = "出  る";
            txt_GameResultExit.text = "出  る";
            txt_GameResultAds.text = "広告(x2 Eggs)";
            txt_GameResultAds3.text = "広告(x2 Eggs)";
        }

        txt_Loading.text = "70%";
        Loading_Bar.value = 0.7f;

        startplayerCnt = GMN.playerCnt;

        StartCoroutine(showStartTime());

    }

    // Update is called once per frame
    void Update()
    {
        if(startChk == true )
        {
            gameTime = Mathf.RoundToInt(Time.time) - startTime;
            gameLevel = gameTime / 15;

            if(gameEndChk == false)
            {
                SpawnSlime();
                SpawnBat();
                SpawnSlimeBoss();
                SpawnHyena();
                SpawnWolf();
                SpawnRedbird();
                SpawnYellowbird();
                SpawnManticore();
                SpawnWildbore();
                SpawnHellhound();
            }
            setPlayerInfo();
            setPlayerData();

            if(Input.GetMouseButtonUp(0))
            {
                Vector3 Pos = Input.mousePosition;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(Pos);
                Instantiate(TouchPos, worldPos, Quaternion.identity);   
            }

            EndPanelOpen();
            printPlayerInfo();
            getMonsterCnt();

            touchdmg = start_touchdmg + (( start_touchdmg * 10 / 100 * fairyDCnt) + (start_touchdmg * 20 / 100 * fairyCCnt) + (start_touchdmg * 30 / 100 * fairyBCnt) + (start_touchdmg * 40 / 100 * fairyACnt) + (start_touchdmg * 50 / 100 * fairySCnt) );

            txt_HPTop.text = p_HP.ToString();
            txt_UnitTop.text = g_unit_cnt.ToString() + "/"+ p_unit_cnt.ToString();

            txt_killTop.text = m_killCnt.ToString();
            txt_TimeTop.text = gameTime.ToString();
            txt_EggTop.text = eggCnt.ToString();
            txt_MoneyTop.text = goldCnt.ToString();

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

            getRankResult();

            txt_Egg_Result.text = eggCnt.ToString();
            txt_ruby_Result.text = rubyCnt.ToString();
            
        } else
        {
            StartPanelOpen();
        }
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
    public void getLanguage()
    {
        PlayFabClientAPI.GetUserData( new GetUserDataRequest() {PlayFabId = User_ID}
                        , (result) => {
                            Language = result.Data["Language"].Value;
                           
                            if(Language == "KOR")
                            {
                                txt_OptionMenuExit.text = "나 가 기";
                                txt_SoundSettingExit.text = "나 가 기";
                                txt_GameResultExit.text = "나 가 기";
                                txt_GameResultAds.text = "광고(+Ruby)";
                                txt_GameResultAds3.text = "광고(+Ruby)";
                            } else if(Language == "Eng")
                            {
                                txt_OptionMenuExit.text = "E X I T";
                                txt_SoundSettingExit.text = "E X I T";
                                txt_GameResultExit.text = "E X I T";
                                txt_GameResultAds.text = "Ads(+Ruby)";
                                txt_GameResultAds3.text = "Ads(+Ruby)";
                            } else
                            {
                                txt_OptionMenuExit.text = "出  る";
                                txt_SoundSettingExit.text = "出  る";
                                txt_GameResultExit.text = "出  る";
                                txt_GameResultAds.text = "広告(+Ruby)";
                                txt_GameResultAds3.text = "広告(+Ruby)";
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


    void getslotinfo()
    {
        getUserItem();
    }
    void getUserItem()
    {
            for(int i = 0; i < LobbyManager.networksetarmyIDList.Count; i++)
            {
                networksetarmyIDList.Add(LobbyManager.networksetarmyIDList[i]);
                networksetarmyNameList.Add(LobbyManager.networksetarmyNameList[i]);
            }
            getAllItem();
    }

    void getAllItem()
    {
            for(int i = 0; i < LobbyManager.network_all_army_id.Count; i++)
            {
                network_all_army_id.Add(LobbyManager.network_all_army_id[i]);
                network_all_army_name.Add(LobbyManager.network_all_army_name[i]);
                network_all_army_grade.Add(LobbyManager.network_all_army_grade[i]);
                network_all_army_value.Add(LobbyManager.network_all_army_value[i]);
            }

            for(int i = 0; i < networksetarmyIDList.Count; i++)
            {
                for(int j = 0; j < network_all_army_id.Count; j++)
                {
                    if(networksetarmyIDList[i] == network_all_army_id[j])
                    {
                        networksetarmyValueList.Add(network_all_army_value[j]);
                        networksetarmyGradeList.Add(network_all_army_grade[j]);
                    }

                }
            }
            setUserSlot();
    }

    public void setUserSlot()
    {
        deleteSlot();
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

        renewSlot();
    }

    public void renewSlot()
    {
        for(int i = 0; i < networksetarmyIDList.Count; i++)
        {
            setslot[i].item_id = networksetarmyIDList[i];
            setslot[i].item_name = networksetarmyNameList[i];
            setslot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + networksetarmyNameList[i]);
            setslot[i].item_grade = networksetarmyGradeList[i];
            setslot[i].item_value = networksetarmyValueList[i];
        
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
        if(select_unit_value > goldCnt || g_unit_cnt >= p_unit_cnt)
        {
            return;
        }

        goldCnt = goldCnt - (int)select_unit_value;
        g_unit_cnt++;

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
            Instantiate(swordman, this.gameObject.transform.position, Quaternion.identity);
        } else if (select_unit_name == "파이어보우맨_FireBowMan" ||
                   select_unit_name == "아이스보우맨_IceBowMan" ||
                   select_unit_name == "스톤보우맨_StoneBowMan" ||
                   select_unit_name == "썬더보우맨_ThunderBowMan")
        {
            Instantiate(bowman, this.gameObject.transform.position, Quaternion.identity);
        } else if (select_unit_name == "프리스트_Preist")
        {
            Instantiate(preist, this.gameObject.transform.position, Quaternion.identity);
        } else if (select_unit_name == "파이어위자드_FireWizard" ||
                   select_unit_name == "아이스위자드_IceWizard" ||
                   select_unit_name == "스톤위자드_StoneWizard" ||
                   select_unit_name == "썬더위자드_ThunderWizard")
        {
            Instantiate(wizard, this.gameObject.transform.position, Quaternion.identity);
        } else if (select_unit_name == "파이어소서러_FireSocerer" ||
                   select_unit_name == "아이스소서러_IceSocerer" ||
                   select_unit_name == "스톤소서러_StoneSocerer" ||
                   select_unit_name == "썬더소서러_ThunderSocerer")
        {
            Instantiate(socerer, this.gameObject.transform.position, Quaternion.identity);
        } else if (select_unit_name == "디펜더_Defender")
        {
            Instantiate(defender, this.gameObject.transform.position, Quaternion.identity);
        } else if (select_unit_name == "요정_Fairy")
        {
            Instantiate(fairy, this.gameObject.transform.position, Quaternion.identity);
        } else if (select_unit_name == "대장장이_BlackSmith")
        {
            Instantiate(blacksmith, this.gameObject.transform.position, Quaternion.identity);
        }
    }

    public void onClickKillUnitBtn()
    {
        //PV.RPC("printMsg", RpcTarget.Others);

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

        g_unit_cnt--;

        Destroy(obj[obj_no]);
        
    }

    public void setPlayerInfo()
    {
        if(gameEndChk == false)
        {
            if(playerChk == false)
            {
                
                PIL = GameObject.FindGameObjectsWithTag("PlayerInfo");
                print(PIL.Length);
                for(int i = 0; i < PIL.Length; i++)
                {
                    if(PIL[i].GetComponent<PlayerInfo>().PV.IsMine)
                    {
                        PI = PIL[i].GetComponent<PlayerInfo>();
                        
                    }
                }
            }
            if(PIL.Length == PhotonNetwork.CurrentRoom.PlayerCount)
            {
                playerChk = true;
            }
        }
    }

    public void setPlayerData()
    {
        PI.p_hp = p_HP;
        PI.p_gold = goldCnt;
    }


    [PunRPC]
    public void callSlimeHeader()
    {
        PV.RPC("callSlimeEnemy", RpcTarget.Others);
    }

    [PunRPC]
    public void callSlimeEnemy()
    { 
        //Instantiate(Slime_Enemy, getCirclePosition(), Quaternion.identity);
        PhotonNetwork.Instantiate("Slime_Enemy", getCirclePosition(), Quaternion.identity);
    }

    public Vector3 getCirclePosition()
    {
            float radius = 0;

            radius = 3f;

            Vector3 spwanpos = Chicken.position;

            float a = spwanpos.x;
            float b = spwanpos.y;

            float x = UnityEngine.Random.Range(-radius + a, radius + a);
            float y_b = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x - a, 2));
            y_b *= UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
            float y = y_b + b;

            Vector3 randomPosition = new Vector3(x, y, 0);
    
            return randomPosition;

    }

    public void SpawnSlime()
    {
        if(PV.IsMine)
        {
            if(Time.time > slime_fire && monster_cnt < 10 )
            {
                if(monster_cnt > 50)
                {
                    return;
                }
                
                for(int i = 0; i < 3; i++)
                {
                    //Instantiate(Slime, getCirclePosition(), Quaternion.identity);
                    PhotonNetwork.Instantiate("Slime_Multi", getCirclePosition(), Quaternion.identity);
                }
                slime_fire = Time.time + slime_cool;
            }   
        }
    }

    public void SpawnBat()
    {
        if(PV.IsMine)
        {
            if(Time.time > bat_fire && monster_cnt < 20  && gameLevel >= 1)
            {
                if(monster_cnt > 50)
                {
                    return;
                }

                for(int i = 0; i < 3; i++)
                {
                    PhotonNetwork.Instantiate("Bat_Multi", getCirclePosition(), Quaternion.identity);
                }
                
                bat_fire = Time.time + bat_cool;
            }
        }
    } 

    public void SpawnSlimeBoss()
    {
        if(PV.IsMine)
        {
            if(gameLevel >= 3 && Time.time > slimeBoss_fire )
            {
                slimeBoss_fire = Time.time + slimeBoss_cool;
                PhotonNetwork.Instantiate("BossSlime_Multi", getCirclePosition(), Quaternion.identity);
            }
        }
    }

    public void SpawnHyena()
    {
        if(PV.IsMine)
        {
            if(Time.time > hyena_fire && monster_cnt < 30 && gameLevel >= 5)
            {
                if(monster_cnt > 50)
                {
                    return;
                }

                for(int i = 0; i < 3; i++)
                {
                    PhotonNetwork.Instantiate("Hyena_Multi", getCirclePosition(), Quaternion.identity);
                }
                
                hyena_fire = Time.time + hyena_cool;
            }
        }
    } 
    public void SpawnWolf()
    {
        if(PV.IsMine)
        {
            if(Time.time > wolf_fire && monster_cnt < 40 && gameLevel >= 8)
            {
                if(monster_cnt > 50)
                {
                    return;
                }

                for(int i = 0; i < 3; i++)
                {
                    PhotonNetwork.Instantiate("Wolf_Multi", getCirclePosition(), Quaternion.identity);
                }
                
                wolf_fire = Time.time + wolf_cool;
            }
        }
    } 

    public void SpawnRedbird()
    {
        if(PV.IsMine)
        {
            if(Time.time > redbird_fire && monster_cnt < 30 && gameLevel >= 6)
            {
                if(monster_cnt > 50)
                {
                    return;
                }

                for(int i = 0; i < 3; i++)
                {
                    PhotonNetwork.Instantiate("Redbird_Multi", getCirclePosition(), Quaternion.identity);
                }
                
                redbird_fire = Time.time + redbird_cool;
            }
        }
    } 

    public void SpawnYellowbird()
    {
        if(PV.IsMine)
        {
            if(Time.time > yellowbird_fire && monster_cnt < 40 && gameLevel >= 6)
            {
                if(monster_cnt > 50)
                {
                    return;
                }

                for(int i = 0; i < 3; i++)
                {
                    PhotonNetwork.Instantiate("Yellowbird_Multi", getCirclePosition(), Quaternion.identity);
                }
                
                yellowbird_fire = Time.time + yellowbird_cool;
            }
        }
    } 

    public void SpawnManticore()
    {
        if(PV.IsMine)
        {
            if(Time.time > manticore_fire && gameLevel >= 7 )
            {
                manticore_fire = Time.time + manticore_cool;
                PhotonNetwork.Instantiate("Manticore_Multi", getCirclePosition(), Quaternion.identity);
            }
        }
    }
    public void SpawnWildbore()
    {
        if(PV.IsMine)
        {
            if( Time.time > wildbore_fire && gameLevel >= 9 )
            {
                wildbore_fire = Time.time+wildbore_cool;
                PhotonNetwork.Instantiate("Wildbore_Multi", getCirclePosition(), Quaternion.identity);
            }
        }
    }
    public void SpawnHellhound()
    {
        if(PV.IsMine)
        {
            if( Time.time > hellhound_fire  && gameLevel >= 11 )
            {
                hellhound_fire = Time.time + hellhound_cool;
                PhotonNetwork.Instantiate("Hellhound_Multi", getCirclePosition(), Quaternion.identity);
            }
        }
    }

    public void printPlayerInfo()
    {
        if(gameEndChk == false)
        {
            p_info_list.Clear();

            for(int i = 0; i < 4; i++)
            {
                txt_player[i].text = "No Player\n0";
            }

            for(int i = 0; i < PIL.Length; i++)
            {
                if(!PIL[i].GetComponent<PlayerInfo>().PV.IsMine)
                {
                    p_info_list.Add(PIL[i].GetComponent<PlayerInfo>().PV.Owner.NickName + "\n" + PIL[i].GetComponent<PlayerInfo>().p_hp);
                }
            }

            for(int i = 0; i < p_info_list.Count; i++)
            {
                txt_player[i].text = p_info_list[i];
            }
        }

    }

    public void getMonsterCnt()
    {
        monsterList = GameObject.FindGameObjectsWithTag("Enemy");
        monster_cnt = monsterList.Length;
    }

    private IEnumerator showStartTime()
    {
        float currentTime = 5;

        while(currentTime > 0)
        {
            txt_startTime.text = currentTime.ToString();
            currentTime--;
            yield return new WaitForSeconds(1);
        }

        startChk = true;
        Panel_StartTime.SetActive(false);

    }

    public void StartPanelOpen()
    {
        if(startChk == false)
        {
            txt_Loading.text = "100%";
            Loading_Bar.value = 1f;  
        } else
        {
            txt_Loading.text = "0%";
            Loading_Bar.value = 0.0f;  
        }

        if(startChk == false && langChk == true)
        {
            txt_Loading.text = "100%";
            Loading_Bar.value = 1f;  
            startTime = Mathf.RoundToInt(Time.time);
            Panel_Loading.SetActive(false);
            Panel_StartTime.SetActive(true);


        }

        return;
    }

    public void EndPanelOpen()
    {
        
        if((p_HP < 1 && gameEndChk == false) || (gameRank == 1 && gameEndChk == false))
        {
            gameEndChk = true;
            Panel_Option.SetActive(true);
            Panel_Result.SetActive(true);
            Loading_Bar.value = 0.0f;
            txt_Loading.text = "0";
            optionmenuChk = true;
            PhotonNetwork.Disconnect();
            Time.timeScale = 0;
            return;
        }
    }

    public void getRankResult()
    {
        if(startplayerCnt > 2)
        {
            if(gameRank == 1)
            {
                txt_total_Result.text = "TOP 1 Player!";
                txt_rank_Result.text = (myRank + 5).ToString() + "(+5)";
                rubyCnt = rubyCnt + 3;
                totalPoint = myRank + 5;
            } else if(gameRank == 2)
            {
                txt_total_Result.text = "TOP 2 Player!";
                txt_rank_Result.text = (myRank + 4).ToString()+ "(+4)";
                rubyCnt = rubyCnt + 2;
                totalPoint = myRank + 4;
            } else if(gameRank == 3)
            {
                txt_total_Result.text = "TOP 3 Player!";
                txt_rank_Result.text = (myRank + 3).ToString()+ "(+3)";
                rubyCnt = rubyCnt + 1;
                totalPoint = myRank + 3;
            } else if(gameRank == 4)
            {
                txt_total_Result.text = "TOP 4 Player!";
                txt_rank_Result.text = (myRank).ToString()+ "(+2)";
                totalPoint = myRank + 2 ;
            } else if(gameRank == 5)
            {
                txt_total_Result.text = "TOP 5 Player!";
                txt_rank_Result.text = (myRank + 1).ToString()+ "(+1)";
                totalPoint = myRank + 1 ;
            }
        } else 
        {
            if(gameRank == 1)
            {
                txt_total_Result.text = "TOP 1 Player!";
                txt_rank_Result.text = (myRank + 3).ToString() + "(+3)";
                rubyCnt = rubyCnt + 1;
                totalPoint = myRank + 3;
            } else if(gameRank == 2)
            {
                txt_total_Result.text = "TOP 2 Player!";
                txt_rank_Result.text = (myRank + 1).ToString()+ "(+1)";
                totalPoint = myRank + 1;
            }
        }
    }

    public void onClickResultCloseBtn()
    {
        SM.PlaySE("button");
        Time.timeScale = 1;
        btn_ResultConfirm.interactable = false;
        setGameCnt();
        Panel_Loading.SetActive(true);
        PlayFabClientAPI.AddUserVirtualCurrency(new PlayFab.ClientModels.AddUserVirtualCurrencyRequest() {
                VirtualCurrency = "EG", Amount = (int)eggCnt}
                            , (result) => {
                                
                                grantRuby();
                            }
                            
                            , (error) => print("fail"));
        return;
    }

    public void grantRuby()
    {
        PlayFabClientAPI.AddUserVirtualCurrency(new PlayFab.ClientModels.AddUserVirtualCurrencyRequest() {
                VirtualCurrency = "RB", Amount = (int)rubyCnt}
                            , (result) => {
                                
                                setUserRank();
                            }
                            
                            , (error) => print("fail"));
        
        return;
    }

    public void setUserRank()
    {

        var request = new UpdatePlayerStatisticsRequest {Statistics = new List<StatisticUpdate> {new StatisticUpdate {StatisticName = "pvp_Rank", Value = totalPoint}}};

        PlayFabClientAPI.UpdatePlayerStatistics(request
                                , (result) => {
                                    Connect();
                                }
                                , (error) => print("fail"));

    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        JoinLobby();
    }
    public void JoinLobby()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        JoinOrCreatRoom();
    }
    public void JoinOrCreatRoom()
    {
        PhotonNetwork.LocalPlayer.NickName = UnityEngine.Random.Range(1,99999).ToString();
        byte maxPlayers = 1;
        int maxTime = 3600;

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayers; // 인원 지정.
        roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { "maxTime", maxTime } }; // 게임 시간 지정.
        roomOptions.CustomRoomPropertiesForLobby = new string[] { "maxTime" }; // 여기에 키 값을 등록해야, 필터링이 가능하다.

        // 방 참가를 시도하고, 실패하면 생성해서 참가함.
        PhotonNetwork.JoinRandomOrCreateRoom(
            expectedCustomRoomProperties: new ExitGames.Client.Photon.Hashtable() { { "maxTime", maxTime } }, expectedMaxPlayers: maxPlayers, // 참가할 때의 기준.
            roomOptions: roomOptions // 생성할 때의 기준.
        );

        
    }
    public override void OnJoinedRoom()
    {
        print("방 참가 완료.");
        SceneManager.LoadScene("LobbyScene");
        PhotonNetwork.Disconnect();
        
    }


    public void onClickOptionMenuBtn()
    {
        SM.PlaySE("button");
        Panel_Option.SetActive(true);
        Panel_OptionMenu.SetActive(true);
        Panel_Result.SetActive(false);
        Panel_SoundSetting.SetActive(false);
        Time.timeScale = 1;
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

    public void onClickGameQuitBtn()
    {
        SM.PlaySE("button");
        Application.Quit();
        PhotonNetwork.Disconnect();
        return;
    }

    public void onclickLobbyBtn()
    {
        SM.PlaySE("button");
        SceneManager.LoadScene("LobbyScene");
        PhotonNetwork.Disconnect();
        Time.timeScale = 1;
        return;
    }

    void OnApplicationPause(bool bPaused) {
        
        if(Ads == false)
        {
            Application.Quit();
        }

    }

    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
