using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour
{
    public Animator anim;
    private CharacterController controller;
    private float runSpeed = 12.0f;
    private float gravity = 1.0f;
    private float jumpForce = 10.0f;
    private float verticalVelocity;

    public bool isGrounded = false;
    private Farmer farmer;
    private bool isRunning = false;

    // sound variables 
    private AudioSource playerAudio; // players audio source variable
    public AudioClip horseRunning;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        farmer = GameObject.FindGameObjectWithTag("Farmer").GetComponent<Farmer>();
    }

    void Start(){
        //Time.timeScale = .3f;
        playerAudio = GetComponent<AudioSource>(); // init to audio source component
    }

    void Update()
    {
        if(MobileInput.Instance.Tap && !isRunning && GameManager.Instance.isGameStarted){
            ObstacleSpawner.Instance.SpawnRandomObstacle();
            anim.SetBool("running", true);
            playerAudio.Play(); //play background music
        }
        else if(MobileInput.Instance.SwipeUp && isRunning){
            anim.SetTrigger("jump");
        }

        else if(MobileInput.Instance.DoubleTap && isRunning){
            anim.SetTrigger("attack");
        }

        else if(MobileInput.Instance.SwipeDown && !isRunning){
            anim.SetTrigger("eat");
        }

        isGrounded = controller.isGrounded;

        if(isGrounded){
            verticalVelocity -= 0.1f;
        }
        else{
            verticalVelocity -= gravity;
        }

        Vector3 moveVector = Vector3.zero;
        moveVector.y = verticalVelocity;
        if(isRunning && GameManager.Instance.isGameStarted){
            moveVector.z = runSpeed; //move forward;
        }
        controller.Move(moveVector * Time.deltaTime);
    }
     public void StartRunning(){
        isRunning = true; //Start pushing the horse on the ground
        //playerAudio.PlayOneShot(horseRunning, .5f); //play running horse
        farmer.StartRunning();
     }

     public void StopRunning(){
        isRunning = false;
     }
     public void Jump(){
        verticalVelocity = jumpForce;
     }

     /*void OnCollisionEnter(Collision collision){
         Debug.Log("hit c");
         if(collision.collider.CompareTag("Obstacle")){
             anim.SetTrigger("death");
             StopRunning();
         }
     }
     */

    void OnTriggerEnter(Collider collider){
         Debug.Log("hit");
         if(collider.CompareTag("Obstacle")){
             StopRunning();
             GameManager.Instance.GameOver();
             Invoke("OnDeath" ,2.0f);
             anim.SetTrigger("death");
             playerAudio.Stop();
         }
     }

     private void OnDeath(){
        GameManager.Instance.OnDeath();
     }

     
}