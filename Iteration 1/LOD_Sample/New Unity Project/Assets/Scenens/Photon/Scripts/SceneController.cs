using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour, photonConnect.IPhotonConnectDelegate, UIController.IUIControllerDelegate
{
    public photonConnect PhotonController;
    public UIController UIController;
    public GameScript Game;

    // Start is called before the first frame update
    void Start()
    {
        this.PhotonController.PhotonDelegate = this;
        this.UIController.UIControllerDelegate = this;
        this.UIController.InitialState();
    }

    private void UIController_OnDisconnectButtonClickEvent()
    {
        
    }

    private void UIController_OnConnectButtonClickEvent()
    {
        this.PhotonController.DisconnectFromPhoton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region IPhotonConnectDelegate
    public void ConnectedToTheMaster()
    {
        this.UIController.ConnectingToLobbyState();
    }

    public void DisconnectingProcessStart()
    {
        this.UIController.DisconnectingFromState();
    }

    public void DisconnectedFromPhoton()
    {
        Game.gameObject.SetActive(false);
        this.UIController.DisconnectedState();
        //throw new System.NotImplementedException();
    }

    public void ErrorOccured()
    {
        //throw new System.NotImplementedException();
    }

    public void ConnectionStart()
    {
        this.UIController.ConnectionStartState();
    }

    public void OnJoinedToLobby()
    {
        this.UIController.StartChoosingRoomState();
    }

    public void OnConnectingToRoom(string name)
    {
        this.UIController.StartConnectingToRoomState(name);
    }

    public void OnConnectedToRoom(string name)
    {
        this.UIController.ConnectedToRoomState(name);
        Game.gameObject.SetActive(true);
        Game.InitializeGame();
    }
    #endregion

    #region IUIControllerDelegate
    public void OnConnectButtonClick()
    {
        PhotonController.ConnectToPhoton();
    }

    public void OnDisconnectButtonClick()
    {
        this.PhotonController.DisconnectFromPhoton();
    }

    public void CreateRoom(string roomName)
    {
       this.PhotonController.CreateOrJoinToRoom(roomName);
    }

    public void JoinToRoom(string roomName)
    {
        this.PhotonController.CreateOrJoinToRoom(roomName);
    }
    #endregion
}
