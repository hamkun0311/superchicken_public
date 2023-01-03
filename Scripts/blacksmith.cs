using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


public class blacksmith : MonoBehaviour
{
    // Start is called before the first frame update
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

    public int unitHP = 15;
    public int unitHPTotal = 15;
    public float fire_time = 0;
    public float cool_time = 5f;
    public float dmg_time = 0f;
    public float dmgcool_time = 1f;
    public bool deadChk = false;
    public GameManager GM;
    public SoundManager SM;
    public GameObject chicken;
    public float timeCounter = 0;
    public GameObject movetxt;
    public GameObject robot;

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
        if(moveFlag == true)
        {
            MoveUnit();
        }

        if(Time.time > fire_time)
        {
            StartCoroutine(AttackCo());
            fire_time = Time.time + cool_time;
        }

        

        if(unitHP < 1 && deadChk == false)
        {
            deadChk = true;
            moveSpeed = 0;
            StartCoroutine(DeadUnitCo());
        }

        img_hpbar.fillAmount = (float)unitHP / (float)unitHPTotal;
        img_coolbar.fillAmount = (Time.time + cool_time - fire_time) /cool_time;
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
            unitHP = 15;
            unitHPTotal = 15;
        } else if (iteminfo.item_grade == "C")
        {
            iteminfo.BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            summon.startColor = new Color( 150/255f, 255/255f, 150/255f);
            unitHP = 16;
            unitHPTotal = 16;
            summon.Play();
            gradeC.Play();
        } else if (iteminfo.item_grade == "B")
        {
            iteminfo.BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            summon.startColor = new Color( 100/255f, 200/255f, 255/255f);
            unitHP = 18;
            unitHPTotal = 18;
            summon.Play();
            gradeB.Play();
        } else if (iteminfo.item_grade == "A")
        {
            iteminfo.BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            summon.startColor = new Color( 210/255f, 150/255f, 255/255f);
            unitHP = 20;
            unitHPTotal = 20;
            summon.Play();
            gradeA.Play();
        } else if (iteminfo.item_grade == "S")
        {
            iteminfo.BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
            summon.startColor = new Color(  255/255f, 150/255f, 150/255f);
            unitHP = 25;
            unitHPTotal = 25;
            summon.Play();
            gradeS.Play();
        }

    }

    private IEnumerator DeadUnitCo()
    {
        anim.SetBool("isDead",true);
        yield return new WaitForSeconds(0.5f);
        GM.g_UnitCnt--;
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
        float x = Mathf.Cos(timeCounter) * 1.125f + chicken.transform.position.x;
        float y = Mathf.Sin(timeCounter) * 1.125f + chicken.transform.position.y;
        transform.position = new Vector2(x,y);

        if(transform.position.y > chicken.transform.position.y)
        {
            spr.flipX = true;
        } else if (transform.position.y < chicken.transform.position.y)
        {
            spr.flipX = false;
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

    
    private IEnumerator AttackCo()
    {
        SM.PlaySE("staff");

        int robotCnt = 0;

        if(iteminfo.item_grade == "D")
        {
            robotCnt = 1;
        } else if(iteminfo.item_grade == "C")
        {
            robotCnt = 1;
        } else if(iteminfo.item_grade == "B")
        {
            robotCnt = 2;
        } else if(iteminfo.item_grade == "A")
        {
            robotCnt = 2;
        } else if(iteminfo.item_grade == "S")
        {
            robotCnt = 3;
        }


        for(int i = 0; i < robotCnt; i++)
        {
            GameObject tempObj = Instantiate(robot, transform.position, Quaternion.identity);
            tempObj.transform.SetParent(this.transform);
        }

        moveSpeed = 0f;
        moveFlag = false;
        anim.SetBool("isAttack", true);
        yield return null;
        
        moveSpeed = 1f;
        anim.SetBool("isAttack", false);
        anim.SetBool("isMove", true);
        moveFlag = true;
        
        yield return new WaitForSeconds(1);
        

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
