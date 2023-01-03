using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Robot_Multi : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject Unit;
    public GameManager1 GM;
    public Transform AttackPos;
    public float moveSpeed = 2f;
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

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager1>();
        Unit = this.transform.parent.gameObject;
        InitializeRobot();
        Invoke("destroyRobot", item_time);
    }

    // Update is called once per frame
    void Update()
    {
        robotMove();
    }

    public void InitializeRobot()
    {
        if (Unit.name == "blacksmith_multi(Clone)")
        {
            
            unit_name = GetComponentInParent<blacksmith_multi>().iteminfo.item_name;      
            unit_grade = GetComponentInParent<blacksmith_multi>().iteminfo.item_grade;  

            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            enemy_no = UnityEngine.Random.Range(0,enemy.Length);
            AttackPos = enemy[enemy_no].gameObject.transform;

            item_time = 5f;
            moveSpeed = 2f;
            item_type = "robot";

            if(unit_name == "대장장이_BlackSmith")
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
            }

        } 
        dmg_atk = dmg_atk + (( dmg_atk * 10 / 100 * GM.fairyDCnt) + (dmg_atk * 20 / 100 * GM.fairyCCnt) + (dmg_atk * 30 / 100 * GM.fairyBCnt) + (dmg_atk * 40 / 100 * GM.fairyACnt) + (dmg_atk * 50 / 100 * GM.fairySCnt) );
    }

    public void robotMove()
    {
        try{

            transform.Translate(new Vector3(AttackPos.position.x - this.transform.position.x, AttackPos.position.y - this.transform.position.y,0 ).normalized * moveSpeed * Time.deltaTime);
   
        }
        catch(NullReferenceException ex){ 
                enemy = GameObject.FindGameObjectsWithTag("Enemy");
                enemy_no = UnityEngine.Random.Range(0,enemy.Length);
                if(enemy_no ==0)
                {
                    Destroy(this.gameObject);
                }
                AttackPos = enemy[enemy_no].gameObject.transform;
            }
        catch(IndexOutOfRangeException ex){ 
                enemy = GameObject.FindGameObjectsWithTag("Enemy");
                enemy_no = UnityEngine.Random.Range(0,enemy.Length);
                if(enemy_no ==0)
                {
                    Destroy(this.gameObject);
                }
                AttackPos = enemy[enemy_no].gameObject.transform;
        }
        catch(MissingReferenceException ex){ 
                enemy = GameObject.FindGameObjectsWithTag("Enemy");
                enemy_no = UnityEngine.Random.Range(0,enemy.Length);
                if(enemy_no ==0)
                {
                    Destroy(this.gameObject);
                }
                AttackPos = enemy[enemy_no].gameObject.transform;
        }
        catch(UnassignedReferenceException ex){ 
                InitializeRobot();
        }
    }

    public void destroyRobot()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            if(item_type == "robot")
            {
                if(other.name == "Slime_Multi(Clone)")
                {
                    other.GetComponent<Slime_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Bat_Multi(Clone)")
                {
                    other.GetComponent<Bat_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "BossSlime_Multi(Clone)")
                {
                    other.GetComponent<SlimeBoss_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Hyena_Multi(Clone)")
                {
                    other.GetComponent<Hyena_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Wolf_Multi(Clone)")
                {
                    other.GetComponent<Wolf_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Manticore_Multi(Clone)")
                {
                    other.GetComponent<Manticore_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Redbird_Multi(Clone)")
                {
                    other.GetComponent<Redbird_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Yellowbird_Multi(Clone)")
                {
                    other.GetComponent<Yellowbird_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Wildbore_Multi(Clone)")
                {
                    other.GetComponent<Wildbore_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Hellhound_Multi(Clone)")
                {
                    other.GetComponent<Hellhound_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Slime_Enemy(Clone)")
                {
                    other.GetComponent<Slime_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Bat_Enemy(Clone)")
                {
                    other.GetComponent<Bat_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "BossSlime_Enemy(Clone)")
                {
                    other.GetComponent<SlimeBoss_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Hyena_Enemy(Clone)")
                {
                    other.GetComponent<Hyena_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Wolf_Enemy(Clone)")
                {
                    other.GetComponent<Wolf_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Manticore_Enemy(Clone)")
                {
                    other.GetComponent<Manticore_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Redbird_Enemy(Clone)")
                {
                    other.GetComponent<Redbird_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Yellowbird_Enemy(Clone)")
                {
                    other.GetComponent<Yellowbird_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Wildbore_Enemy(Clone)")
                {
                    other.GetComponent<Wildbore_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(other.name == "Hellhound_Enemy(Clone)")
                {
                    other.GetComponent<Hellhound_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } 
            
        }

        
    }
}
