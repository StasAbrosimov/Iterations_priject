using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager_S : MonoBehaviourPun
{

    #region Private Fields


    [SerializeField]
    private float directionDampTime = 0.25f;


    #endregion

    private Animator animator;

    #region MonoBehaviour Callbacks
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if(animator == null)
        {
            Debug.LogError("animator == null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        if (!animator)
        {
            return;
        }

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // only allow jumping if we are running.
        if (stateInfo.IsName("Base Layer.Run"))
        {
            // When using trigger parameter
            if (Input.GetButtonDown("Fire2"))
            {
                animator.SetTrigger("Jump");
            }
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (v < 0)
        {
            v = 0;
        }

        animator.SetFloat("Speed", System.Math.Abs(h) + System.Math.Abs(v));

        animator.SetFloat("Direction", h, directionDampTime, Time.deltaTime);
    }
    #endregion


    public void Jump()
    {
        animator.SetTrigger("Jump");
        animator.SetFloat("Speed", 2);
    }
}
