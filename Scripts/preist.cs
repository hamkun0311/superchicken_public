using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class preist : MonoBehaviour
{
    public SpriteRenderer spr;
    Animator anim;
    public GameObject hitObj;
    public GameObject spell;
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
    public ParticleSystem healcast;
    public ParticleSystem heal;

    public int preistHp = 10;
    public int preistHpTotal = 10;
    public float fire_time = 0;
    public float cool_time = 5f;
    public float dmg_time = 0f;
    public float dmgcool_time = 0.5f;
    public float timeCounter = 0;
    public bool deadChk = false;
    public GameObject movetxt;

    public GameManager GM;
    public SoundManager SM;
    public GameObject chicken;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        chicken = GameObject.Find("Chicken");
        anim = GetComponent<Animator>();
        anim.SetBool("isMove",true);
        moveSpeed = 1f;
        getUnitInfo();
    }

    // Update is called once per frame
    void Update()
    {
        img_hpbar.fillAmount = (float)preistHp / (float)preistHpTotal;
        img_coolbar.fillAmount = (Time.time + cool_time - fire_time) /cool_time;

        if(preistHp < 1 && deadChk == false)
        {
            deadChk = true;
            moveSpeed = 0;
            StartCoroutine(DeadPreistCo());
        }

        MoveUnit();
    }

    public void getUnitInfo()
    {
        gradeC.Stop();
        gradeB.Stop();
        gradeA.Stop();
        gradeS.Stop();
        summon.Stop();
        heal.Stop();
        healcast.Stop();

        iteminfo.item_id = GM.select_unit_id;
        iteminfo.item_name = GM.select_unit_name;
        iteminfo.item_grade = GM.select_unit_grade;
        iteminfo.item_value = GM.select_unit_value;

        iteminfo.itemImage.sprite = Resources.Load<Sprite>("item/" + iteminfo.item_name);

        if(iteminfo.item_grade == "D")
        {
            preistHp = 10;
            preistHpTotal = 10;
            iteminfo.BackImg.color = UnityEngine.Color.white;
        } else if (iteminfo.item_grade == "C")
        {
            preistHp = 11;
            preistHpTotal = 11;
            iteminfo.BackImg.color = new Color( 150/255f, 255/255f, 150/255f);
            summon.startColor = new Color( 150/255f, 255/255f, 150/255f);
            summon.Play();
            gradeC.Play();
        } else if (iteminfo.item_grade == "B")
        {
            preistHp = 12;
            preistHpTotal = 12;
            iteminfo.BackImg.color = new Color( 100/255f, 200/255f, 255/255f);
            summon.startColor = new Color( 100/255f, 200/255f, 255/255f);
            summon.Play();
            gradeB.Play();
        } else if (iteminfo.item_grade == "A")
        {
            preistHp = 14;
            preistHpTotal = 14;
            iteminfo.BackImg.color = new Color( 210/255f, 150/255f, 255/255f);
            summon.startColor = new Color( 210/255f, 150/255f, 255/255f);
            summon.Play();
            gradeA.Play();
        } else if (iteminfo.item_grade == "S")
        {
            preistHp = 16;
            preistHpTotal = 16;
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
            preistHp = preistHp - atk_dmg;
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
    private IEnumerator DeadPreistCo()
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

    private IEnumerator AttackCo()
    {
        SM.PlaySE("heal");
        GameObject tempObj = Instantiate(spell, transform.position, Quaternion.identity);
        tempObj.transform.SetParent(this.transform);
        healcast.Play();
        anim.SetBool("isAttack", true);
        yield return null;
        anim.SetBool("isAttack", false);
        anim.SetBool("isMove", true);
        yield return new WaitForSeconds(1);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Unit"))
        {
            if(Time.time > fire_time)
            {
                StartCoroutine(AttackCo());    
                fire_time = Time.time + cool_time;
            }
        }
    }

    public void MoveUnit()
    {
        timeCounter = timeCounter + Time.deltaTime * moveSpeed;
        float x = Mathf.Cos(timeCounter) * 0.75f + chicken.transform.position.x;
        float y = Mathf.Sin(timeCounter) * 0.75f + chicken.transform.position.y;
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
    public void healUnit(int atk_dmg)
    {
        if(preistHp < preistHpTotal)
        {
            preistHp = preistHp + atk_dmg;
            if(preistHp > preistHpTotal)
            {
                preistHp = preistHpTotal;
            }
            heal.Play();
            showDamage(atk_dmg,"heal");
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

