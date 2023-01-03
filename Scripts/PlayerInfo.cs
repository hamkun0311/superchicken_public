using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerInfo : MonoBehaviourPunCallbacks, IPunObservable
{
    public int p_hp = 50;
    public int p_egg;
    public int p_gold = 3000;
    public int p_ruby;
    public PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(p_hp);
            stream.SendNext(p_gold);
        } else
        {
            this.p_hp = (int)stream.ReceiveNext();
            this.p_gold = (int)stream.ReceiveNext();
        }
    }

}
