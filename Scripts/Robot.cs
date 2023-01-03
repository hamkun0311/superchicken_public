using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Robot : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject Unit;
    public GameManager GM;
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
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        if (Unit.name == "blacksmith(Clone)")
        {
            
            unit_name = GetComponentInParent<blacksmith>().iteminfo.item_name;      
            unit_grade = GetComponentInParent<blacksmith>().iteminfo.item_grade;  

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
                
            } 
            
        }

        
    }
}
