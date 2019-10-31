using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour, photonConnect.IPhotonConnectDelegate, UIController.IUIControllerDelegate
{
    public photonConnect PhotonController;
    public UIController UIController;

    // Start is called before the first frame update
    void Start()
    {
        this.PhotonController.PhotonDelegate = this;
        this.UIController.UIControllerDelegate = this;
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
        this.UIController.ConnectedToState();
    }

    public void DisconnectingProcessStart()
    {
        this.UIController.DisconnectingFromState();
    }

    public void DisconnectedFromPhoton()
    {
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
    #endregion
}
