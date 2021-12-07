using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    private float MIN_DISTANCE_TO_STAY = 17.0f;
    private bool isRunning = false;
    private Animator anim;
    private CharacterController controller;
    private float runSpeed = 12.0f;
    private float minRunSpeed = 11.0f;
    private float maxRunSpeed = 12.0f;
    private float gravity = 12.0f;
    private float jumpForce = 3.0f;
    private float verticalVelocity;
    private GameObject horse;

    public bool isGrounded = false;

    void Awake(){
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        horse = GameObject.FindGameObjectWithTag("Player");
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
            verticalVelocity -= gravity * Time.deltaTime;
        }

        if(Mathf.Abs(transform.position.z-horse.transform.position.z) < 2.0f && GameManager.Instance.isGameOver && !GameManager.Instance.isCaught){
            Debug.Log("Caught");
            GameManager.Instance.OnCatch();
            StopRunning();
            anim.SetTrigger("kneel");
            //Invoke("RestartGame", 4.0f);
        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f, 1)){
            if(isRunning && isGrounded && hit.transform.CompareTag("Obstacle") && hit.distance<=2.0f){
                Jump();
                Debug.Log("AI Jump");
            }
        }

        if(Mathf.Abs(horse.transform.position.z - transform.position.z) >= MIN_DISTANCE_TO_STAY && runSpeed < maxRunSpeed){
            BackToSpeed();
        }

        Vector3 moveVector = Vector3.zero;
        moveVector.y = verticalVelocity;
        if(isRunning && GameManager.Instance.isGameStarted){
            moveVector.z = runSpeed;
        }
        controller.Move(moveVector * Time.deltaTime);
    }

    public void IsCaught(){
        GameManager.Instance.RestartGame();
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
        isGrounded = false;
        verticalVelocity = jumpForce;
    }

    private void SlowDown(){
        runSpeed = minRunSpeed;
    }

    private void BackToSpeed(){
        runSpeed = maxRunSpeed;
    }

    private void RestartGame(){
        GameManager.Instance.RestartGame();
    }
}
