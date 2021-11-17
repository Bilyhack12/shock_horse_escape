using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    private CharacterController controller;
    private float walkSpeed = 2.0f;
    private float turnSpeed = 5.0f;
    private float runSpeed = 12.0f;
    private float gravity = 2.0f;
    private float jumpForce = 15.0f;
    private float verticalVelocity;
    private bool isWalking = false;

    public bool isGrounded = false;
    private bool isRunning = false;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start(){
        //Time.timeScale = 0.5f;
    }

    void Update()
    {
        if(MobileInput.Instance.Tap && !isRunning){
            anim.SetBool("running", true);
        }
        else if(MobileInput.Instance.SwipeUp && isRunning){
            Debug.Log("jump");
            anim.SetTrigger("jump");
        }

        else if(MobileInput.Instance.DoubleTap && !isRunning){
            anim.SetTrigger("attack");
        }

        else if(MobileInput.Instance.SwipeDown && !isRunning){
            anim.SetTrigger("eat");
        }

        isGrounded = controller.isGrounded;

        if(controller.isGrounded){
            verticalVelocity -= 0.1f;
        }
        else{
            verticalVelocity -= gravity;
        }

        Vector3 moveVector = Vector3.zero;
        moveVector.y = verticalVelocity;
        if(isRunning){
            moveVector.z = runSpeed;
        }
        Debug.Log(moveVector);
        controller.Move(moveVector * Time.deltaTime);
    }
     public void StartRunning(){
        isRunning = true;
     }
     public void Jump(){
        verticalVelocity = jumpForce;
     }
}