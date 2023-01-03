using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.ServerModels;
using UnityEngine;
using UnityEngine.UI;
public class StoreManager : MonoBehaviour
{
    public GameObject Panel_Shop;
    public GameObject Panel_ShopMenu;
    public GameObject Panel_CouponShop;
    public GameObject Panel_SkinShop;
    public GameObject Panel_RubyShop;
    public GameObject Panel_RubyShopAlert;
    public GameObject Panel_ItemCnt;
    public GameObject Panel_Result;
    public GameObject Panel_Loading;
        

    public Text txt_Result;
    public Text txt_Loading;

    //SHOP MENU
    public Text txt_ShopMenuCouponTitle;
    public Text txt_ShopMenuCouponBtn;
    public Text txt_ShopMenuSkinTitle;
    public Text txt_ShopMenuSkinBtn;
    public Text txt_ShopMenuRubyTitle;
    public Text txt_ShopMenuRubyBtn;
    public Text txt_ShopMenuExitBtn;


    //UNIT COUPON
    public Text txt_UnitCouponTitle;
    public Text txt_CouponName;
    public Text txt_CouponInfo;
    public Text txt_CouponPrice;
    public Text txt_UnitCouponBuy;
    public Text txt_UnitCouponExit;

    //Skin 
    public Text txt_SkinTitle;
    public Text txt_SkinName;
    public Text txt_SkinInfo;
    public Text txt_SkinPrice;
    public Text txt_SkinBuy;
    public Text txt_SkinExit;
    public Button btn_buySkin;

    //BuyCnt
    public Text txt_BuyCntTitle;
    public Text txt_BuyCnt;
    public Text txt_BuyCntBuy;
    public Text txt_BuyCntExit;
    public Text txt_ResultConfrimBtn;
    
    
    //RubyStoreAlert
    public Text txt_RubyAlertInfo;
    public Text txt_RubyAlertConfirmBtn;
    public Text txt_RubyAlertExitBtn;
    public Text txt_RubyUnit;
    public Text txt_RubyUnitSpiritS;
    public Text txt_RubyUnitSpiritSInfo;
    public Text txt_RubyUnitSpiritA;
    public Text txt_RubyUnitSpiritAInfo;
    public Text txt_RubyShopExitBtn;
    

    public Image img_select_item;
    public Image img_select_skin;

    public string User_ID;
    public LobbyManager LM;

    public string[] store_item_id = new string[100];
    public string[] store_item_name = new string[100];
    public string[] store_item_info = new string[100];
    public uint[] store_item_value = new uint[100];
    public string select_store_item_id;
    public string select_store_item_name;
    public uint select_store_item_value;
    public string select_store_item_info;
    public Slot[] store_slot = new Slot[100];
    public Transform slotHolder;

    public string[] store_skin_id = new string[100];
    public string[] store_skin_name = new string[100];
    public string[] store_skin_info = new string[100];
    public uint[] store_skin_value = new uint[100];
    public string select_store_skin_id;
    public string select_store_skin_name;
    public uint select_store_skin_value;
    public string select_store_skin_info;
    public Slot[] store_skin_slot = new Slot[100];
    public Transform slotHolder_skin;

    public int cntflag = 0;

