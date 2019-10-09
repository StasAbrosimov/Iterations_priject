using UnityEngine;
using UnityEngine.AI;

public class NawMeshPlayerController : MonoBehaviour {

    public Camera scenecamera;
    public NavMeshAgent playerAgent;
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
	}
}
