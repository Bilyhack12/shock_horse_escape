using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance {set; get;}
    public Animator animator;
    private string screenToLoad;

    private void Awake(){
        Instance = this;
    }

    private void Start(){
        
    }


    public void PlayGame(){
        Debug.Log("play");
        FadeToScene("StartCutScene");
    }

    public void FadeToScene(string screenName){
        screenToLoad = screenName;
        animator.SetTrigger("fadeOut");
    }

    public void OnFadeOutComplete(){
        SceneManager.LoadScene(screenToLoad);
    }

    public void LoadGameScene(){
        FadeToScene("Game");
    }

    private void Update(){
        
    }

    public void QuitGame(){
        Application.Quit();
    }
}
