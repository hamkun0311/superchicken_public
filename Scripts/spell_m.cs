using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell_m : MonoBehaviour
{
    public GameObject Unit;
    public GameObject[] enemy;
    public GameManager1 GM;
    public int enemy_no;

    public string unit_name;
    public string unit_grade;
    public int dmg_atk;
    public int dmg_skill;
    public float skill_time;
    public string skill_type;
    public string item_type;
    public float item_time;
    public float blackhole_cool = 0.1f;
    public float blackhole_fire = 0f;

    public ParticleSystem f_spell;
    public ParticleSystem i_spell;
    public ParticleSystem s_spell;
    public ParticleSystem t_spell;
    public ParticleSystem blackhole;
    public CircleCollider2D cc;
    


    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager1>();
        Unit = this.transform.parent.gameObject;
        InitializeSpell();
        Invoke("destroySpell", item_time);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = new Vector2(-this.transform.position.x,-this.transform.position.y);
    }
    public void InitializeSpell()
    {
        f_spell.Stop();
        i_spell.Stop();
        s_spell.Stop();
        t_spell.Stop();
        blackhole.Stop();
        if(Unit.name == "preist_multi(Clone)")
        {
            unit_name = GetComponentInParent<preist_multi>().iteminfo.item_name;      
            unit_grade = GetComponentInParent<preist_multi>().iteminfo.item_grade;  
            item_time = 0.2f;
            cc.radius = 500f;
            item_type = "preist";
            if(unit_name == "프리스트_Preist")
            {
                if(unit_grade == "D")
                {
                    dmg_atk = 1;
                    dmg_skill = 0;
                    skill_time = 0;
                } else if (unit_grade == "C")
                {
                    dmg_atk = 2;
                    dmg_skill = 0;
                    skill_time = 0;
                } else if (unit_grade == "B")
                {
                    dmg_atk = 3;
                    dmg_skill = 0;
                    skill_time = 0;
                } else if (unit_grade == "A")
                {
                    dmg_atk = 4;
                    dmg_skill = 0;
                    skill_time = 0;
                } else 
                {
                    dmg_atk = 5;
                    dmg_skill = 0;
                    skill_time = 0;
                }

    
            } 

        } else if (Unit.name == "wizard_multi(Clone)")
        {
            unit_name = GetComponentInParent<wizard_multi>().iteminfo.item_name;      
            unit_grade = GetComponentInParent<wizard_multi>().iteminfo.item_grade;  
            item_time = 0.2f;
            item_type = "staff";
            cc.radius = 500f;
            if(unit_name == "파이어위자드_FireWizard")
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
            } else if(unit_name == "아이스위자드_IceWizard")
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
            } else if(unit_name == "스톤위자드_StoneWizard")
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
            } else if(unit_name == "썬더위자드_ThunderWizard")
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
        } else if (Unit.name == "Missile_m(Clone)")
        {
            unit_name = GetComponentInParent<Missile_m>().unit_name;      
            unit_grade = GetComponentInParent<Missile_m>().unit_grade;  
            enemy_no = GetComponentInParent<Missile_m>().enemy_no;  
            enemy = GetComponentInParent<Missile_m>().enemy;
            item_type = GetComponentInParent<Missile_m>().item_type;
            item_time = 0.5f;
            cc.radius = 50f;
            
            if(unit_name == "파이어소서러_FireSocerer")
            {
                skill_type = "fire";
                f_spell.Play();
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
            } else if(unit_name == "아이스소서러_IceSocerer")
            {
                skill_type = "ice";
                i_spell.Play();
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
            } else if(unit_name == "스톤소서러_StoneSocerer")
            {
                skill_type = "stone";
                s_spell.Play();
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
            } else if(unit_name == "썬더소서러_ThunderSocerer")
            {
                skill_type = "thunder";
                t_spell.Play();
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
        } else if(Unit.name == "blackhole_multi(Clone)")
        {
            unit_name = GetComponentInParent<blackhole_multi>().unit_name;    
            item_type = "blackhole";
            dmg_atk = 30;
            cc.radius = 500f;
            item_time = 3f;
            blackhole.Play();
            
        }
        this.transform.parent = null;
        dmg_atk = dmg_atk + (( dmg_atk * 10 / 100 * GM.fairyDCnt) + (dmg_atk * 20 / 100 * GM.fairyCCnt) + (dmg_atk * 30 / 100 * GM.fairyBCnt) + (dmg_atk * 40 / 100 * GM.fairyACnt) + (dmg_atk * 50 / 100 * GM.fairySCnt) );
    }

    public void destroySpell()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Unit"))
        {
            if(item_type == "preist")
            {
                if(other.name == "preist_multi(Clone)")
                {
                    other.GetComponent<preist_multi>().healUnit(dmg_atk);
                } else if (other.name == "bowman_multi(Clone)")
                {
                    other.GetComponent<bowman_multi>().healUnit(dmg_atk);
                } else if (other.name == "swordman_multi(Clone)")
                {
                    other.GetComponent<swordman_multi>().healUnit(dmg_atk);
                } else if (other.name == "socerer_multi(Clone)")
                {
                    other.GetComponent<socerer_multi>().healUnit(dmg_atk);
                } else if (other.name == "guard_multi(Clone)")
                {
                    other.GetComponent<guard_multi>().healUnit(dmg_atk);
                } else if (other.name == "wizard_multi(Clone)")
                {
                    other.GetComponent<wizard_multi>().healUnit(dmg_atk);
                } else if (other.name == "fairy_multi(Clone)")
                {
                    other.GetComponent<fairy_multi>().healUnit(dmg_atk);
                } else if (other.name == "blacksmith_multi(Clone)")
                {
                    other.GetComponent<blacksmith_multi>().healUnit(dmg_atk);
                }
            }   

            //Destroy(this.gameObject);

        } else if(other.CompareTag("Enemy"))
        {
            if(other.name == "Slime_Multi(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Slime_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Slime_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } 
                
            } else if(other.name == "Slime_Enemy(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Slime_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Slime_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } 
                
            } else if(other.name == "Bat_Multi(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Bat_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Bat_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } 
                
            } else if(other.name == "Bat_Enemy(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Bat_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Bat_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } 
                
            } else if(other.name == "BossSlime_Multi(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<SlimeBoss_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<SlimeBoss_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "BossSlime_Enemy(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<SlimeBoss_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<SlimeBoss_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Hyena_Multi(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Hyena_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Hyena_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Hyena_Enemy(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Hyena_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Hyena_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Wolf_Enemy(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Wolf_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Wolf_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Wolf_Multi(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Wolf_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Wolf_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Manticore_Multi(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Manticore_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Manticore_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Manticore_Enemy(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Manticore_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Manticore_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Redbird_Multi(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Redbird_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Redbird_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Redbird_Enemy(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Redbird_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Redbird_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Yellowbird_Multi(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Yellowbird_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Yellowbird_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            }else if(other.name == "Yellowbird_Enemy(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Yellowbird_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Yellowbird_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            }else if(other.name == "Wildbore_Multi(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Wildbore_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Wildbore_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Wildbore_Enemy(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Wildbore_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Wildbore_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Hellhound_Multi(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Hellhound_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Hellhound_Multi>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }                
            } else if(other.name == "Hellhound_Enemy(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Hellhound_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Hellhound_Enemy>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }                
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
                if(other.name == "Slime_Multi(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Slime_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Slime_Enemy(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Slime_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                }else if(other.name == "Bat_Multi(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Bat_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    }
                } else if(other.name == "Bat_Enemy(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Bat_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    }
                } else if(other.name == "BossSlime_Multi(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<SlimeBoss_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "BossSlime_Enemy(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<SlimeBoss_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Hyena_Multi(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Hyena_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Hyena_Enemy(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Hyena_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Wolf_Multi(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Wolf_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    }
                    
                } else if(other.name == "Wolf_Enemy(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Wolf_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    }
                    
                } else if(other.name == "Manticore_Multi(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Manticore_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    }
                    
                } else if(other.name == "Manticore_Enemy(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Manticore_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    }
                    
                } else if(other.name == "Redbird_Multi(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Redbird_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Redbird_Enemy(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Redbird_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Yellowbird_Multi(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Yellowbird_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Yellowbird_Enemy(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Yellowbird_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Wildbore_Multi(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Wildbore_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Wildbore_Enemy(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Wildbore_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Hellhound_Multi(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Hellhound_Multi>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Hellhound_Enemy(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Hellhound_Enemy>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                }
        }
    }

    /*
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            if(other.name == "Slime(Clone)")
            {
                if(item_type == "book")
                {
                    if(other.GetComponent<Slime>().spellfire > Time.time)
                    {
                        other.GetComponent<Slime>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    }
                } 
                
            } else if(other.name == "Bat(Clone)")
            {
                if(item_type == "book")
                {
                    if(other.GetComponent<Bat>().spellfire > Time.time)
                    {
                        other.GetComponent<Bat>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    }
                } 
                
            } else if(other.name == "BossSlime(Clone)")
            {
                if(item_type == "book")
                {
                    if(other.GetComponent<SlimeBoss>().spellfire > Time.time)
                    {
                        other.GetComponent<SlimeBoss>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
               
                    }
                } 
            } else if(other.name == "Hyena(Clone)")
            {
                if(item_type == "book")
                {
                    if(other.GetComponent<Hyena>().spellfire > Time.time)
                    {
                        other.GetComponent<Hyena>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
               
                    }
                } 
            } else if(other.name == "Wolf(Clone)")
            {
                if(item_type == "book")
                {
                    if(other.GetComponent<Wolf>().spellfire > Time.time)
                    {
                        other.GetComponent<Wolf>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
               
                    }
                } 
             } else if(other.name == "Manticore(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Manticore>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
            } else if(other.name == "Redbird(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Redbird>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
            } else if(other.name == "Yellowbird(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Yellowbird>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
            } else if(other.name == "Wildbore(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Wildbore>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
            } else if(other.name == "Hellhound(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Hellhound>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
            }

        }
    }

    */
        
        
}
