using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject startMenuPanel;
    public GameObject leaderBoardPanel;
    public GameObject playerSelectorPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenPlayerSelector(){
        playerSelectorPanel.SetActive(true);
        startMenuPanel.SetActive(false);
    }
    public void ClosePlayerSelector(){
        startMenuPanel.SetActive(true);
        playerSelectorPanel.SetActive(false);
    }
    public void OpenLeaderBoard(){
        leaderBoardPanel.SetActive(true);
        startMenuPanel.SetActive(false);
    }

    public void CloseLeaderBoard(){
        startMenuPanel.SetActive(true);
        leaderBoardPanel.SetActive(false);
    }

    public void StartGame(){
        playerSelectorPanel.SetActive(false);
        GameSceneManager.Instance.PlayGame();
    }
}
