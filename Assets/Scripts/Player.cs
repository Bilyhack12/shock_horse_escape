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
    private float gravity = 1.0f;
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

    }

    void Update()
    {
        if(MobileInput.Instance.Tap && !isRunning){
            GameManager.Instance.isGameStarted = true;
            ObstacleSpawner.Instance.SpawnRandomObstacle();
            anim.SetBool("running", true);
        }
        else if((MobileInput.Instance.SwipeUp || Input.GetAxis("Vertical")>0) && isRunning){
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
        if(isRunning && GameManager.Instance.isGameStarted){
            moveVector.z = runSpeed;
        }
        controller.Move(moveVector * Time.deltaTime);
    }
     public void StartRunning(){
        isRunning = true;
        GameManager.Instance.StartGame();
     }

     public void StopRunning(){
        isRunning = false;
     }
     public void Jump(){
        verticalVelocity = jumpForce;
     }

     void OnCollisionEnter(Collision collision){
         Debug.Log("hit c");
         if(collision.collider.CompareTag("Obstacle")){
             anim.SetTrigger("death");
             StopRunning();
         }
     }

    void OnTriggerEnter(Collider collider){
         Debug.Log("hit");
         if(collider.CompareTag("Obstacle")){
             anim.SetTrigger("death");
             StopRunning();
         }
     }
}