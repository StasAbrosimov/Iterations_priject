using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    public Button ConnectButton;
    public Button DisConnectButton;
    public Text informationText;
    public GameObject LobbyPanel;
    public Text LobbyName;

    private string lastRoomName = "";

    private WeakReference weakRefDelegate;

    public IUIControllerDelegate UIControllerDelegate
    {
        get
        {
            return weakRefDelegate?.Target as IUIControllerDelegate;
        }

        set
        {
            weakRefDelegate = new WeakReference(value);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
  
    }


    public void OnConnectButtonClick(string obj)
    {
        UIControllerDelegate?.OnConnectButtonClick();
    }

    public void OnDisconnectButtonClick(string obj)
    {
        UIControllerDelegate.OnDisconnectButtonClick();
    }

    public void CreateLobby(string obj)
    {
        lastRoomName = LobbyName.text;
        this.UIControllerDelegate.CreateRoom(lastRoomName);
    }

    public void JoinToLobby(string obj)
    {
        lastRoomName = LobbyName.text;
        this.UIControllerDelegate.JoinToRoom(lastRoomName);
    }

    public void ConnectionStartState()
    {
        this.informationText.text = "Connection starting..";
        this.ConnectButton.gameObject.SetActive(false);
    }

    public void ConnectingToLobbyState()
    {
        this.informationText.text = "Connected.\nJoin to lobby...";
    }

    public void StartChoosingRoomState()
    {
        this.informationText.text = "Create, or connect to room";
        this.LobbyPanel.SetActive(true);
    }

    public void StartConnectingToRoomState(string roomName)
    {
        if (string.IsNullOrEmpty(roomName))
        {
            this.informationText.text = "Connecting";
        }
        else
        {
            this.informationText.text = String.Format("Connecting to \"{0}\"...", roomName);
        }
        this.LobbyPanel.SetActive(false);
    }

    public void ConnectedToRoomState(string roomName)
    {
        if (string.IsNullOrEmpty(roomName))
        {
            this.informationText.text = "Connected";
        }
        else
        {
            this.informationText.text = String.Format("Connected to \"{0}\".", roomName);
        }
        this.DisConnectButton.gameObject.SetActive(false);
    }

    public void JoinedToLobbyState()
    {
        this.informationText.text = "Connected.\nJoined to lobby.";
        this.LobbyPanel.SetActive(true);
    }

    public void DisconnectingFromState()
    {
        this.informationText.text = "Disconnecting...";
        this.DisConnectButton.gameObject.SetActive(false);
    }

    public void DisconnectedState()
    {
        this.informationText.text = "Disconnected.\nPlease reconnect.";
        this.ConnectButton.gameObject.SetActive(true);
    }

    public void InitialState()
    {
        this.informationText.text = "Please connect";
        this.ConnectButton.gameObject.SetActive(true);
    }

    public interface IUIControllerDelegate
    {
        void OnConnectButtonClick();
        void OnDisconnectButtonClick();
        void CreateRoom(string roomName);
        void JoinToRoom(string roomName);
    }
}
