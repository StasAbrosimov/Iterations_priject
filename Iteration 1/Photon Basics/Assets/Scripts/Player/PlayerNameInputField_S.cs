using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class PlayerNameInputField_S : MonoBehaviour
{

    const string playerNamePrefKey = "PlayerName";

    // Start is called before the first frame update
    void Start()
    {
        string defName = string.Empty;
        InputField inputF = this.GetComponent<InputField>();
        if(inputF != null)
        {
            if(PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defName = PlayerPrefs.GetString(playerNamePrefKey);
                inputF.text = defName;
            }
        }
        else
        {
            throw new MissingComponentException(typeof(InputField).ToString());
        }
    }

    public void SetPlayerName(string newName)
    {
        if(string.IsNullOrEmpty(newName))
        {
            Debug.Log("newName is empty");
        }
        else
        {
            Photon.Pun.PhotonNetwork.NickName = newName;
            Debug.Log(string.Format("newName is \"{0}\"", newName));
            PlayerPrefs.SetString(playerNamePrefKey, newName);
            PlayerPrefs.Save();
        }
    }
}
