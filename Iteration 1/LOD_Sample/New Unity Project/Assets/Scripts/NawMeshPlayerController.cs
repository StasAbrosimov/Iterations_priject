using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class NawMeshPlayerController : MonoBehaviour {

    public Camera scenecamera;
    public NavMeshAgent playerAgent;

    public ThirdPersonCharacter characterScript;


    void Start()
    {
        playerAgent.updateRotation = false;
    }

	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = scenecamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;

            if(Physics.Raycast(ray, out rayHit))
            {
                playerAgent.SetDestination(rayHit.point);
            }
        }


        if (playerAgent.remainingDistance > playerAgent.stoppingDistance)
        {
            characterScript.Move(playerAgent.desiredVelocity, false, false);
        }
        else
        {
            characterScript.Move(Vector3.zero, false, false);
        }
	}
}
