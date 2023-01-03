using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public LobbyManager LM;
    public string playerCnt;
    public Text totalUser;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Disconnect();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void UpdatePlayerCounts()
    {
        LM.txt_matchmember.text = $"{PhotonNetwork.CurrentRoom.PlayerCount} / {PhotonNetwork.CurrentRoom.MaxPlayers}";
        for(int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
        {
            LM.txt_matchmember.text = LM.txt_matchmember.text + "\n"
                                    + PhotonNetwork.PlayerList[i].NickName;
        }

        int etimeNum = PhotonNetwork.CountOfPlayers;
        print(etimeNum);
        if(etimeNum < 3)
        {
            totalUser.text = "Waiting : 30min";
        } else if(etimeNum >= 3 && etimeNum < 20 )
        {
            if(etimeNum % 3 == 0)
            {
                totalUser.text = "Waiting : 5min";
            } else if(etimeNum % 3 == 1)
            {
                totalUser.text = "Waiting : 3min";
            } else if(etimeNum % 3 == 2)
            {
                totalUser.text = "Waiting : 1min";
            }
        } else if (etimeNum >= 20)
        {
            if(etimeNum % 3 == 0)
            {
                totalUser.text = "Waiting : 30sec";
            } else if(etimeNum % 3 == 1)
            {
                totalUser.text = "Waiting : 20sec";
            } else if(etimeNum % 3 == 2)
            {
                totalUser.text = "Waiting : 10sec";
            }
        }

        if (PhotonNetwork.IsMasterClient)
        {
            LM.btn_ready.gameObject.SetActive(true);
            // 목표 인원 수 채웠으면, 맵 이동을 한다. 권한은 마스터 클라이언트만.
            // PhotonNetwork.AutomaticallySyncScene = true; 를 해줬어야 방에 접속한 인원이 모두 이동함.
            if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
            {
                LM.btn_ready.interactable = true;
            } else 
            {
                LM.btn_ready.interactable = false;
            }
        }

    }

    public void InitializePhoton()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        LM.btn_ready.gameObject.SetActive(false);
        LM.networkChk = true;
        Connect();
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("서버접속완료");
        JoinLobby();
    }

    public void JoinLobby()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        print("로비접속완료");
        JoinOrCreatRoom();
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
        LM.networkChk = false;
    }

    public void JoinOrCreatRoom()
    {
        PhotonNetwork.LocalPlayer.NickName = LM.User_NickNM;
        byte maxPlayers = 5;
        int maxTime = 3600;

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayers; // 인원 지정.
        roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { "maxTime", maxTime } }; // 게임 시간 지정.
        roomOptions.CustomRoomPropertiesForLobby = new string[] { "maxTime" }; // 여기에 키 값을 등록해야, 필터링이 가능하다.

        // 방 참가를 시도하고, 실패하면 생성해서 참가함.
        PhotonNetwork.JoinRandomOrCreateRoom(
            expectedCustomRoomProperties: new ExitGames.Client.Photon.Hashtable() { { "maxTime", maxTime } }, expectedMaxPlayers: maxPlayers, // 참가할 때의 기준.
            roomOptions: roomOptions // 생성할 때의 기준.
        );

        
    }
    public override void OnJoinedRoom()
    {
        print("방 참가 완료.");

        Debug.Log($"{PhotonNetwork.LocalPlayer.NickName}은 인원수 {PhotonNetwork.CurrentRoom.MaxPlayers} 매칭 기다리는 중.");
        UpdatePlayerCounts();

    }
   
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"플레이어 {newPlayer.NickName} 방 참가.");
        UpdatePlayerCounts();
    }

    public void onClickGameStartBtn()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.LoadLevel("MultiPlayScene");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"플레이어 {otherPlayer.NickName} 방 나감.");
        UpdatePlayerCounts();
        
    }
    

}