    // Start is called before the first frame update
    void Start()
    {
        Panel_Shop.SetActive(false);
        Panel_ShopMenu.SetActive(false);
        Panel_CouponShop.SetActive(false);
        Panel_SkinShop.SetActive(false);
        Panel_RubyShop.SetActive(false);
        Panel_RubyShopAlert.SetActive(false);
        Panel_ItemCnt.SetActive(false);
        Panel_Result.SetActive(false);
        Panel_Loading.SetActive(false);
        User_ID = LoginMenu.User_ID;
        img_select_item.gameObject.SetActive(false);
        store_slot = slotHolder.GetComponentsInChildren<Slot>();
        store_skin_slot = slotHolder_skin.GetComponentsInChildren<Slot>();

        if(LM.Language == "KOR")
        {
            txt_ShopMenuCouponTitle.text = "용 병 교 환 권";
            txt_ShopMenuCouponBtn.text = "상 점 열 기";
            txt_ShopMenuSkinTitle.text = "스    킨";
            txt_ShopMenuSkinBtn.text = "상 점 열 기";
            txt_ShopMenuRubyTitle.text = "루    비";
            txt_ShopMenuRubyBtn.text = "상 점 열 기";
            txt_ShopMenuExitBtn.text = "나 가 기";
            txt_UnitCouponTitle.text = "용 병 교 환 권";
            txt_UnitCouponBuy.text = "구 매";
            txt_UnitCouponExit.text = "닫 기";
            txt_SkinBuy.text = "구 매";
            txt_SkinExit.text = "닫 기";
            txt_CouponName.text = "";
            txt_CouponInfo.text = "";
            txt_BuyCntTitle.text = "구매 수량";
            txt_BuyCntBuy.text = "구 매";
            txt_BuyCntExit.text = "닫 기";
            txt_RubyAlertInfo.text = "구매하신 루비 교환권은 용병 메뉴에서 확인 가능합니다. 이미 사용한 루비 교환권이나 구매후 48시간이 지난 루비 교환권은 환불이 불가능 합니다.";
            txt_RubyAlertConfirmBtn.text = "확 인";
            txt_ResultConfrimBtn.text = "확 인";
            txt_RubyAlertExitBtn.text = "닫 기";
            txt_RubyUnit.text = "용병교환권(R)";
            txt_RubyUnitSpiritS.text = "영웅조각(S)";
            txt_RubyUnitSpiritSInfo.text = "S급 성공확률\n+2.5%";
            txt_RubyUnitSpiritA.text = "영웅조각(A)";
            txt_RubyUnitSpiritAInfo.text = "A급 성공확률\n+5%";
            txt_RubyShopExitBtn.text = "나 가 기";
        }else if(LM.Language == "Eng")
        {
            txt_ShopMenuCouponTitle.text = "Unit Coupon";
            txt_ShopMenuCouponBtn.text = "Store";
            txt_ShopMenuSkinTitle.text = "Skin";
            txt_ShopMenuSkinBtn.text = "Store";
            txt_ShopMenuRubyTitle.text = "Ruby Coupon";
            txt_ShopMenuRubyBtn.text = "Store";
            txt_ShopMenuExitBtn.text = "E X I T";
            txt_UnitCouponTitle.text = "Unit Coupon";
            txt_UnitCouponBuy.text = "BUY";
            txt_UnitCouponExit.text = "EXIT";
            txt_SkinBuy.text = "BUY";
            txt_SkinExit.text = "EXIT";
            txt_CouponName.text = "";
            txt_CouponInfo.text = "";
            txt_BuyCntTitle.text = "Buy Count";
            txt_BuyCntBuy.text = "BUY";
            txt_ResultConfrimBtn.text = "Confirm";
            txt_BuyCntExit.text = "EXIT";
            txt_RubyAlertInfo.text = "You can check the Ruby coupon you purchased in your Unit Menu.\n\nUsed coupon and 48 hours after purchased are non-refundable.";
            txt_RubyAlertConfirmBtn.text = "Apply";
            txt_RubyAlertExitBtn.text = "Cancel";
            txt_RubyUnit.text = "UnitCoupon(R)";
            txt_RubyUnitSpiritS.text = "Hero Spirit(S)";
            txt_RubyUnitSpiritSInfo.text = "S Success\nPercent +2.5%";
            txt_RubyUnitSpiritA.text = "Hero Spirit(A)";
            txt_RubyUnitSpiritAInfo.text = "A Success\nPercent +5%";
            txt_RubyShopExitBtn.text = "E X I T";
        } else 
        {
            txt_ShopMenuCouponTitle.text = "傭兵クーポン";
            txt_ShopMenuCouponBtn.text = "お 店";
            txt_ShopMenuSkinTitle.text = "コスチューム";
            txt_ShopMenuSkinBtn.text = "お 店";
            txt_ShopMenuRubyTitle.text = "ルビークーポン";
            txt_ShopMenuRubyBtn.text = "お 店";
            txt_ShopMenuExitBtn.text = "出 る";
            txt_UnitCouponTitle.text = "傭兵クーポン";
            txt_UnitCouponBuy.text = "購 入";
            txt_UnitCouponExit.text = "出 る";
            txt_CouponName.text = "";
            txt_CouponInfo.text = "";
            txt_BuyCntTitle.text = "購 入 数 量";
            txt_BuyCntBuy.text = "購 入";
            txt_BuyCntExit.text = "出 る";
            txt_SkinBuy.text = "購 入";
            txt_SkinExit.text = "出 る";
            txt_RubyAlertInfo.text = "購入したルビー交換券は傭兵メニューで確認できます。\n\nすでに使用したルビー商品券や購入後48時間経過したルビー商品券は返金できません。";
            txt_RubyAlertConfirmBtn.text = "は い";
            txt_ResultConfrimBtn.text = "出 る";
            txt_RubyAlertExitBtn.text = "い い え";
            txt_RubyUnit.text = "UnitCoupon(R)";
            txt_RubyUnitSpiritS.text = "Hero Spirit(S)";
            txt_RubyUnitSpiritSInfo.text = "S Success\nPercent +2.5%";
            txt_RubyUnitSpiritA.text = "Hero Spirit(A)";
            txt_RubyUnitSpiritAInfo.text = "A Success\nPercent +5%";
            txt_RubyShopExitBtn.text = "出 る";
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //상점메뉴
    //상점클릭
    public void onClickStoreBtn()
    {
        SoundManager.instance.PlaySE("button");

                if(LM.Language == "KOR")
        {
            txt_ShopMenuCouponTitle.text = "용 병 교 환 권";
            txt_ShopMenuCouponBtn.text = "상 점 열 기";
            txt_ShopMenuSkinTitle.text = "스    킨";
            txt_ShopMenuSkinBtn.text = "상 점 열 기";
            txt_ShopMenuRubyTitle.text = "루    비";
            txt_ShopMenuRubyBtn.text = "상 점 열 기";
            txt_ShopMenuExitBtn.text = "나 가 기";
            txt_UnitCouponTitle.text = "용 병 교 환 권";
            txt_UnitCouponBuy.text = "구 매";
            txt_UnitCouponExit.text = "닫 기";
            txt_SkinBuy.text = "구 매";
            txt_SkinExit.text = "닫 기";
            txt_CouponName.text = "";
            txt_CouponInfo.text = "";
            txt_BuyCntTitle.text = "구매 수량";
            txt_BuyCntBuy.text = "구 매";
            txt_BuyCntExit.text = "닫 기";
            txt_RubyAlertInfo.text = "구매하신 루비 교환권은 용병 메뉴에서 확인 가능합니다. 이미 사용한 루비 교환권이나 구매후 48시간이 지난 루비 교환권은 환불이 불가능 합니다.";
            txt_RubyAlertConfirmBtn.text = "확 인";
            txt_ResultConfrimBtn.text = "확 인";
            txt_RubyAlertExitBtn.text = "닫 기";
            txt_RubyUnit.text = "용병교환권(R)";
            txt_RubyUnitSpiritS.text = "영웅조각(S)";
            txt_RubyUnitSpiritSInfo.text = "S급 성공확률\n+2.5%";
            txt_RubyUnitSpiritA.text = "영웅조각(A)";
            txt_RubyUnitSpiritAInfo.text = "A급 성공확률\n+5%";
            txt_RubyShopExitBtn.text = "나 가 기";
        }else if(LM.Language == "Eng")
        {
            txt_ShopMenuCouponTitle.text = "Unit Coupon";
            txt_ShopMenuCouponBtn.text = "Store";
            txt_ShopMenuSkinTitle.text = "Skin";
            txt_ShopMenuSkinBtn.text = "Store";
            txt_ShopMenuRubyTitle.text = "Ruby Coupon";
            txt_ShopMenuRubyBtn.text = "Store";
            txt_ShopMenuExitBtn.text = "E X I T";
            txt_UnitCouponTitle.text = "Unit Coupon";
            txt_UnitCouponBuy.text = "BUY";
            txt_UnitCouponExit.text = "EXIT";
            txt_SkinBuy.text = "BUY";
            txt_SkinExit.text = "EXIT";
            txt_CouponName.text = "";
            txt_CouponInfo.text = "";
            txt_BuyCntTitle.text = "Buy Count";
            txt_BuyCntBuy.text = "BUY";
            txt_ResultConfrimBtn.text = "Confirm";
            txt_BuyCntExit.text = "EXIT";
            txt_RubyAlertInfo.text = "You can check the Ruby coupon you purchased in your Unit Menu.\n\nUsed coupon and 48 hours after purchased are non-refundable.";
            txt_RubyAlertConfirmBtn.text = "Apply";
            txt_RubyAlertExitBtn.text = "Cancel";
            txt_RubyUnit.text = "UnitCoupon(R)";
            txt_RubyUnitSpiritS.text = "Hero Spirit(S)";
            txt_RubyUnitSpiritSInfo.text = "S Success\nPercent +2.5%";
            txt_RubyUnitSpiritA.text = "Hero Spirit(A)";
            txt_RubyUnitSpiritAInfo.text = "A Success\nPercent +5%";
            txt_RubyShopExitBtn.text = "E X I T";
        } else 
        {
            txt_ShopMenuCouponTitle.text = "傭兵クーポン";
            txt_ShopMenuCouponBtn.text = "お 店";
            txt_ShopMenuSkinTitle.text = "コスチューム";
            txt_ShopMenuSkinBtn.text = "お 店";
            txt_ShopMenuRubyTitle.text = "ルビークーポン";
            txt_ShopMenuRubyBtn.text = "お 店";
            txt_ShopMenuExitBtn.text = "出 る";
            txt_UnitCouponTitle.text = "傭兵クーポン";
            txt_UnitCouponBuy.text = "購 入";
            txt_UnitCouponExit.text = "出 る";
            txt_CouponName.text = "";
            txt_CouponInfo.text = "";
            txt_BuyCntTitle.text = "購 入 数 量";
            txt_BuyCntBuy.text = "購 入";
            txt_BuyCntExit.text = "出 る";
            txt_SkinBuy.text = "購 入";
            txt_SkinExit.text = "出 る";
            txt_RubyAlertInfo.text = "購入したルビー交換券は傭兵メニューで確認できます。\n\nすでに使用したルビー商品券や購入後48時間経過したルビー商品券は返金できません。";
            txt_RubyAlertConfirmBtn.text = "は い";
            txt_ResultConfrimBtn.text = "出 る";
            txt_RubyAlertExitBtn.text = "い い え";
            txt_RubyUnit.text = "UnitCoupon(R)";
            txt_RubyUnitSpiritS.text = "Hero Spirit(S)";
            txt_RubyUnitSpiritSInfo.text = "S Success\nPercent +2.5%";
            txt_RubyUnitSpiritA.text = "Hero Spirit(A)";
            txt_RubyUnitSpiritAInfo.text = "A Success\nPercent +5%";
            txt_RubyShopExitBtn.text = "出 る";
        }

        Panel_Shop.SetActive(true);
        Panel_ShopMenu.SetActive(true);
    }
    //상점종료
    public void onClickStoreCloseBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_Shop.SetActive(false);
        Panel_ShopMenu.SetActive(false);
    }
    //루비샵
    //루비상점열기
    public void onClickRubyShopBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_ShopMenu.SetActive(false);
        Panel_RubyShopAlert.SetActive(true);
        cntflag = 2;
    }
    //루비구매알림동의
    public void onClickRubyAlertConfirm()
    {
        SoundManager.instance.PlaySE("button");
        Panel_RubyShopAlert.SetActive(false);
        Panel_RubyShop.SetActive(true);
    }
    //루비구매알림거부
    public void onClickRubyAlertCancel()
    {
        SoundManager.instance.PlaySE("button");
        Panel_RubyShopAlert.SetActive(false);
        Panel_ShopMenu.SetActive(true);
        cntflag = 0;
    }
    //계란구매
    public void onClickEggbuy()
    {
        SoundManager.instance.PlaySE("button");
        txt_BuyCnt.text = "1";
        txt_BuyCntTitle.text = "구매 수량";

        if(LM.Language == "KOR")
        {
            txt_BuyCntTitle.text = "루비 수량";
        } else if(LM.Language == "Eng")
        {
            txt_BuyCntTitle.text = "Ruby Count";
        } else
        {
            txt_BuyCntTitle.text = "ル ビー 数 量";
        }

        Panel_ItemCnt.SetActive(true);
    }

