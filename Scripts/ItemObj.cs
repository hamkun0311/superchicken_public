using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemObj : MonoBehaviour
{
    public SpriteRenderer spr;
    public GameManager1 GM;     
    public GameObject movetxt;
    public List<string> itemIDList_S;
    public List<string> itemNameList_S;
    public List<uint> itemValueList_S;
    public string selectItemID;
    public string selectItemName;
    public uint selectItemValue;
    void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager1>();
        getItemInfo();
    }
    public void TouchedObject()
    {
        for(int i = 0; i < GM.networksetarmyIDList.Count; i++)
        {
            if(GM.networksetarmyIDList[i] == selectItemID || GM.networksetarmyIDList.Count == 10)
            {
                GM.goldCnt = GM.goldCnt + 100;
                showDamage(100, "");
                Destroy(this.gameObject);
                return;
            }
        }

            GM.networksetarmyIDList.Add(selectItemID);
            GM.networksetarmyNameList.Add(selectItemName);
            GM.networksetarmyValueList.Add(selectItemValue);
            GM.networksetarmyGradeList.Add("S");
            GM.setUserSlot();

            Destroy(this.gameObject);

            return;

    }
    public void showDamage(int damage, string skill_type)
    {

        TextMeshPro dmgtxt = movetxt.GetComponent<TextMeshPro>();
        if(skill_type == "fire")
        {
            dmgtxt.color = new Color32(255,90,60,255);
        } else if (skill_type == "ice")
        {
            dmgtxt.color = new Color32(60, 90, 255,255);
        } else if (skill_type == "stone")
        {
            dmgtxt.color = new Color32(150, 60, 0, 255);
        } else if (skill_type == "thunder")
        {
            dmgtxt.color = new Color32(255, 200, 0, 255);
        } else
        {
            dmgtxt.color = UnityEngine.Color.black;
        }
        dmgtxt.GetComponent<TextMeshPro>().text ="Already have it!\n+" + damage.ToString() + "Gold";
        Instantiate(dmgtxt, this.transform.position, Quaternion.identity);
        dmgtxt.transform.position = transform.position;
        
    }

    public void getItemInfo()
    {

        spr = this.gameObject.GetComponent<SpriteRenderer>();

        for(int i = 0; i < GM.network_all_army_id.Count; i++)
        {
            if( GM.network_all_army_grade[i] == "S")
            {
                itemIDList_S.Add(GM.network_all_army_id[i]);
                itemNameList_S.Add(GM.network_all_army_name[i]);
                itemValueList_S.Add(GM.network_all_army_value[i]);
            }
        }

        int rand_no = UnityEngine.Random.Range(0,itemIDList_S.Count);

        spr.sprite = Resources.Load<Sprite>("item/" + itemNameList_S[rand_no]);

        selectItemID = itemIDList_S[rand_no];
        selectItemName = itemNameList_S[rand_no];
        selectItemValue = itemValueList_S[rand_no];

    }

}

