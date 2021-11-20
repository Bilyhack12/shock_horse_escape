using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {set; get;}
    public bool isDead = false, isCaught = false;
    public bool isGameStarted = false;
    public bool isGameOver = false;
    private Player motor;

    private void Awake(){
        Instance = this;
        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void StartGame(){
        isGameOver = false;
        isGameStarted = true;
    }

    public void GameOver(){
        isGameOver = true;
        isGameStarted = false;
    }

    private void Update(){
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);
        if(isGameStarted && !isGameOver && !isDead && !isCaught){
            
        }
    }

    public void OnDeath(){
        isDead = true;
    }

    public void OnCatch(){
        isCaught = true;
    }
}
