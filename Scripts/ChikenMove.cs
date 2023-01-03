using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChikenMove : MonoBehaviour
{
    public SpriteRenderer spr;
    public GameObject[] chick_pos = new GameObject[3];
    public Transform chicken;
    public float movespeed = 1f;
    Animator anim;

    public AnimatorOverrideController[] AOCList;
    public string skin_name;

    public float pos_cool = 6f;
    public float pos_fire = 0;
    public float move_cool = 3f;
    public float move_fire = 0;

    public float showTime;

    public int pos_no = 0;
    public int pos_chk = 0;
    public GameObject movetxt;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(8,9);
        onSkinChanged();

    }

    // Update is called once per frame
    void Update()
    {
        showTime = Time.time;

        if(Time.time > pos_fire)
        {
            setPos();
            pos_fire = Time.time + pos_cool;
        }

        if(pos_fire < move_fire)
        {
            ChickenPeck();
        } else
        {
            ChickenMove();
        }
    }

    public int setPos()
    {
        pos_chk = pos_chk % 3;

        if(pos_chk == 0)
        {
            pos_no = 0;
        } else if(pos_chk == 1)
        {
            pos_no = 1 ;
        } else 
        {
            pos_no = 2;
        }

        pos_chk++;
        return pos_no;
    }

    public void ChickenMove()
    {
        anim.SetBool("isMove", true);
        anim.SetBool("isPeck",false);
        if(chick_pos[pos_no].transform.position.x < chicken.position.x)
        {
            spr.flipX = true;
        } else if (chick_pos[pos_no].transform.position.x > chicken.position.x)
        {
            spr.flipX = false;
        } 

        transform.Translate(new Vector2((chick_pos[pos_no].transform.position.x - chicken.position.x), (chick_pos[pos_no].transform.position.y - chicken.position.y)).normalized* movespeed * Time.deltaTime);
        move_fire = Time.time + move_cool;
    }
    public void ChickenPeck()
    {
        anim.SetBool("isMove",false);
        anim.SetBool("isPeck", true);
        
    }

    public void showDamage(int damage, string skill_type)
    {

        TextMeshPro dmgtxt = movetxt.GetComponent<TextMeshPro>();

        if(skill_type == "monster")
        {
            dmgtxt.color = new Color32(255,90,60,255);
        } else if( skill_type == "heal")
        {
            dmgtxt.color = new Color32(150,255,150,255);
        }
        
        dmgtxt.GetComponent<TextMeshPro>().text = damage.ToString();
        Instantiate(dmgtxt, this.transform.position, Quaternion.identity);
        dmgtxt.transform.position = transform.position;
        
    }

    public void onSkinChanged()
    {

        skin_name = LobbyManager.skin_name;

        if(skin_name == "default")
        {
            spr.sprite = Resources.Load<Sprite>("Character/Army/Chicken/ChickenIdle_2");
            anim.runtimeAnimatorController = AOCList[0];
        } else if (skin_name == "santa")
        {
            spr.sprite = Resources.Load<Sprite>("Character/Army/Chicken/ChickenIdle_0");
            anim.runtimeAnimatorController = AOCList[1];
        }

    }

}
