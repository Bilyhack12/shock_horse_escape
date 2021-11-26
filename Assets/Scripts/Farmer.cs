using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    private bool isRunning = false;
    private Animator anim;
    private CharacterController controller;
    private float runSpeed = 12.0f;
    private float gravity = 1.0f;
    private float jumpForce = 12.0f;
    private float verticalVelocity;

    public bool isGrounded = false;

    void Awake(){
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    public void StartRunning(){
        isRunning = true;
        anim.SetBool("isRunning", isRunning);
        Invoke("SlowDown", 4.0f);
    }

    public void StopRunning(){
        isRunning = false;
        anim.SetBool("isRunning", isRunning);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = IsGrounded();

        if(isGrounded){
            verticalVelocity -= 0.1f;
        }
        else{
            verticalVelocity -= gravity;
        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2.5f, 1)){
            if(GameManager.Instance.isGameOver && hit.transform.CompareTag("Player")){
                Debug.Log("Caught");
                GameManager.Instance.OnCatch();
                StopRunning();
            }
            if(isRunning && isGrounded && hit.transform.CompareTag("Obstacle")){
                Jump();
                Debug.Log("AI Jump");
            }
        }

        Vector3 moveVector = Vector3.zero;
        moveVector.y = verticalVelocity;
        if(isRunning && GameManager.Instance.isGameStarted){
            moveVector.z = runSpeed;
        }
        controller.Move(moveVector * Time.deltaTime);
    }

    private bool IsGrounded(){
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.0f, 1)){
           if(hit.transform.CompareTag("Ground") && hit.distance < .1f){
                return true;
            }
        }
        return false;
    }

    public void Jump(){
        verticalVelocity = jumpForce;
    }

    private void SlowDown(){
        runSpeed -= 1.0f;
    }
}
