using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class fswordI : MonoBehaviour
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

    public int swordmanHp = 10;
    public int swordmanHpTotal = 10;
    public float fire_time = 0;
    public float cool_time = 1f;
    public float dmg_time = 0f;
    public float dmgcool_time = 0.5f;
    public bool deadChk = false;

    public GameManager GM;
    public SoundManager SM;
    public GameObject Missile;
    public GameObject movetxt;

    public Transform AttackPos;

    // Start is called before the first frame update
    void Start()
    {

        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        anim = GetComponent<Animator>();
        anim.SetBool("isMove",true);
        moveSpeed = 1;
        getUnitInfo();

    }

    // Update is called once per frame
    void Update()
    {
        if(moveFlag == true)
        {
            MoveUnit(enemy_no);
        }

        if(swordmanHp < 1 && deadChk == false)
        {
            deadChk = true;
            moveSpeed = 0;
            StartCoroutine(DeadSwordManCo());
        }

        img_hpbar.fillAmount = (float)swordmanHp / (float)swordmanHpTotal;
        img_coolbar.fillAmount = (Time.time + cool_time - fire_time) /cool_time;
    }

public void MoveUnit(int enemy_no)
    {

        try{

            if(enemy[enemy_no] == null)
            {
                enemy = GameObject.FindGameObjectsWithTag("Enemy");
                selectPostion();
            }

            if(transform.position.x > enemy[enemy_no].transform.position.x)
            {
                spr.flipX = true;
            } else if (transform.position.x < enemy[enemy_no].transform.position.x)
            {
                spr.flipX = false;
            } else
            {

            }
            //transform.Translate(new Vector2((enemy.position.x), (enemy.position.y))* moveSpeed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, enemy[enemy_no].transform.position, moveSpeed * Time.deltaTime );
        }
        catch(NullReferenceException ex){ 
            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            selectPostion();
        }
        catch(IndexOutOfRangeException ex){ 
            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            selectPostion();
        }
    }

    public int selectPostion()
    {

        int rand_no = UnityEngine.Random.Range(0,enemy.Length);

        return enemy_no = rand_no;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("Enemy"))
        {
            moveFlag = false;
            moveSpeed = 0;
            AttackPos = other.gameObject.transform;
            if(Time.time > fire_time)
            {
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
            moveSpeed = 0;
            AttackPos = other.gameObject.transform;
            if(Time.time > fire_time)
            {
                StartCoroutine(AttackCo());    
                fire_time = Time.time + cool_time;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        moveFlag = true;
        moveSpeed = 1f;
        if(other.CompareTag("Enemy"))
        {
            anim.SetBool("isMove",true);
            anim.SetBool("isAttack",false);
        }
    }

    private IEnumerator AttackCo()
    {
        SM.PlaySE("sword");
        GameObject tempObj = Instantiate(Missile, transform.position, Quaternion.identity);
        tempObj.transform.SetParent(this.transform);

        anim.SetBool("isAttack", true);
        yield return null;
        anim.SetBool("isAttack", false);
        yield return new WaitForSeconds(1);

    }

    public void getUnitInfo()
    {
        gradeC.Stop();
        gradeB.Stop();
        gradeA.Stop();
        gradeS.Stop();
        summon.Stop();
        

        iteminfo.item_id = GM.select_unit_id;
        iteminfo.item_name = GM.select_unit_name;
        iteminfo.item_grade = GM.select_unit_grade;
        iteminfo.item_value = GM.select_unit_value;

        iteminfo.itemImage.sprite = Resources.Load<Sprite>("item/" + iteminfo.item_name);

        if(iteminfo.item_grade == "D")
        {
            swordmanHp = 15;
            swordmanHpTotal = 15;
            iteminfo.BackImg.color = UnityEngine.Color.white;
        } else if (iteminfo.item_grade == "C")
        {
            swordmanHp = 16;
            swordmanHpTotal = 16;
            iteminfo.BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            summon.startColor = new Color( 150/255f, 255/255f, 150/255f);
            summon.Play();
            gradeC.Play();
        } else if (iteminfo.item_grade == "B")
        {
            swordmanHp = 18;
            swordmanHpTotal = 18;
            iteminfo.BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            summon.startColor = new Color( 100/255f, 200/255f, 255/255f);
            summon.Play();
            gradeB.Play();
        } else if (iteminfo.item_grade == "A")
        {
            swordmanHp = 21;
            swordmanHpTotal = 21;
            iteminfo.BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            summon.startColor = new Color( 210/255f, 150/255f, 255/255f);
            summon.Play();
            gradeA.Play();
        } else if (iteminfo.item_grade == "S")
        {
            swordmanHp = 25;
            swordmanHpTotal = 25;
            iteminfo.BackImg.color = new Color( 255/255f, 150/255f, 150/255f);
            summon.startColor = new Color(  255/255f, 150/255f, 150/255f);
            summon.Play();
            gradeS.Play();
        }

    }

    public void damaged(int dmg_atk)
    {
        if(Time.time > dmg_time)
        {
            StartCoroutine(DamagedCo());
            dmg_time = Time.time + dmgcool_time;
            swordmanHp = swordmanHp - dmg_atk;
            showDamage(dmg_atk,"monster");
        }
        
    }

    private IEnumerator DamagedCo()
    {

        spr.color = UnityEngine.Color.red;
        yield return new WaitForSeconds(1f);
        spr.color = UnityEngine.Color.white;
        yield return null;

    }

    private IEnumerator DeadSwordManCo()
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
    public void healUnit(int atk_dmg)
    {
        if(swordmanHp < swordmanHpTotal)
        {
            swordmanHp = swordmanHp + atk_dmg;
            if(swordmanHp > swordmanHpTotal)
            {
                swordmanHp = swordmanHpTotal;
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
