using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestConnect : MonoBehaviourPunCallbacks
{
    void Start()
    {
        print($"Connecting to Server");
        PhotonNetwork.GameVersion = Application.version;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print($"Connected to server");

        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print($"Disconnected: {cause}");
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CreateRoom();
        }
    }


    public void CreateRoom()
    {
        print($"Try to create room");

        if (!PhotonNetwork.IsConnected)
        {
            print($"Photon network not connected");
            return;
        }
            
        
        var roomOptions = new RoomOptions
        {
            MaxPlayers = 2,
            EmptyRoomTtl = 60000
        };

        PhotonNetwork.JoinOrCreateRoom($"basic_{Random.Range(0, 10000)}", roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        print($"Room created");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print($"Room creation failed: {message}");
    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        print($"Rooms list updated ({roomList.Count}):");

        foreach (var roomInfo in roomList)
        {
            string status = roomInfo.RemovedFromList ? "deleted" : "created";
            print($"{roomInfo.Name} - {status}");
        }
    }
}
