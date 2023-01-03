using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class Slime_Multi : MonoBehaviour
{

    Animator anim;
    public SpriteRenderer spr;
    public GameManager1 GM1;
    public Transform Chicken;
    public float moveSpeed = 0.1f;
    public float tmp_moveSpeed = 0.1f;
    public ParticleSystem fire1;
    public ParticleSystem fire2;
    public ParticleSystem fire3;
    public ParticleSystem ice1;
    public ParticleSystem ice2;
    public ParticleSystem ice3;
    public ParticleSystem stone1;
    public ParticleSystem stone2;
    public ParticleSystem stone3;
    public ParticleSystem lightning1;
    public ParticleSystem lightning2;
    public ParticleSystem lightning3;
    public ParticleSystem slash;
    public ParticleSystem touch;
    public Image img_hpbar;

    public int SlimeHP = 30;
    public int SlimeTotal = 30;
    public bool deadChk = false;
    public float spellcool = 0.5f;
    public float spellfire = 0;
    public int dmg_atk = 1;
    public bool blackholeChk = false;

    public GameObject movetxt;
    public GameObject TouchPos;

    public GameObject Egg;
    public GameObject blackhole;
    public GameObject itemObj;

    public PhotonView PV;
    public bool playerChk = false;
    public GameObject[] PIL;
    public PlayerInfo PI;

    void Awake()
    {
        spr = this.gameObject.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        GM1 = GameObject.Find("GameManager").GetComponent<GameManager1>();
        Chicken = GameObject.Find("Chicken").GetComponent<Transform>();

        SlimeHP = SlimeHP + (SlimeHP / 10 * GM1.gameLevel);
        SlimeTotal = SlimeHP;
        moveSpeed = moveSpeed + (moveSpeed /10 * GM1.gameLevel);
        tmp_moveSpeed = moveSpeed;
        fire1.Stop();
        fire2.Stop();
        fire3.Stop();
        ice1.Stop();
        ice2.Stop();
        ice3.Stop();
        stone1.Stop();
        stone2.Stop();
        stone3.Stop();
        lightning1.Stop();
        lightning2.Stop();
        lightning3.Stop();
        slash.Stop();
        touch.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position != Chicken.position && blackholeChk == false))
        {
            MonsterMove();
        }

        if(SlimeHP < 1 && deadChk == false)
        {
            deadChk = true;
            moveSpeed = 0;
            StartCoroutine(DeadGoblinCo());
        }

        img_hpbar.fillAmount = (float)SlimeHP / (float)SlimeTotal;
        //setPlayerInfo();

    }

    public void setPlayerInfo()
    {
        if(playerChk == false)
        {
            PIL = GameObject.FindGameObjectsWithTag("PlayerInfo");

            for(int i = 0; i < PIL.Length; i++)
            {
                if(PIL[i].GetComponent<PlayerInfo>().PV.IsMine)
                {
                    PI = PIL[i].GetComponent<PlayerInfo>();
                    playerChk = true;
                }
            }
        }
    }

    public void MonsterMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, Chicken.position, moveSpeed * Time.deltaTime );

        if(Chicken.position.x > transform.position.x)
        {
            spr.flipX = true;
        } else if (Chicken.position.x < transform.position.x)
        {
            spr.flipX = false;
        }

        anim.SetBool("isMove",true);
    }

    private IEnumerator DeadGoblinCo()
    {
        anim.SetBool("isDead",true);
        yield return new WaitForSeconds(0.5f);
        
        GM1.goldCnt++;
        GM1.m_killCnt++;

        PV.RPC("callEnemy",RpcTarget.Others);
        
        int rand_unit = UnityEngine.Random.Range(1,100);

        if(rand_unit == 50)
        {
            Instantiate(Egg, this.transform.position, Quaternion.identity);
        }

        if(rand_unit == 49)
        {
            Instantiate(blackhole, this.transform.position, Quaternion.identity);
        }
        if(rand_unit == 48)
        {
            Instantiate(itemObj, this.transform.position, Quaternion.identity);
        }
        
        this.enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().isTrigger = false;
        Destroy(this.gameObject);
        this.gameObject.SetActive(false);
        yield return null;

    }

    [PunRPC]
    void callEnemy()
    {
        PhotonNetwork.Instantiate("Slime_Enemy", GM1.getCirclePosition(), Quaternion.identity);
    }

    void KnockbackCo(float x, float y)
    {
        transform.Translate(new Vector2(x, y).normalized * Time.deltaTime * 5);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Chicken"))
        {
            if(blackholeChk == false)
            {
                GM1.p_HP--;
                other.GetComponent<ChikenMove>().showDamage(-1, "monster");
                Destroy(this.gameObject);
            }

        } else if(other.CompareTag("Hitbox"))
        {
            if(other.transform.parent.name == "swordman_multi(Clone)")
            {
                other.GetComponentInParent<swordman_multi>().damaged(dmg_atk);        
            } else if(other.transform.parent.name == "bowman_multi(Clone)")
            {
                other.GetComponentInParent<bowman_multi>().damaged(dmg_atk);        
            } else if(other.transform.parent.name == "preist_multi(Clone)")
            {
                other.GetComponentInParent<preist_multi>().damaged(dmg_atk);        
            } else if(other.transform.parent.name == "socerer(Clone)")
            {
                other.GetComponentInParent<socerer>().damaged(dmg_atk);        
            } else if(other.transform.parent.name == "wizard_multi(Clone)")
            {
                other.GetComponentInParent<wizard_multi>().damaged(dmg_atk);        
            }
            else if(other.transform.parent.name == "guard_multi(Clone)")
            {
                other.GetComponentInParent<guard_multi>().damaged(dmg_atk);        
                GM1.m_killCnt = GM1.m_killCnt + 1;
                GM1.goldCnt++;
            } else if(other.transform.parent.name == "fairy_multi(Clone)")
            {
                other.GetComponentInParent<fairy_multi>().damaged(dmg_atk);        
            } else if(other.transform.parent.name == "blacksmith_multi(Clone)")
            {
                other.GetComponentInParent<blacksmith_multi>().damaged(dmg_atk);        
            }

            Destroy(this.gameObject);
            
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.name == "spell_m(Clone)")
        {
            if(other.GetComponent<spell_m>().unit_name == "blackhole")
            {
                blackholeChk = true;
                this.transform.position = Vector2.MoveTowards(transform.position, other.gameObject.transform.position, 3 * Time.deltaTime );
            }
        } else if (other.name == "guard_multi(Clone)")
        {
            blackholeChk = true;
            this.transform.position = Vector2.MoveTowards(transform.position, other.transform.position, 3 * Time.deltaTime );
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "spell_m(Clone)")
        {
            if(other.GetComponent<spell_m>().unit_name == "blackhole")
            {
                blackholeChk = false;
            }
        } else if (other.name == "guard_multi(Clone)")
        {
            blackholeChk = false;
        }
    }

    public void TouchedObject()
    {
            touch.Play();
            this.SlimeHP = this.SlimeHP - GM1.touchdmg;
            showDamage(GM1.touchdmg, "");
    }

    public void Damaged(int dmg_atk, int dmg_skill, string skill_type, float skill_time, string item_type)
    {
        SlimeHP = SlimeHP - dmg_atk;
        showDamage(dmg_atk, skill_type);
        StartCoroutine(DamagedCo(dmg_atk, dmg_skill, skill_type, skill_time, item_type));
    }

    public void DamagedSpell(int dmg_atk, int dmg_skill, string skill_type, float skill_time, string item_type)
    {
        if(spellfire < Time.time)
        {
            spellfire = spellcool + Time.time;
            SlimeHP = SlimeHP - dmg_atk;
            showDamage(dmg_atk, skill_type);
            StartCoroutine(DamagedCo(dmg_atk, dmg_skill, skill_type, skill_time, item_type));
        }

    }

    private IEnumerator DamagedCo(int dmg_atk, int dmg_skill, string skill_type, float skill_time, string item_type)
    {
        
        if(skill_type == "fire")
        {
            float currentTime = skill_time;

            while(currentTime > 0)
            {
                currentTime--;
                if(item_type == "sword" || item_type == "bow")
                {
                    fire1.Play();   
                } else if(item_type == "book")
                {
                    fire2.Play();
                } else if(item_type == "staff" || item_type == "robot")
                {
                    fire3.Play();
                }
                
                SlimeHP = SlimeHP - dmg_skill;
                showDamage(dmg_skill, skill_type);
                yield return new WaitForSeconds(1);
            }
            fire1.Stop();
            fire2.Stop();
            fire3.Stop();
        }

        if(skill_type == "ice")
        {
            float currentTime = skill_time;
            moveSpeed = 0;
            while(currentTime > 0)
            {
                currentTime--;
                if(item_type == "sword" || item_type == "bow")
                {
                    ice1.Play();
                } else if(item_type == "book")
                {
                    ice2.Play();
                } else if(item_type == "staff")
                {
                    ice3.Play();
                }
                yield return new WaitForSeconds(1);
            }
            moveSpeed = tmp_moveSpeed;
            ice1.Stop();
            ice2.Stop();
            ice3.Stop();
        }

        if(skill_type == "stone")
        {
            if(item_type == "sword" || item_type == "bow")
            {
                stone1.Play();
            } else if(item_type == "book")
            {
                stone2.Play();
            } 
                else if(item_type == "staff")
            {
                stone3.Play();
            }
            stone1.Play();
            stone2.Play();
            stone3.Play();
        }

        if(skill_type == "thunder")
        {
            float currentTime = skill_time;
            moveSpeed = moveSpeed / 2;
            while(currentTime > 0)
            {
                currentTime --;
                SlimeHP = SlimeHP - dmg_skill; 
                showDamage(dmg_skill, skill_type);
                if(item_type == "sword" || item_type == "bow")
                {
                    lightning1.Play();
                } else if(item_type == "book")
                {
                    lightning2.Play();
                } else if(item_type == "staff")
                {
                    lightning3.Play();
                }

                yield return new WaitForSeconds(1);

            }
            moveSpeed = tmp_moveSpeed;
            lightning1.Stop();
            lightning2.Stop();
            lightning3.Stop();
            //라이트닝 이펙트 해제
        }

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
        dmgtxt.GetComponent<TextMeshPro>().text = damage.ToString();
        Instantiate(dmgtxt, this.transform.position, Quaternion.identity);
        dmgtxt.transform.position = transform.position;
        
    }
}
