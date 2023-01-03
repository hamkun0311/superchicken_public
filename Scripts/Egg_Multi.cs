using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Egg_Multi : MonoBehaviour
{
    public SpriteRenderer spr;
    public GameManager1 GM;
    public GameObject movetxt;
    void Awake()
    {
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager1>();
    }
    public void TouchedObject()
    {
        System.Random randomObj = new System.Random(); // 난수발생 obj

        int rand_egg = randomObj.Next(1,6); // 1~5까지 난수발생
        GM.eggCnt = GM.eggCnt + rand_egg;
        GM.goldCnt = GM.goldCnt + (rand_egg*100);
        showDamage(rand_egg, "");
        Destroy(this.gameObject);
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
        dmgtxt.GetComponent<TextMeshPro>().text ="+" + damage.ToString() + "Eggs, " + (damage*100).ToString() + "Gold";
        Instantiate(dmgtxt, this.transform.position, Quaternion.identity);
        dmgtxt.transform.position = transform.position;
        
    }
}