    public void onClickUnitCouponRubyBtn()
    {
        SoundManager.instance.PlaySE("button");

        if(LM.user_ruby < 100)
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "루비가 부족합니다.";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Check Your Ruby.";
            } else
            {
                txt_Result.text = "ルビーが足りない.";
            }
            Panel_Result.SetActive(true);
            Panel_ItemCnt.SetActive(false);
            return;
        }

        buyUnitCouponRuby();

    }

    public void buyUnitCouponRuby()
    {
        if(LM.Language == "KOR")
        {
            txt_Loading.text = "구매중..";
        } else
        {
            txt_Loading.text = "Buying..";
        }
        Panel_Loading.SetActive(true);
        
        List<string> CouponID = new List<string>();

        CouponID.Add("3");


        PlayFabServerAPI.GrantItemsToUser(new GrantItemsToUserRequest {
                            CatalogVersion = "COUPON",PlayFabId = User_ID, ItemIds = CouponID}
                                                , (result) => {
                                                    substractRuby(100);                                                    
                                                }
                                                , (error) => 
                                                {
                                                    if(LM.Language == "KOR")
                                                    {
                                                        txt_Result.text = "구매 실패.";
                                                    } else if (LM.Language == "Eng")
                                                    {
                                                        txt_Result.text = "Failed Buy Items.";
                                                    } else 
                                                    {
                                                        txt_Result.text = "購 入 失 敗.";
                                                    }
                                                    Panel_Result.SetActive(true);
                                                    return;
                                                });

    }

    public void onClickBuyHeroStoneS()
    {
        SoundManager.instance.PlaySE("button");

        if(LM.user_ruby < 30)
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "루비가 부족합니다.";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Check Your Ruby.";
            } else
            {
                txt_Result.text = "ルビーが足りない.";
            }
            Panel_Result.SetActive(true);
            Panel_ItemCnt.SetActive(false);
            return;
        }

        buyHeroSpritS();
    }

    public void onClickBuyHeroStoneA()
    {
        SoundManager.instance.PlaySE("button");

        if(LM.user_ruby < 10)
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "루비가 부족합니다.";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Check Your Ruby.";
            } else
            {
                txt_Result.text = "ルビーが足りない.";
            }
            Panel_Result.SetActive(true);
            Panel_ItemCnt.SetActive(false);
            return;
        }

        buyHeroSpritA();
    }

    public void buyHeroSpritS()
    {
        if(LM.Language == "KOR")
        {
            txt_Loading.text = "구매중..";
        } else
        {
            txt_Loading.text = "Buying..";
        }
        Panel_Loading.SetActive(true);
        
        List<string> CouponID = new List<string>();

        CouponID.Add("heroSpiritS");

        PlayFabServerAPI.GrantItemsToUser(new GrantItemsToUserRequest {
                            CatalogVersion = "HERO",PlayFabId = User_ID, ItemIds = CouponID}
                                                , (result) => {
                                                    substractRuby(30);                                                    
                                                }
                                                , (error) => 
                                                {
                                                    if(LM.Language == "KOR")
                                                    {
                                                        txt_Result.text = "구매 실패.";
                                                    } else if (LM.Language == "Eng")
                                                    {
                                                        txt_Result.text = "Failed Buy Items.";
                                                    } else 
                                                    {
                                                        txt_Result.text = "購 入 失 敗.";
                                                    }
                                                    Panel_Result.SetActive(true);
                                                    return;
                                                });

    }

    public void buyHeroSpritA()
    {
        if(LM.Language == "KOR")
        {
            txt_Loading.text = "구매중..";
        } else
        {
            txt_Loading.text = "Buying..";
        }
        Panel_Loading.SetActive(true);
        
        List<string> CouponID = new List<string>();

        CouponID.Add("heroSpiritA");

        PlayFabServerAPI.GrantItemsToUser(new GrantItemsToUserRequest {
                            CatalogVersion = "HERO",PlayFabId = User_ID, ItemIds = CouponID}
                                                , (result) => {
                                                    substractRuby(10);                                                    
                                                }
                                                , (error) => 
                                                {
                                                    if(LM.Language == "KOR")
                                                    {
                                                        txt_Result.text = "구매 실패.";
                                                    } else if (LM.Language == "Eng")
                                                    {
                                                        txt_Result.text = "Failed Buy Items.";
                                                    } else 
                                                    {
                                                        txt_Result.text = "購 入 失 敗.";
                                                    }
                                                    Panel_Result.SetActive(true);
                                                    return;
                                                });

    }

    public void substractRuby(int value)
    {
        var request = new PlayFab.ClientModels.SubtractUserVirtualCurrencyRequest() { VirtualCurrency = "RB", Amount = value };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, 
                                (result) => {
                                        LM.user_ruby = LM.user_ruby - value;

                                        if(LM.Language == "KOR")
                                        {
                                            txt_Result.text = "구매 성공!";
                                        } else if(LM.Language == "Eng")
                                        {
                                            txt_Result.text = "Success\n Buy Items!";
                                        } else
                                        {
                                            txt_Result.text = "購 入 成 功!";
                                        }

                                        Panel_Loading.SetActive(false);
                                        Panel_Result.SetActive(true);

                                }
                              , (error) => {
                                    if(LM.Language == "KOR")
                                    {
                                        txt_Result.text = "구매 실패.";
                                    } else if (LM.Language == "Eng")
                                    {
                                        txt_Result.text = "Failed Buy Items.";
                                    } else 
                                    {
                                        txt_Result.text = "購 入 失 敗.";
                                    }
                                    Panel_Result.SetActive(true);
                                    Panel_Loading.SetActive(false);
                                    return;

                              });
    }

    //루비상점 종료 : 루비상점닫히기, 상점메뉴 열기
    public void onClickRubyShopQuit()
    {
        SoundManager.instance.PlaySE("button");
        Panel_RubyShop.SetActive(false);
        Panel_ShopMenu.SetActive(true);
        cntflag = 0;
    }
    //용병교환권
    //용병교환권 상점 열기 --> 상점매뉴 닫기, 용병교환권 열기
    public void onClickCouponShopBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_ShopMenu.SetActive(false);
        Panel_CouponShop.SetActive(true);
        Panel_Loading.SetActive(true);
        cntflag = 1;
        getCouponList();
    }
    //용병교환권 닫기 --> 용병교환권 닫기, 상점매뉴 열기
    public void onClickCouponShopCloseBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_CouponShop.SetActive(false);
        Panel_ShopMenu.SetActive(true);

        img_select_item.gameObject.SetActive(false);
        txt_CouponInfo.text = "";
        txt_CouponName.text = "";
        txt_CouponPrice.text = "";

        cntflag = 0;
        
    }

    //구매아이템 불러오기
    public void getCouponList()
    {
        for(int i = 0; i<LM.all_coupon_id.Count; i++)
        {
            store_item_id[i] = LM.all_coupon_id[i];
            store_item_name[i] = LM.all_coupon_name[i];
            store_item_info[i] = LM.all_coupon_info[i];
            store_item_value[i] = LM.all_coupon_value[i];
        
            store_slot[i].item_id = store_item_id[i];
            store_slot[i].item_name = store_item_name[i];
            store_slot[i].item_info = store_item_info[i];
            store_slot[i].item_value = store_item_value[i];
            store_slot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + store_item_name[i]);
            store_slot[i].itemImage.preserveAspect = true;
        }

        Panel_Loading.SetActive(false);

    }
    //구매 아이템 슬롯 선택
    public void onClinkStoreSlotItem(Slot input_slot)
    {

        if(input_slot.item_id == "")
        {
            return;
        }

        img_select_item.gameObject.SetActive(true);

        SoundManager.instance.PlaySE("button");

        for(int i = 0; i < store_slot.Length; i++)
        {
            store_slot[i].SelectedImg.color = UnityEngine.Color.white;
        }
        
        input_slot.SelectedImg.color = UnityEngine.Color.yellow;
        select_store_item_id = input_slot.item_id;
        select_store_item_name = input_slot.item_name;
        select_store_item_value = input_slot.item_value;
        select_store_item_info = input_slot.item_info;
        img_select_item.sprite = Resources.Load<Sprite>("item/" + select_store_item_name);

        string[] languageitem_name = select_store_item_name.Split('_');
        string[] languageitem_info = select_store_item_info.Split('_');

        if(LM.Language == "KOR")
        {
            txt_CouponName.text = languageitem_name[0];
            txt_CouponInfo.text = languageitem_info[0];
        } else
        {
            txt_CouponName.text = languageitem_name[1];
            txt_CouponInfo.text = languageitem_info[1];
            
        }

        txt_CouponPrice.text = " : " + select_store_item_value.ToString();

    }

    //구매버튼 클릭
    public void onClickCouponBuyBtn()
    {
        SoundManager.instance.PlaySE("button");
        if(txt_CouponInfo.text == "")
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "교환권을 클릭하세요!";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Choose Item!";
            } else
            {
                txt_Result.text = "クーポンを\n選択してください!";
            }
            Panel_Result.SetActive(true);
            return;
        }

        txt_BuyCnt.text = "1";        
    
        Panel_ItemCnt.SetActive(true);

        txt_CouponName.text = "";
        txt_CouponInfo.text = "";
        txt_CouponPrice.text = "";

    }

    public void onClickPlusBtn()
    {
        if(int.Parse(txt_BuyCnt.text) * select_store_item_value > LM.user_money)
        {
            return;
        }

        txt_BuyCnt.text = (int.Parse(txt_BuyCnt.text) + 1).ToString();

    }
    public void onClickMinusBtn()
    {
        if(int.Parse(txt_BuyCnt.text) <= 1)
        {
            return;
        }

        txt_BuyCnt.text = (int.Parse(txt_BuyCnt.text) - 1).ToString();
    }
    //구매갯수 취소
    public void onClickItemCntCancel()
    {
        SoundManager.instance.PlaySE("button");
        Panel_ItemCnt.SetActive(false);
    }
    //수량 입력후 구매
    public void onClickItemCntConfirm()
    {
        SoundManager.instance.PlaySE("button");
        int buyCouponCnt = int.Parse(txt_BuyCnt.text);

        if(cntflag == 1)
        {

            if(buyCouponCnt < 1)
            {
                if(LM.Language == "KOR")
                {
                    txt_Result.text = "구매 수량을 확인하세요.";
                } else if(LM.Language == "Eng")
                {
                    txt_Result.text = "Check Item Count!";
                } else
                {
                    txt_Result.text = "購入数量を\n確認してください!";
                }
                Panel_Result.SetActive(true);
                Panel_ItemCnt.SetActive(false);
                return;
            }

            List<string> CouponID = new List<string>();

            CouponID.Add(select_store_item_id);

            if(buyCouponCnt * select_store_item_value > LM.user_money)
            {
                if(LM.Language == "KOR")
                {
                    txt_Result.text = "계란이 부족합니다.";
                } else if(LM.Language == "Eng")
                {
                    txt_Result.text = "Check Your Eggs.";
                } else
                {
                    txt_Result.text = "卵数量を\n確認してください!";
                }
                Panel_Result.SetActive(true);
                Panel_ItemCnt.SetActive(false);
                return;
            }

            if(LM.Language == "KOR")
            {
                txt_Loading.text = "구매중..";
            } else
            {
                txt_Loading.text = "Buying..";
            }
            Panel_Loading.SetActive(true);
            Panel_ItemCnt.SetActive(false);

            PlayFabServerAPI.GrantItemsToUser(new GrantItemsToUserRequest {
                    CatalogVersion = "COUPON",PlayFabId = User_ID, ItemIds = CouponID}
                                        , (result) => {
                                            var ItemResult = result.ItemGrantResults[0];
                                            modifyChestCnt(buyCouponCnt, ItemResult.ItemInstanceId);
                                            
                                        }
                                        , (error) => 
                                        {
                                            if(LM.Language == "KOR")
                                            {
                                                txt_Result.text = "교환권 구매 실패.";
                                            } else if (LM.Language == "Eng")
                                            {
                                                txt_Result.text = "Failed Buy Items.";
                                            } else 
                                            {
                                                txt_Result.text = "購 入 失 敗.";
                                            }
                                            Panel_Result.SetActive(true);
                                            return;
                                        });
        } else
        {
            if(buyCouponCnt > LM.user_ruby)
            {
                if(LM.Language == "KOR")
                {
                    txt_Result.text = "루비가 부족합니다.";
                } else if(LM.Language == "Eng")
                {
                    txt_Result.text = "Check Your Ruby.";
                } else
                {
                    txt_Result.text = "ルビーが足りない.";
                }
                Panel_Result.SetActive(true);
                Panel_ItemCnt.SetActive(false);
                return;
            }

            if(LM.Language == "KOR")
            {
                txt_Loading.text = "구매중..";
            } else
            {
                txt_Loading.text = "Buying..";
            }
            Panel_Loading.SetActive(true);
            Panel_ItemCnt.SetActive(false);

            grantUserMoney(buyCouponCnt);

        }

    }
    public void grantUserMoney(int sellRubyCnt)
    {
        PlayFabClientAPI.AddUserVirtualCurrency(new PlayFab.ClientModels.AddUserVirtualCurrencyRequest() {
                VirtualCurrency = "EG", Amount = sellRubyCnt * 100}
                            , (result) => {
                                        substracUserRuby(sellRubyCnt);      
                            }
                            
                            , (error) => {
                                if(LM.Language == "KOR")
                                {
                                    txt_Result.text = "계란 구매 실패!";
                                } else if(LM.Language == "Eng")
                                {
                                    txt_Result.text = "Fail get Eggs!";
                                } else
                                {
                                    txt_Result.text = "卵の購入に\n失敗しました!";
                                }

                                Panel_Loading.SetActive(false);
                                Panel_Result.SetActive(true);
                            });
    }
    public void substracUserRuby(int sellRubyCnt)
    {
        var request = new PlayFab.ClientModels.SubtractUserVirtualCurrencyRequest() { VirtualCurrency = "RB", Amount = sellRubyCnt };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, 
                                (result) => {
                                        LM.user_money = LM.user_money + (sellRubyCnt * 100);
                                        LM.user_ruby = LM.user_ruby - sellRubyCnt;

                                        if(LM.Language == "KOR")
                                        {
                                            txt_Result.text = "계란 구매 성공!";
                                        } else if(LM.Language == "Eng")
                                        {
                                            txt_Result.text = "Success\n Buy Items!";
                                        } else
                                        {
                                            txt_Result.text = "卵 購 入 成 功!";
                                        }

                                        Panel_Loading.SetActive(false);
                                        Panel_Result.SetActive(true);

                                }
                              , (error) => {
                                    if(LM.Language == "KOR")
                                    {
                                        txt_Result.text = "계란 구매 실패.";
                                    } else if(LM.Language == "Eng")
                                    {
                                        txt_Result.text = "Fail get Eggs!";
                                    } else
                                    {
                                        txt_Result.text = "卵の購入に\n失敗しました!";
                                    }
                                    Panel_Result.SetActive(true);
                                    Panel_Loading.SetActive(false);
                                    return;

                              });
    }

    public void modifyChestCnt(int buyitemCnt, string instanceId)
    {
        PlayFabServerAPI.ModifyItemUses(new ModifyItemUsesRequest{
            PlayFabId = User_ID, ItemInstanceId = instanceId, UsesToAdd = buyitemCnt - 1}, 
            (result)=>{
                substracUserMoney(buyitemCnt*(int)select_store_item_value);
            }, 
            (error)=>{
                    if(LM.Language == "KOR")
                    {
                        txt_Result.text = "계란 구매 실패.";
                    } else if(LM.Language == "Eng")
                    {
                        txt_Result.text = "Fail get Eggs!";
                    } else
                    {
                        txt_Result.text = "卵の購入に\n失敗しました!";
                    }
                    Panel_Result.SetActive(true);
                    Panel_Loading.SetActive(false);
                    return;
            }
        );
    }
    public void substracUserMoney(int money_amount)
    {
        var request = new PlayFab.ClientModels.SubtractUserVirtualCurrencyRequest() { VirtualCurrency = "EG", Amount = money_amount };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, 
                                (result) => {
                                        LM.user_money = LM.user_money - money_amount;
                                        Panel_Loading.SetActive(false);
                                        if(LM.Language == "KOR")
                                        {
                                            txt_Result.text = "교환권 구매 성공!";
                                        } else if(LM.Language == "Eng")
                                        {
                                            txt_Result.text = "Success\n Buy Items!";
                                        } else
                                        {
                                            txt_Result.text = "クーポン購入成功!";
                                        }
                                        Panel_Result.SetActive(true);
                                        Panel_ItemCnt.SetActive(false);
                                }
                              , (error) => 
                              {
                                        if(LM.Language == "KOR")
                                        {
                                            txt_Result.text = "교환권 구매 실패.";
                                        } else if(LM.Language == "Eng")
                                        {
                                            txt_Result.text = "Failed Buy Items.";
                                        } else
                                        {
                                            txt_Result.text = "クーポンの購入に\n失敗しました.";
                                        }
                                        Panel_Result.SetActive(true);
                                        Panel_ItemCnt.SetActive(false);
                                        return;
                              });

    }


    //결과패널 확인
    public void onClickResultConfirmBtn()
    {
        SoundManager.instance.PlaySE("button");
        img_select_item.gameObject.SetActive(false);
        txt_CouponInfo.text = "";
        txt_CouponName.text = "";
        txt_CouponPrice.text = "";
        txt_SkinInfo.text = "";
        txt_SkinName.text = "";
        txt_SkinPrice.text = "";
        Panel_Result.SetActive(false);
    }



    public void onClickSkinShopBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_ShopMenu.SetActive(false);
        Panel_SkinShop.SetActive(true);
        Panel_Loading.SetActive(true);
        getSkinList();
    }
    public void onClickSkinShopCloseBtn()
    {
        SoundManager.instance.PlaySE("button");
        Panel_SkinShop.SetActive(false);
        Panel_ShopMenu.SetActive(true);

        img_select_skin.gameObject.SetActive(false);
        txt_SkinInfo.text = "";
        txt_SkinName.text = "";
        txt_SkinPrice.text = "";
    }
    public void getSkinList()
    {
        for(int i = 0; i < LM.all_skin_id.Count; i++)
        {
            store_skin_id[i] = LM.all_skin_id[i];
            store_skin_name[i] = LM.all_skin_name[i];
            store_skin_info[i] = LM.all_skin_info[i];
            store_skin_value[i] = LM.all_skin_value[i];
        
            store_skin_slot[i].item_id = store_skin_id[i];
            store_skin_slot[i].item_name = store_skin_name[i];
            store_skin_slot[i].item_info = store_skin_info[i];
            store_skin_slot[i].item_value = store_skin_value[i];
            store_skin_slot[i].itemImage.sprite = Resources.Load<Sprite>("item/" + store_skin_name[i]);
            store_skin_slot[i].itemImage.preserveAspect = true;
        }
        Panel_Loading.SetActive(false);
    }
    public void onClickStoreSkinSlotItem(Slot input_slot)
    {

        if(input_slot.item_id == "")
        {
            return;
        }

        img_select_skin.gameObject.SetActive(true);

        SoundManager.instance.PlaySE("button");

        for(int i = 0; i < store_skin_slot.Length; i++)
        {
            store_skin_slot[i].SelectedImg.color = UnityEngine.Color.white;
        }
        
        input_slot.SelectedImg.color = UnityEngine.Color.yellow;
        select_store_skin_id = input_slot.item_id;
        select_store_skin_name = input_slot.item_name;
        select_store_skin_value = input_slot.item_value;
        select_store_skin_info = input_slot.item_info;
        img_select_skin.sprite = Resources.Load<Sprite>("item/" + select_store_skin_name);

        string[] languageitem_name = select_store_skin_name.Split('_');
        string[] languageitem_info = select_store_skin_info.Split('_');

        if(LM.Language == "KOR")
        {
            txt_SkinName.text = languageitem_name[0];
            txt_SkinInfo.text = languageitem_info[0];
        } else
        {
            txt_SkinName.text = languageitem_name[1];
            txt_SkinInfo.text = languageitem_info[1];
            
        }

        txt_SkinPrice.text = " : " + select_store_skin_value.ToString();

        if(LM.player_skin_id.Contains(select_store_skin_id))
        {
            btn_buySkin.interactable = false;
        } else
        {
            btn_buySkin.interactable = true;
        }

    }

    public void onClickSkinBuyBtn()
    {
        SoundManager.instance.PlaySE("button");
        if(txt_SkinInfo.text == "")
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "아이템을 클릭하세요!";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Choose Item!";
            } else
            {
                txt_Result.text = "コスチュームを\n選択してください!";
            }
            Panel_Result.SetActive(true);
            return;
        }

        if(LM.user_money < select_store_skin_value)
        {
            if(LM.Language == "KOR")
            {
                txt_Result.text = "계란이 부족합니다.";
            } else if(LM.Language == "Eng")
            {
                txt_Result.text = "Check Your Eggs.";
            } else
            {
                txt_Result.text = "卵数量を\n確認してください!";
            }
            Panel_Result.SetActive(true);
            return;
        }

            if (LM.Language == "KOR")
            {
                txt_Loading.text = "구매중..";
            }
            else
            {
                txt_Loading.text = "Buying..";
            }
            Panel_Loading.SetActive(true);
            
            List<string> skinid = new List<string>();

            skinid.Add(select_store_skin_id);

            PlayFabServerAPI.GrantItemsToUser(new GrantItemsToUserRequest {
                    CatalogVersion = "SKIN",PlayFabId = User_ID, ItemIds = skinid}
                                        , (result) => {
                                            var ItemResult = result.ItemGrantResults[0];
                                            substracUserMoney2((int)select_store_skin_value);
                                            
                                        }
                                        , (error) => 
                                        {
                                            if(LM.Language == "KOR")
                                            {
                                                txt_Result.text = "스킨 구매 실패.";
                                            } else if(LM.Language == "Eng")
                                            {
                                                txt_Result.text = "Failed Buy Skin.";
                                            } else
                                            {
                                                txt_Result.text = "コスチュームの購入に\n失敗しました.";
                                            }
                                            Panel_Loading.SetActive(false);
                                            Panel_Result.SetActive(true);
                                            return;
                                        });


    }

    public void substracUserMoney2(int money_amount)
    {
        var request = new PlayFab.ClientModels.SubtractUserVirtualCurrencyRequest() { VirtualCurrency = "EG", Amount = money_amount };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, 
                                (result) => {
                                        LM.user_money = LM.user_money - money_amount;
                                        LM.player_skin_id.Add(select_store_skin_id);
                                        LM.player_skin_name.Add(select_store_skin_name);
                                        LM.player_skin_info.Add(select_store_skin_info);
                                        Panel_Loading.SetActive(false);
                                        if(LM.Language == "KOR")
                                        {
                                            txt_Result.text = "스킨 구매 성공!";
                                        } else if(LM.Language == "Eng")
                                        {
                                            txt_Result.text = "Success\n Buy Skin!";
                                        } else
                                        {
                                            txt_Result.text = "コスチューム購入成功!";
                                        }
                                        Panel_Result.SetActive(true);
                                        Panel_ItemCnt.SetActive(false);
                                }
                              , (error) => 
                              {
                                        if(LM.Language == "KOR")
                                        {
                                            txt_Result.text = "스킨 구매 실패.";
                                        } else if(LM.Language == "Eng")
                                        {
                                            txt_Result.text = "Failed Buy Skin.";
                                        } else
                                        {
                                            txt_Result.text = "コスチュームの購入に\n失敗しました.";
                                        }
                                        Panel_Loading.SetActive(false);
                                        Panel_Result.SetActive(true);
                                        Panel_ItemCnt.SetActive(false);
                                        return;
                              });

    }


}
