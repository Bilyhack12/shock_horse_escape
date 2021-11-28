using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {set; get;}
    public bool isDead = false, isCaught = false;
    public bool isGameStarted = false;
    public bool isGameOver = false;
    private GameObject horse;
    
    public GameObject startMenuPanel;
    public GameObject boardPanel;
    private float distance;
    private Vector3 initialPosition;
    public TextMeshProUGUI distanceText;


    private void Awake(){
        Instance = this;
        horse = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start(){
        initialPosition = horse.transform.position;
        distance = 0;
        UpdateDistance();
    }

    private void UpdateDistance(){
        distanceText.SetText("Distance: {0:1}m", distance);
    }

    public void PlayGame(){
        isGameOver = false;
        isGameStarted = true;
        startMenuPanel.SetActive(false);
        boardPanel.SetActive(true);
    }

    public void GameOver(){
        isGameOver = true;
    }

    private void Update(){
        if(isGameStarted && !isGameOver && !isDead && !isCaught){
            distance = Mathf.Abs(horse.transform.position.z - initialPosition.z);
            UpdateDistance();
        }
    }

    public void RestartGame(){
        SceneManager.LoadScene("Game");
    }

    public void OnDeath(){
        isDead = true;
        //RestartGame();
    }

    public void OnCatch(){
        isCaught = true;
        //RestartGame();
    }

    public void QuitGame(){
        Application.Quit();
    }
}
