using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.ServerModels;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ArmyManager : MonoBehaviour
{
    public GameObject Panel_Army;
    public GameObject Panel_ArmyMenu;
    public GameObject Panel_GetArmy;
    public GameObject Panel_ArmyCnt;
    public GameObject Panel_SetArmy;
    public GameObject Panel_EnforceArmy;
    public GameObject Panel_EnforceInfo;
    public GameObject Panel_GetArmyResultList;
    public GameObject Panel_GetArmyResult;
    public GameObject Panel_GetArmyResult2;
    public GameObject Panel_Result;
    public GameObject Panel_Loading;

    public Text txt_Result;
    public Text txt_Loading;

    //용병메뉴
    public Text txt_UnitMenuTitle;
    public Text txt_UnitCouponBtn;
    public Text txt_UnitEntryBtn;
    public Text txt_UnitEnforceBtn;
    public Text txt_UnitMenuExitBtn;

    //용병교환권
    public Text txt_UnitCouponTitle;
    public Text txt_CouponName;
    public Text txt_CouponInfo;
    public Text txt_UnitCouponConfirmBtn;
    public Text txt_UnitCouponExitBtn;
    public Image img_select_coupon;

    //용병고용
    public Text txt_UnitEntryTitle;
    public Text txt_ArmyName;
    public Text txt_ArmyInfo;
    public Text txt_EntryPlusBtn;
    public Text txt_EntryMinusBtn;
    public Text txt_EntryConfirmBtn;
    public Text txt_EntryExitBtn;
    public Image img_select_army;
    public Text txt_ArmyCntTitle;
    public Text txt_ArmyCnt;
    public Text txt_ArmyCntUseBtn;
    public Text txt_ArmyCntCancelBtn;

    //용병강화
    public Text txt_UnitPowerUPTitle;
    public Text txt_UnitPowerUPBtn;
    public Text txt_EnforceArmyName;
    public Text txt_EnforceArmyInfo;
    public Text txt_EnforcePlusBtn;
    public Text txt_EnforceMinusBtn;
    public Text txt_UnitPowerUPExit;
    public Text txt_EnforceBtn;
    public Text Txt_EnforcePercent;
    public Text txt_EnforeBeforeGrade;
    public Text txt_EnforeNextGrade;
    public Text txt_EnforceBeforeCnt;
    public Text txt_EnforceNextCnt;
    public Text txt_EnforceAllConfirmBtn;
    public Text txt_EnforceAllCancelBtn;
    public Text txt_EnforceAllResultGrade;
    public Text txt_EnforceAllResultCnt;
    public Image img_select_army_EF;
    public Image img_Enforce1;
    public Image img_Enforce2;
    public Image img_EnforceAllResult;

    //용병메뉴 결과
    public Text txt_ArmyResultBtn;


    public string User_ID;
    public LobbyManager LM;
    
    

    public Slot[] user_coupon_slot = new Slot[110];
    public Slot[] user_army_slot = new Slot[110];
    public Slot[] set_army_slot = new Slot[5];
    public Slot[] user_enforce_army_slot = new Slot[110];
    public Slot[] user_enforce_set_slot = new Slot[3];
    public Slot[] coupon_result_List_slot = new Slot[100];
    public Slot[] coupon_result_slot = new Slot[1];
    


    public Transform slotHolder;
    public Transform SH_GetArmyResult;
    public Transform SH_GetArmyResultList;

    public Transform SH_SetArmyList;
    public Transform SH_UserArmyList;

    public Transform SH_UserArmyListEF;
    public Transform SH_SetArmyListEF;

    public List<string> user_coupon_id = new List<string>();
    public List<string> user_coupon_info = new List<string>();
    public List<string> user_coupon_name = new List<string>();
    public List<uint> user_coupon_value = new List<uint>();
    public List<int> user_coupon_cnt = new List<int>();
    public List<string> user_coupon_instance_id = new List<string>();

    public string select_user_coupon_id;
    public string select_user_coupon_name;
    public uint select_user_coupon_value;
    public string select_user_coupon_info;
    public int select_user_coupon_cnt;
    public string select_user_coupon_instance_id;
    public List<string> setArmyID = new List<string>();
    public List<string> setArmyName = new List<string>();
    public List<string> setArmyGrade = new List<string>();

    public List<string> user_army_id = new List<string>();
    public List<string> user_army_info = new List<string>();
    public List<string> user_army_name = new List<string>();
    public List<string> user_army_grade = new List<string>();
    public List<uint> user_army_value = new List<uint>();
    public List<int> user_army_cnt = new List<int>();
    public List<string> user_army_instance_id = new List<string>();
    public List<int> user_army_grade_code = new List<int>();

    public string select_army_id;
    public string select_army_name;
    public uint select_army_value;
    public string select_army_info;
    public string select_army_grade;
    public int select_army_cnt;
    public string select_army_instance_id;

    public List<string> user_enforce_army_id = new List<string>();
    public List<string> user_enforce_army_info = new List<string>();
    public List<string> user_enforce_army_name = new List<string>();
    public List<string> user_enforce_army_grade = new List<string>();
    public List<uint> user_enforce_army_value = new List<uint>();
    public List<int> user_enforce_army_cnt = new List<int>();
    public List<string> user_enforce_army_instance_id = new List<string>();
    public List<int> user_enforce_army_grade_code = new List<int>();
    public string select_enforce_army_id;
    public string select_enforce_army_name;
    public string select_enforce_army_grade;
    public uint select_enforce_army_value;
    public string select_enforce_army_info;
    public int select_enforce_army_cnt;
    public string select_enforce_army_instance_id;

    public List<string> setEnforceArmyID = new List<string>();
    public List<string> setEnforceArmyName = new List<string>();
    public List<string> setEnforceArmyGrade = new List<string>();
    public List<string> setEnforceArmyInstance = new List<string>();

    public List<string> user_allenforce_army_id = new List<string>();
    public List<string> user_allenforce_army_info = new List<string>();
    public List<string> user_allenforce_army_name = new List<string>();
    public List<string> user_allenforce_army_grade = new List<string>();
    public List<uint> user_allenforce_army_value = new List<uint>();
    public List<int> user_allenforce_army_cnt = new List<int>();
    public List<string> user_allenforce_army_instance_id = new List<string>();
    public List<int> user_allenforce_army_grade_code = new List<int>();
    public List<string> itemList = new List<string>();
    public List<string> newItemList = new List<string>();

    public int total_item_cnt = 0;
    public int consume_item_cnt = 0;
    public int successCnt = 0;

    public bool Enforce_Success_flag = false;
    public int panel_flag = 0;
    public int panel_subflag = 0;

    // Start is called before the first frame update
    void Start()
    {
        Panel_Army.SetActive(false);
        Panel_ArmyMenu.SetActive(false);
        Panel_GetArmy.SetActive(false);
        Panel_ArmyCnt.SetActive(false);
        Panel_SetArmy.SetActive(false);
        Panel_EnforceArmy.SetActive(false);
        Panel_EnforceInfo.SetActive(false);
        Panel_Result.SetActive(false);
        Panel_Loading.SetActive(false);
        Panel_GetArmyResultList.SetActive(false);
        Panel_GetArmyResult.SetActive(false);
        Panel_GetArmyResult2.SetActive(false);

        img_select_coupon.gameObject.SetActive(false);
        img_select_army.gameObject.SetActive(false);
        img_select_army_EF.gameObject.SetActive(false);
        
        user_coupon_slot = slotHolder.GetComponentsInChildren<Slot>();
        coupon_result_List_slot = SH_GetArmyResultList.GetComponentsInChildren<Slot>();
        coupon_result_slot = SH_GetArmyResult.GetComponentsInChildren<Slot>();
        user_army_slot = SH_UserArmyList.GetComponentsInChildren<Slot>();
        set_army_slot = SH_SetArmyList.GetComponentsInChildren<Slot>();
        user_enforce_army_slot = SH_UserArmyListEF.GetComponentsInChildren<Slot>();
        user_enforce_set_slot = SH_SetArmyListEF.GetComponentsInChildren<Slot>();

        User_ID = LoginMenu.User_ID;

        if(LM.Language == "KOR")
        {
            txt_UnitMenuTitle.text = "용 병 메 뉴";
            txt_UnitCouponBtn.text = "용병교환권";
            txt_UnitEntryBtn.text = "용병고용";
            txt_UnitEnforceBtn.text = "용병강화";
            txt_UnitMenuExitBtn.text = "나 가 기";
            txt_UnitCouponTitle.text = "용 병 교 환 권";
            txt_CouponName.text = "";
            txt_CouponInfo.text = "";
            txt_UnitCouponConfirmBtn.text = "사 용";
            txt_UnitCouponExitBtn.text = "닫 기";
            txt_UnitEntryTitle.text = "용 병 고 용";
            txt_ArmyName.text = "";
            txt_ArmyInfo.text = "";
            txt_EntryPlusBtn.text = "고 용";
            txt_EntryMinusBtn.text = "해 고";
            txt_EntryConfirmBtn.text = "확 인";
            txt_EntryExitBtn.text = "닫 기";
            txt_UnitPowerUPTitle.text = "용 병 강 화";
            txt_UnitPowerUPBtn.text = "강 화";
            txt_EnforceArmyName.text = "";
            txt_EnforceArmyInfo.text = "";
            txt_EnforcePlusBtn.text = "추 가";
            txt_EnforceMinusBtn.text = "제 외";
            txt_UnitPowerUPExit.text = "닫 기";
            txt_ArmyResultBtn.text = "확 인";
            txt_ArmyCntTitle.text = "사용 수량";
            txt_ArmyCntUseBtn.text = "사 용";
            txt_ArmyCntCancelBtn.text = "닫 기";
            txt_EnforceAllConfirmBtn.text = "강 화";
            txt_EnforceAllCancelBtn.text = "취 소";
        } else if(LM.Language == "Eng")
        {
            txt_UnitMenuTitle.text = "U N I T";
            txt_UnitCouponBtn.text = "Unit Coupon";
            txt_UnitEntryBtn.text = "Unit Entry";
            txt_UnitEnforceBtn.text = "Unit UP";
            txt_UnitMenuExitBtn.text = "E X I T";
            txt_UnitCouponTitle.text = "Unit Coupon";
            txt_CouponName.text = "";
            txt_CouponInfo.text = "";
            txt_UnitCouponConfirmBtn.text = "USE";
            txt_UnitCouponExitBtn.text = "EXIT";
            txt_UnitEntryTitle.text = "Unit Entry";
            txt_ArmyName.text = "";
            txt_ArmyInfo.text = "";
            txt_EntryPlusBtn.text = "Add";
            txt_EntryMinusBtn.text = "Delete";
            txt_EntryConfirmBtn.text = "Confirm";
            txt_EntryExitBtn.text = "EXIT";
            txt_UnitPowerUPTitle.text = "Unit PowerUP";
            txt_UnitPowerUPBtn.text = "U P";
            txt_EnforceArmyName.text = "Select Unit";
            txt_EnforceArmyInfo.text = "Select Unit";
            txt_EnforcePlusBtn.text = "Add";
            txt_EnforceMinusBtn.text = "Delete";
            txt_UnitPowerUPExit.text = "E X I T";
            txt_ArmyResultBtn.text = "Confirm";
            txt_ArmyCntTitle.text = "Count";
            txt_ArmyCntUseBtn.text = "USE";
            txt_ArmyCntCancelBtn.text = "EXIT";
            txt_EnforceAllConfirmBtn.text = "U P";
            txt_EnforceAllCancelBtn.text = "Cancel";
        } else
        {
            txt_UnitMenuTitle.text = "傭  兵";
            txt_UnitCouponBtn.text = "傭兵クーポン";
            txt_UnitEntryBtn.text = "傭 兵 雇 用";
            txt_UnitEnforceBtn.text = "傭 兵 強 化";
            txt_UnitMenuExitBtn.text = "出 る";
            txt_UnitCouponTitle.text = "傭兵クーポン";
            txt_CouponName.text = "";
            txt_CouponInfo.text = "";
            txt_UnitCouponConfirmBtn.text = "使 用";
            txt_UnitCouponExitBtn.text = "出 る";
            txt_UnitEntryTitle.text = "傭 兵 雇 用";
            txt_ArmyName.text = "";
            txt_ArmyInfo.text = "";
            txt_EntryPlusBtn.text = "追 加";
            txt_EntryMinusBtn.text = "除 外";
            txt_EntryConfirmBtn.text = "は い";
            txt_EntryExitBtn.text = "い い え";
            txt_UnitPowerUPTitle.text = "傭 兵 強 化";
            txt_UnitPowerUPBtn.text = "強 化";
            txt_EnforceArmyName.text = "";
            txt_EnforceArmyInfo.text = "";
            txt_EnforcePlusBtn.text = "追 加";
            txt_EnforceMinusBtn.text = "除 外";
            txt_UnitPowerUPExit.text = "出 る";
            txt_ArmyResultBtn.text = "は い";
            txt_ArmyCntTitle.text = "数 量";
            txt_ArmyCntUseBtn.text = "は い";
            txt_ArmyCntCancelBtn.text = "出 る";
            txt_EnforceAllConfirmBtn.text = "強 化";
            txt_EnforceAllCancelBtn.text = "出 る";
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(user_enforce_set_slot[0].item_grade == "D")
        {
            txt_EnforceBtn.text = "100%";
        } else if(user_enforce_set_slot[0].item_grade == "C")
        {
            txt_EnforceBtn.text = "70%";
        } else if(user_enforce_set_slot[0].item_grade == "B")
        {
            int addcnt = 0;
            for(int i = 0; i < 3; i++ )
            {
                if(user_enforce_set_slot[i].item_id == "heroSpiritA")
                {
                    addcnt = addcnt + 5;
                }
            }
            txt_EnforceBtn.text = (40 + addcnt).ToString() + "%";
        } else if(user_enforce_set_slot[0].item_grade == "A")
        {
            float addcnt = 0;
            for(int i = 0; i < 3; i++ )
            {
                if(user_enforce_set_slot[i].item_id == "heroSpiritS")
                {
                    addcnt = addcnt + 2.5f;
                }
            }
            txt_EnforceBtn.text = (10 + addcnt).ToString() + "%";
        } else
        {
            if(LM.Language == "KOR")
            {
                txt_EnforceBtn.text = "강 화";
            } else 
            {
                txt_EnforceBtn.text = "U P";
            }
            
        }
    }
    //army 건물 클릭시
    public void onClickArmyMenuBtn()
    {
        SoundManager.instance.PlaySE("button");

        if(LM.Language == "KOR")
        {
            txt_UnitMenuTitle.text = "용 병 메 뉴";
            txt_UnitCouponBtn.text = "용병교환권";
            txt_UnitEntryBtn.text = "용병고용";
            txt_UnitEnforceBtn.text = "용병강화";
            txt_UnitMenuExitBtn.text = "나 가 기";
            txt_UnitCouponTitle.text = "용 병 교 환 권";
            txt_CouponName.text = "";
            txt_CouponInfo.text = "";
            txt_UnitCouponConfirmBtn.text = "사 용";
            txt_UnitCouponExitBtn.text = "닫 기";
            txt_UnitEntryTitle.text = "용 병 고 용";
            txt_ArmyName.text = "";
            txt_ArmyInfo.text = "";
            txt_EntryPlusBtn.text = "고 용";
            txt_EntryMinusBtn.text = "해 고";
            txt_EntryConfirmBtn.text = "확 인";
            txt_EntryExitBtn.text = "닫 기";
            txt_UnitPowerUPTitle.text = "용 병 강 화";
            txt_UnitPowerUPBtn.text = "강 화";
            txt_EnforceArmyName.text = "";
            txt_EnforceArmyInfo.text = "";
            txt_EnforcePlusBtn.text = "추 가";
            txt_EnforceMinusBtn.text = "제 외";
            txt_UnitPowerUPExit.text = "닫 기";
            txt_ArmyResultBtn.text = "확 인";
            txt_ArmyCntTitle.text = "사용 수량";
            txt_ArmyCntUseBtn.text = "사 용";
            txt_ArmyCntCancelBtn.text = "닫 기";
            txt_EnforceAllConfirmBtn.text = "강 화";
            txt_EnforceAllCancelBtn.text = "취 소";
        } else if(LM.Language == "Eng")
        {
            txt_UnitMenuTitle.text = "U N I T";
            txt_UnitCouponBtn.text = "Unit Coupon";
            txt_UnitEntryBtn.text = "Unit Entry";
            txt_UnitEnforceBtn.text = "Unit UP";
            txt_UnitMenuExitBtn.text = "E X I T";
            txt_UnitCouponTitle.text = "Unit Coupon";
            txt_CouponName.text = "";
            txt_CouponInfo.text = "";
            txt_UnitCouponConfirmBtn.text = "USE";
            txt_UnitCouponExitBtn.text = "EXIT";
            txt_UnitEntryTitle.text = "Unit Entry";
            txt_ArmyName.text = "";
            txt_ArmyInfo.text = "";
            txt_EntryPlusBtn.text = "Add";
            txt_EntryMinusBtn.text = "Delete";
            txt_EntryConfirmBtn.text = "Confirm";
            txt_EntryExitBtn.text = "EXIT";
            txt_UnitPowerUPTitle.text = "Unit PowerUP";
            txt_UnitPowerUPBtn.text = "U P";
            txt_EnforceArmyName.text = "Select Unit";
            txt_EnforceArmyInfo.text = "Select Unit";
            txt_EnforcePlusBtn.text = "Add";
            txt_EnforceMinusBtn.text = "Delete";
            txt_UnitPowerUPExit.text = "E X I T";
            txt_ArmyResultBtn.text = "Confirm";
            txt_ArmyCntTitle.text = "Count";
            txt_ArmyCntUseBtn.text = "USE";
            txt_ArmyCntCancelBtn.text = "EXIT";
            txt_EnforceAllConfirmBtn.text = "U P";
            txt_EnforceAllCancelBtn.text = "Cancel";
        } else
        {
            txt_UnitMenuTitle.text = "傭  兵";
            txt_UnitCouponBtn.text = "傭兵クーポン";
            txt_UnitEntryBtn.text = "傭 兵 雇 用";
            txt_UnitEnforceBtn.text = "傭 兵 強 化";
            txt_UnitMenuExitBtn.text = "出 る";
            txt_UnitCouponTitle.text = "傭兵クーポン";
            txt_CouponName.text = "";
            txt_CouponInfo.text = "";
            txt_UnitCouponConfirmBtn.text = "使 用";
            txt_UnitCouponExitBtn.text = "出 る";
            txt_UnitEntryTitle.text = "傭 兵 雇 用";
            txt_ArmyName.text = "";
            txt_ArmyInfo.text = "";
            txt_EntryPlusBtn.text = "追 加";
            txt_EntryMinusBtn.text = "除 外";
            txt_EntryConfirmBtn.text = "は い";
            txt_EntryExitBtn.text = "い い え";
            txt_UnitPowerUPTitle.text = "傭 兵 強 化";
            txt_UnitPowerUPBtn.text = "強 化";
            txt_EnforceArmyName.text = "";
            txt_EnforceArmyInfo.text = "";
            txt_EnforcePlusBtn.text = "追 加";
            txt_EnforceMinusBtn.text = "除 外";
            txt_UnitPowerUPExit.text = "出 る";
            txt_ArmyResultBtn.text = "は い";
            txt_ArmyCntTitle.text = "数 量";
            txt_ArmyCntUseBtn.text = "は い";
            txt_ArmyCntCancelBtn.text = "出 る";
            txt_EnforceAllConfirmBtn.text = "強 化";
            txt_EnforceAllCancelBtn.text = "出 る";
        }
        Panel_Army.SetActive(true);
        Panel_ArmyMenu.SetActive(true);
    }
    //용병교환권 클릭
    public void onClickGetArmyBtn()
    {

        SoundManager.instance.PlaySE("button");
        Panel_ArmyMenu.SetActive(false);

        panel_flag = 1;
        panel_subflag = 0;

        if(LM.Language == "KOR")
        {
            txt_Loading.text = "불러오는 중..";
        } else 
        {
            txt_Loading.text = "Loading..";
        }

        Panel_Loading.SetActive(true);
        Panel_GetArmy.SetActive(true);
        getUserCouponList();
    }
    //용병고용 클릭
    public void onClickSetArmyBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_ArmyMenu.SetActive(false);

        panel_flag = 2;
        panel_subflag = 0;

        if(LM.Language == "KOR")
        {
            txt_Loading.text = "불러오는 중..";
        } else 
        {
            txt_Loading.text = "Loading..";
        }

        Panel_Loading.SetActive(true);
        Panel_SetArmy.SetActive(true);
        getUserArmyList();
    }
    //용병강화 클릭
    public void onClickEnforceArmyBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_ArmyMenu.SetActive(false);

        panel_flag = 3;
        panel_subflag = 0;

        if(LM.Language == "KOR")
        {
            txt_Loading.text = "불러오는 중..";
        } else 
        {
            txt_Loading.text = "Loading..";
        }

        Panel_Loading.SetActive(true);
        Panel_EnforceArmy.SetActive(true);
        getUserEnforceArmyList();
    }
    //용병매뉴 나가기 버튼
    public void onClickArmyMenuQuitBtn()
    {
        SoundManager.instance.PlaySE("button");
        panel_flag = 0;
        panel_subflag = 0;
        Panel_Army.SetActive(false);
        Panel_ArmyMenu.SetActive(false);
    }

    //용병고용권 
    public void getUserCouponList()
    {

        if(LM.Language == "KOR")
        {
            txt_Loading.text = "불러오는 중..";
        } else 
        {
            txt_Loading.text = "Loading..";
        }
        Panel_Loading.SetActive(true);

        user_coupon_id.Clear();
        user_coupon_name.Clear();
        user_coupon_info.Clear();
        user_coupon_value.Clear();
        user_coupon_cnt.Clear();
        user_coupon_instance_id.Clear();

        for(int i = 0; i < user_coupon_slot.Length; i++)
        {
            user_coupon_slot[i].SelectedImg.color = UnityEngine.Color.white;
        }

        deleteSlot();

        PlayFabClientAPI.GetUserInventory(new PlayFab.ClientModels.GetUserInventoryRequest(),
        (result) => 
        {
            
            foreach(var item in result.Inventory)
            {
                if (item.CatalogVersion == "COUPON" || item.CatalogVersion == "MONEY")
                {
                    user_coupon_id.Add(item.ItemId);
                    user_coupon_name.Add(item.DisplayName);
                    user_coupon_value.Add(item.UnitPrice);
                    user_coupon_cnt.Add(item.RemainingUses.Value);
                    user_coupon_instance_id.Add(item.ItemInstanceId);
                    
                }

            }

            for(int i = 0; i < user_coupon_id.Count; i++)
            {
                user_coupon_slot[i].item_id = user_coupon_id[i];
                user_coupon_slot[i].item_name = user_coupon_name[i];
                user_coupon_slot[i].item_value = user_coupon_value[i];
                user_coupon_slot[i].item_count = user_coupon_cnt[i];
                user_coupon_slot[i].item_instance_id = user_coupon_instance_id[i];
                user_coupon_slot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + user_coupon_name[i]);
                user_coupon_slot[i].itemImage.preserveAspect = true;

                for(int j = 0; j < LM.all_coupon_id.Count; j++)
                {
                    if(user_coupon_slot[i].item_id == LM.all_coupon_id[j])
                    {
                        user_coupon_slot[i].item_info = LM.all_coupon_info[j];
                    }
                }

                if(user_coupon_slot[i].item_id == "money.chest.ruby300" ||user_coupon_slot[i].item_id == "money.chest.ruby50")
                {
                    if(LM.Language == "KOR")
                    {
                        user_coupon_slot[i].item_info = "사용 시 루비 획득_ ";
                    }else if(LM.Language == "Eng")
                    {
                        user_coupon_slot[i].item_info = "_Use get Ruby";
                    } else 
                    {
                        user_coupon_slot[i].item_info = "_使用時にルビーを獲得";
                    }
                    
                }

                if(user_coupon_slot[i].item_id == "3")
                {
                    if(LM.Language == "KOR")
                    {
                        user_coupon_slot[i].item_info = "S : 3%\nA : 27%\nB : 70%_";
                    } else 
                    {
                        user_coupon_slot[i].item_info = "_S : 3%\nA : 27%\nB : 70%";
                    }
                }

            }
            Panel_Loading.SetActive(false);
            Panel_Result.SetActive(false);
        }, 
        (error) => {

            if(LM.Language == "KOR")
            {
                txt_Result.text = "불러오기 실패!";
            }else
            {
                txt_Result.text = "Loading Failed!";
            }
            
            Panel_Result.SetActive(true);
        });


    }

    public void deleteSlot()
    {
        for(int i = 0; i < user_coupon_slot.Length; i++)
        {
            user_coupon_slot[i].item_id = null;
            user_coupon_slot[i].item_info = null;
            user_coupon_slot[i].item_name = null;
            user_coupon_slot[i].item_value = 0;
            user_coupon_slot[i].item_count = 0;
            user_coupon_slot[i].item_instance_id = null;
            user_coupon_slot[i].itemImage.sprite = null;
        }

    }

    public void onClickCouponSlot(Slot input_slot)
    {
        try
        {
            if(input_slot.item_id.Length < 1)
            {
                return;
            }

            img_select_coupon.gameObject.SetActive(true);

            SoundManager.instance.PlaySE("button");
            
            for(int i = 0; i<user_coupon_slot.Length; i++)
            {
                user_coupon_slot[i].SelectedImg.color = UnityEngine.Color.white;
            }

            input_slot.SelectedImg.color = UnityEngine.Color.black;

            select_user_coupon_id = input_slot.item_id;
            select_user_coupon_name = input_slot.item_name;
            select_user_coupon_value = input_slot.item_value;
            select_user_coupon_info = input_slot.item_info;
            select_user_coupon_cnt = input_slot.item_count;
            select_user_coupon_instance_id = input_slot.item_instance_id;

            img_select_coupon.sprite = Resources.Load<Sprite>("item/" + select_user_coupon_name);

            if(select_user_coupon_name == "" || select_user_coupon_name == null)
            {
                return;
            }

            string[] languagecoupon_name = select_user_coupon_name.Split('_');
            string[] languagecoupon_info = select_user_coupon_info.Split('_');
            
            if(LM.Language == "KOR")
            {
                txt_CouponName.text = languagecoupon_name[0];
                txt_CouponInfo.text = languagecoupon_info[0] + "\n갯수 : " + select_user_coupon_cnt;
            } else if(LM.Language == "Eng")
            {
                txt_CouponName.text = languagecoupon_name[1];
                txt_CouponInfo.text = languagecoupon_info[1] + "\nCount : " + select_user_coupon_cnt;
            } else
            {
                txt_CouponName.text = languagecoupon_name[1];
                txt_CouponInfo.text = languagecoupon_info[1] + "\n数 量 : " + select_user_coupon_cnt;
            }

        } catch (NullReferenceException ex){ 
        }
        
    }

    public void onClickUseCouponCntPlusBtn()
    {
        SoundManager.instance.PlaySE("button");
        
        if(int.Parse(txt_ArmyCnt.text) >= 10 || int.Parse(txt_ArmyCnt.text) >= select_user_coupon_cnt)
        {
            return;
        }

        txt_ArmyCnt.text = (int.Parse(txt_ArmyCnt.text) + 1).ToString();
    }

    public void onClickUseCouponCntMinusBtn()
    {
        SoundManager.instance.PlaySE("button");
        if(int.Parse(txt_ArmyCnt.text) <= 1 )
        {
            return;
        }

        txt_ArmyCnt.text = (int.Parse(txt_ArmyCnt.text) - 1).ToString();
    }

    public void onClickUseCouponCountBtn()
    {
        SoundManager.instance.PlaySE("button");


        int selectNum = 0;
        selectNum = int.Parse(txt_ArmyCnt.text);



        Panel_ArmyCnt.SetActive(false);
        Panel_Loading.SetActive(true);

        if(LM.Language == "KOR")
        {
            txt_Loading.text = "교환권 사용중..";
        }else if(LM.Language == "Eng")
        {
            txt_Loading.text = "Using Items..";
        }else
        {
            txt_Loading.text = "クーポン使用中..";
        }

        
        Panel_Loading.SetActive(true);

        System.Random randomObj = new System.Random(); // 난수발생 obj

        if(select_user_coupon_id == "money.chest.ruby300" || select_user_coupon_id == "money.chest.ruby50")
        {
            if(select_user_coupon_id == "money.chest.ruby300")
            {
                grantUserRuby(select_user_coupon_instance_id, 300, selectNum);
            } else if(select_user_coupon_id == "money.chest.ruby50")
            {
                grantUserRuby(select_user_coupon_instance_id, 100, selectNum);
            }
            return;
        }

        List<string> getArmyID = new List<string>();
        List<string> getArmyName = new List<string>();
        List<string> getArmyGrade = new List<string>();

        //용병교환권(D)
        for(int a = 0; a < selectNum; a++)
        {
            if (select_user_coupon_id == "2")
            {
                for(int i = 0; i < 10; i++)
                {
                    int rand_army = randomObj.Next(1,21); // 1~13까지 난수발생
                    if(rand_army == 1)
                    {
                        getArmyID.Add("fswordI");
                        getArmyName.Add("파이어소드맨_FireSwordMan");
                    } else if(rand_army == 2)
                    {
                        getArmyID.Add("iswordI");
                        getArmyName.Add("아이스소드맨_IceSwordMan");
                    } else if(rand_army == 3)
                    {
                        getArmyID.Add("sswordI");
                        getArmyName.Add("스톤소드맨_StoneSwordMan");
                    } else if(rand_army == 4)
                    {
                        getArmyID.Add("tswordI");
                        getArmyName.Add("썬더소드맨_ThunderSwordMan");
                    } else if(rand_army == 5)
                    {
                        getArmyID.Add("fbowI");
                        getArmyName.Add("파이어보우맨_FireBowMan");
                    } else if(rand_army == 6)
                    {
                        getArmyID.Add("ibowI");
                        getArmyName.Add("아이스보우맨_IceBowMan");
                    } else if(rand_army == 7)
                    {
                        getArmyID.Add("sbowI");
                        getArmyName.Add("스톤보우맨_StoneBowMan");
                    } else if(rand_army == 8)
                    {
                        getArmyID.Add("tbowI");
                        getArmyName.Add("썬더보우맨_ThunderBowMan");
                    } else if(rand_army == 9)
                    {
                        getArmyID.Add("preistI");
                        getArmyName.Add("프리스트_Preist");
                    } else if(rand_army == 10)
                    {
                        getArmyID.Add("fwizardI");
                        getArmyName.Add("파이어위자드_FireWizard");
                    } else if(rand_army == 11)
                    {
                        getArmyID.Add("iwizardI");
                        getArmyName.Add("아이스위자드_IceWizard");
                    } else if(rand_army == 12)
                    {
                        getArmyID.Add("swizardI");
                        getArmyName.Add("스톤위자드_StoneWizard");
                    } else if(rand_army == 13)
                    {
                        getArmyID.Add("twizardI");
                        getArmyName.Add("썬더위자드_ThunderWizard");
                    } else if(rand_army == 14)
                    {
                        getArmyID.Add("fsocererI");
                        getArmyName.Add("파이어소서러_FireSocerer");
                    } else if(rand_army == 15)
                    {
                        getArmyID.Add("isocererI");
                        getArmyName.Add("아이스소서러_IceSocerer");
                    } else if(rand_army == 16)
                    {
                        getArmyID.Add("ssocererI");
                        getArmyName.Add("스톤소서러_StoneSocerer");
                    } else if(rand_army == 17)
                    {
                        getArmyID.Add("tsocererI");
                        getArmyName.Add("썬더소서러_ThunderSocerer");
                    } else if(rand_army == 18)
                    {
                        getArmyID.Add("defenderI");
                        getArmyName.Add("디펜더_Defender");
                    } else if(rand_army == 19)
                    {
                        getArmyID.Add("fairyI");
                        getArmyName.Add("요정_Fairy");
                    } else if(rand_army == 20)
                    {
                        getArmyID.Add("smithI");
                        getArmyName.Add("대장장이_BlackSmith");
                    }
                }
                for(int i = 0; i < getArmyID.Count; i++)
                {
                    getArmyGrade.Add("D");
                }
                //grantNewArmyList(getArmyID, getArmyName, getArmyGrade);
            } 
            else if (select_user_coupon_id == "3")
            {
                for(int i = 0; i < 10; i++)
                {
                    int rand_grade = randomObj.Next(1,101); // 1~100까지 난수발생
                    if(rand_grade >= 1 && rand_grade <= 69) // 1~69 : B등급
                    {
                        getArmyGrade.Add("B");
                        int rand_army = randomObj.Next(1,21);

                        if(rand_army == 1)
                        {
                            getArmyID.Add("fswordIII");
                            getArmyName.Add("파이어소드맨_FireSwordMan");
                        } else if(rand_army == 2)
                        {
                            getArmyID.Add("iswordIII");
                            getArmyName.Add("아이스소드맨_IceSwordMan");
                        } else if(rand_army == 3)
                        {
                            getArmyID.Add("sswordIII");
                            getArmyName.Add("스톤소드맨_StoneSwordMan");
                        } else if(rand_army == 4)
                        {
                            getArmyID.Add("tswordIII");
                            getArmyName.Add("썬더소드맨_ThunderSwordMan");
                        } else if(rand_army == 5)
                        {
                            getArmyID.Add("fbowIII");
                            getArmyName.Add("파이어보우맨_FireBowMan");
                        } else if(rand_army == 6)
                        {
                            getArmyID.Add("ibowIII");
                            getArmyName.Add("아이스보우맨_IceBowMan");
                        } else if(rand_army == 7)
                        {
                            getArmyID.Add("sbowIII");
                            getArmyName.Add("스톤보우맨_StoneBowMan");
                        } else if(rand_army == 8)
                        {
                            getArmyID.Add("tbowIII");
                            getArmyName.Add("썬더보우맨_ThunderBowMan");
                        } else if(rand_army == 9)
                        {
                            getArmyID.Add("preistIII");
                            getArmyName.Add("프리스트_Preist");
                        } else if(rand_army == 10)
                        {
                            getArmyID.Add("fwizardIII");
                            getArmyName.Add("파이어위자드_FireWizard");
                        } else if(rand_army == 11)
                        {
                            getArmyID.Add("iwizardIII");
                            getArmyName.Add("아이스위자드_IceWizard");
                        } else if(rand_army == 12)
                        {
                            getArmyID.Add("swizardIII");
                            getArmyName.Add("스톤위자드_StoneWizard");
                        } else if(rand_army == 13)
                        {
                            getArmyID.Add("twizardIII");
                            getArmyName.Add("썬더위자드_ThunderWizard");
                        } else if(rand_army == 14)
                        {
                            getArmyID.Add("fsocererIII");
                            getArmyName.Add("파이어소서러_FireSocerer");
                        } else if(rand_army == 15)
                        {
                            getArmyID.Add("isocererIII");
                            getArmyName.Add("아이스소서러_IceSocerer");
                        } else if(rand_army == 16)
                        {
                            getArmyID.Add("ssocererIII");
                            getArmyName.Add("스톤소서러_StoneSocerer");
                        } else if(rand_army == 17)
                        {
                            getArmyID.Add("tsocererIII");
                            getArmyName.Add("썬더소서러_ThunderSocerer");
                        } else if(rand_army == 18)
                        {
                            getArmyID.Add("defenderIII");
                            getArmyName.Add("디펜더_Defender");
                        } else if(rand_army == 19)
                        {
                            getArmyID.Add("fairyIII");
                            getArmyName.Add("요정_Fairy");
                        } else if(rand_army == 20)
                        {
                            getArmyID.Add("smithIII");
                            getArmyName.Add("대장장이_BlackSmith");
                        }
                    } else if(rand_grade >= 70 && rand_grade <= 97)
                    {
                        int rand_army = randomObj.Next(1,21);
                        getArmyGrade.Add("A");
                        if(rand_army == 1)
                        {
                            getArmyID.Add("fswordIIII");
                            getArmyName.Add("파이어소드맨_FireSwordMan");
                        } else if(rand_army == 2)
                        {
                            getArmyID.Add("iswordIIII");
                            getArmyName.Add("아이스소드맨_IceSwordMan");
                        } else if(rand_army == 3)
                        {
                            getArmyID.Add("sswordIIII");
                            getArmyName.Add("스톤소드맨_StoneSwordMan");
                        } else if(rand_army == 4)
                        {
                            getArmyID.Add("tswordIIII");
                            getArmyName.Add("썬더소드맨_ThunderSwordMan");
                        } else if(rand_army == 5)
                        {
                            getArmyID.Add("fbowIIII");
                            getArmyName.Add("파이어보우맨_FireBowMan");
                        } else if(rand_army == 6)
                        {
                            getArmyID.Add("ibowIIII");
                            getArmyName.Add("아이스보우맨_IceBowMan");
                        } else if(rand_army == 7)
                        {
                            getArmyID.Add("sbowIIII");
                            getArmyName.Add("스톤보우맨_StoneBowMan");
                        } else if(rand_army == 8)
                        {
                            getArmyID.Add("tbowIIII");
                            getArmyName.Add("썬더보우맨_ThunderBowMan");
                        } else if(rand_army == 9)
                        {
                            getArmyID.Add("preistIIII");
                            getArmyName.Add("프리스트_Preist");
                        } else if(rand_army == 10)
                        {
                            getArmyID.Add("fwizardIIII");
                            getArmyName.Add("파이어위자드_FireWizard");
                        } else if(rand_army == 11)
                        {
                            getArmyID.Add("iwizardIIII");
                            getArmyName.Add("아이스위자드_IceWizard");
                        } else if(rand_army == 12)
                        {
                            getArmyID.Add("swizardIIII");
                            getArmyName.Add("스톤위자드_StoneWizard");
                        } else if(rand_army == 13)
                        {
                            getArmyID.Add("twizardIIII");
                            getArmyName.Add("썬더위자드_ThunderWizard");
                        } else if(rand_army == 14)
                        {
                            getArmyID.Add("fsocererIIII");
                            getArmyName.Add("파이어소서러_FireSocerer");
                        } else if(rand_army == 15)
                        {
                            getArmyID.Add("isocererIIII");
                            getArmyName.Add("아이스소서러_IceSocerer");
                        } else if(rand_army == 16)
                        {
                            getArmyID.Add("ssocererIIII");
                            getArmyName.Add("스톤소서러_StoneSocerer");
                        } else if(rand_army == 17)
                        {
                            getArmyID.Add("tsocererIIII");
                            getArmyName.Add("썬더소서러_ThunderSocerer");
                        } else if(rand_army == 18)
                        {
                            getArmyID.Add("defenderIIII");
                            getArmyName.Add("디펜더_Defender");
                        } else if(rand_army == 19)
                        {
                            getArmyID.Add("fairyIIII");
                            getArmyName.Add("요정_Fairy");
                        } else if(rand_army == 20)
                        {
                            getArmyID.Add("smithIIII");
                            getArmyName.Add("대장장이_BlackSmith");
                        }
                    } else if(rand_grade >= 98 && rand_grade <= 100)
                    {
                        int rand_army = randomObj.Next(1,21);
                        getArmyGrade.Add("S");
                        if(rand_army == 1)
                        {
                            getArmyID.Add("fswordIIIII");
                            getArmyName.Add("파이어소드맨_FireSwordMan");
                        } else if(rand_army == 2)
                        {
                            getArmyID.Add("iswordIIIII");
                            getArmyName.Add("아이스소드맨_IceSwordMan");
                        } else if(rand_army == 3)
                        {
                            getArmyID.Add("sswordIIIII");
                            getArmyName.Add("스톤소드맨_StoneSwordMan");
                        } else if(rand_army == 4)
                        {
                            getArmyID.Add("tswordIIIII");
                            getArmyName.Add("썬더소드맨_ThunderSwordMan");
                        } else if(rand_army == 5)
                        {
                            getArmyID.Add("fbowIIIII");
                            getArmyName.Add("파이어보우맨_FireBowMan");
                        } else if(rand_army == 6)
                        {
                            getArmyID.Add("ibowIIIII");
                            getArmyName.Add("아이스보우맨_IceBowMan");
                        } else if(rand_army == 7)
                        {
                            getArmyID.Add("sbowIIIII");
                            getArmyName.Add("스톤보우맨_StoneBowMan");
                        } else if(rand_army == 8)
                        {
                            getArmyID.Add("tbowIIIII");
                            getArmyName.Add("썬더보우맨_ThunderBowMan");
                        } else if(rand_army == 9)
                        {
                            getArmyID.Add("preistIIIII");
                            getArmyName.Add("프리스트_Preist");
                        } else if(rand_army == 10)
                        {
                            getArmyID.Add("fwizardIIIII");
                            getArmyName.Add("파이어위자드_FireWizard");
                        } else if(rand_army == 11)
                        {
                            getArmyID.Add("iwizardIIIII");
                            getArmyName.Add("아이스위자드_IceWizard");
                        } else if(rand_army == 12)
                        {
                            getArmyID.Add("swizardIIIII");
                            getArmyName.Add("스톤위자드_StoneWizard");
                        } else if(rand_army == 13)
                        {
                            getArmyID.Add("twizardIIIII");
                            getArmyName.Add("썬더위자드_ThunderWizard");
                        } else if(rand_army == 14)
                        {
                            getArmyID.Add("fsocererIIIII");
                            getArmyName.Add("파이어소서러_FireSocerer");
                        } else if(rand_army == 15)
                        {
                            getArmyID.Add("isocererIIIII");
                            getArmyName.Add("아이스소서러_IceSocerer");
                        } else if(rand_army == 16)
                        {
                            getArmyID.Add("ssocererIIIII");
                            getArmyName.Add("스톤소서러_StoneSocerer");
                        } else if(rand_army == 17)
                        {
                            getArmyID.Add("tsocererIIIII");
                            getArmyName.Add("썬더소서러_ThunderSocerer");
                        } else if(rand_army == 18)
                        {
                            getArmyID.Add("defenderIIIII");
                            getArmyName.Add("디펜더_Defender");
                        } else if(rand_army == 19)
                        {
                            getArmyID.Add("fairyIIIII");
                            getArmyName.Add("요정_Fairy");
                        } else if(rand_army == 20)
                        {
                            getArmyID.Add("smithIIIII");
                            getArmyName.Add("대장장이_BlackSmith");
                        }
                        
                    } 
                    
                }
            }
            else if (select_user_coupon_id == "4")
            {
                for(int i = 0; i < 10; i++)
                {
                    int rand_army = randomObj.Next(1,21); // 1~13까지 난수발생
                    if(rand_army == 1)
                    {
                        getArmyID.Add("fswordII");
                        getArmyName.Add("파이어소드맨_FireSwordMan");
                    } else if(rand_army == 2)
                    {
                        getArmyID.Add("iswordII");
                        getArmyName.Add("아이스소드맨_IceSwordMan");
                    } else if(rand_army == 3)
                    {
                        getArmyID.Add("sswordII");
                        getArmyName.Add("스톤소드맨_StoneSwordMan");
                    } else if(rand_army == 4)
                    {
                        getArmyID.Add("tswordII");
                        getArmyName.Add("썬더소드맨_ThunderSwordMan");
                    } else if(rand_army == 5)
                    {
                        getArmyID.Add("fbowII");
                        getArmyName.Add("파이어보우맨_FireBowMan");
                    } else if(rand_army == 6)
                    {
                        getArmyID.Add("ibowII");
                        getArmyName.Add("아이스보우맨_IceBowMan");
                    } else if(rand_army == 7)
                    {
                        getArmyID.Add("sbowII");
                        getArmyName.Add("스톤보우맨_StoneBowMan");
                    } else if(rand_army == 8)
                    {
                        getArmyID.Add("tbowII");
                        getArmyName.Add("썬더보우맨_ThunderBowMan");
                    } else if(rand_army == 9)
                    {
                        getArmyID.Add("preistII");
                        getArmyName.Add("프리스트_Preist");
                    } else if(rand_army == 10)
                    {
                        getArmyID.Add("fwizardII");
                        getArmyName.Add("파이어위자드_FireWizard");
                    } else if(rand_army == 11)
                    {
                        getArmyID.Add("iwizardII");
                        getArmyName.Add("아이스위자드_IceWizard");
                    } else if(rand_army == 12)
                    {
                        getArmyID.Add("swizardII");
                        getArmyName.Add("스톤위자드_StoneWizard");
                    } else if(rand_army == 13)
                    {
                        getArmyID.Add("twizardII");
                        getArmyName.Add("썬더위자드_ThunderWizard");
                    } else if(rand_army == 14)
                    {
                        getArmyID.Add("fsocererII");
                        getArmyName.Add("파이어소서러_FireSocerer");
                    } else if(rand_army == 15)
                    {
                        getArmyID.Add("isocererII");
                        getArmyName.Add("아이스소서러_IceSocerer");
                    } else if(rand_army == 16)
                    {
                        getArmyID.Add("ssocererII");
                        getArmyName.Add("스톤소서러_StoneSocerer");
                    } else if(rand_army == 17)
                    {
                        getArmyID.Add("tsocererII");
                        getArmyName.Add("썬더소서러_ThunderSocerer");
                    } else if(rand_army == 18)
                    {
                        getArmyID.Add("defenderII");
                        getArmyName.Add("디펜더_Defender");
                    } else if(rand_army == 19)
                    {
                        getArmyID.Add("fairyII");
                        getArmyName.Add("요정_Fairy");
                    } else if(rand_army == 20)
                    {
                        getArmyID.Add("smithII");
                        getArmyName.Add("대장장이_BlackSmith");
                    }
                }
                for(int i = 0; i < getArmyID.Count; i++)
                {
                    getArmyGrade.Add("C");
                }
            }
            else if (select_user_coupon_id == "5")
            {
                for(int i = 0; i < 10; i++)
                {
                    int rand_army = randomObj.Next(1,21); // 1~13까지 난수발생
                    if(rand_army == 1)
                    {
                        getArmyID.Add("fswordIII");
                        getArmyName.Add("파이어소드맨_FireSwordMan");
                    } else if(rand_army == 2)
                    {
                        getArmyID.Add("iswordIII");
                        getArmyName.Add("아이스소드맨_IceSwordMan");
                    } else if(rand_army == 3)
                    {
                        getArmyID.Add("sswordIII");
                        getArmyName.Add("스톤소드맨_StoneSwordMan");
                    } else if(rand_army == 4)
                    {
                        getArmyID.Add("tswordIII");
                        getArmyName.Add("썬더소드맨_ThunderSwordMan");
                    } else if(rand_army == 5)
                    {
                        getArmyID.Add("fbowIII");
                        getArmyName.Add("파이어보우맨_FireBowMan");
                    } else if(rand_army == 6)
                    {
                        getArmyID.Add("ibowIII");
                        getArmyName.Add("아이스보우맨_IceBowMan");
                    } else if(rand_army == 7)
                    {
                        getArmyID.Add("sbowIII");
                        getArmyName.Add("스톤보우맨_StoneBowMan");
                    } else if(rand_army == 8)
                    {
                        getArmyID.Add("tbowIII");
                        getArmyName.Add("썬더보우맨_ThunderBowMan");
                    } else if(rand_army == 9)
                    {
                        getArmyID.Add("preistIII");
                        getArmyName.Add("프리스트_Preist");
                    } else if(rand_army == 10)
                    {
                        getArmyID.Add("fwizardIII");
                        getArmyName.Add("파이어위자드_FireWizard");
                    } else if(rand_army == 11)
                    {
                        getArmyID.Add("iwizardIII");
                        getArmyName.Add("아이스위자드_IceWizard");
                    } else if(rand_army == 12)
                    {
                        getArmyID.Add("swizardIII");
                        getArmyName.Add("스톤위자드_StoneWizard");
                    } else if(rand_army == 13)
                    {
                        getArmyID.Add("twizardIII");
                        getArmyName.Add("썬더위자드_ThunderWizard");
                    } else if(rand_army == 14)
                    {
                        getArmyID.Add("fsocererIII");
                        getArmyName.Add("파이어소서러_FireSocerer");
                    } else if(rand_army == 15)
                    {
                        getArmyID.Add("isocererIII");
                        getArmyName.Add("아이스소서러_IceSocerer");
                    } else if(rand_army == 16)
                    {
                        getArmyID.Add("ssocererIII");
                        getArmyName.Add("스톤소서러_StoneSocerer");
                    } else if(rand_army == 17)
                    {
                        getArmyID.Add("tsocererIII");
                        getArmyName.Add("썬더소서러_ThunderSocerer");
                    } else if(rand_army == 18)
                    {
                        getArmyID.Add("defenderIII");
                        getArmyName.Add("디펜더_Defender");
                    } else if(rand_army == 19)
                    {
                        getArmyID.Add("fairyIII");
                        getArmyName.Add("요정_Fairy");
                    } else if(rand_army == 20)
                    {
                        getArmyID.Add("smithIII");
                        getArmyName.Add("대장장이_BlackSmith");
                    }
                }
                for(int i = 0; i < getArmyID.Count; i++)
                {
                    getArmyGrade.Add("B");
                }
            } 
            else if (select_user_coupon_id == "6")
            {
                for(int i = 0; i < 10; i++)
                {
                    int rand_army = randomObj.Next(1,21); // 1~13까지 난수발생
                    if(rand_army == 1)
                    {
                        getArmyID.Add("fswordIIII");
                        getArmyName.Add("파이어소드맨_FireSwordMan");
                    } else if(rand_army == 2)
                    {
                        getArmyID.Add("iswordIIII");
                        getArmyName.Add("아이스소드맨_IceSwordMan");
                    } else if(rand_army == 3)
                    {
                        getArmyID.Add("sswordIIII");
                        getArmyName.Add("스톤소드맨_StoneSwordMan");
                    } else if(rand_army == 4)
                    {
                        getArmyID.Add("tswordIIII");
                        getArmyName.Add("썬더소드맨_ThunderSwordMan");
                    } else if(rand_army == 5)
                    {
                        getArmyID.Add("fbowIIII");
                        getArmyName.Add("파이어보우맨_FireBowMan");
                    } else if(rand_army == 6)
                    {
                        getArmyID.Add("ibowIIII");
                        getArmyName.Add("아이스보우맨_IceBowMan");
                    } else if(rand_army == 7)
                    {
                        getArmyID.Add("sbowIIII");
                        getArmyName.Add("스톤보우맨_StoneBowMan");
                    } else if(rand_army == 8)
                    {
                        getArmyID.Add("tbowIIII");
                        getArmyName.Add("썬더보우맨_ThunderBowMan");
                    } else if(rand_army == 9)
                    {
                        getArmyID.Add("preistIIII");
                        getArmyName.Add("프리스트_Preist");
                    } else if(rand_army == 10)
                    {
                        getArmyID.Add("fwizardIIII");
                        getArmyName.Add("파이어위자드_FireWizard");
                    } else if(rand_army == 11)
                    {
                        getArmyID.Add("iwizardIIII");
                        getArmyName.Add("아이스위자드_IceWizard");
                    } else if(rand_army == 12)
                    {
                        getArmyID.Add("swizardIIII");
                        getArmyName.Add("스톤위자드_StoneWizard");
                    } else if(rand_army == 13)
                    {
                        getArmyID.Add("twizardIIII");
                        getArmyName.Add("썬더위자드_ThunderWizard");
                    } else if(rand_army == 14)
                    {
                        getArmyID.Add("fsocererIIII");
                        getArmyName.Add("파이어소서러_FireSocerer");
                    } else if(rand_army == 15)
                    {
                        getArmyID.Add("isocererIIII");
                        getArmyName.Add("아이스소서러_IceSocerer");
                    } else if(rand_army == 16)
                    {
                        getArmyID.Add("ssocererIIII");
                        getArmyName.Add("스톤소서러_StoneSocerer");
                    } else if(rand_army == 17)
                    {
                        getArmyID.Add("tsocererIIII");
                        getArmyName.Add("썬더소서러_ThunderSocerer");
                    } else if(rand_army == 18)
                    {
                        getArmyID.Add("defenderIIII");
                        getArmyName.Add("디펜더_Defender");
                    } else if(rand_army == 19)
                    {
                        getArmyID.Add("fairyIIII");
                        getArmyName.Add("요정_Fairy");
                    } else if(rand_army == 20)
                    {
                        getArmyID.Add("smithIIII");
                        getArmyName.Add("대장장이_BlackSmith");
                    }
                }
                for(int i = 0; i < getArmyID.Count; i++)
                {
                    getArmyGrade.Add("A");
                }
            }
        }
        grantNewArmyList(getArmyID, getArmyName, getArmyGrade, selectNum);
    }

    public void onClickUseCouponBtn()
    {
        SoundManager.instance.PlaySE("button");
        
        if(txt_CouponName.text == "")
        {

            if(LM.Language == "KOR")
            {
                txt_Result.text = "교환권을 선택하세요!";
            }else if(LM.Language == "Eng")
            {
                txt_Result.text = "Select Items!";
            }else
            {
                txt_Result.text = "クーポンを\n選択してください!";
            }
            Panel_Result.SetActive(true);
            return;
        }

        Panel_GetArmy.SetActive(false);
        Panel_ArmyCnt.SetActive(true);
    }

    public void onClickUseCouponCountCloseBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_GetArmy.SetActive(true);
        Panel_ArmyCnt.SetActive(false);
    }

    public void grantNewArmyList(List<string> getArmyID, List<string> getArmyName, List<string> getArmyGrade, int cnt)
    {
        PlayFabServerAPI.GrantItemsToUser(new GrantItemsToUserRequest {
                CatalogVersion = "ARMY1", PlayFabId = User_ID, ItemIds = getArmyID}
                                    , (result) => {
                                            
                                            SoundManager.instance.PlaySE("store");
                                            Panel_GetArmyResultList.SetActive(true);
                                            Panel_GetArmyResult.SetActive(false);
                                            Panel_GetArmyResult2.SetActive(false);

                                            for(int i = 0; i < getArmyID.Count; i++)
                                            {
                                                if(getArmyGrade[i] == "D")
                                                {
                                                    coupon_result_List_slot[i].BackImg.color = UnityEngine.Color.white;
                                                    coupon_result_List_slot[i].item_info = "success";
                                                }
                                                else if(getArmyGrade[i] == "C")
                                                {
                                                    coupon_result_List_slot[i].BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
                                                    coupon_result_List_slot[i].item_info = "success";
                                                } else if(getArmyGrade[i] == "B")
                                                {
                                                    coupon_result_List_slot[i].BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
                                                    coupon_result_List_slot[i].item_info = "success";
                                                } else if(getArmyGrade[i] == "A")
                                                {
                                                    coupon_result_List_slot[i].BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
                                                    coupon_result_List_slot[i].item_info = "success";
                                                } else if(getArmyGrade[i] == "S")
                                                {
                                                    coupon_result_List_slot[i].BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
                                                    coupon_result_List_slot[i].item_info = "success";
                                                } else
                                                {
                                                    coupon_result_List_slot[i].BackImg.color = UnityEngine.Color.white;
                                                }
                                                coupon_result_List_slot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + getArmyName[i]);
                                                
                                            }

                                            for(int i = 0; i < 100; i++)
                                            {
                                                if(coupon_result_List_slot[i].item_info != "success")
                                                {
                                                    coupon_result_List_slot[i].gameObject.SetActive(false);
                                                } else
                                                {
                                                    coupon_result_List_slot[i].gameObject.SetActive(true);
                                                }

                                            }
                                            useCouponItem(select_user_coupon_instance_id,cnt);
                                    }
                                   , (error) => {
                                            if(LM.Language == "KOR")
                                            {
                                                txt_Result.text = "교환권 사용 실패!";
                                            }else if(LM.Language =="Eng") 
                                            {
                                                txt_Result.text = "Failed Using Items!";
                                            }else
                                            {
                                                txt_Result.text = "クーポンの使用に\n失敗しました!";
                                            }
                                            
                                            Panel_GetArmyResultList.SetActive(false);
                                            Panel_GetArmyResult.SetActive(false);
                                            Panel_GetArmyResult2.SetActive(false);
                                            Panel_Result.SetActive(true);
                                            return;
                                    });



    }

