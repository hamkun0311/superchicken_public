using System.Dynamic;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManagerNetwork : MonoBehaviourPunCallbacks
{

    public int playerCnt;
    public GameManager1 GM;

    void Awake()
    {
        PhotonNetwork.Instantiate("PlayerInfo",Vector3.zero,Quaternion.identity);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        playerCnt = PhotonNetwork.CurrentRoom.PlayerCount;
        GM.gameRank = playerCnt;
        print(PhotonNetwork.LocalPlayer.ActorNumber);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        GM.playerChk = false;
        GM.gameRank = PhotonNetwork.CurrentRoom.PlayerCount;
        playerCnt = PhotonNetwork.CurrentRoom.PlayerCount;
    }


    


}
