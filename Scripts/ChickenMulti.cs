using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;



public class ChickenMulti : MonoBehaviourPunCallbacks, IPunObservable
{
    public Rigidbody2D RB;
    public Animator AN;
    public SpriteRenderer SR;
    public PhotonView PV;
    public SoundManager SM;
    public GameManagerNetwork GMN;

    public AnimatorOverrideController[] AOCList;
    public string skin_name;

    public GameObject[] chick_pos = new GameObject[3];
    public Transform chicken;
    public GameObject movetxt;

    public float movespeed = 0.001f;

    public int pos_no = 0;
    public int pos_chk = 0;
    public float pos_cool = 6f;
    public float pos_fire = 0;
    public float move_cool = 3f;
    public float move_fire = 0;

    public string User_ID;
    public string NickName;

    public string select_unit_id;
    public string select_unit_name;
    public uint select_unit_value = 0;
    public string select_unit_grade;

    public int goldCnt;
    public int g_unit_cnt;
    public int p_unit_cnt;
    public int[] s_unit_cnt = new int[10];

    public int p_HP;

    public List<string> networksetarmyIDList = new List<string>();
    public List<string> networksetarmyNameList = new List<string>();
    public List<string> networksetarmyGradeList = new List<string>();
    public List<uint> networksetarmyValueList = new List<uint>();
    public List<string> network_all_army_id = new List<string>();
    public List<string> network_all_army_name = new List<string>();
    public List<string> network_all_army_info = new List<string>();
    public List<string> network_all_army_grade = new List<string>();
    public List<uint> network_all_army_value = new List<uint>();

    public Transform slotholder;
    public Slot[] setslot = new Slot[10];
    public Button btn_Call;
    public Button btn_Sell;

    public int player_no;

    public GameObject swordman;
    public GameObject bowman;
    public GameObject preist;
    public GameObject wizard;
    public GameObject socerer;
    public GameObject defender;
    public GameObject fairy;
    public GameObject blacksmith;
    public GameObject Egg;
    public GameObject Store;

    // Start is called before the first frame update
    void Start()
    {
        NickName = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
        User_ID = PV.IsMine ? LoginMenu.User_ID : PV.Owner.NickName;
        GMN = GameObject.Find("GameManagerNetwork").GetComponent<GameManagerNetwork>();
        SM = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        player_no = PV.IsMine ? PhotonNetwork.LocalPlayer.ActorNumber - 1  : PV.Owner.ActorNumber - 1;
        getcamerainfo();
        onSkinChanged();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PV.IsMine)
        {
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
    }

    [PunRPC]
    void getcamerainfo()
    {
        if(PV.IsMine)
        {
            var CM = GameObject.Find("CMCamera").GetComponent<CinemachineVirtualCamera>();
            CM.Follow = this.transform;
            CM.LookAt = this.transform;
        }
    }

    [PunRPC]
    int setPos()
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

    [PunRPC]
    void ChickenMove()
    {
        AN.SetBool("isMove", true);
        AN.SetBool("isPeck",false);
        if(pos_no == 2)
        {
            FlipXRPC(1);
        } else 
        {
            FlipXRPC(-1);
        } 

        transform.Translate(new Vector2((chick_pos[pos_no].transform.position.x - chicken.position.x), (chick_pos[pos_no].transform.position.y - chicken.position.y)).normalized* movespeed * Time.deltaTime);
        move_fire = Time.time + move_cool;
    }

    [PunRPC]
    void ChickenPeck()
    {
        AN.SetBool("isMove",false);
        AN.SetBool("isPeck", true);
    }

    [PunRPC]
    void FlipXRPC(int num) 
    {
        if(num == 1)
        {
            SR.flipX = false;
        }
        else 
        {
            SR.flipX = true;
        }
    }

    public void onSkinChanged()
    {

        skin_name = LobbyManager.skin_name;

        if(skin_name == "default")
        {
            SR.sprite = Resources.Load<Sprite>("Character/Army/Chicken/ChickenIdle_2");
            AN.runtimeAnimatorController = AOCList[0];
        } else if (skin_name == "santa")
        {
            SR.sprite = Resources.Load<Sprite>("Character/Army/Chicken/ChickenIdle_0");
            AN.runtimeAnimatorController = AOCList[1];
        }

    }


    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

}
