using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class photonConnect : MonoBehaviour
{
    public string versionName = "0.1";
    private WeakReference weakRefDelegate;

    public IPhotonConnectDelegate PhotonDelegate
    {
        get
        {
            return weakRefDelegate?.Target as IPhotonConnectDelegate;
        }

        set
        {
            weakRefDelegate = new WeakReference(value);
        }
    }

    private void Start()
    {
        PhotonNetwork.autoJoinLobby = false;
    }

    public void ConnectToPhoton()
    {
        this.PhotonDelegate.ConnectionStart();
        PhotonNetwork.ConnectUsingSettings(versionName);
        Debug.Log("Connecting...");
    }

    public void DisconnectFromPhoton()
    {
        this.PhotonDelegate?.DisconnectingProcessStart();
        PhotonNetwork.Disconnect();
    }

    private void OnConnectedToMaster()
    {
        this.PhotonDelegate?.ConnectedToTheMaster();
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public void CreateOrJoinToRoom(string name)
    {
        this.PhotonDelegate?.OnConnectingToRoom(name);
        if (string.IsNullOrEmpty(name))
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.JoinOrCreateRoom(name, new RoomOptions() { IsOpen = true, IsVisible = true, MaxPlayers = 4 }, TypedLobby.Default);
        }
        
    }

    private void OnJoinedRoom()
    {
        this.PhotonDelegate.OnConnectedToRoom(PhotonNetwork.room?.Name);
    }

    private void OnJoinedLobby()
    {
        this.PhotonDelegate?.OnJoinedToLobby();
        Debug.Log("OnJointedLobby...");
    }

    private void OnDisconnectedFromPhoton()
    {
        this.PhotonDelegate?.DisconnectedFromPhoton();
        Debug.Log("OnDisconnectedFromPhoton");
    }

    private void OnFailedToConnectToPhoton()
    {
        this.PhotonDelegate?.ErrorOccured();
        Debug.Log("OnFailedToConnectToPhoton");
    }

    public interface IPhotonConnectDelegate
    {
        void ConnectedToTheMaster();
        void OnJoinedToLobby();
        void OnConnectingToRoom(string name);
        void OnConnectedToRoom(string name);
        void DisconnectedFromPhoton();
        void DisconnectingProcessStart();
        void ErrorOccured();
        void ConnectionStart();
    }
}