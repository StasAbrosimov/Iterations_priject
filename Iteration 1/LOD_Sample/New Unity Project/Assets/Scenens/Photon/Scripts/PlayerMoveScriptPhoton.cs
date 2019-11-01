using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScriptPhoton : Photon.MonoBehaviour
{
    public PhotonView PlayerPhotonView;
    public Rigidbody2D PlayerRigidbody;
    public float MoveSpeed = 5f;
    public float JumpForce = 500;
    public float DeltaJump = 1.1f;
    public bool TestInput = false;

    private float curDelta = 0.0f; 
    private bool canDoubleJump = true;

    private Vector3 netPosition;

    private void Update()
    {
        if (PlayerPhotonView.isMine || TestInput)
        {
            this.checkInput();
        }
        else
        {
            if(!this.PlayerRigidbody.isKinematic)
            {
                this.PlayerRigidbody.isKinematic = true;
            }
            this.MoveMeFromeNetwork();
        }
    }

    private void checkInput()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += move * MoveSpeed * Time.deltaTime;
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bool jump = false;
            if (curDelta <= 0 || canDoubleJump)
            {                
                jump = true;
                if (curDelta <= 0)
                {
                    curDelta = DeltaJump;
                    canDoubleJump = true;                    
                }
                else
                {
                    this.PlayerRigidbody.velocity = new Vector2(this.PlayerRigidbody.velocity.x, this.PlayerRigidbody.velocity.y/2.0f);
                }
            }

            if (jump)
            {
                this.PlayerRigidbody.AddForce(new Vector2(0, JumpForce));
            }
        }

        if(curDelta >= 0)
        {
            curDelta -= Time.deltaTime;
        }
    }

    private void MoveMeFromeNetwork()
    {
        var deltaUpdate = (now - last).HasValue ? (float)((now - last).Value.TotalSeconds) : Time.deltaTime;

        transform.position = Vector3.Lerp(transform.position, netPosition, deltaUpdate);

        Debug.Log((float)deltaUpdate);
        Debug.Log((float)Time.deltaTime);
        Debug.Log((float)PhotonNetwork.GetPing());
       
    }

    private System.DateTime? last;
    private System.DateTime? now;

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {        
        if(stream.isWriting)
        {
            stream.SendNext(transform.position);
        }
        else
        {
            if (now != null)
            {
                last = now;
            }
            netPosition = (Vector3)stream.ReceiveNext();
            now = System.DateTime.UtcNow;
        }
        
    }
}
