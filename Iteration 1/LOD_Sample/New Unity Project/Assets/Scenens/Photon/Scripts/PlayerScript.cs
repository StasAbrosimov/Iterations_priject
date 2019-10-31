using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Text PlayerName;
    private bool itsPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!itsPlayer)
        {
            PlayerName.text = "OTHER";
            PlayerName.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName(string playerName, bool itsMe = false)
    {
        PlayerName.text = playerName;
        this.itsPlayer = itsMe;
        if (itsMe)
        {
            PlayerName.color = Color.blue;
        }
        else
        {
            PlayerName.color = Color.red;
        }
    }
}
