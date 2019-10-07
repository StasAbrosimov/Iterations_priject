using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraUpRight : MonoBehaviour {

    //public float sensitivity = 10f;
    //public float maxYAngle = 80f;
    //public Vector2 currentRotation;

    //void Update()
    //{
    //    currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
    //    currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
    //    currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
    //    currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
    //    Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
    //    if (Input.GetMouseButtonDown(0))
    //        Cursor.lockState = CursorLockMode.Locked;
    //}

    Vector2 mouseLoock;
    Vector2 smoothV;
    public float sens = 5.0f;
    public float smooting = 2.0f;
    public float maxYAngle = 85f;

    public GameObject character;
    public GameObject flashLight;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (!Cursor.visible)
        {
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            md = Vector2.Scale(md, new Vector2(sens * smooting, sens * smooting));
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smooting);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smooting);
            mouseLoock += smoothV;

            mouseLoock.y = Mathf.Clamp(mouseLoock.y, -maxYAngle, maxYAngle);

            transform.localRotation = Quaternion.AngleAxis(-mouseLoock.y, Vector3.right);
            flashLight.transform.localRotation = Quaternion.AngleAxis(-mouseLoock.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(mouseLoock.x, Vector3.up);
        }
    }
}
