using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BossAttack_Multi : MonoBehaviour
{

    public Transform AttackPos;
    public GameObject Boss;
    public GameManager1 GM1;
    public SpriteRenderer spr;
    public float moveSpeed;

    public string boss_name;
    public int dmg_atk;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Boss = this.transform.parent.gameObject;
        GM1 = GameObject.Find("GameManager").GetComponent<GameManager1>();
        InitializeMissile();
    }

    // Update is called once per frame
    void Update()
    {
        MissileMove();
    }
    public void InitializeMissile()
    {
        if(Boss.name == "BossSlime_Multi(Clone)")
        {
            moveSpeed = 3f;
            dmg_atk = 3 + (GM1.gameLevel / 10);
            spr.color = UnityEngine.Color.blue;
            AttackPos = GetComponentInParent<SlimeBoss_Multi>().AttackPos;
        } else if(Boss.name == "BossSlime_Enemy(Clone)")
        {
            moveSpeed = 3f;
            dmg_atk = 3 + (GM1.gameLevel / 10);
            spr.color = UnityEngine.Color.blue;
            AttackPos = GetComponentInParent<SlimeBoss_Enemy>().AttackPos;
        } else if (Boss.name == "Manticore_Multi(Clone)")
        {
            moveSpeed = 3f;
            dmg_atk = 5 + (GM1.gameLevel / 10);
            spr.color = UnityEngine.Color.green;
            AttackPos = GetComponentInParent<Manticore_Multi>().AttackPos;
        } else if (Boss.name == "Manticore_Enemy(Clone)")
        {
            moveSpeed = 3f;
            dmg_atk = 5 + (GM1.gameLevel / 10);
            spr.color = UnityEngine.Color.green;
            AttackPos = GetComponentInParent<Manticore_Enemy>().AttackPos;
        }else if (Boss.name == "Wildbore_Multi(Clone)")
        {
            moveSpeed = 3f;
            dmg_atk = 7 + (GM1.gameLevel / 10);
            spr.color = UnityEngine.Color.yellow;
            AttackPos = GetComponentInParent<Wildbore_Multi>().AttackPos;
        } else if (Boss.name == "Wildbore_Enemy(Clone)")
        {
            moveSpeed = 3f;
            dmg_atk = 7 + (GM1.gameLevel / 10);
            spr.color = UnityEngine.Color.yellow;
            AttackPos = GetComponentInParent<Wildbore_Enemy>().AttackPos;
        } else if (Boss.name == "Hellhound_Multi(Clone)")
        {
            moveSpeed = 3f;
            dmg_atk = 7 + (GM1.gameLevel / 10);
            spr.color = UnityEngine.Color.red;
            AttackPos = GetComponentInParent<Hellhound_Multi>().AttackPos;
        } else if (Boss.name == "Hellhound_Enemy(Clone)")
        {
            moveSpeed = 3f;
            dmg_atk = 7 + (GM1.gameLevel / 10);
            spr.color = UnityEngine.Color.red;
            AttackPos = GetComponentInParent<Hellhound_Enemy>().AttackPos;
        }

        this.transform.parent = null;
    }
    public void MissileMove()
    {
        try{
            /*
            if(enemy[enemy_no].transform.position.x < Unit.transform.position.x)
            {
                //spr.flipX = true;
                select_missile.startRotation = Mathf.Atan2(enemy[enemy_no].transform.position.x,Unit.transform.position.x);
            } else if (enemy[enemy_no].transform.position.x > Unit.transform.position.x)
            {
                //spr.flipX = false;
                select_missile.startRotation = Mathf.Atan2(Unit.transform.position.x,enemy[enemy_no].transform.position.x);
            } else
            {

            }
            */
            transform.Translate(new Vector2(AttackPos.position.x - this.transform.position.x, AttackPos.position.y - this.transform.position.y).normalized* moveSpeed * Time.deltaTime);
        }
        catch(NullReferenceException ex){ 
            Destroy(this.gameObject);
        }
        catch(IndexOutOfRangeException ex){ 
            Destroy(this.gameObject);
        }
        catch(MissingReferenceException ex){ 
            Destroy(this.gameObject);
        }
        
    }
    public void destroyMissile()
    {
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Hitbox"))
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
            } else if(other.transform.parent.name == "fairy_multi(Clone)")
            {
                other.GetComponentInParent<fairy_multi>().damaged(dmg_atk);        
            } else if(other.transform.parent.name == "blacksmith_multi(Clone)")
            {
                other.GetComponentInParent<blacksmith_multi>().damaged(dmg_atk);        
            }
            Destroy(this.gameObject);
        } else if(other.CompareTag("Chicken"))
        {
            GM1.p_HP = GM1.p_HP - dmg_atk;
            other.GetComponent<ChikenMove>().showDamage(dmg_atk, "monster");
            Destroy(this.gameObject);
        }
        
    }
}
