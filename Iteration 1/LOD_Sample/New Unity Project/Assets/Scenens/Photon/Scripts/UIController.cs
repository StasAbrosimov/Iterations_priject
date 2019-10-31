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
        this.InitialState();
    }


    public void OnConnectButtonClick(string obj)
    {
        UIControllerDelegate?.OnConnectButtonClick();
    }

    public void OnDisconnectButtonClick(string obj)
    {
        UIControllerDelegate.OnDisconnectButtonClick();
    }

    public void ConnectionStartState()
    {
        this.informationText.text = "Connection starting..";
        this.ConnectButton.gameObject.SetActive(false);
    }

    public void ConnectedToState()
    {
        this.informationText.text = "Connected";
        this.DisConnectButton.gameObject.SetActive(true);
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
    }
}
