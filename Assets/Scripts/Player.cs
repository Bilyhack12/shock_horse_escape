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
    private bool isWalking = false;
    private bool isRunning = false;

    void Awake()
    {
        //anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Start(){
        //anim.SetBool("walking", isWalking);
    }

    void Update()
    {
        if(MobileInput.Instance.SwipeRight && !isWalking){
            Debug.Log("walk");
            isWalking = true;
            anim.SetBool("walking", isWalking);
        }

        else if(MobileInput.Instance.SwipeRight && isWalking && !isRunning){
            Debug.Log("run");
            isRunning = true;
            anim.SetBool("running", isRunning);
        }

        else if(MobileInput.Instance.SwipeLeft && isRunning){
            Debug.Log("backToWalk");
            isRunning = false;
            anim.SetBool("running", isRunning);
        }

        else if(MobileInput.Instance.SwipeLeft && !isRunning && isWalking){
            Debug.Log("backToStop");
            isWalking = false;
            anim.SetBool("walking", isWalking);
        }

        else if(MobileInput.Instance.SwipeUp && isRunning){
            Debug.Log("jump");
            anim.SetTrigger("jump");
        }

        else if(MobileInput.Instance.SwipeLeft && !isWalking && !isRunning){
            anim.SetTrigger("attack");
        }

        else if(MobileInput.Instance.SwipeDown && !isWalking && !isRunning){
            anim.SetTrigger("eat");
        }
        //Vector3 moveVector = new Vector3(0, 0, xInput).normalized;
        //Vector3 turnVector = new Vector3(xInput, 0, 0).normalized;
        //Debug.Log(moveVector);
        //controller.Move(moveVector * walkSpeed * Time.deltaTime);
        //transform.Rotate(turnVector * turnSpeed * Time.deltaTime);
    }
}
