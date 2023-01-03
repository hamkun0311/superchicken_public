using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossAttack : MonoBehaviour
{
    public Transform AttackPos;
    public GameObject Boss;
    public GameManager GM;
    public SpriteRenderer spr;
    public float moveSpeed;

    public string boss_name;
    public int dmg_atk;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Boss = this.transform.parent.gameObject;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        InitializeMissile();
    }

    // Update is called once per frame
    void Update()
    {
        MissileMove();
    }
    public void InitializeMissile()
    {
        if(Boss.name == "BossSlime(Clone)")
        {
            moveSpeed = 3f;
            dmg_atk = 3 + (GM.gameLevel / 10);
            spr.color = UnityEngine.Color.blue;
            AttackPos = GetComponentInParent<SlimeBoss>().AttackPos;
        } else if (Boss.name == "Manticore(Clone)")
        {
            moveSpeed = 3f;
            dmg_atk = 5 + (GM.gameLevel / 10);
            spr.color = UnityEngine.Color.green;
            AttackPos = GetComponentInParent<Manticore>().AttackPos;
        }else if (Boss.name == "Wildbore(Clone)")
        {
            moveSpeed = 3f;
            dmg_atk = 7 + (GM.gameLevel / 10);
            spr.color = UnityEngine.Color.yellow;
            AttackPos = GetComponentInParent<Wildbore>().AttackPos;
        } else if (Boss.name == "Hellhound(Clone)")
        {
            moveSpeed = 3f;
            dmg_atk = 7 + (GM.gameLevel / 10);
            spr.color = UnityEngine.Color.red;
            AttackPos = GetComponentInParent<Hellhound>().AttackPos;
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
            if(other.transform.parent.name == "fswordI(Clone)")
            {
                other.GetComponentInParent<fswordI>().damaged(dmg_atk);        
            } else if(other.transform.parent.name == "bowman(Clone)")
            {
                other.GetComponentInParent<bowman>().damaged(dmg_atk);        
            } else if(other.transform.parent.name == "preist(Clone)")
            {
                other.GetComponentInParent<preist>().damaged(dmg_atk);        
            } else if(other.transform.parent.name == "socerer(Clone)")
            {
                other.GetComponentInParent<socerer>().damaged(dmg_atk);        
            } else if(other.transform.parent.name == "wizard(Clone)")
            {
                other.GetComponentInParent<wizard>().damaged(dmg_atk);        
            }
            else if(other.transform.parent.name == "guard(Clone)")
            {
                other.GetComponentInParent<guard>().damaged(dmg_atk);        
            } else if(other.transform.parent.name == "fairy(Clone)")
            {
                other.GetComponentInParent<fairy>().damaged(dmg_atk);        
            } else if(other.transform.parent.name == "blacksmith(Clone)")
            {
                other.GetComponentInParent<blacksmith>().damaged(dmg_atk);        
            }
            Destroy(this.gameObject);
        } else if(other.CompareTag("Chicken"))
        {
            GM.p_HP = GM.p_HP - dmg_atk;
            other.GetComponent<ChikenMove>().showDamage(dmg_atk, "monster");
            Destroy(this.gameObject);
        }
        
    }
}
