using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


public class fairy : MonoBehaviour
{
    public SpriteRenderer spr;
    Animator anim;
    public GameObject hitObj;
    public float moveSpeed;
    public bool moveFlag = true;

    public Image img_hpbar;
    public Image img_coolbar;
    public Slot iteminfo;

    public ParticleSystem gradeC;
    public ParticleSystem gradeB;
    public ParticleSystem gradeA;
    public ParticleSystem gradeS;
    public ParticleSystem summon;
    public ParticleSystem heal;
    public ParticleSystem defence;

    public int unitHP = 10;
    public int unitHPTotal = 10;
    public float dmg_time = 0f;
    public float dmgcool_time = 0.5f;
    public bool deadChk = false;
    public GameManager GM;
    public SoundManager SM;
    public GameObject chicken;
    public float timeCounter = 0;
    public GameObject movetxt;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetBool("isMove",true);
        chicken = GameObject.Find("Chicken");
        moveSpeed = 1f;
        getUnitInfo();
    }

    // Update is called once per frame
    void Update()
    {
        MoveUnit();

        if(unitHP < 1 && deadChk == false)
        {
            deadChk = true;
            moveSpeed = 0;
            StartCoroutine(DeadUnitCo());
        }

        img_hpbar.fillAmount = (float)unitHP / (float)unitHPTotal;
        img_coolbar.fillAmount = 1;
    }

    public void getUnitInfo()
    {
        gradeC.Stop();
        gradeB.Stop();
        gradeA.Stop();
        gradeS.Stop();
        summon.Stop();
        defence.Stop();
        

        iteminfo.item_id = GM.select_unit_id;
        iteminfo.item_name = GM.select_unit_name;
        iteminfo.item_grade = GM.select_unit_grade;
        iteminfo.item_value = GM.select_unit_value;

        iteminfo.itemImage.sprite = Resources.Load<Sprite>("item/" + iteminfo.item_name);

        if(iteminfo.item_grade == "D")
        {
            iteminfo.BackImg.color = UnityEngine.Color.white;
            unitHP = 10;
            unitHPTotal = 10;
            GM.fairyDCnt++;
        } else if (iteminfo.item_grade == "C")
        {
            iteminfo.BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            summon.startColor = new Color( 150/255f, 255/255f, 150/255f);
            unitHP = 11;
            unitHPTotal = 11;
            summon.Play();
            gradeC.Play();
            GM.fairyCCnt++;
        } else if (iteminfo.item_grade == "B")
        {
            iteminfo.BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            summon.startColor = new Color( 100/255f, 200/255f, 255/255f);
            unitHP = 12;
            unitHPTotal = 12;
            summon.Play();
            gradeB.Play();
            GM.fairyBCnt++;
        } else if (iteminfo.item_grade == "A")
        {
            iteminfo.BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            summon.startColor = new Color( 210/255f, 150/255f, 255/255f);
            unitHP = 13;
            unitHPTotal = 13;
            summon.Play();
            gradeA.Play();
            GM.fairyACnt++;
        } else if (iteminfo.item_grade == "S")
        {
            iteminfo.BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
            summon.startColor = new Color(  255/255f, 150/255f, 150/255f);
            unitHP = 14;
            unitHPTotal = 14;
            summon.Play();
            gradeS.Play();
            GM.fairySCnt++;
        }

    }

    private IEnumerator DeadUnitCo()
    {
        anim.SetBool("isDead",true);
        yield return new WaitForSeconds(0.5f);
        GM.g_UnitCnt--;

        if(iteminfo.item_grade == "D")
        {
            GM.fairyDCnt--;
        } else if (iteminfo.item_grade == "C")
        {
            GM.fairyCCnt--;
        } else if (iteminfo.item_grade == "B")
        {
            GM.fairyBCnt--;
        } else if (iteminfo.item_grade == "A")
        {
            GM.fairyACnt--;
        } else if (iteminfo.item_grade == "S")
        {
            GM.fairySCnt--;
        }

        
        for(int i = 0; i < 10; i++)
        {
            if(iteminfo.item_id == GM.setslot[i].item_id)
            {
                GM.s_unit_cnt[i]--;
            }
        }
        this.enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().isTrigger = false;
        Destroy(this.gameObject);
        this.gameObject.SetActive(false);
        yield return null;

    }

    public void MoveUnit()
    {

        timeCounter = timeCounter + Time.deltaTime * moveSpeed;
        float x = Mathf.Cos(timeCounter) * 0.5f + chicken.transform.position.x;
        float y = Mathf.Sin(timeCounter) * 0.5f + chicken.transform.position.y;
        transform.position = new Vector2(x,y);

        if(transform.position.y > chicken.transform.position.y)
        {
            spr.flipX = false;
        } else if (transform.position.y < chicken.transform.position.y)
        {
            spr.flipX = true;
        } else
        {

        }
    }
    public void damaged(int dmg_atk)
    {
        //if(Time.time > dmg_time)
        //{
            StartCoroutine(DamagedCo());
            dmg_time = Time.time + dmgcool_time;
            unitHP = unitHP - dmg_atk;
            showDamage(dmg_atk, "monster");
        //}
        
    }
    private IEnumerator DamagedCo()
    {

        spr.color = UnityEngine.Color.red;
        yield return new WaitForSeconds(1f);
        spr.color = UnityEngine.Color.white;
        yield return null;

    }
    public void healUnit(int atk_dmg)
    {
        if(unitHP < unitHPTotal)
        {
            unitHP = unitHP + atk_dmg;
            if(unitHP > unitHPTotal)
            {
                unitHP = unitHPTotal;
            }
            heal.Play();
            showDamage(atk_dmg, "heal");
        }

    }
    public void showDamage(int damage, string skill_type)
    {
        TextMeshPro dmgtxt = movetxt.GetComponent<TextMeshPro>();

        if(skill_type == "monster")
        {
            dmgtxt.color = new Color32(255,90,60,255);
        } else if( skill_type == "heal")
        {
            dmgtxt.color = new Color32(150,255,150,255);
        }
        
        dmgtxt.GetComponent<TextMeshPro>().text = damage.ToString();
        Instantiate(dmgtxt, this.transform.position, Quaternion.identity);
        dmgtxt.transform.position = transform.position;
        
    }
}
