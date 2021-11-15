using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {set; get;}
    public bool isDead = false, isCaught = false;
    private bool isGameStarted = false;
    private Player motor;

    private void Awake(){
        Instance = this;
        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update(){
        if(isGameStarted && !isDead && !isCaught){
            
        }
    }

    public void OnDeath(){
        isDead = true;
    }
}
