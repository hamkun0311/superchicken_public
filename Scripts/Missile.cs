using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Missile : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject Unit;
    public GameObject spell;
    public GameManager GM;
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
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        if(Unit.name == "fswordI(Clone)")
        {
            select_missile = slash;
            select_missile.Play();
            unit_name = GetComponentInParent<fswordI>().iteminfo.item_name;      
            unit_grade = GetComponentInParent<fswordI>().iteminfo.item_grade;  
            enemy = GetComponentInParent<fswordI>().enemy;  
            enemy_no = GetComponentInParent<fswordI>().enemy_no;
            AttackPos = GetComponentInParent<fswordI>().AttackPos;
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

        } else if (Unit.name == "bowman(Clone)")
        {
            
            unit_name = GetComponentInParent<bowman>().iteminfo.item_name;      
            unit_grade = GetComponentInParent<bowman>().iteminfo.item_grade;  

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

        } else if(Unit.name == "socerer(Clone)")
        {
            unit_name = GetComponentInParent<socerer>().iteminfo.item_name;      
            unit_grade = GetComponentInParent<socerer>().iteminfo.item_grade;  

            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            enemy_no = UnityEngine.Random.Range(0,enemy.Length);

            AttackPos = enemy[enemy_no].gameObject.transform;

            item_time = 1f;
            moveSpeed = 2f;
            item_type = "book";

            spr.sprite = Resources.Load<Sprite>("item/" + "Acid");

        }

        dmg_atk = dmg_atk + (( dmg_atk * 10 / 100 * GM.fairyDCnt) + (dmg_atk * 20 / 100 * GM.fairyCCnt) + (dmg_atk * 30 / 100 * GM.fairyBCnt) + (dmg_atk * 40 / 100 * GM.fairyACnt) + (dmg_atk * 50 / 100 * GM.fairySCnt) );
        
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
                if(other.name == "Slime(Clone)")
                {
                    other.GetComponent<Slime>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Bat(Clone)")
                {
                    other.GetComponent<Bat>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "BossSlime(Clone)")
                {
                    other.GetComponent<SlimeBoss>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Hyena(Clone)")
                {
                    other.GetComponent<Hyena>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Wolf(Clone)")
                {
                    other.GetComponent<Wolf>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Manticore(Clone)")
                {
                    other.GetComponent<Manticore>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Redbird(Clone)")
                {
                    other.GetComponent<Redbird>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Yellowbird(Clone)")
                {
                    other.GetComponent<Yellowbird>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Wildbore(Clone)")
                {
                    other.GetComponent<Wildbore>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Hellhound(Clone)")
                {
                    other.GetComponent<Hellhound>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
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
