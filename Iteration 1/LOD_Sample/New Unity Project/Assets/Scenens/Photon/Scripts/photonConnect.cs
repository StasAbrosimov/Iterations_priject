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
        OnJointedLobby();
    }
    //private void On
    //{
    //   //PhotonNetwork.JoinLobby(TypedLobby.Default);

    //}

    private void OnJointedLobby()
    {
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
        void DisconnectedFromPhoton();
        void DisconnectingProcessStart();
        void ErrorOccured();
        void ConnectionStart();
    }
}