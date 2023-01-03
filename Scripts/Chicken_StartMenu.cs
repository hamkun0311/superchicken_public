using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_StartMenu : MonoBehaviour
{
    public SpriteRenderer spr;
    public GameObject[] chick_pos = new GameObject[2];
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
    public bool pos_chk = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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

        onSkinChanged();


    }

    public int setPos()
    {
        pos_chk = !pos_chk;

        if(pos_chk == false)
        {
            pos_no = 0;
        } else
        {
            pos_no = 1 ;
        }

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