public void useCouponItem(string select_user_coupon_instance_id, int cnt)
    {
        PlayFabClientAPI.ConsumeItem( new PlayFab.ClientModels.ConsumeItemRequest {
                ConsumeCount = cnt, ItemInstanceId = select_user_coupon_instance_id}
                                    , (result) =>         
                                    {
                                        if(LM.Language == "KOR")
                                        {
                                            txt_Result.text = "용병 획득 성공!";
                                        }else if(LM.Language == "Eng")
                                        {
                                            txt_Result.text = "Success Get Units!";
                                        } else
                                        {
                                            txt_Result.text = "傭 兵 獲 得 成 功!";
                                        }

                                        if(select_user_coupon_id == "1")
                                        {
                                            Panel_Loading.SetActive(false);
                                            Panel_GetArmyResult.SetActive(true);
                                            Panel_GetArmyResultList.SetActive(false);
                                            Panel_GetArmyResult2.SetActive(false);
                                            Panel_Result.SetActive(true);
                                        } 
                                        else 
                                        {
                                            Panel_Loading.SetActive(false);
                                            Panel_GetArmyResult.SetActive(false);
                                            Panel_GetArmyResultList.SetActive(true);
                                            Panel_GetArmyResult2.SetActive(false);
                                            Panel_Result.SetActive(true);
                                        }
                                    }
                                    , (error) => {
                                        print(error.Error);
                                    });
    }

    public void grantUserRuby(string select_user_coupon_instance_id, int amount, int cnt)
    {

        PlayFabClientAPI.AddUserVirtualCurrency(new PlayFab.ClientModels.AddUserVirtualCurrencyRequest() {
                VirtualCurrency = "RB", Amount = amount * cnt}
                            , (result) => {
                                useChestRuby(select_user_coupon_instance_id, amount, cnt);
                            }
                            , (error) => {
                                if(LM.Language == "KOR")
                                {
                                    txt_Result.text = "교환권 사용 실패!";
                                }else if(LM.Language =="Eng") 
                                {
                                    txt_Result.text = "Failed Using Items!";
                                }else
                                {
                                    txt_Result.text = "クーポンの使用に\n失敗しました!";
                                }
                                Panel_Loading.SetActive(false);
                                Panel_Result.SetActive(true);
                            });


    }

    public void useChestRuby(string select_user_coupon_instance_id, int amount, int cnt)
    {
        PlayFabClientAPI.ConsumeItem( new PlayFab.ClientModels.ConsumeItemRequest {
                ConsumeCount = cnt, ItemInstanceId = select_user_coupon_instance_id}
                                    , (result) =>         
                                    {
                                            grantUserEgg(amount, cnt);

                                    }
                                    , (error) => {
                                            Panel_Loading.SetActive(false);
                                            if(LM.Language == "KOR")
                                            {
                                                txt_Result.text = "교환권 사용 실패!";
                                            }else if(LM.Language =="Eng") 
                                            {
                                                txt_Result.text = "Failed Using Items!";
                                            }else
                                            {
                                                txt_Result.text = "クーポンの使用に\n失敗しました!";
                                            }
                                            Panel_Result.SetActive(true);
                                    });
    }

    public void grantUserEgg(int amount, int cnt)
    {
        int egg_amount = 0;
        if(amount == 300)
        {
            egg_amount = 5000 * cnt;
        } else if(amount == 100)
        {
            egg_amount = 1000 * cnt;
        }

        PlayFabClientAPI.AddUserVirtualCurrency(new PlayFab.ClientModels.AddUserVirtualCurrencyRequest() {
                VirtualCurrency = "EG", Amount = egg_amount}
                            , (result) => {
                                            Panel_Loading.SetActive(false);
                                            if(LM.Language == "KOR")
                                            {
                                                txt_Result.text = "루비 지급 완료!";
                                            }else if(LM.Language == "Eng")
                                            {
                                                txt_Result.text = "Success get Ruby!";
                                            }else
                                            {
                                                txt_Result.text = "ルビー 獲得 成功!";
                                            }
                                            Panel_Result.SetActive(true);
                            }
                            , (error) => {
                                            Panel_Loading.SetActive(false);
                                            if(LM.Language == "KOR")
                                            {
                                                txt_Result.text = "교환권 사용 실패!";
                                            }else if(LM.Language =="Eng") 
                                            {
                                                txt_Result.text = "Failed Using Items!";
                                            }else
                                            {
                                                txt_Result.text = "クーポンの使用に\n失敗しました!";
                                            }
                                            Panel_Result.SetActive(true);
                            });
    }

    public void onClickCouponQuitBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_GetArmy.SetActive(false);
        Panel_ArmyMenu.SetActive(true);

        img_select_coupon.gameObject.SetActive(false);
        txt_CouponName.text = "";
        txt_CouponInfo.text = "";

        panel_flag = 0;
        panel_subflag = 0;

    }
    //용병교환권 끝

    //용병 고용
    public void getUserArmyList()
    {

        if(LM.Language == "KOR")
        {
            txt_Loading.text = "불러오는 중..";
        } else 
        {
            txt_Loading.text = "Loading..";
        }
        Panel_Loading.SetActive(true);

        user_army_id.Clear();
        user_army_name.Clear();
        user_army_grade.Clear();
        user_army_info.Clear();
        user_army_value.Clear();
        user_army_cnt.Clear();
        user_army_instance_id.Clear();
        user_army_grade_code.Clear();

        deleteArmySlot();

        PlayFabClientAPI.GetUserInventory(new PlayFab.ClientModels.GetUserInventoryRequest(),
        (result) => 
        {
            
            foreach(var item in result.Inventory)
            {
                if (item.CatalogVersion == "ARMY1")
                {
                    user_army_id.Add(item.ItemId);
                    user_army_name.Add(item.DisplayName);
                    user_army_grade.Add(item.ItemClass);
                    user_army_value.Add(item.UnitPrice);
                    user_army_cnt.Add(item.RemainingUses.Value);
                    user_army_instance_id.Add(item.ItemInstanceId);

                    if(item.ItemClass == "D")
                    {
                        user_army_grade_code.Add(1);
                    } else if(item.ItemClass == "C")
                    {
                        user_army_grade_code.Add(2);
                    } else if(item.ItemClass == "B")
                    {
                        user_army_grade_code.Add(3);
                    } else if(item.ItemClass == "A")
                    {
                        user_army_grade_code.Add(4);
                    } else if(item.ItemClass == "S")
                    {
                        user_army_grade_code.Add(5);
                    }

                }

            }

            sortuserArmySlot();

            for(int i = 0; i < user_army_id.Count; i++)
            {
                user_army_slot[i].item_id = user_army_id[i];
                user_army_slot[i].item_name = user_army_name[i];
                user_army_slot[i].item_value = user_army_value[i];
                user_army_slot[i].item_count = user_army_cnt[i];
                user_army_slot[i].item_grade = user_army_grade[i];
                user_army_slot[i].item_instance_id = user_army_instance_id[i];
                user_army_slot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + user_army_name[i]);
                user_army_slot[i].itemImage.preserveAspect = true;

                if(user_army_slot[i].item_grade == "D")
                {
                    user_army_slot[i].BackImg.color = UnityEngine.Color.white;
                } else if (user_army_slot[i].item_grade == "C")
                {
                    user_army_slot[i].BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
                } else if (user_army_slot[i].item_grade == "B")
                {
                    user_army_slot[i].BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
                    
                } else if (user_army_slot[i].item_grade == "A")
                {
                    user_army_slot[i].BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
                    
                } else if (user_army_slot[i].item_grade == "S")
                {
                    user_army_slot[i].BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
                    
                }

                for(int j = 0; j < LM.all_army_id.Count; j++)
                {
                    if(user_army_slot[i].item_id == LM.all_army_id[j])
                    {
                        user_army_slot[i].item_info = LM.all_army_info[j];
                    }
                }

            }

            for(int i = 0; i < LM.setarmyIDList.Count; i++)
            {
                for(int j = 0; j < user_army_id.Count; j++)
                {
                    if(LM.setarmyIDList[i] == user_army_id[j])
                    {
                        user_army_cnt[j]--;
                        user_army_slot[j].item_count = user_army_cnt[j];
                    }
                }
            }

            setArmyID.Clear();
            setArmyName.Clear();
            setArmyGrade.Clear();

            for(int i = 0; i < LM.setarmyIDList.Count; i++ )
            {
                setArmyID.Add(LM.setarmyIDList[i]);
                setArmyName.Add(LM.setarmyNameList[i]);
            }

            for(int i = 0; i < setArmyID.Count; i++)
            {
                for(int j = 0; j < LM.all_army_id.Count; j++)
                {
                    if(setArmyID[i] == LM.all_army_id[j])
                    {
                        setArmyGrade.Add(LM.all_army_grade[j]);
                    }
                }
            }   

            setArmySlot();

            Panel_Loading.SetActive(false);
            Panel_Result.SetActive(false);
        }, 
        (error) => {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "불러오기 실패!";
            }else
            {
                txt_Result.text = "Failed Loading!";
            }
            
            Panel_Result.SetActive(true);
        });


    }

    public void setArmySlot()
    {
        deleteSetArmySlot();

        for(int i = 0; i < setArmyID.Count; i++)
        {
            set_army_slot[i].item_id = setArmyID[i];
            set_army_slot[i].item_name = setArmyName[i];
            set_army_slot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + setArmyName[i]);
            set_army_slot[i].item_grade = setArmyGrade[i];
            
            if(set_army_slot[i].item_grade == "D")
            {
                set_army_slot[i].BackImg.color = UnityEngine.Color.white;
            } else if (set_army_slot[i].item_grade == "C")
            {
                set_army_slot[i].BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            } else if (set_army_slot[i].item_grade == "B")
            {
                set_army_slot[i].BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            } else if (set_army_slot[i].item_grade == "A")
            {
                set_army_slot[i].BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            } else if (set_army_slot[i].item_grade == "S")
            {
                set_army_slot[i].BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
            }
        }
    }

    public void deleteSetArmySlot()
    {
        for(int i = 0; i < 5; i++)
        {
            set_army_slot[i].item_id = null;
            set_army_slot[i].item_info = null;
            set_army_slot[i].item_name = null;
            set_army_slot[i].item_grade = null;
            set_army_slot[i].item_value = 0;
            set_army_slot[i].item_count = 0;
            set_army_slot[i].item_instance_id = null;
            set_army_slot[i].itemImage.sprite = null;
            set_army_slot[i].SelectedImg.color = UnityEngine.Color.white;
            set_army_slot[i].BackImg.color = UnityEngine.Color.white;
        }
    }

    public void deleteArmySlot()
    {
        for(int i = 0; i < user_army_slot.Length; i++)
        {
            user_army_slot[i].item_id = null;
            user_army_slot[i].item_info = null;
            user_army_slot[i].item_name = null;
            user_army_slot[i].item_grade = null;
            user_army_slot[i].item_value = 0;
            user_army_slot[i].item_count = 0;
            user_army_slot[i].item_instance_id = null;
            user_army_slot[i].itemImage.sprite = null;
            user_army_slot[i].SelectedImg.color = UnityEngine.Color.white;
            user_army_slot[i].BackImg.color = UnityEngine.Color.white;
        }

    }

    public void deleteArmyGetSlot()
    {
        for(int i = 0; i < 100; i++)
        {
            coupon_result_List_slot[i].item_id = null;
            coupon_result_List_slot[i].item_info = null;
            coupon_result_List_slot[i].item_name = null;
            coupon_result_List_slot[i].item_grade = null;
            coupon_result_List_slot[i].item_value = 0;
            coupon_result_List_slot[i].item_count = 0;
            coupon_result_List_slot[i].item_instance_id = null;
            coupon_result_List_slot[i].itemImage.sprite = null;
            coupon_result_List_slot[i].SelectedImg.color = UnityEngine.Color.white;
            coupon_result_List_slot[i].BackImg.color = UnityEngine.Color.white;
        }

    }

    public void sortuserArmySlot()
    {
        for(int i = 0; i < user_army_id.Count; i++)
        {
            for(int j = i+1; j < user_army_id.Count; j++)
            {
              if( user_army_grade_code[i] < user_army_grade_code[j])
              {
                  string temp_id;
                  string temp_name;
                  string temp_info;
                  string temp_grade;
                  string temp_instance_id;
                  uint temp_value;
                  int temp_grade_code;
                  int temp_cnt;

                  temp_id = user_army_id[i];
                  user_army_id[i] = user_army_id[j];
                  user_army_id[j] = temp_id;

                  temp_name = user_army_name[i];
                  user_army_name[i] = user_army_name[j];
                  user_army_name[j] = temp_name;

                  temp_grade = user_army_grade[i];
                  user_army_grade[i] = user_army_grade[j];
                  user_army_grade[j] = temp_grade;

                  temp_value = user_army_value[i];
                  user_army_value[i] = user_army_value[j];
                  user_army_value[j] = temp_value;

                  temp_grade_code = user_army_grade_code[i];
                  user_army_grade_code[i] = user_army_grade_code[j];
                  user_army_grade_code[j] = temp_grade_code;

                  temp_instance_id = user_army_instance_id[i];
                  user_army_instance_id[i] = user_army_instance_id[j];
                  user_army_instance_id[j] = temp_instance_id;

                  temp_cnt = user_army_cnt[i];
                  user_army_cnt[i] = user_army_cnt[j];
                  user_army_cnt[j] = temp_cnt;

              }
            }
        }
    }

    public void onClickArmySlot(Slot input_slot)
    {
        try
        {
            if(input_slot.item_id.Length < 1)
            {
                return;
            }

            img_select_army.gameObject.SetActive(true);

            SoundManager.instance.PlaySE("button");

            renewUserArmyCnt();

            for(int i = 0; i < user_army_slot.Length; i++)
            {
                user_army_slot[i].SelectedImg.color = UnityEngine.Color.white;
            }
            
            input_slot.SelectedImg.color = UnityEngine.Color.black;

            select_army_id = input_slot.item_id;
            select_army_name = input_slot.item_name;
            select_army_grade = input_slot.item_grade;
            select_army_value = input_slot.item_value;
            select_army_info = input_slot.item_info;
            select_army_cnt = input_slot.item_count;
            select_army_instance_id = input_slot.item_instance_id;

            img_select_army.sprite = Resources.Load<Sprite>("item/" + select_army_name);

            if(select_army_name == "" ||select_army_name == null)
            {
                return;
            }

            string[] languageitem_name = select_army_name.Split('_');
            string[] languageitem_info = select_army_info.Split('_');
            
            if(LM.Language == "KOR")
            {
                txt_ArmyName.text = languageitem_name[0] + "(" + select_army_grade + ")" + "x" + select_army_cnt;
                txt_ArmyInfo.text = languageitem_info[0];
            } else
            {
                txt_ArmyName.text = languageitem_name[1] + "(" + select_army_grade + ")" + "x" + select_army_cnt;
                txt_ArmyInfo.text = languageitem_info[1];
            }
        } catch (NullReferenceException ex){ 
        }

    }

    public void onClickArmyPlusBtn()
    {
        SoundManager.instance.PlaySE("button");

        if(select_army_cnt < 1)
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "용병의 수가 부족합니다.";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Check Unit Count.";
            } else
            {
                txt_Result.text = "傭兵が 足りない.";
            }

            panel_subflag = 1;
            
            Panel_Result.SetActive(true);
            Panel_GetArmyResult.SetActive(false);
            Panel_GetArmyResult2.SetActive(false);
            Panel_GetArmyResultList.SetActive(false);
            return;
        }

        if(setArmyID.Count > 4 )
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "더이상 추가할 수 없습니다.";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Check Unit Slot.";
            } else
            {
                txt_Result.text = "もう追加できません。";
            }
            
            panel_subflag = 1;

            Panel_Result.SetActive(true);
            Panel_GetArmyResult.SetActive(false);
            Panel_GetArmyResult2.SetActive(false);
            Panel_GetArmyResultList.SetActive(false);
            return;
        }

        setArmyID.Add(select_army_id);
        setArmyName.Add(select_army_name);
        setArmyGrade.Add(select_army_grade);

        panel_subflag = 0;

        for(int i = 0; i < setArmyID.Count; i++)
        {
            set_army_slot[i].item_id = setArmyID[i];
            set_army_slot[i].item_name = setArmyName[i];
            set_army_slot[i].item_grade = setArmyGrade[i];
            set_army_slot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + setArmyName[i]);
            set_army_slot[i].itemImage.preserveAspect = true;

            if(set_army_slot[i].item_grade == "D")
            {
                set_army_slot[i].BackImg.color = UnityEngine.Color.white;
            } else if (set_army_slot[i].item_grade == "C")
            {
                set_army_slot[i].BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            } else if (set_army_slot[i].item_grade == "B")
            {
                set_army_slot[i].BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            } else if (set_army_slot[i].item_grade == "A")
            {
                set_army_slot[i].BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            } else if (set_army_slot[i].item_grade == "S")
            {
                set_army_slot[i].BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
            }

        }

        for(int i = 0; i < user_army_id.Count; i++)
        {
            if(set_army_slot[setArmyID.Count - 1].item_id == user_army_id[i])
            {
                user_army_cnt[i]--;
            }

            if(select_army_id == user_army_id[i])
            {
                select_army_cnt--;
            }
        }

        renewUserArmyCnt();

        string[] languageitem_name = select_army_name.Split('_');
        string[] languageitem_info = select_army_info.Split('_');
        
        if(LM.Language == "KOR")
        {
            txt_ArmyName.text = languageitem_name[0] + "(" + select_army_grade + ")" + "x" + select_army_cnt;
            txt_ArmyInfo.text = languageitem_info[0];
        } else
        {
            txt_ArmyName.text = languageitem_name[1] + "(" + select_army_grade + ")" + "x" + select_army_cnt;
            txt_ArmyInfo.text = languageitem_info[1];
        }

    }

    public void onClickArmyMinusBtn()
    {

        SoundManager.instance.PlaySE("button");

        if(setArmyID.Count <= 0)
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "더이상 해제할 수 없습니다.";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Check Unit Slot.";
            } else
            {
                txt_Result.text = "これ以上 除外できません。";
            }

            panel_subflag = 1;
            
            Panel_GetArmyResult.SetActive(false);
            Panel_GetArmyResult2.SetActive(false);
            Panel_GetArmyResultList.SetActive(false);
            Panel_Result.SetActive(true);
            return;
        }

        panel_subflag = 0;

        for(int i = 0; i < user_army_id.Count; i++)
        {
            if(set_army_slot[setArmyID.Count - 1].item_id == user_army_id[i])
            {
                user_army_cnt[i]++;
            }

        }

        if(select_army_id == set_army_slot[setArmyID.Count - 1].item_id)
        {
            select_army_cnt++;                
        }

        renewUserArmyCnt();

        if(select_army_id == setArmyID[setArmyID.Count-1])
        {
            string[] languageitem_name = select_army_name.Split('_');
            string[] languageitem_info = select_army_info.Split('_');
            
            if(LM.Language == "KOR")
            {
                txt_ArmyName.text = languageitem_name[0] + "(" + select_army_grade + ")" + "x" + select_army_cnt;
                txt_ArmyInfo.text = languageitem_info[0];
            } else
            {
                txt_ArmyName.text = languageitem_name[1] + "(" + select_army_grade + ")" + "x" + select_army_cnt;
                txt_ArmyInfo.text = languageitem_info[1];
            }
        }

        set_army_slot[setArmyID.Count - 1].item_id = null;
        set_army_slot[setArmyID.Count - 1].item_name = null;
        set_army_slot[setArmyID.Count - 1].item_grade = null;
        set_army_slot[setArmyID.Count - 1].itemImage.sprite = null;
        set_army_slot[setArmyID.Count - 1].BackImg.color = UnityEngine.Color.white;
        setArmyID.RemoveAt(setArmyID.Count - 1);
        setArmyName.RemoveAt(setArmyName.Count - 1);
        setArmyGrade.RemoveAt(setArmyGrade.Count - 1);

    }

    public void renewUserArmyCnt()
    {
        for(int i = 0; i < user_army_id.Count; i++)
        {
            user_army_slot[i].item_count = user_army_cnt[i];
        }
    }

    public void onclickSetArmyConfirm()
    {
        SoundManager.instance.PlaySE("button");

        string playFabArmyIDList = "";
        string playFabArmyNameList = "";
/*
        if(setArmyID.Count < 1)
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "용병을 추가하세요!";
            } else
            {
                txt_Result.text = "Add Unit!";
            }
            
            Panel_Result.SetActive(true);
            Panel_GetArmyResult.SetActive(false);
            Panel_GetArmyResultList.SetActive(false);
            return;
        }
*/
        for(int i = 0; i < setArmyID.Count; i++)
        {
            if( i == setArmyID.Count - 1 )
            {
                playFabArmyIDList = playFabArmyIDList + setArmyID[i];
                playFabArmyNameList = playFabArmyNameList + setArmyName[i];
            } else 
            {
                playFabArmyIDList = playFabArmyIDList + setArmyID[i] + ":" ;
                playFabArmyNameList = playFabArmyNameList + setArmyName[i] + ":";
            }
            
        }

        panel_subflag = 0;

        if(LM.Language == "KOR")
        {
            txt_Loading.text = "저장 중..";
        } else
        {
            txt_Loading.text = "Saving..";
        }

        Panel_Loading.SetActive(true);

       PlayFabClientAPI.UpdateUserData(new PlayFab.ClientModels.UpdateUserDataRequest() 
        {Data = new Dictionary<string, string>(){

                 {"ARMYID", playFabArmyIDList}  
                ,{"ARMYNAME", playFabArmyNameList}

                }}
                            , (result) => {
                                
                                LM.setarmyIDList.Clear();
                                LM.setarmyNameList.Clear();

                                for(int i = 0; i<setArmyID.Count; i++)
                                {
                                    LM.setarmyIDList.Add(setArmyID[i]);
                                    LM.setarmyNameList.Add(setArmyName[i]);
                                }
                                
                                Panel_Loading.SetActive(false);
                                
                                if(LM.Language == "KOR")
                                {
                                    txt_Result.text = "저장 성공 !";
                                } else
                                {
                                    txt_Result.text = "Success Saved!";
                                }
                                
                                Panel_Result.SetActive(true);
                                Panel_Loading.SetActive(false);
                                Panel_GetArmyResult.SetActive(false);
                                Panel_GetArmyResult2.SetActive(false);
                                Panel_GetArmyResultList.SetActive(false);

                            }
                            , (error) => {
                                Panel_Loading.SetActive(false);
                                if(LM.Language == "KOR")
                                {
                                    txt_Result.text = "저장 실패 !";
                                } else
                                {
                                    txt_Result.text = "Failed Saved!";
                                }
                                Panel_Result.SetActive(true);
                                Panel_Loading.SetActive(false);
                                Panel_GetArmyResult.SetActive(false);
                                Panel_GetArmyResult2.SetActive(false);
                                Panel_GetArmyResultList.SetActive(false);
                            });


    }

    //용병고용 창 닫기
    public void onClicksetArmyCloseBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_SetArmy.SetActive(false);
        Panel_ArmyMenu.SetActive(true);

        img_select_army.gameObject.SetActive(false);
        txt_ArmyInfo.text = "";
        txt_ArmyName.text = "";

        panel_flag = 0;
        panel_subflag = 0;

    }

    //용병 고용 끝
    //용병 강화

    public void getUserEnforceArmyList()
    {
        
        if(LM.Language == "KOR")
        {
            txt_Loading.text = "불러오는 중..";
        } else 
        {
            txt_Loading.text = "Loading..";
        }
        Panel_Loading.SetActive(true);

        user_enforce_army_id.Clear();
        user_enforce_army_name.Clear();
        user_enforce_army_grade.Clear();
        user_enforce_army_info.Clear();
        user_enforce_army_value.Clear();
        user_enforce_army_cnt.Clear();
        user_enforce_army_instance_id.Clear();
        user_enforce_army_grade_code.Clear();

        deleteEnforceArmySlot();

        PlayFabClientAPI.GetUserInventory(new PlayFab.ClientModels.GetUserInventoryRequest(),
        (result) => 
        {
            
            foreach(var item in result.Inventory)
            {
                if (item.CatalogVersion == "ARMY1" || item.CatalogVersion == "HERO" )
                {
                    user_enforce_army_id.Add(item.ItemId);
                    user_enforce_army_name.Add(item.DisplayName);
                    user_enforce_army_grade.Add(item.ItemClass);
                    user_enforce_army_value.Add(item.UnitPrice);
                    user_enforce_army_cnt.Add(item.RemainingUses.Value);
                    user_enforce_army_instance_id.Add(item.ItemInstanceId);
                    

                    if(item.ItemClass == "D")
                    {
                        user_enforce_army_grade_code.Add(1);
                    } else if(item.ItemClass == "C")
                    {
                        user_enforce_army_grade_code.Add(2);
                    } else if(item.ItemClass == "B")
                    {
                        user_enforce_army_grade_code.Add(3);
                    } else if(item.ItemClass == "A")
                    {
                        user_enforce_army_grade_code.Add(4);
                    } else if(item.ItemClass == "S")
                    {
                        user_enforce_army_grade_code.Add(5);
                    }

                }

            }

            sortuserEnforceArmySlot();

            for(int i = 0; i < user_enforce_army_id.Count; i++)
            {
                user_enforce_army_slot[i].item_id = user_enforce_army_id[i];
                user_enforce_army_slot[i].item_name = user_enforce_army_name[i];
                user_enforce_army_slot[i].item_grade = user_enforce_army_grade[i];
                user_enforce_army_slot[i].item_value = user_enforce_army_value[i];
                user_enforce_army_slot[i].item_count = user_enforce_army_cnt[i];
                user_enforce_army_slot[i].item_instance_id = user_enforce_army_instance_id[i];
                user_enforce_army_slot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + user_enforce_army_name[i]);
                user_enforce_army_slot[i].itemImage.preserveAspect = true;

                if(user_enforce_army_slot[i].item_grade == "D")
                {
                    user_enforce_army_slot[i].BackImg.color = UnityEngine.Color.white;
                } else if (user_enforce_army_slot[i].item_grade == "C")
                {
                    user_enforce_army_slot[i].BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
                } else if (user_enforce_army_slot[i].item_grade == "B")
                {
                    user_enforce_army_slot[i].BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
                } else if (user_enforce_army_slot[i].item_grade == "A")
                {
                    user_enforce_army_slot[i].BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
                } else if (user_enforce_army_slot[i].item_grade == "S")
                {
                    user_enforce_army_slot[i].BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
                }

                for(int j = 0; j < LM.all_army_id.Count; j++)
                {
                    if(user_enforce_army_slot[i].item_id == LM.all_army_id[j])
                    {
                        user_enforce_army_slot[i].item_info = LM.all_army_info[j];
                    }

                    if(user_enforce_army_slot[i].item_id == "heroSpiritS")
                    {
                        if(LM.Language == "KOR")
                        {
                            user_enforce_army_slot[i].item_info = "S급 성공확률\n+2.5%_";
                        } else 
                        {
                            user_enforce_army_slot[i].item_info = "_S Success\nPercent +2.5%";
                        }
                    }

                    if(user_enforce_army_slot[i].item_id == "heroSpiritA")
                    {
                        if(LM.Language == "KOR")
                        {
                            user_enforce_army_slot[i].item_info = "A급 성공확률\n+5%_";
                        } else 
                        {
                            user_enforce_army_slot[i].item_info = "_A Success\nPercent +5%";
                        }
                    }
                }

            }

            for(int i = 0; i < LM.setarmyIDList.Count; i++)
            {
                for(int j = 0; j < user_enforce_army_id.Count; j++)
                {
                    if(LM.setarmyIDList[i] == user_enforce_army_id[j])
                    {
                        user_enforce_army_cnt[j]--;
                        user_enforce_army_slot[j].item_count = user_enforce_army_cnt[j];
                    }
                }
            }

            setEnforceArmyID.Clear();
            setEnforceArmyName.Clear();
            setEnforceArmyGrade.Clear();
            setEnforceArmyInstance.Clear();

            deleteSetEnforceArmySlot();

            Panel_Loading.SetActive(false);
            Panel_Result.SetActive(false);
        }, 
        (error) => {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "불러오기 실패!";
            } else
            {
                txt_Result.text = "Failed Loading!";
            }
            Panel_Result.SetActive(true);
        });


    }

    public void deleteEnforceArmySlot()
    {
        for(int i = 0; i < user_enforce_army_slot.Length; i++)
        {
            user_enforce_army_slot[i].item_id = null;
            user_enforce_army_slot[i].item_info = null;
            user_enforce_army_slot[i].item_name = null;
            user_enforce_army_slot[i].item_grade = null;
            user_enforce_army_slot[i].item_value = 0;
            user_enforce_army_slot[i].item_count = 0;
            user_enforce_army_slot[i].item_instance_id = null;
            user_enforce_army_slot[i].itemImage.sprite = null;
            user_enforce_army_slot[i].SelectedImg.color = UnityEngine.Color.white;
            user_enforce_army_slot[i].BackImg.color = UnityEngine.Color.white;
        }

    }

    public void deleteSetEnforceArmySlot()
    {
        for(int i = 0; i < user_enforce_set_slot.Length; i++)
        {
            user_enforce_set_slot[i].item_id = null;
            user_enforce_set_slot[i].item_info = null;
            user_enforce_set_slot[i].item_name = null;
            user_enforce_set_slot[i].item_grade = null;
            user_enforce_set_slot[i].item_value = 0;
            user_enforce_set_slot[i].item_count = 0;
            user_enforce_set_slot[i].item_instance_id = null;
            user_enforce_set_slot[i].itemImage.sprite = null;
            user_enforce_set_slot[i].SelectedImg.color = UnityEngine.Color.white;
            user_enforce_set_slot[i].BackImg.color = UnityEngine.Color.white;
        }

    }

    public void sortuserEnforceArmySlot()
    {
        for(int i = 0; i < user_enforce_army_id.Count; i++)
        {
            for(int j = i+1; j < user_enforce_army_id.Count; j++)
            {
              if( user_enforce_army_grade_code[i] < user_enforce_army_grade_code[j])
              {
                  string temp_id;
                  string temp_name;
                  string temp_info;
                  string temp_grade;
                  string temp_instance_id;
                  uint temp_value;
                  int temp_grade_code;
                  int temp_cnt;

                  temp_id = user_enforce_army_id[i];
                  user_enforce_army_id[i] = user_enforce_army_id[j];
                  user_enforce_army_id[j] = temp_id;

                  temp_name = user_enforce_army_name[i];
                  user_enforce_army_name[i] = user_enforce_army_name[j];
                  user_enforce_army_name[j] = temp_name;

                  temp_grade = user_enforce_army_grade[i];
                  user_enforce_army_grade[i] = user_enforce_army_grade[j];
                  user_enforce_army_grade[j] = temp_grade;

                  temp_value = user_enforce_army_value[i];
                  user_enforce_army_value[i] = user_enforce_army_value[j];
                  user_enforce_army_value[j] = temp_value;

                  temp_grade_code = user_enforce_army_grade_code[i];
                  user_enforce_army_grade_code[i] = user_enforce_army_grade_code[j];
                  user_enforce_army_grade_code[j] = temp_grade_code;

                  temp_instance_id = user_enforce_army_instance_id[i];
                  user_enforce_army_instance_id[i] = user_enforce_army_instance_id[j];
                  user_enforce_army_instance_id[j] = temp_instance_id;

                  temp_cnt = user_enforce_army_cnt[i];
                  user_enforce_army_cnt[i] = user_enforce_army_cnt[j];
                  user_enforce_army_cnt[j] = temp_cnt;

              }
            }
        }
    }

    public void onClickEnforceArmyPlusBtn()
    {
        SoundManager.instance.PlaySE("button");

        if(select_enforce_army_cnt < 1)
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "용병의 수가 부족합니다.";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Check Unit Count.";
            } else
            {
                txt_Result.text = "傭兵が 足りない.";
            }

            panel_subflag = 1;
            
            Panel_Result.SetActive(true);
            Panel_GetArmyResult.SetActive(false);
            Panel_GetArmyResult2.SetActive(false);
            Panel_GetArmyResultList.SetActive(false);
            return;
        }

        if(setEnforceArmyID.Count > 0)
        {
            if(select_enforce_army_grade != setEnforceArmyGrade[0])
            {
                if(LM.Language == "KOR")
                {
                    txt_Result.text = "같은 등급의 \n용병을 선택하세요.";
                } else if(LM.Language == "Eng")
                {
                    txt_Result.text = "Check Unit Grade!";
                } else 
                {
                    txt_Result.text = "評価を確認して\nください!";
                }

                panel_subflag = 1;

                Panel_Result.SetActive(true);
                Panel_GetArmyResult.SetActive(false);
                Panel_GetArmyResult2.SetActive(false);
                Panel_GetArmyResultList.SetActive(false);
                return;
            }
        }

        if(setEnforceArmyID.Count > 2 || select_enforce_army_grade == "S")
        {
            
            if(LM.Language == "KOR")
            {
                txt_Result.text = "더이상 추가할 수 없습니다.";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Can't Add Anymore.";
            } else
            {
                txt_Result.text = "もう追加できません。";
            }

            panel_subflag = 1;

            Panel_Result.SetActive(true);
            Panel_GetArmyResult.SetActive(false);
            Panel_GetArmyResult2.SetActive(false);
            Panel_GetArmyResultList.SetActive(false);
            return;
        }

        if(setEnforceArmyID.Count == 0 && (select_enforce_army_id == "heroSpiritS" || select_enforce_army_id == "heroSpiritA" ))
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "재료 아이템 입니다.";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "It's material item.";
            } else
            {
                txt_Result.text = "素材アイテムです。";
            }

            panel_subflag = 1;

            Panel_Result.SetActive(true);
            Panel_GetArmyResult.SetActive(false);
            Panel_GetArmyResult2.SetActive(false);
            Panel_GetArmyResultList.SetActive(false);
            return;
        }

        panel_subflag = 0;

        setEnforceArmyID.Add(select_enforce_army_id);
        setEnforceArmyName.Add(select_enforce_army_name);
        setEnforceArmyGrade.Add(select_enforce_army_grade);
        setEnforceArmyInstance.Add(select_enforce_army_instance_id);

        for(int i = 0; i < setEnforceArmyID.Count; i++)
        {
            user_enforce_set_slot[i].item_id = setEnforceArmyID[i];
            user_enforce_set_slot[i].item_name = setEnforceArmyName[i];
            user_enforce_set_slot[i].item_grade = setEnforceArmyGrade[i];
            user_enforce_set_slot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + setEnforceArmyName[i]);

            if(user_enforce_set_slot[i].item_grade == "D")
            {
                user_enforce_set_slot[i].BackImg.color = UnityEngine.Color.white;
            } else if (user_enforce_set_slot[i].item_grade == "C")
            {
                user_enforce_set_slot[i].BackImg.color = new Color( 150/255f, 255/255f, 150/255f);   
            }else if (user_enforce_set_slot[i].item_grade == "B")
            {
                user_enforce_set_slot[i].BackImg.color = new Color( 100/255f, 200/255f, 255/255f);   
            }else if (user_enforce_set_slot[i].item_grade == "A")
            {
                user_enforce_set_slot[i].BackImg.color = new Color( 210/255f, 150/255f, 255/255f);   
            }else if (user_enforce_set_slot[i].item_grade == "S")
            {
                user_enforce_set_slot[i].BackImg.color = new Color( 255/255f, 150/255f, 150/255f);   
            }

            user_enforce_set_slot[0].SelectedImg.color = UnityEngine.Color.black;

        }
        
        for(int i = 0; i < user_enforce_army_id.Count; i++)
        {
            if(user_enforce_set_slot[setEnforceArmyID.Count - 1].item_id == user_enforce_army_id[i])
            {
                user_enforce_army_cnt[i]--;
            }

            if(select_enforce_army_id == user_enforce_army_id[i])
            {
                select_enforce_army_cnt--;                
            }

        }

        renewEnforceArmyCnt();

        string[] languageenforce_name = select_enforce_army_name.Split('_');
        string[] languageenforce_info = select_enforce_army_info.Split('_');
        
        if(LM.Language == "KOR")
        {
            txt_EnforceArmyName.text = languageenforce_name[0] + "(" + select_enforce_army_grade + ")" + "x" + select_enforce_army_cnt;
            txt_EnforceArmyInfo.text = languageenforce_info[0];
        } else
        {
            txt_EnforceArmyName.text = languageenforce_name[1]+ "(" + select_enforce_army_grade + ")" + "x" + select_enforce_army_cnt;
            txt_EnforceArmyInfo.text = languageenforce_info[1];
        }

   }

    public void onClickEnforceArmyMinusBtn()
    {
        SoundManager.instance.PlaySE("button");

        if(setEnforceArmyID.Count <= 0)
        {
            panel_subflag = 1;

            if(LM.Language == "KOR")
            {
                txt_Result.text = "더이상 해제할 수 없습니다.";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Check PowerUP Slot";
            } else
            {
                txt_Result.text = "これ以上 除外できません。";
            }
            Panel_GetArmyResult.SetActive(false);
            Panel_GetArmyResult2.SetActive(false);
            Panel_GetArmyResultList.SetActive(false);
            Panel_Result.SetActive(true);
            return;
        }

        for(int i = 0; i < user_enforce_army_id.Count; i++)
        {
            if(user_enforce_set_slot[setEnforceArmyID.Count - 1].item_id == user_enforce_army_id[i])
            {
                user_enforce_army_cnt[i]++;
            }

        }

        if(select_enforce_army_id == user_enforce_set_slot[setEnforceArmyID.Count - 1].item_id)
        {
            select_enforce_army_cnt++;                
        }

        renewEnforceArmyCnt();

        if(select_enforce_army_id == setEnforceArmyID[setEnforceArmyID.Count-1])
        {
            string[] languageenforce_name = select_enforce_army_name.Split('_');
            string[] languageenforce_info = select_enforce_army_info.Split('_');
            
            if(LM.Language == "KOR")
            {
                txt_EnforceArmyName.text = languageenforce_name[0] + "(" + select_enforce_army_grade + ")" + "x" + select_enforce_army_cnt;
                txt_EnforceArmyInfo.text = languageenforce_info[0];
            } else
            {
                txt_EnforceArmyName.text = languageenforce_name[1] + "(" + select_enforce_army_grade + ")" + "x" + select_enforce_army_cnt;
                txt_EnforceArmyInfo.text = languageenforce_info[1];
            }
        }

        user_enforce_set_slot[setEnforceArmyID.Count - 1].item_id = null;
        user_enforce_set_slot[setEnforceArmyID.Count - 1].item_name = null;
        user_enforce_set_slot[setEnforceArmyID.Count - 1].item_grade = null;
        user_enforce_set_slot[setEnforceArmyID.Count - 1].itemImage.sprite = null;
        user_enforce_set_slot[setEnforceArmyID.Count - 1].BackImg.color = UnityEngine.Color.white;
        setEnforceArmyID.RemoveAt(setEnforceArmyID.Count - 1);
        setEnforceArmyName.RemoveAt(setEnforceArmyName.Count - 1);
        setEnforceArmyGrade.RemoveAt(setEnforceArmyGrade.Count - 1);
        setEnforceArmyInstance.RemoveAt(setEnforceArmyInstance.Count - 1);

    }

    public void renewEnforceArmyCnt()
    {
        for(int i = 0; i < user_enforce_army_id.Count; i++)
        {
            user_enforce_army_slot[i].item_count = user_enforce_army_cnt[i];
        }
    }

    public void onClickEnforceArmyPowerUPBtn()
    {
        System.Random randomObj = new System.Random(); // 난수발생 obj

        int rand_army = randomObj.Next(1,101); // 1~8까지 난수발생

        string getArmyID = "";
        string getArmyName = "";
        string getArmyInstanceID1 = "";
        string getArmyInstanceID2 = "";
        string getArmyInstanceID3 = "";

        if( setEnforceArmyID.Count < 3)
        {

            panel_subflag = 1;

            if(LM.Language == "KOR")
            {
                txt_Result.text = "용병을 추가하세요!";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Add Unit!";
            } else
            {
                txt_Result.text = "傭兵を追加し\nてください!";
            }
            
            Panel_Result.SetActive(true);
            Panel_GetArmyResult.SetActive(false);
            Panel_GetArmyResult2.SetActive(false);
            Panel_GetArmyResultList.SetActive(false);
            return;
        }

        
        if(LM.Language == "KOR")
        {
            txt_Loading.text = "강화중..";
        } else
        {
            txt_Loading.text = "Power UP..";
        }
        Panel_Loading.SetActive(true);


        getArmyID = setEnforceArmyID[0] + "I";
        getArmyName = setEnforceArmyName[0];
        getArmyInstanceID1 = setEnforceArmyInstance[0];
        getArmyInstanceID2 = setEnforceArmyInstance[1];
        getArmyInstanceID3 = setEnforceArmyInstance[2];
        //D등급
        if(setEnforceArmyGrade[0] == "D")
        {
            Enforce_Success_flag = true;
            UnitEnforceSuccess(getArmyID,getArmyName, setEnforceArmyGrade[0] ,getArmyInstanceID1,getArmyInstanceID2,getArmyInstanceID3);
        } else if(setEnforceArmyGrade[0] == "C")
        {
            if(rand_army >= 31)
            {
                //강화성공
                Enforce_Success_flag = true;
                UnitEnforceSuccess(getArmyID,getArmyName, setEnforceArmyGrade[0] ,getArmyInstanceID1,getArmyInstanceID2,getArmyInstanceID3);
            } else 
            {
                //강화실패
                Enforce_Success_flag = false;
                UnitEnforcefailed(getArmyInstanceID1,getArmyInstanceID2,getArmyInstanceID3);
            }
        } else if(setEnforceArmyGrade[0] == "B")
        {

            int AddItem = 0;

            for(int i = 0; i < 3; i++)
            {
                if(setEnforceArmyID[i] == "heroSpiritA")
                {
                    AddItem = AddItem + 5;
                }
            }

            if(rand_army >= 61 - AddItem)
            {
                //강화성공
                Enforce_Success_flag = true;
                UnitEnforceSuccess(getArmyID,getArmyName, setEnforceArmyGrade[0] ,getArmyInstanceID1,getArmyInstanceID2,getArmyInstanceID3);
            } else 
            {
                //강화실패
                Enforce_Success_flag = false;
                UnitEnforcefailed(getArmyInstanceID1,getArmyInstanceID2,getArmyInstanceID3);
            }
        } else if(setEnforceArmyGrade[0] == "A")
        {
            int AddItem = 0;

            for(int i = 0; i < 3; i++)
            {
                if(setEnforceArmyID[i] == "heroSpiritS")
                {
                    AddItem = AddItem + 2;
                }
            }

            if(rand_army >= 91 - AddItem)
            {
                Enforce_Success_flag = true;
                UnitEnforceSuccess(getArmyID,getArmyName, setEnforceArmyGrade[0] ,getArmyInstanceID1,getArmyInstanceID2,getArmyInstanceID3);
            } else 
            {
                Enforce_Success_flag = false;
                UnitEnforcefailed(getArmyInstanceID1,getArmyInstanceID2,getArmyInstanceID3);
            }
        }

    }

    public void UnitEnforceSuccess(string getArmyID, string getArmyName, string getArmyGrade, string getArmyInstanceID1, string getArmyInstanceID2, string getArmyInstanceID3)
    {
        
        PlayFabServerAPI.GrantItemsToUser(new GrantItemsToUserRequest {
                CatalogVersion = "ARMY1", PlayFabId = User_ID, ItemIds = new List<string> {getArmyID}}
                                    , (result) => {
                                            Panel_GetArmyResultList.SetActive(false);
                                            Panel_GetArmyResult.SetActive(true);
                                            Panel_GetArmyResult2.SetActive(false);
                                            if(getArmyGrade == "D")
                                            {
                                                coupon_result_slot[0].BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
                                                coupon_result_slot[0].SelectedImg.color = new Color( 150/255f, 255/255f, 150/255f);
                                            } else if (getArmyGrade == "C")
                                            {
                                                coupon_result_slot[0].BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
                                                coupon_result_slot[0].SelectedImg.color = new Color( 100/255f, 200/255f, 255/255f);
                                            } else if (getArmyGrade == "B")
                                            {
                                                coupon_result_slot[0].BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
                                                coupon_result_slot[0].SelectedImg.color = new Color( 210/255f, 150/255f, 255/255f);
                                            } else if (getArmyGrade == "A")
                                            {
                                                coupon_result_slot[0].BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
                                                coupon_result_slot[0].SelectedImg.color = new Color( 255/255f, 150/255f, 150/255f);
                                            }
                                            coupon_result_slot[0].itemImage.sprite = Resources.Load<Sprite>("item/" + getArmyName);
                                            useArmyItem(getArmyInstanceID1,getArmyInstanceID2,getArmyInstanceID3);
                                    }
                                    , (error) => {
                                            if(LM.Language == "KOR")
                                            {
                                                txt_Result.text = "강화 실패!";
                                            }else if(LM.Language == "Eng")
                                            {
                                                txt_Result.text = "Failed Power UP!";
                                            } else 
                                            {
                                                txt_Result.text = "強 化 失 敗!";
                                            }
                                            Panel_GetArmyResultList.SetActive(false);
                                            Panel_GetArmyResult.SetActive(false);
                                            Panel_GetArmyResult2.SetActive(false);
                                            Panel_Result.SetActive(true);
                                            return;
                                    });
    }

    public void UnitEnforcefailed(string getArmyInstanceID1, string getArmyInstanceID2, string getArmyInstanceID3)
    {
        SoundManager.instance.PlaySE("staff");
        useArmyItem2(getArmyInstanceID1,getArmyInstanceID2,getArmyInstanceID3);
    }

    public void useArmyItem(string getArmyInstanceID1,string getArmyInstanceID2,string getArmyInstanceID3)
    {
        PlayFabClientAPI.ConsumeItem( new PlayFab.ClientModels.ConsumeItemRequest {
                ConsumeCount = 1, ItemInstanceId = getArmyInstanceID1}
                                    , (result) =>         
                                    {
                                        useArmyItem2(getArmyInstanceID1,getArmyInstanceID2,getArmyInstanceID3);
                                    }
                                    , (error) => {
                                        if(LM.Language == "KOR")
                                        {
                                            txt_Result.text = "용병 강화 실패!";
                                        }else if(LM.Language == "Eng")
                                        {
                                            txt_Result.text = "Failed Power UP!";
                                        } else 
                                        {
                                            txt_Result.text = "強 化 失 敗!";
                                        }
                                        Panel_Loading.SetActive(false);
                                        Panel_GetArmyResult.SetActive(false);
                                        Panel_GetArmyResult2.SetActive(false);
                                        Panel_GetArmyResultList.SetActive(false);
                                        Panel_Result.SetActive(true);
                                                                                print(error.Error);
                                        print(error.ErrorMessage);
                                        print(error.ErrorDetails);

                                    });

    }
    public void useArmyItem2(string getArmyInstanceID1,string getArmyInstanceID2,string getArmyInstanceID3)
    {
        PlayFabClientAPI.ConsumeItem( new PlayFab.ClientModels.ConsumeItemRequest {
                ConsumeCount = 1, ItemInstanceId = getArmyInstanceID2}
                                    , (result) =>         
                                    {
                                        useArmyItem3(getArmyInstanceID1,getArmyInstanceID2,getArmyInstanceID3);
                                    }
                                    , (error) => {
                                        if(LM.Language == "KOR")
                                        {
                                            txt_Result.text = "용병 강화 실패!";
                                        }else if(LM.Language == "Eng")
                                        {
                                            txt_Result.text = "Failed Power UP!";
                                        } else 
                                        {
                                            txt_Result.text = "強 化 失 敗!";
                                        }
                                        Panel_Loading.SetActive(false);
                                        Panel_GetArmyResult.SetActive(false);
                                        Panel_GetArmyResult2.SetActive(false);
                                        Panel_GetArmyResultList.SetActive(false);
                                        Panel_Result.SetActive(true);
                                        print(error.Error);
                                        print(error.ErrorMessage);
                                        print(error.ErrorDetails);

                                    });

    }
    public void useArmyItem3(string getArmyInstanceID1,string getArmyInstanceID2,string getArmyInstanceID3)
    {
        PlayFabClientAPI.ConsumeItem( new PlayFab.ClientModels.ConsumeItemRequest {
                ConsumeCount = 1, ItemInstanceId = getArmyInstanceID3}
                    , (result) =>         
                    {
                        if(Enforce_Success_flag == true)
                        {
                            if(LM.Language == "KOR")
                            {
                                txt_Result.text = "용병 강화 성공!";
                            }else if(LM.Language == "Eng")
                            {
                                txt_Result.text = "Success Power UP!";
                            } else
                            {
                                txt_Result.text = "傭兵 強化 成功!";
                            }
                            Panel_Loading.SetActive(false);
                            Panel_GetArmyResult.SetActive(true);
                            Panel_GetArmyResult2.SetActive(false);
                            Panel_GetArmyResultList.SetActive(false);
                            Panel_Result.SetActive(true);
                            SoundManager.instance.PlaySE("store");
                        } else 
                        {
                            if(LM.Language == "KOR")
                            {
                                txt_Result.text = "용병 강화 실패!";
                            }else if(LM.Language == "Eng")
                            {
                                txt_Result.text = "Failed Power UP!";
                            } else 
                            {
                                txt_Result.text = "強 化 失 敗!";
                            }
                            Panel_Loading.SetActive(false);
                            Panel_GetArmyResult.SetActive(false);
                            Panel_GetArmyResult2.SetActive(false);
                            Panel_GetArmyResultList.SetActive(false);
                            Panel_Result.SetActive(true);
                        }

                        Enforce_Success_flag = false;

                    }
                    , (error) => {
                        if(LM.Language == "KOR")
                        {
                            txt_Result.text = "용병 강화 실패!";
                        }else if(LM.Language == "Eng")
                        {
                            txt_Result.text = "Failed Power UP!";
                        } else 
                        {
                            txt_Result.text = "強 化 失 敗!";
                        }

                                                                print(error.Error);
                                        print(error.ErrorMessage);
                                        print(error.ErrorDetails);

                        Panel_Loading.SetActive(false);
                        Panel_GetArmyResult.SetActive(false);
                        Panel_GetArmyResult2.SetActive(false);
                        Panel_GetArmyResultList.SetActive(false);
                        Panel_Result.SetActive(true);

        });

    }

    public void onClickEnforceArmySlot(Slot input_slot)
    {
        try{
            if(input_slot.item_id.Length < 1)
            {
                return;
            }

            img_select_army_EF.gameObject.SetActive(true);

            SoundManager.instance.PlaySE("button");

            renewEnforceArmyCnt();

            for(int i = 0; i < user_enforce_army_slot.Length; i++)
            {
                user_enforce_army_slot[i].SelectedImg.color = UnityEngine.Color.white;
            }
            
            input_slot.SelectedImg.color = UnityEngine.Color.black;


            select_enforce_army_id = input_slot.item_id;
            select_enforce_army_name = input_slot.item_name;
            select_enforce_army_grade = input_slot.item_grade;
            select_enforce_army_value = input_slot.item_value;
            select_enforce_army_info = input_slot.item_info;
            select_enforce_army_cnt = input_slot.item_count;
            select_enforce_army_instance_id = input_slot.item_instance_id;

            img_select_army_EF.sprite = Resources.Load<Sprite>("item/" + select_enforce_army_name);

            if(select_enforce_army_name == "" || select_enforce_army_name == null)
            {
                return;
            }

            string[] languageenforce_name = select_enforce_army_name.Split('_');
            string[] languageenforce_info = select_enforce_army_info.Split('_');
            
            if(LM.Language == "KOR")
            {
                txt_EnforceArmyName.text = languageenforce_name[0] + "(" + select_enforce_army_grade + ")" + "x" + select_enforce_army_cnt;
                txt_EnforceArmyInfo.text = languageenforce_info[0];
            } else
            {
                txt_EnforceArmyName.text = languageenforce_name[1] + "(" + select_enforce_army_grade + ")" + "x" + select_enforce_army_cnt;
                txt_EnforceArmyInfo.text = languageenforce_info[1];
            }
        } catch (NullReferenceException ex){ 
        }
        
    }

    public void onClickEnforceArmyCloseBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_EnforceArmy.SetActive(false);
        Panel_ArmyMenu.SetActive(true);

        img_select_army_EF.gameObject.SetActive(false);
        txt_EnforceArmyInfo.text = "";
        txt_EnforceArmyName.text = "";

        panel_flag = 0;
        panel_subflag = 0;
    }

    public void onClickEnforeArmyEntireBtn(string str)
    {
        try
        {

        SoundManager.instance.PlaySE("button");

        total_item_cnt = 0;
        consume_item_cnt = 0;

        user_allenforce_army_id.Clear();
        user_allenforce_army_name.Clear();
        user_allenforce_army_grade.Clear();
        user_allenforce_army_value.Clear();
        user_allenforce_army_cnt.Clear();
        user_allenforce_army_instance_id.Clear();
        user_allenforce_army_grade_code.Clear();
        
        if(str == "C")
        {
            for(int i = 0; i < user_enforce_army_id.Count; i++)
            {
                if(user_enforce_army_grade[i] == "D")
                {
                    user_allenforce_army_id.Add(user_enforce_army_id[i]);
                    user_allenforce_army_name.Add(user_enforce_army_name[i]);
                    user_allenforce_army_grade.Add(user_enforce_army_grade[i]);
                    user_allenforce_army_cnt.Add(user_enforce_army_cnt[i]);
                    user_allenforce_army_instance_id.Add(user_enforce_army_instance_id[i]);
                    user_allenforce_army_value.Add(user_enforce_army_value[i]);
                    user_allenforce_army_grade_code.Add(user_enforce_army_grade_code[i]);

                    total_item_cnt = total_item_cnt + user_enforce_army_cnt[i];
                }
            }
            Txt_EnforcePercent.text = "100%";
            img_Enforce1.color = UnityEngine.Color.white;
            img_Enforce2.color = new Color( 150/255f, 255/255f, 150/255f);

            txt_EnforeBeforeGrade.text = "D";
            txt_EnforeNextGrade.text = "C";
        } else if (str == "B")
        {
            for(int i = 0; i < user_enforce_army_id.Count; i++)
            {
                if(user_enforce_army_grade[i] == "C")
                {
                    user_allenforce_army_id.Add(user_enforce_army_id[i]);
                    user_allenforce_army_name.Add(user_enforce_army_name[i]);
                    user_allenforce_army_grade.Add(user_enforce_army_grade[i]);
                    user_allenforce_army_cnt.Add(user_enforce_army_cnt[i]);
                    user_allenforce_army_instance_id.Add(user_enforce_army_instance_id[i]);
                    user_allenforce_army_value.Add(user_enforce_army_value[i]);
                    user_allenforce_army_grade_code.Add(user_enforce_army_grade_code[i]);

                    total_item_cnt = total_item_cnt + user_enforce_army_cnt[i];
                }
            }
            Txt_EnforcePercent.text = "70%";
            img_Enforce1.color = new Color( 150/255f, 255/255f, 150/255f);
            img_Enforce2.color = new Color( 100/255f, 200/255f, 255/255f);

            txt_EnforeBeforeGrade.text = "C";
            txt_EnforeNextGrade.text = "B";
        } else if (str == "A")
        {
            for(int i = 0; i < user_enforce_army_id.Count; i++)
            {
                if(user_enforce_army_grade[i] == "B")
                {
                    user_allenforce_army_id.Add(user_enforce_army_id[i]);
                    user_allenforce_army_name.Add(user_enforce_army_name[i]);
                    user_allenforce_army_grade.Add(user_enforce_army_grade[i]);
                    user_allenforce_army_cnt.Add(user_enforce_army_cnt[i]);
                    user_allenforce_army_instance_id.Add(user_enforce_army_instance_id[i]);
                    user_allenforce_army_value.Add(user_enforce_army_value[i]);
                    user_allenforce_army_grade_code.Add(user_enforce_army_grade_code[i]);

                    total_item_cnt = total_item_cnt + user_enforce_army_cnt[i];
                }
            }
            Txt_EnforcePercent.text = "40%";
            img_Enforce1.color = new Color( 100/255f, 200/255f, 255/255f);
            img_Enforce2.color = new Color( 210/255f, 150/255f, 255/255f);

            txt_EnforeBeforeGrade.text = "B";
            txt_EnforeNextGrade.text = "A";
        } else if (str == "S")
        {
            for(int i = 0; i < user_enforce_army_id.Count; i++)
            {
                if(user_enforce_army_grade[i] == "A")
                {
                    user_allenforce_army_id.Add(user_enforce_army_id[i]);
                    user_allenforce_army_name.Add(user_enforce_army_name[i]);
                    user_allenforce_army_grade.Add(user_enforce_army_grade[i]);
                    user_allenforce_army_cnt.Add(user_enforce_army_cnt[i]);
                    user_allenforce_army_instance_id.Add(user_enforce_army_instance_id[i]);
                    user_allenforce_army_value.Add(user_enforce_army_value[i]);
                    user_allenforce_army_grade_code.Add(user_enforce_army_grade_code[i]);

                    total_item_cnt = total_item_cnt + user_enforce_army_cnt[i];
                }
            }
            Txt_EnforcePercent.text = "10%";
            img_Enforce1.color = new Color( 210/255f, 150/255f, 255/255f);
            img_Enforce2.color = new Color( 255/255f, 150/255f, 150/255f);

            txt_EnforeBeforeGrade.text = "A";
            txt_EnforeNextGrade.text = "S";
        }

        while(total_item_cnt % 3 != 0)
        {
            user_allenforce_army_cnt[0]--;
            total_item_cnt--;

            if(user_allenforce_army_cnt[0] == 0)
            {
                user_allenforce_army_id.RemoveAt(0);
                user_allenforce_army_name.RemoveAt(0);
                user_allenforce_army_grade.RemoveAt(0);
                user_allenforce_army_cnt.RemoveAt(0);
                user_allenforce_army_instance_id.RemoveAt(0);
                user_allenforce_army_value.RemoveAt(0);
                user_allenforce_army_grade_code.RemoveAt(0);
            }
        }

        if(total_item_cnt < 3)
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "용병의 수가 부족합니다.";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Check Unit Count.";
            } else
            {
                txt_Result.text = "傭兵が 足りない.";
            }

            panel_subflag = 1;
            
            Panel_Result.SetActive(true);
            Panel_GetArmyResult.SetActive(false);
            Panel_GetArmyResult2.SetActive(false);
            Panel_GetArmyResultList.SetActive(false);
            return;
        }

        txt_EnforceBeforeCnt.text = "x" + total_item_cnt.ToString();
        txt_EnforceNextCnt.text = "x??";

        Panel_EnforceArmy.SetActive(false);
        Panel_EnforceInfo.SetActive(true);

        } catch(ArgumentOutOfRangeException ex){ 
            if(LM.Language == "KOR")
            {
                txt_Result.text = "용병의 수가 부족합니다.";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Check Unit Count.";
            } else
            {
                txt_Result.text = "傭兵が 足りない.";
            }

            panel_subflag = 1;
            
            Panel_Result.SetActive(true);
            Panel_GetArmyResult.SetActive(false);
            Panel_GetArmyResult2.SetActive(false);
            Panel_GetArmyResultList.SetActive(false);
            return;
        }

    }

    public void onClickEnforceInfoConfirmBtn()
    {
        SoundManager.instance.PlaySE("button");

        int EnforceCnt = total_item_cnt / 3;
        string grade = txt_EnforeNextGrade.text;

        successCnt = 0;

        itemList.Clear();
        newItemList.Clear();

        
        for(int i = 0; i < LM.all_army_id.Count; i++)
        {
            if(LM.all_army_grade[i] == grade)
            {
                itemList.Add(LM.all_army_id[i]);
            }
        }

        for(int i = 0; i < EnforceCnt; i++)
        {
            int rand_item_no = UnityEngine.Random.Range(0,itemList.Count);
            int rand_upgrade_no = UnityEngine.Random.Range(1,101);
            if(grade == "C")
            {
                newItemList.Add(itemList[rand_item_no]);
                successCnt++;
            } else if (grade == "B")
            {
                if(rand_upgrade_no >= 31)
                {
                    newItemList.Add(itemList[rand_item_no]);
                    successCnt++;
                }
            } else if (grade == "A")
            {
                if(rand_upgrade_no >= 61)
                {
                    newItemList.Add(itemList[rand_item_no]);
                    successCnt++;
                }
            } else if (grade == "S")
            {
                if(rand_upgrade_no >= 91)
                {
                    newItemList.Add(itemList[rand_item_no]);
                    successCnt++;
                }
            }
            print(rand_upgrade_no);
        }

        Panel_Loading.SetActive(true);

        if(successCnt < 1)
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "용병 강화 실패!";
            }else if(LM.Language == "Eng")
            {
                txt_Result.text = "Failed Power UP!";
            } else 
            {
                txt_Result.text = "強 化 失 敗!";
            }
            for(int i = 0; i < user_allenforce_army_id.Count; i++)
            {
                AllEnforceFail(user_allenforce_army_instance_id[i], user_allenforce_army_cnt[i]);
            }
            
        }
        else {
            AllEnforceSuccess(newItemList, successCnt, grade);

        }
    }

    public void AllEnforceFail(string ItemInstanceId, int ConsumeCount)
    {
        PlayFabClientAPI.ConsumeItem( new PlayFab.ClientModels.ConsumeItemRequest {
                ConsumeCount = ConsumeCount, ItemInstanceId = ItemInstanceId}
                                    , (result) =>         
                                    {
                                        panel_subflag = 0;
                                        consume_item_cnt = consume_item_cnt + ConsumeCount;

                                        if(consume_item_cnt == total_item_cnt)
                                        {
                                            SoundManager.instance.PlaySE("staff");
                                            Panel_Loading.SetActive(false);
                                            Panel_GetArmyResult.SetActive(false);
                                            Panel_GetArmyResult2.SetActive(false);
                                            Panel_GetArmyResultList.SetActive(false);
                                            Panel_Result.SetActive(true);
                                        }
                                    }
                                    , (error) => {
                                        panel_subflag = 0;
                                        if(LM.Language == "KOR")
                                        {
                                            txt_Result.text = "용병 강화 실패!";
                                        }else if(LM.Language == "Eng")
                                        {
                                            txt_Result.text = "Failed Power UP!";
                                        } else 
                                        {
                                            txt_Result.text = "強 化 失 敗!";
                                        }
                                        Panel_Loading.SetActive(false);
                                        Panel_GetArmyResult.SetActive(false);
                                        Panel_GetArmyResult2.SetActive(false);
                                        Panel_GetArmyResultList.SetActive(false);
                                        Panel_Result.SetActive(true);
                                        print(error.Error);
                                        print(error.ErrorMessage);
                                        print(error.ErrorDetails);

                                    });

    }

    public void AllEnforceItemUse(string ItemInstanceId, int ConsumeCount)
    {
        PlayFabClientAPI.ConsumeItem( new PlayFab.ClientModels.ConsumeItemRequest {
                ConsumeCount = ConsumeCount, ItemInstanceId = ItemInstanceId}
                                    , (result) =>         
                                    {
                                        consume_item_cnt = consume_item_cnt + ConsumeCount;

                                        if(consume_item_cnt == total_item_cnt)
                                        {
                                            panel_subflag = 0;
                                            SoundManager.instance.PlaySE("store");
                                            Panel_Loading.SetActive(false);
                                            Panel_Result.SetActive(true);
                                            Panel_GetArmyResult.SetActive(false);
                                            Panel_GetArmyResult2.SetActive(true);
                                            Panel_GetArmyResultList.SetActive(false);
                                        }
                                    }
                                    , (error) => {
                                        if(LM.Language == "KOR")
                                        {
                                            txt_Result.text = "용병 강화 실패!";
                                        }else if(LM.Language == "Eng")
                                        {
                                            txt_Result.text = "Failed Power UP!";
                                        } else 
                                        {
                                            txt_Result.text = "強 化 失 敗!";
                                        }
                                        Panel_GetArmyResult.SetActive(false);
                                        Panel_GetArmyResult2.SetActive(false);
                                        Panel_GetArmyResultList.SetActive(false);
                                        Panel_Result.SetActive(true);
                                        print(error.Error);
                                        print(error.ErrorMessage);
                                        print(error.ErrorDetails);

                                    });

    }
    public void AllEnforceSuccess(List<string> newItemList, int successCnt, string grade)
    {
        PlayFabServerAPI.GrantItemsToUser(new GrantItemsToUserRequest {
                CatalogVersion = "ARMY1", PlayFabId = User_ID, ItemIds = newItemList}
                                    , (result) => {

                                            if(LM.Language == "KOR")
                                            {
                                                txt_Result.text = "용병 획득 성공!";
                                            }else if(LM.Language == "Eng")
                                            {
                                                txt_Result.text = "Success Get Units!";
                                            } else
                                            {
                                                txt_Result.text = "傭 兵 獲 得 成 功!";
                                            }

                                            if (grade == "C")
                                            {
                                                img_EnforceAllResult.color = new Color( 150/255f, 255/255f, 150/255f);
                                                txt_EnforceAllResultGrade.text = "C";
                                            } else if (grade == "B")
                                            {
                                                img_EnforceAllResult.color = new Color( 100/255f, 200/255f, 255/255f);
                                                txt_EnforceAllResultGrade.text = "B";
                                            } else if (grade == "A")
                                            {
                                                img_EnforceAllResult.color = new Color( 210/255f, 150/255f, 255/255f);
                                                txt_EnforceAllResultGrade.text = "A";
                                            } else if (grade == "S")
                                            {
                                                img_EnforceAllResult.color = new Color( 255/255f, 150/255f, 150/255f);
                                                txt_EnforceAllResultGrade.text = "S";
                                            }
                                            txt_EnforceAllResultCnt.text = "x" + successCnt.ToString();

                                            for(int i = 0; i < user_allenforce_army_id.Count; i++)
                                            {
                                                AllEnforceItemUse(user_allenforce_army_instance_id[i], user_allenforce_army_cnt[i]);
                                            }

                                    }
                                    , (error) => {
                                            if(LM.Language == "KOR")
                                            {
                                                txt_Result.text = "강화 실패!";
                                            }else if(LM.Language == "Eng")
                                            {
                                                txt_Result.text = "Failed Power UP!";
                                            } else 
                                            {
                                                txt_Result.text = "強 化 失 敗!";
                                            }
                                            Panel_GetArmyResultList.SetActive(false);
                                            Panel_GetArmyResult.SetActive(false);
                                            Panel_GetArmyResult2.SetActive(false);
                                            Panel_Result.SetActive(true);
                                            return;
                                    });
    }

    public void onClickEnforceInfoCancelBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_EnforceArmy.SetActive(true);
        Panel_EnforceInfo.SetActive(false);
    }

    // 용병 강화 끝
    // 용병 결과 패널
    public void onClickUnitResultCloseBtn()
    {
        SoundManager.instance.PlaySE("button");

        if(panel_flag == 1 && panel_subflag == 1)
        {
            Panel_ArmyMenu.SetActive(true);
            Panel_EnforceArmy.SetActive(false);
            Panel_EnforceInfo.SetActive(false);
            Panel_GetArmy.SetActive(true);
            Panel_ArmyCnt.SetActive(false);
            Panel_Loading.SetActive(false);
            Panel_SetArmy.SetActive(false);
            Panel_Result.SetActive(false);
            return;
        }

        if(panel_flag == 2 && panel_subflag == 1)
        {
            Panel_ArmyMenu.SetActive(true);
            Panel_EnforceArmy.SetActive(false);
            Panel_EnforceInfo.SetActive(false);
            Panel_GetArmy.SetActive(false);
            Panel_ArmyCnt.SetActive(false);
            Panel_Loading.SetActive(false);
            Panel_SetArmy.SetActive(true);
            Panel_Result.SetActive(false);
            return;
        }

        if(panel_flag == 3 && panel_subflag == 1)
        {
            Panel_ArmyMenu.SetActive(true);
            Panel_EnforceArmy.SetActive(true);
            Panel_EnforceInfo.SetActive(false);
            Panel_GetArmy.SetActive(false);
            Panel_ArmyCnt.SetActive(false);
            Panel_Loading.SetActive(false);
            Panel_SetArmy.SetActive(false);
            Panel_Result.SetActive(false);
            return;
        }

        Panel_ArmyMenu.SetActive(true);
        Panel_EnforceArmy.SetActive(false);
        Panel_EnforceInfo.SetActive(false);
        Panel_GetArmy.SetActive(false);
        Panel_ArmyCnt.SetActive(false);
        Panel_Loading.SetActive(false);
        Panel_SetArmy.SetActive(false);
        Panel_Result.SetActive(false);

        LM.getUserMoney();

        txt_ArmyCnt.text = "1";

        txt_CouponName.text = "";
        txt_CouponInfo.text = "";
        select_user_coupon_id = "";
        select_user_coupon_info = "";
        select_user_coupon_name = "";
        select_user_coupon_instance_id = "";
        select_user_coupon_cnt = 0;
        select_user_coupon_value = 0;
        img_select_coupon.gameObject.SetActive(false);

        txt_ArmyName.text = "";
        txt_ArmyInfo.text = "";
        select_army_id = "";
        select_army_name = "";
        select_army_info = "";
        select_army_value = 0;
        select_army_cnt = 0;
        select_army_grade = "";
        select_army_instance_id = "";
        img_select_army.gameObject.SetActive(false);

        txt_EnforceArmyName.text = "";
        txt_EnforceArmyInfo.text = "";
        select_enforce_army_id = "";
        select_enforce_army_name = "";
        select_enforce_army_info = "";
        select_enforce_army_value = 0;
        select_enforce_army_cnt = 0;
        select_enforce_army_grade = "";
        select_enforce_army_instance_id = "";
        img_select_army_EF.gameObject.SetActive(false);

        deleteArmySlot();
        deleteSetArmySlot();
        deleteEnforceArmySlot();
        deleteSetEnforceArmySlot();
        deleteArmyGetSlot();

        Panel_GetArmyResult.SetActive(false);
        Panel_GetArmyResult2.SetActive(false);
        Panel_GetArmyResultList.SetActive(false);
        Panel_EnforceInfo.SetActive(false);

        if(panel_flag == 1)
        {
            getUserCouponList();
            Panel_GetArmy.SetActive(true);
        }

        if(panel_flag == 2)
        {
            getUserArmyList();
            Panel_SetArmy.SetActive(true);
        }

        if(panel_flag ==3 )
        {
            getUserEnforceArmyList();
            Panel_EnforceArmy.SetActive(true);
        }

        consume_item_cnt = 0;
        total_item_cnt = 0;

        img_Enforce1.color = UnityEngine.Color.white;
        img_Enforce2.color = UnityEngine.Color.white;
        img_EnforceAllResult.color = UnityEngine.Color.white;

        txt_EnforeBeforeGrade.text = "";
        txt_EnforeNextGrade.text = "";
        txt_EnforceAllResultGrade.text = "";



    }

}
