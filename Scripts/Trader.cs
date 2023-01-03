using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
    public SpriteRenderer spr;
    public GameManager GM;
    public SoundManager SM;
    public float moveSpeed = 1f;

    public Transform TraderPos1;
    public Transform TraderPos2;

    // Start is called before the first frame update
    void Start()
    {

        spr = this.gameObject.GetComponent<SpriteRenderer>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        TraderPos1 = GameObject.Find("TraderPos1").GetComponent<Transform>();
        TraderPos2 = GameObject.Find("TraderPos2").GetComponent<Transform>();
        SM.PlaySE("store");
        Destroy(this.gameObject,10f);
    }

    // Update is called once per frame
    void Update()
    {
        TraderMove();
    }

    public void TraderMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, TraderPos2.position, moveSpeed * Time.deltaTime);
        spr.flipX = true;
    }
    public void TouchedObject()
    {
        Destroy(this.gameObject);
        GM.onClickShopBtn();
    }

}

