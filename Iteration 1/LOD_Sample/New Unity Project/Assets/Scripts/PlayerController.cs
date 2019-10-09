using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform playerTransform;
    public FreeCameraUpRight cameraRotation;
    public GameObject flashLight;
    public float strafeSensativily = 2f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        var strafe = Input.GetAxis("Horizontal") * Time.deltaTime * strafeSensativily;
        var translation = Input.GetAxis("Vertical") * Time.deltaTime * strafeSensativily;

        playerTransform.Translate(strafe, 0, translation);

        if(Input.GetKeyDown(KeyCode.F))
        {
            var lightComp = flashLight.GetComponent<Light>();
            if(lightComp !=null)
            {
                lightComp.enabled = !lightComp.enabled;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            cameraRotation.rotate = !cameraRotation.rotate;
        }
    }
}
