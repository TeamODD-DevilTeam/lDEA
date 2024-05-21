using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks {
    [SerializeField] GameObject playerA, playerB;

    public static NetworkManager instance;
    bool connected = false;
    string gameVersion = "1.0";
    string roomName = "";

    void Start() {
        if (instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;
        } else {
            Destroy(this);
        }
        Connect();
    }

    public void Connect() {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        connected = true;
    }

    public void CreateRoom(TMP_InputField inputField) {
        if (!connected) return;
        if (PhotonNetwork.InRoom) {
            Debug.Log("InRoom at " + PhotonNetwork.CurrentRoom.Name);
        } else {
            roomName = GenerateRoomName();
            PhotonNetwork.CreateRoom(roomName, new RoomOptions{ MaxPlayers = 2 });
            inputField.text = roomName;
        }
    }

    public void JoinRoom(TMP_InputField inputField) {
        if (PhotonNetwork.InRoom) PhotonNetwork.LeaveRoom();
        PhotonNetwork.JoinRoom(inputField.text);
    }

    public override void OnCreatedRoom() {
        Debug.Log("Room Created.");
    }
    
    public override void OnJoinedRoom() {
        Debug.Log("Room Joined.");
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer) {
        newPlayer.NickName = "beta";
        Debug.Log("새로운 플레이어가 입장하였습니다.");
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList) {
            Debug.Log("플레이어명: " + player.NickName);
        }
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer) {
        Debug.Log("플레이어가 퇴장하였습니다.");
    }

    public void CreatePlayer() {
        if (!PhotonNetwork.IsMasterClient) 
            PhotonNetwork.Instantiate(playerB.name, Vector3.zero, Quaternion.identity);
        else
            PhotonNetwork.Instantiate(playerA.name, Vector3.zero, Quaternion.identity);
    }


    const string chars = "0123456789abcdefghijklmnopqrstuvwxyz" ;

    string GenerateRoomName() {
        var sb = new System.Text.StringBuilder(4);
        var r = new System.Random ();

        for (int i = 0 ; i < 4; i++) {
            int pos = r.Next (chars.Length);
            char c = chars[pos];
            sb.Append(c);
        }

        return sb.ToString();
    }
}
