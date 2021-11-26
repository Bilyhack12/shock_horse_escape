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
    
    public GameObject startMenuPanel;

    private void Awake(){
        Instance = this;
        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void StartGame(){
        isGameOver = false;
        isGameStarted = true;
        startMenuPanel.SetActive(false);
    }

    public void GameOver(){
        isGameOver = true;
        isGameStarted = false;
    }

    private void Update(){
        if(isGameStarted && !isGameOver && !isDead && !isCaught){
            
        }
    }

    private void RestartGame(){
        SceneManager.LoadScene("Game");
    }

    public void OnDeath(){
        isDead = true;
        RestartGame();
    }

    public void OnCatch(){
        isCaught = true;
    }

    public void QuitGame(){
        Application.Quit();
    }
}
