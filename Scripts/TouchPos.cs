using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPos : MonoBehaviour
{
    public SpriteRenderer spr;
    public SoundManager SM;

    // Start is called before the first frame update
    void Start()
    {
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        Invoke("DestoryObject",0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DestoryObject()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.name == "Egg(Clone)")
        {
            SM.PlaySE("egg");
            other.GetComponent<Egg>().TouchedObject();
        } else if (other.name == "Trader(Clone)")
        {
            SM.PlaySE("egg");
            other.GetComponent<Trader>().TouchedObject();
        } else if(other.name == "Slime(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Slime>().TouchedObject();
        } else if(other.name == "Bat(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Bat>().TouchedObject();
        } else if(other.name == "Hyena(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Hyena>().TouchedObject();
        } else if(other.name == "Wolf(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Wolf>().TouchedObject();
        } else if(other.name == "BossSlime(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<SlimeBoss>().TouchedObject();
        } else if(other.name == "Manticore(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Manticore>().TouchedObject();
        } else if(other.name == "Redbird(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Redbird>().TouchedObject();
        } else if(other.name == "Yellowbird(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Yellowbird>().TouchedObject();
        } else if(other.name == "Wildbore(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Wildbore>().TouchedObject();
        }  else if(other.name == "Hellhound(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Hellhound>().TouchedObject();
        } else if(other.name == "blackhole(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<blackhole>().TouchedObject();
        } else if(other.name == "blackhole_multi(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<blackhole_multi>().TouchedObject();
        } else if(other.name == "Egg_Multi(Clone)")
        {
            SM.PlaySE("egg");
            other.GetComponent<Egg_Multi>().TouchedObject();
        } else if(other.name == "ItemObj(Clone)")
        {
            SM.PlaySE("egg");
            other.GetComponent<ItemObj>().TouchedObject();
        } else if(other.name == "Slime_Multi(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Slime_Multi>().TouchedObject();
        } else if(other.name == "Slime_Enemy(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Slime_Enemy>().TouchedObject();
        } else if(other.name == "Bat_Multi(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Bat_Multi>().TouchedObject();
        } else if(other.name == "Bat_Enemy(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Bat_Enemy>().TouchedObject();
        } else if(other.name == "Hyena_Multi(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Hyena_Multi>().TouchedObject();
        } else if(other.name == "Hyena_Enemy(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Hyena_Enemy>().TouchedObject();
        } else if(other.name == "Wolf_Multi(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Wolf_Multi>().TouchedObject();
        } else if(other.name == "Wolf_Enemy(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Wolf_Enemy>().TouchedObject();
        } else if(other.name == "BossSlime_Enemy(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<SlimeBoss_Enemy>().TouchedObject();
        } else if(other.name == "BossSlime_Multi(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<SlimeBoss_Multi>().TouchedObject();
        } else if(other.name == "Manticore_Multi(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Manticore_Multi>().TouchedObject();
        } else if(other.name == "Manticore_Enemy(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Manticore_Enemy>().TouchedObject();
        } else if(other.name == "Redbird_Multi(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Redbird_Multi>().TouchedObject();
        } else if(other.name == "Redbird_Enemy(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Redbird_Enemy>().TouchedObject();
        } else if(other.name == "Yellowbird_Multi(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Yellowbird_Multi>().TouchedObject();
        } else if(other.name == "Yellowbird_Enemy(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Yellowbird_Enemy>().TouchedObject();
        } else if(other.name == "Wildbore_Multi(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Wildbore_Multi>().TouchedObject();
        }  else if(other.name == "Wildbore_Enemy(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Wildbore_Enemy>().TouchedObject();
        }  else if(other.name == "Hellhound_Multi(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Hellhound_Multi>().TouchedObject();
        }  else if(other.name == "Hellhound_Enemy(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<Hellhound_Enemy>().TouchedObject();
        } else if(other.name == "blackhole(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<blackhole>().TouchedObject();
        }else if(other.name == "blackhole_multi(Clone)")
        {
            SM.PlaySE("touch");
            other.GetComponent<blackhole_multi>().TouchedObject();
        }
    }

}
