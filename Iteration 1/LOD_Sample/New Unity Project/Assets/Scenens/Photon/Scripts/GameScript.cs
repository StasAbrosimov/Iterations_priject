using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class GameScript : MonoBehaviour
{
    public GameObject playerSpawn;    

    PlayerScript currentPlayer;
    List<PlayerScript> players;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeGame()
    {
        this.SpawnOnwPlayer();
    }    

    private void SpawnOnwPlayer()
    {
        //var player = Instantiate(playerPrefab);
        //player.transform.parent = playerSpawn.transform;
        //var playerScript = player.GetComponent<PlayerScript>();
        //currentPlayer = playerScript;
        //currentPlayer.SetPlayerName("ME", true);
        //players.Add(playerScript);
        var player = PhotonNetwork.Instantiate("player", new Vector3(), new Quaternion(), 0);
        currentPlayer = player.GetComponent<PlayerScript>();
        currentPlayer.SetPlayerName("ME", true);
    }

    private void SpawnNewPlayer()
    {

    }
}
