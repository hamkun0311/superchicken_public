using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class bowman_multi : MonoBehaviour
{
    public SpriteRenderer spr;
    Animator anim;
    public GameObject[] enemy;
    public GameObject hitObj;

    public float moveSpeed;

    public int enemy_no = 0;

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

    public int bowmanHp = 10;
    public int bowmanHpTotal = 10;
    public float fire_time = 0;
    public float cool_time = 1f;
    public float dmg_time = 0f;
    public float dmgcool_time = 0.5f;
    public float timeCounter = 0;
    public bool deadChk = false;

    public GameManager1 GM;
    public SoundManager SM;
    public GameObject chicken;
    public GameObject missile;
    public GameObject movetxt;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager1>();
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        chicken = GameObject.Find("Chicken");
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        anim = GetComponent<Animator>();
        anim.SetBool("isMove",true);
        moveSpeed = 0.75f;
        getUnitInfo();
    }

    // Update is called once per frame
    void Update()
    {
        img_hpbar.fillAmount = (float)bowmanHp / (float)bowmanHpTotal;
        img_coolbar.fillAmount = (Time.time + cool_time - fire_time) /cool_time;

        if(bowmanHp < 1 && deadChk == false)
        {
            deadChk = true;
            moveSpeed = 0;
            StartCoroutine(DeadBowManCo());
        }

        MoveUnit();
    }

    public void MoveUnit()
    {
        timeCounter = timeCounter + Time.deltaTime * moveSpeed;
        float x = Mathf.Cos(timeCounter) * 1f + chicken.transform.position.x;
        float y = Mathf.Sin(timeCounter) * 1f + chicken.transform.position.y;
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

    public void getUnitInfo()
    {
        gradeC.Stop();
        gradeB.Stop();
        gradeA.Stop();
        gradeS.Stop();
        summon.Stop();
        heal.Stop();

        iteminfo.item_id = GM.select_unit_id;
        iteminfo.item_name = GM.select_unit_name;
        iteminfo.item_grade = GM.select_unit_grade;
        iteminfo.item_value = GM.select_unit_value;

        iteminfo.itemImage.sprite = Resources.Load<Sprite>("item/" + iteminfo.item_name);

        if(iteminfo.item_grade == "D")
        {
            bowmanHp = 12;
            bowmanHpTotal = 12;
            iteminfo.BackImg.color = UnityEngine.Color.white;
        } else if (iteminfo.item_grade == "C")
        {
            bowmanHp = 13;
            bowmanHpTotal = 13;
            iteminfo.BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            summon.startColor = new Color( 150/255f, 255/255f, 150/255f);
            summon.Play();
            gradeC.Play();
        } else if (iteminfo.item_grade == "B")
        {
            bowmanHp = 14;
            bowmanHpTotal = 14;
            iteminfo.BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            summon.startColor = new Color( 100/255f, 200/255f, 255/255f);
            summon.Play();
            gradeB.Play();
        } else if (iteminfo.item_grade == "A")
        {
            bowmanHp = 16;
            bowmanHpTotal = 16;
            iteminfo.BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            summon.startColor = new Color( 210/255f, 150/255f, 255/255f);
            summon.Play();
            gradeA.Play();
        } else if (iteminfo.item_grade == "S")
        {
            bowmanHp = 20;
            bowmanHpTotal = 20;
            iteminfo.BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
            summon.startColor = new Color(  255/255f, 150/255f, 150/255f);
            summon.Play();
            gradeS.Play();
        }

    }

    public void damaged(int atk_dmg)
    {
        //if(Time.time > dmg_time)
        //{
            StartCoroutine(DamagedCo());
            dmg_time = Time.time + dmgcool_time;
            bowmanHp = bowmanHp - atk_dmg;
            showDamage(atk_dmg,"monster");
        //}
        
    }

    private IEnumerator DamagedCo()
    {

        spr.color = UnityEngine.Color.red;
        yield return new WaitForSeconds(1f);
        spr.color = UnityEngine.Color.white;
        yield return null;

    }

    private IEnumerator DeadBowManCo()
    {
        anim.SetBool("isDead",true);
        yield return new WaitForSeconds(0.5f);
        GM.g_unit_cnt--;
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

    public int selectPostion()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        int rand_no = UnityEngine.Random.Range(0,enemy.Length);
        return enemy_no = rand_no;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("Enemy"))
        {
            moveFlag = false;
            if(Time.time > fire_time)
            {
                selectPostion();
                StartCoroutine(AttackCo());    
                fire_time = Time.time + cool_time;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            moveFlag = false;
            if(Time.time > fire_time)
            {
                selectPostion();
                StartCoroutine(AttackCo());    
                fire_time = Time.time + cool_time;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        moveFlag = true;
        if(other.CompareTag("Enemy"))
        {
            anim.SetBool("isMove",true);
            anim.SetBool("isAttack",false);
        }
    }

    private IEnumerator AttackCo()
    {
        SM.PlaySE("bow");

        int bowcnt = 0;

        if(iteminfo.item_grade == "D")
        {
            bowcnt = 1;
        } else if(iteminfo.item_grade == "C")
        {
            bowcnt = 1;
        } else if(iteminfo.item_grade == "B")
        {
            bowcnt = 2;
        } else if(iteminfo.item_grade == "A")
        {
            bowcnt = 2;
        } else if(iteminfo.item_grade == "S")
        {
            bowcnt = 3;
        }

        for(int i = 0; i < bowcnt; i++)
        {
            GameObject tempObj = Instantiate(missile, transform.position, Quaternion.identity);
            tempObj.transform.SetParent(this.transform);
        }
        

        anim.SetBool("isAttack", true);
        yield return null;
        anim.SetBool("isAttack", false);
        yield return new WaitForSeconds(1);

    }
    public void healUnit(int atk_dmg)
    {
        if(bowmanHp < bowmanHpTotal)
        {
            bowmanHp = bowmanHp + atk_dmg;
            if(bowmanHp > bowmanHpTotal)
            {
                bowmanHp = bowmanHpTotal;
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
