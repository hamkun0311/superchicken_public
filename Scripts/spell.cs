using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class spell : MonoBehaviour
{
    public GameObject Unit;
    public GameObject[] enemy;
    public GameManager GM;
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
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        if(Unit.name == "preist(Clone)")
        {
            unit_name = GetComponentInParent<preist>().iteminfo.item_name;      
            unit_grade = GetComponentInParent<preist>().iteminfo.item_grade;  
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

        } else if (Unit.name == "wizard(Clone)")
        {
            unit_name = GetComponentInParent<wizard>().iteminfo.item_name;      
            unit_grade = GetComponentInParent<wizard>().iteminfo.item_grade;  
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
        } else if (Unit.name == "Missile(Clone)")
        {
            unit_name = GetComponentInParent<Missile>().unit_name;      
            unit_grade = GetComponentInParent<Missile>().unit_grade;  
            enemy_no = GetComponentInParent<Missile>().enemy_no;  
            enemy = GetComponentInParent<Missile>().enemy;
            item_type = GetComponentInParent<Missile>().item_type;
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
        } else if(Unit.name == "blackhole(Clone)")
        {
            unit_name = GetComponentInParent<blackhole>().unit_name;    
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
                if(other.name == "preist(Clone)")
                {
                    other.GetComponent<preist>().healUnit(dmg_atk);
                } else if (other.name == "bowman(Clone)")
                {
                    other.GetComponent<bowman>().healUnit(dmg_atk);
                } else if (other.name == "fswordI(Clone)")
                {
                    other.GetComponent<fswordI>().healUnit(dmg_atk);
                } else if (other.name == "socerer(Clone)")
                {
                    other.GetComponent<socerer>().healUnit(dmg_atk);
                } else if (other.name == "guard(Clone)")
                {
                    other.GetComponent<guard>().healUnit(dmg_atk);
                } else if (other.name == "wizard(Clone)")
                {
                    other.GetComponent<wizard>().healUnit(dmg_atk);
                } else if (other.name == "fairy(Clone)")
                {
                    other.GetComponent<fairy>().healUnit(dmg_atk);
                } else if (other.name == "blacksmith(Clone)")
                {
                    other.GetComponent<blacksmith>().healUnit(dmg_atk);
                }
            }   

            //Destroy(this.gameObject);

        } else if(other.CompareTag("Enemy"))
        {
            if(other.name == "Slime(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Slime>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Slime>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } 
                
            } else if(other.name == "Bat(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Bat>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Bat>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } 
                
            } else if(other.name == "BossSlime(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<SlimeBoss>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<SlimeBoss>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Hyena(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Hyena>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Hyena>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Wolf(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Wolf>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Wolf>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Manticore(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Manticore>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Manticore>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Redbird(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Redbird>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Redbird>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Yellowbird(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Yellowbird>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Yellowbird>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            }else if(other.name == "Wildbore(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Wildbore>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Wildbore>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }
                
            } else if(other.name == "Hellhound(Clone)")
            {
                if(item_type == "book")
                {
                    other.GetComponent<Hellhound>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                } else if(item_type == "staff")
                {
                    other.GetComponent<Hellhound>().Damaged(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                }                
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
                if(other.name == "Slime(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Slime>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Bat(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Bat>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    }
                } else if(other.name == "BossSlime(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<SlimeBoss>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Hyena(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Hyena>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Wolf(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Wolf>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    }
                    
                } else if(other.name == "Manticore(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Manticore>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    }
                    
                } else if(other.name == "Redbird(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Redbird>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Yellowbird(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Yellowbird>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Wildbore(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Wildbore>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
                    } 
                    
                } else if(other.name == "Hellhound(Clone)")
                {
                    if(item_type == "blackhole")
                    {
                        other.GetComponent<Hellhound>().DamagedSpell(dmg_atk, dmg_skill, skill_type, skill_time,item_type);
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

