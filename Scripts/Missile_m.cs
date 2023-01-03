using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Missile_m : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject Unit;
    public GameObject spell;
    public GameManager1 GM1;
    public Transform AttackPos;
    public float moveSpeed = 5f;
    public int enemy_no;

    public string unit_name;
    public string unit_grade;
    public int dmg_atk;
    public int dmg_skill;
    public float skill_time;
    public string skill_type;
    public string item_type;
    public float item_time;

    public SpriteRenderer spr;

    public ParticleSystem slash;

    public ParticleSystem select_missile;

    // Start is called before the first frame update
    void Start()
    {
        GM1 = GameObject.Find("GameManager").GetComponent<GameManager1>();
        Unit = this.transform.parent.gameObject;
        slash.Stop();
        InitializeMissile();
        Invoke("destroyMissile", item_time);
    }

    // Update is called once per frame
    void Update()
    {
        MissileMove();
    }

    public void InitializeMissile()
    {
        if(Unit.name == "swordman_multi(Clone)")
        {
            select_missile = slash;
            select_missile.Play();
            unit_name = GetComponentInParent<swordman_multi>().iteminfo.item_name;      
            unit_grade = GetComponentInParent<swordman_multi>().iteminfo.item_grade;  
            enemy = GetComponentInParent<swordman_multi>().enemy;  
            enemy_no = GetComponentInParent<swordman_multi>().enemy_no;
            AttackPos = GetComponentInParent<swordman_multi>().AttackPos;
            item_time = 0.5f;
            moveSpeed = 3.5f;
            item_type = "sword";

            spr.sprite = Resources.Load<Sprite>("item/" + "Ball");

            if(unit_name == "파이어소드맨_FireSwordMan")
            {

                skill_type = "fire";
                
                if(unit_grade == "D")
                {
                    dmg_atk = 10;
                    dmg_skill = 1;
                    skill_time = 5;
                } else if (unit_grade == "C")
                {
                    dmg_atk = 20;
                    dmg_skill = 2;
                    skill_time = 5;
                } else if (unit_grade == "B")
                {
                    dmg_atk = 30;
                    dmg_skill = 3;
                    skill_time = 5;
                } else if (unit_grade == "A")
                {
                    dmg_atk = 40;
                    dmg_skill = 4;
                    skill_time = 5;
                } else 
                {
                    dmg_atk = 50;
                    dmg_skill = 5;
                    skill_time = 5;
                }

            } else if (unit_name == "아이스소드맨_IceSwordMan")
            {
                skill_type = "ice";

                if(unit_grade == "D")
                {
                    dmg_atk = 10;
                    dmg_skill = 0;
                    skill_time = 1;
                } else if (unit_grade == "C")
                {
                    dmg_atk = 20;
                    dmg_skill = 0;
                    skill_time = 2;
                } else if (unit_grade == "B")
                {
                    dmg_atk = 30;
                    dmg_skill = 0;
                    skill_time = 3;
                } else if (unit_grade == "A")
                {
                    dmg_atk = 40;
                    dmg_skill = 0;
                    skill_time = 4;
                } else 
                {
                    dmg_atk = 50;
                    dmg_skill = 0;
                    skill_time = 5;
                }
            } else if (unit_name == "스톤소드맨_StoneSwordMan")
            {
                skill_type = "stone";

                if(unit_grade == "D")
                {
                    dmg_atk = 15;
                    dmg_skill = 0;
                    skill_time = 0;
                } else if (unit_grade == "C")
                {
                    dmg_atk = 30;
                    dmg_skill = 0;
                    skill_time = 0;
                } else if (unit_grade == "B")
                {
                    dmg_atk = 45;
                    dmg_skill = 0;
                    skill_time = 0;
                } else if (unit_grade == "A")
                {
                    dmg_atk = 60;
                    dmg_skill = 0;
                    skill_time = 0;
                } else 
                {
                    dmg_atk = 75;
                    dmg_skill = 0;
                    skill_time = 0;
                }
            } else if (unit_name == "썬더소드맨_ThunderSwordMan")
            {
                skill_type = "thunder";

                if(unit_grade == "D")
                {
                    dmg_atk = 10;
                    dmg_skill = 1;
                    skill_time = 5;
                } else if (unit_grade == "C")
                {
                    dmg_atk = 20;
                    dmg_skill = 1;
                    skill_time = 5;
                } else if (unit_grade == "B")
                {
                    dmg_atk = 30;
                    dmg_skill = 2;
                    skill_time = 5;
                } else if (unit_grade == "A")
                {
                    dmg_atk = 40;
                    dmg_skill = 2;
                    skill_time = 5;
                } else 
                {
                    dmg_atk = 50;
                    dmg_skill = 3;
                    skill_time = 5;
                }
            }

        } else if (Unit.name == "bowman_multi(Clone)")
        {
            
            unit_name = GetComponentInParent<bowman_multi>().iteminfo.item_name;      
            unit_grade = GetComponentInParent<bowman_multi>().iteminfo.item_grade;  

            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            enemy_no = UnityEngine.Random.Range(0,enemy.Length);
            AttackPos = enemy[enemy_no].gameObject.transform;

            item_time = 1f;
            moveSpeed = 3f;
            item_type = "bow";

            spr.sprite = Resources.Load<Sprite>("item/" + "Arrow");

            if(unit_name == "파이어보우맨_FireBowMan")
            {
                skill_type = "fire";

                if(unit_grade == "D")
                {
                    dmg_atk = 10;
                    dmg_skill = 1;
                    skill_time = 5;
                } else if (unit_grade == "C")
                {
                    dmg_atk = 20;
                    dmg_skill = 2;
                    skill_time = 5;
                } else if (unit_grade == "B")
                {
                    dmg_atk = 30;
                    dmg_skill = 3;
                    skill_time = 5;
                } else if (unit_grade == "A")
                {
                    dmg_atk = 40;
                    dmg_skill = 4;
                    skill_time = 5;
                } else 
                {
                    dmg_atk = 50;
                    dmg_skill = 5;
                    skill_time = 5;
                }

            } else if (unit_name == "아이스보우맨_IceBowMan")
            {
                skill_type = "ice";

                if(unit_grade == "D")
                {
                    dmg_atk = 10;
                    dmg_skill = 0;
                    skill_time = 1;
                } else if (unit_grade == "C")
                {
                    dmg_atk = 20;
                    dmg_skill = 0;
                    skill_time = 2;
                } else if (unit_grade == "B")
                {
                    dmg_atk = 30;
                    dmg_skill = 0;
                    skill_time = 3;
                } else if (unit_grade == "A")
                {
                    dmg_atk = 40;
                    dmg_skill = 0;
                    skill_time = 4;
                } else 
                {
                    dmg_atk = 50;
                    dmg_skill = 0;
                    skill_time = 5;
                }
            } else if (unit_name == "스톤보우맨_StoneBowMan")
            {
                skill_type = "stone";

                if(unit_grade == "D")
                {
                    dmg_atk = 15;
                    dmg_skill = 0;
                    skill_time = 0;
                } else if (unit_grade == "C")
                {
                    dmg_atk = 30;
                    dmg_skill = 0;
                    skill_time = 0;
                } else if (unit_grade == "B")
                {
                    dmg_atk = 45;
                    dmg_skill = 0;
                    skill_time = 0;
                } else if (unit_grade == "A")
                {
                    dmg_atk = 60;
                    dmg_skill = 0;
                    skill_time = 0;
                } else 
                {
                    dmg_atk = 75;
                    dmg_skill = 0;
                    skill_time = 0;
                }
            } else if (unit_name == "썬더보우맨_ThunderBowMan")
            {
                skill_type = "thunder";
                if(unit_grade == "D")
                {
                    dmg_atk = 10;
                    dmg_skill = 1;
                    skill_time = 5;
                } else if (unit_grade == "C")
                {
                    dmg_atk = 20;
                    dmg_skill = 1;
                    skill_time = 5;
                } else if (unit_grade == "B")
                {
                    dmg_atk = 30;
                    dmg_skill = 2;
                    skill_time = 5;
                } else if (unit_grade == "A")
                {
                    dmg_atk = 40;
                    dmg_skill = 2;
                    skill_time = 5;
                } else 
                {
                    dmg_atk = 50;
                    dmg_skill = 3;
                    skill_time = 5;
                }
            }

        } else if(Unit.name == "socerer_multi(Clone)")
        {
            unit_name = GetComponentInParent<socerer_multi>().iteminfo.item_name;      
            unit_grade = GetComponentInParent<socerer_multi>().iteminfo.item_grade;  

            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            enemy_no = UnityEngine.Random.Range(0,enemy.Length);

            AttackPos = enemy[enemy_no].gameObject.transform;

            item_time = 1f;
            moveSpeed = 2f;
            item_type = "book";

            spr.sprite = Resources.Load<Sprite>("item/" + "Acid");

        }

        dmg_atk = dmg_atk + (( dmg_atk * 10 / 100 * GM1.fairyDCnt) + (dmg_atk * 20 / 100 * GM1.fairyCCnt) + (dmg_atk * 30 / 100 * GM1.fairyBCnt) + (dmg_atk * 40 / 100 * GM1.fairyACnt) + (dmg_atk * 50 / 100 * GM1.fairySCnt) );
        
    }

    public void MissileMove()
    {
        try{
            //== 방향==//
            Vector3 dir = AttackPos.position - Unit.transform.position;
             
            //== 타겟 방향으로 다가감 ==//
            transform.position += dir * moveSpeed * Time.deltaTime;
             
            //== 타겟 방향으로 회전함 ==//
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
   
        }
        catch(NullReferenceException ex){ 
            if(item_type == "sword")
            {
                Destroy(this.gameObject);
            } else if(item_type == "bow" || item_type == "book")
            {
            
                enemy = GameObject.FindGameObjectsWithTag("Enemy");
                enemy_no = UnityEngine.Random.Range(0,enemy.Length);
                if(enemy_no ==0)
                {
                    Destroy(this.gameObject);
                }
                AttackPos = enemy[enemy_no].gameObject.transform;
            }
            
        }
        catch(IndexOutOfRangeException ex){ 
            if(item_type == "sword")
            {
                Destroy(this.gameObject);
            } else if(item_type == "bow" || item_type == "book")
            {
                enemy = GameObject.FindGameObjectsWithTag("Enemy");
                enemy_no = UnityEngine.Random.Range(0,enemy.Length);
                if(enemy_no ==0)
                {
                    Destroy(this.gameObject);
                }
                AttackPos = enemy[enemy_no].gameObject.transform;
            }
        }
        catch(MissingReferenceException ex){ 
            if(item_type == "sword")
            {
                Destroy(this.gameObject);
            } else if(item_type == "bow" || item_type == "book")
            {
                enemy = GameObject.FindGameObjectsWithTag("Enemy");
                enemy_no = UnityEngine.Random.Range(0,enemy.Length);
                if(enemy_no ==0)
                {
                    Destroy(this.gameObject);
                }
                AttackPos = enemy[enemy_no].gameObject.transform;
            }
        }
    }

    public void destroyMissile()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            if(item_type == "sword" || item_type == "bow")
            {
                if(other.name == "Slime_Multi(Clone)")
                {
                    other.GetComponent<Slime_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Slime_Enemy(Clone)")
                {
                    other.GetComponent<Slime_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }  else if(other.name == "Bat_Multi(Clone)")
                {
                    other.GetComponent<Bat_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }  else if(other.name == "Bat_Enemy(Clone)")
                {
                    other.GetComponent<Bat_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "BossSlime_Multi(Clone)")
                {
                    other.GetComponent<SlimeBoss_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "BossSlime_Enemy(Clone)")
                {
                    other.GetComponent<SlimeBoss_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Hyena_Multi(Clone)")
                {
                    other.GetComponent<Hyena_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Hyena_Enemy(Clone)")
                {
                    other.GetComponent<Hyena_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Wolf_Multi(Clone)")
                {
                    other.GetComponent<Wolf_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Wolf_Enemy(Clone)")
                {
                    other.GetComponent<Wolf_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Manticore_Multi(Clone)")
                {
                    other.GetComponent<Manticore_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Manticore_Enemy(Clone)")
                {
                    other.GetComponent<Manticore_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Redbird_Multi(Clone)")
                {
                    other.GetComponent<Redbird_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Redbird_Enemy(Clone)")
                {
                    other.GetComponent<Redbird_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Yellowbird_Multi(Clone)")
                {
                    other.GetComponent<Yellowbird_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Yellowbird_Enemy(Clone)")
                {
                    other.GetComponent<Yellowbird_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Wildbore_Multi(Clone)")
                {
                    other.GetComponent<Wildbore_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Wildbore_Enemy(Clone)")
                {
                    other.GetComponent<Wildbore_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Hellhound_Multi(Clone)")
                {
                    other.GetComponent<Hellhound_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Hellhound_Enemy(Clone)")
                {
                    other.GetComponent<Hellhound_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                Destroy(this.gameObject);    
            } else
            {
                GameObject tempObj = Instantiate(spell, this.transform.position, Quaternion.identity);
                tempObj.transform.SetParent(this.transform);
                Destroy(this.gameObject,0.1f);
            }

            
            
        }

        
    }
}
